# SwaggerToOcelotConverter
Projeto console em .NET 7 para ler um arquivo swagger.json e convertê-lo para ocelot.json

# Swagger to Ocelot Converter

## Descrição

Este projeto é uma ferramenta de linha de comando feita em .NET 7 que converte arquivos `swagger.json` para o formato `ocelot.json`. É especialmente útil para projetos que usam Ocelot como gateway de API e desejam automatizar a criação de arquivos de configuração com base em especificações Swagger existentes.

## Tecnologias Utilizadas

- **.NET 7**
- **Newtonsoft.Json**
- **ASP.NET Core** (para ler arquivos de configuração)

## Como Usar

### Pré-requisitos

- .NET SDK 7 ou superior instalado em sua máquina

### Passos

1. **Clone este repositório**
   ```bash
   git clone https://github.com/ivaldobatista/SwaggerToOcelotConverter.git

2. **Navegue até a pasta do projeto**
```bash
	cd sua_pasta_onde_salvou

3. **Compile o projeto**
```bash
	dotnet build

4. **Execute o projeto**
```bash
	dotnet run

5. ***Configuração ***
Você pode ajustar as configurações do projeto no arquivo appsettings.json.

json
Copy code
{
  "OcelotConfig": {
    "Host": "seu_host",
    "Port": sua_porta,
    "Region": "sua_regiao"
  }
}


