using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;

namespace SwaggerToOcelotConverter
{
	internal class Program
	{
        protected Program()
        {
				
        }

        private static void Main(string[] args)
		{
			var config = new ConfigurationBuilder()
			  .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
			  .Build();

			string? swaggerFilePath = config["FilePaths:Swagger"];
			
			if (swaggerFilePath == null)
			{
				Console.WriteLine("O caminho para o arquivo Swagger não foi definido.");
				return;
			}

			string? ocelotFilePath = config["FilePaths:Ocelot"];

			if (ocelotFilePath == null)
			{
				Console.WriteLine("O caminho para o arquivo Ocelot não foi definido.");
				return;
			}

			string swaggerJson = File.ReadAllText(swaggerFilePath);
			JObject swaggerObject = JObject.Parse(swaggerJson);

			JObject ocelotObject = ConvertSwaggerToOcelot(swaggerObject);

			File.WriteAllText(ocelotFilePath, ocelotObject.ToString());

			Console.WriteLine("Conversão concluída.");

		}

		static JObject ConvertSwaggerToOcelot(JObject swaggerObject)
		{
			IConfiguration config = new ConfigurationBuilder()
					.SetBasePath(Directory.GetCurrentDirectory())
					.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
					.Build();

			string? host = config["OcelotConfig:Host"];
			string? port = config["OcelotConfig:Port"];
			string? region = config["OcelotConfig:Region"];
			string? version = config["OcelotConfig:Version"];

			if (string.IsNullOrEmpty(host))
			{
				throw new ArgumentException("O host não foi definido.");
			}
			if (string.IsNullOrEmpty(port))
			{
				throw new ArgumentException("A porta não foi definida.");
			}
			if (string.IsNullOrEmpty(region))
			{
				throw new ArgumentException("A region não foi definida.");
			}
			if (string.IsNullOrEmpty(version))
			{
				throw new ArgumentException("A versão da sua api não foi definida.");
			}

			JObject ocelotObject = new JObject();
			JArray routes = new JArray();

			foreach (var path in swaggerObject["paths"].Children<JProperty>())
			{
				string pathKey = path.Name;
				JObject pathValue = (JObject)path.Value;

				foreach (var method in pathValue.Children<JProperty>())
				{
					string methodKey = method.Name.ToUpper(); // GET, POST, etc
					JObject methodValue = (JObject)method.Value; //se precisar do payload / valor.. 

					string upstreamPath = $"/{region}/{version}{pathKey}";
					string downstreamPath = $"{pathKey}";

					JObject ocelotEntry = CreateOcelotEntry(methodKey, upstreamPath, downstreamPath, host, int.Parse(port), region);
					routes.Add(ocelotEntry);
				}
			}

			ocelotObject["Routes"] = routes;

			return ocelotObject;
		}

		static JObject CreateOcelotEntry(string httpMethod, string upstreamPath, string downstreamPath, string host, int port, string region)
		{
			return new JObject
			{
				["UpstreamPathTemplate"] = upstreamPath,
				["UpstreamHttpMethod"] = new JArray(httpMethod, "OPTIONS"),
				["DownstreamPathTemplate"] = downstreamPath,
				["DownstreamScheme"] = "https",
				["DownstreamHostAndPorts"] = new JArray(new JObject { ["Host"] = host, ["Port"] = port }),
				["FileCacheOptions"] = new JObject { ["Region"] = region, ["TtlSeconds"] = 120 },
				["Policies"] = new JObject
				{
					["Retry"] = 2,
					["CircuitBreaker"] = new JObject
					{
						["ExceptionsAllowedBeforeBreaking"] = 3,
						["DurationOfBreak"] = 10000
					}
				},
				["RateLimitOptions"] = new JObject 
				{
					["EnableRateLimiting"] = true,
					["Period"] = "1m",
					["Limit"] = 10
				}
			};
		}

	}
}