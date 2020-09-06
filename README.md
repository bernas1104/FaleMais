# Desafio Técnico LOLDesign - FaleMais Telzir

Implementação do desafio do candidato Front-End LOLDesign. O repositório está
dividido em duas partes: back-end e front-end.

## Back-end

O servidor back-end foi implementado utilizando ASP.NET Core 3.1, Entity Framework
Core, PostgreSQL e XUnit. Para facilitar a execução, recomenda-se a utilização do
Docker para o banco de dados.

### Docker

Para instalação do banco de dados, execute o seguinte comando:

> docker run --name \<NomeContainer\> -e POSTGRES_PASSWORD=123456 -p 5432:5432 -d postgres

\* Substitua \<NomeContainer\> por qualquer nome.

### .NET Core

É necessário instalação da SDK .NET Core para compilação e execução do projeto.
Instruções para instalação podem ser encontradas [aqui](https://dotnet.microsoft.com/download).

Para verificar se a instalação foi realizada com sucesso, execute:

> dotnet --version

O comando deve retornar '3.1.401'. Após a instalação do .NET Core, execute o comando:

> dotnet tool install --global dotnet-ef

Para instalação das ferramentas do Entity Framework Core. Após a instalação, execute:

> dotnet ef --version

A saída deverá ser:

> Entity Framework Core .NET Command-line Tools  
> 3.1.7

### Execução das Migrations

Após a instalação do .NET Core e do EF Core CLI, é necessária a execução das migrations
para configuração do banco de dados da aplicação. Vá para a pasta raíz do back-end
e execute:

> dotnet restore

Após a conclusão da restauração da solução, verifique que o banco PostgreSQL esteja
rodando e execute o comando:

> dotnet ef database update -p FaleMaisPersistence -s FaleMaisAPI

Caso nenhum erro tenha ocorrido, o banco de dados está pronto e o servidor back-end
pode ser executado.

### Testes

Para executar os testes do back-end, os passos [.NET Core](#.NET%20Core) e [Execução 
das Migrations](#Execução%20das%20Migrations) devem ter sido concluídos.

A suite de testes é executada com o comando:

> dotnet test /p:CollectCoverage=true

Após a execução dos testes, o comando irá gerar, no terminal e em um arquivo .json na
pasta do projeto de testes (FaleMaisTests), a % de cobertura do código.

### Execução

Para iniciar o servidor, é necessário ter concluído todos os passos - com exceção
dos testes - e executar o comando:

> dotnet run -p FaleMaisAPI

Certifique-se de que as portas 5000 e 5001 estão livres para execução do back-end.

## Fron-end

O front-end da aplicação foi desenvolvido utilizando o React.js e TypeScript. Para
execução do servidor de desenvolvimento e dos testes, é necessário instalar todas as
dependências do projeto. 

### NPM

Para executar o projeto React, deve-se instalar o Node.js e NPM. A instalação
pode ser feita seguindo as instruções encontradas [aqui](https://nodejs.org/en/).

Após a instalação, utilize os comandos:

> node -v  
> npm -v

Para verificar se a instalação foi bem sucedida.

### Dependências React.js

Para realizar a instalação das dependências do projeto, vá para raíz do projeto 
front-end e execute:

> npm i

Após a conclusão da instalação das dependências, o projeto estará pronto para execução
dos testes e do servidor de desenvolvimento.

### Testes

Para execução dos testes, basta executar o comando:

> npm test --coverage --watchAll false

Após a conclusão da execução, o script irá gerar um relatório de cobertura, que pode
ser aberto em "coverage/lcov-report/index.html".

### Execução

Para executar o servidor Web, certifique-se de que o servidor back-end esteja funcionando. Caso algum problema ocorra com a execução do servidor back-end, pode-se
executar o servidor JSON, para simular o back-end:

> npx json-server server.json --routes routes.json -p 5000

Com o back-end rodando, basta executar o comando:

> npm start

O front-end irá abrir automaticamente no seu navegador padrão.
