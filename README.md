# APIPermission

## Visão Geral

O intuito deste projeto era construir uma API simples com dois endpoints: um para fazer o cadastro de permissões e outro para trazer a listagem de permissões, Consegui criar apenas seu crud com 5 endpoints,
 sendo 3 requisições de inserção POST, PUT, DELETE e 2 para listagem, sendo que um deles é para listar todas as permissões e o outro é para listar uma permissão específica.

## Objetivos

1. O cadastro dos registros deverá ser feito no banco de dados não relacional MongoDB quando chamada a rota de cadastro de permissão.
2. A primeira leitura a ser realizada pelo endpoint de listagem de permissões deverá ir no MongoDB para coletar os registros de permissões do banco de dados. Após essa leitura, é necessário gravar os mesmos registros coletados no componente de cache Redis, para que as próximas leituras num intervalo de tempo de 10 minutos busquem os dados diretamente do cache e não necessite ir até o MongoDB.

## Especificações

O projeto foi desenvolvido utilizando as seguintes tecnologias e práticas:

- **Linguagem:** C#
- **Framework:** .NET Core 6
- **Banco de Dados:** MongoDB (para armazenar registros de permissões)

- **Injeção de Dependência**
1- Apenas AddSingleton,AddTransient.

## Pré-requisitos

Antes de executar o projeto, certifique-se de ter as seguintes ferramentas e recursos instalados:

- [**.NET Core 6**](https://dotnet.microsoft.com/download/dotnet/6.0)
- [**MongoDB**](https://www.mongodb.com/try/download/community)
- [**MongoDB Compass**](https://www.mongodb.com/products/tools/compass)
- [**Docker Desktop**](https://www.docker.com/products/docker-desktop/)

## Executando o Projeto

Siga as etapas abaixo para executar o projeto em sua máquina local:

1. Clone este repositório:

   ```bash
   git clone https://github.com/GMBuzatto/APIPermission.git
   ```
2. Utilizando o Docker Desktop:

   ```bash
     docker pull mongo
   ```
  Crie um container apartir da imagem da mongo.
   - Insira seu Container Name: APIPermission;
   - Insira sua Host port padrão: 27017.

  Inicie a instancia de seu container APIPermission.

3. Utilizando o MongoDB Compass:
   Crie uma nova conexão com sua url sendo : mongodb://localhost:27017.

4. Inicie a aplicação do projeto APIPermission:
   Apartir do swagger você podera solicitar as requisições:
    GET buscar todos os items no container.
    POST inserir um objeto como:
       {
          "name": "string",
          "description": "string",
          "isCompleted": true
       }
   GET buscar um determinado objeto apartir de seu id.
   PUT atualiza um determinado objeto por inteiro apartir de seu id.
   DELETE exclui um determinado objeto sendo referenciado por seu id.
    
