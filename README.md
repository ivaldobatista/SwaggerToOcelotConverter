# Swagger to Ocelot Converter

## Description

This project is a .NET 7 command-line tool that converts swagger.json files to ocelot.json format. It is particularly useful for projects that use Ocelot as an API gateway and wish to automate the creation of configuration files based on existing Swagger specifications.

## Technologies Used

- **.NET 7**
- **Newtonsoft.Json**
- **ASP.NET Core** (for reading configuration files)

## How to Use

### Prerequisites

- .NET SDK 7 or higher installed on your machine
 
### Steps

#### Clone this repository

```bash
   git clone https://github.com/ivaldobatista/SwaggerToOcelotConverter.git
```

#### Navigate to the project folder

```bash
	your_folder_where_saved
```

### Create the appsettings file

To run the project locally, you'll need to create an appsettings.json file in the project root. You can use the appsettings.example.json file as a starting point. Copy the contents of appsettings.example.json to a new file named appsettings.json and replace the values as needed.

```bash
cp appsettings.example.json appsettings.json
```

Build the project

```bash
	dotnet build
```

Run the project

```bash
	dotnet run
```

## Configuration

You can adjust the project settings in the appsettings.json file.

```json
	{
  "OcelotConfig": {
    "Host": "your_host",
    "Port": your_port,
    "Region": "your_region"
  }
}

```


This should provide a comprehensive guide for anyone interested in using or contributing to your project.


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
```

3. **Crie o arquivo appsettings**

 Para rodar o projeto localmente, é necessário criar um arquivo `appsettings.json` na raiz do projeto. Você pode usar o arquivo `appsettings.example.json` como um ponto de partida. Copie o conteúdo de `appsettings.example.json` para um novo arquivo chamado `appsettings.json` e substitua os valores de acordo com sua configuração.

```bash
cp appsettings.example.json appsettings.json
```

4. **Compile o projeto**
```bash
	dotnet build
```

5. **Execute o projeto**
```bash
	dotnet run
```

6. ***Configuração ***
Você pode ajustar as configurações do projeto no arquivo appsettings.json.
```json
	{
	  "OcelotConfig": {
		"Host": "seu_host",
		"Port": sua_porta,
		"Region": "sua_regiao"
	  }
	}
```

