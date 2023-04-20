# API Relacionamento Médico Paciente 

### Tópicos 

- [Descrição do projeto](#descrição-do-projeto)

- [Requisitos funcionais](#requisitos-funcionais)

- [Requisitos não funcionais](#requisitos-não-funcionais)

- [Abstração](#abstração)

- [Execução](#execução)

- [Extras](#extras)

- [Ferramentas utilizadas](#ferramentas-utilizadas)

<br>

## Descrição do projeto 

<p align="justify">
Esta é uma API que define as regras de ações entre dois atores: médico e paciente; e contempla os endpoints de cadastro, edição, leitura e ação dos atores com o meio que os relaciona.
A interação entre médico e paciente será feita através de uma interface de agendamento de consultas
</p>
<br>

## Requisitos funcionais
<p align="justify">
Modelagem e identificação das interações entre os atores.

Dados devem ser persistidos em memória, mas de forma que facilmente seja substituída a persistência  para um banco de dados, através de repository pattern.

Deverá ter validação dos dados principais dos atores e do relacionamento entre eles.
</p>
<br>

## Requisitos não funcionais
<p align="justify">
A API deverá ser desenvolvida em clean architecture onde abrigará em sua modelagem os patterns: Repository, IoC, ID.

Deverá ser desenvolvida com orientação a objeto, existindo por completo, o encapsulamento de dados e utilizando .Net 6.
</p>
<br>

## Abstração
   Iniciaremos pela modelagem dos dados considerando os padrões Repository e ID que deverá nos permitir desenvolver um código desacoplado, facilmente integrável e escalável observando boas práticas com interfaces e repositórios genéricos compartilháveis entre todas as entidades pelo padrão ID.

   Usaremos a orientação Code First, preparando a camada de infraestrutura para aplicar o Migration em vários bancos de dados Sql diferentes.

   Data Annotations para validação dos dados e relacionamentos na própria entidade, além de lógicas de consistência em conjunto com a classe de contexto.

   Neste Projeto usaremos <a href="https://sqlite.org/" target="_blank" rel="noreferrer"> <img src="https://img.shields.io/badge/SQLite-07405E?style=for-the-badge&logo=sqlite&logoColor=white"/></a><a href="https://www.microsoft.com/pt-br/sql-server/sql-server-downloads" target="_blank" rel="noreferrer"> <img src="https://img.shields.io/badge/Microsoft%20SQL%20Server-CC2927?style=for-the-badge&logo=microsoft%20sql%20server&logoColor=white"/></a><a href="https://www.mysql.com/" target="_blank" rel="noreferrer"> <img src="https://img.shields.io/badge/MySQL-005C84?style=for-the-badge&logo=mysql&logoColor=white"/></a>
   
   Deixaremos como padrão o banco <a href="https://sqlite.org/" target="_blank" rel="noreferrer"> <img src="https://img.shields.io/badge/SQLite-07405E?style=for-the-badge&logo=sqlite&logoColor=white"/></a>, mas o código ficará preparado com as configurações e conexões necessárias comentadas para o caso de rodar os outros.

   Na camada de apresentação, ficará disponível uma interface para trabalhar com serviço de autenticação através do Jason Web Token, porém não usaremos nesse momento para facilitar os testes.

   Usaremos o padrão de inversão de controle com injeções de dependências na classe Program.cs, já que usaremos a versão 6 do .net, e com isso podemos maximizar a modularidade e flexibilidade do nosso código

   Pacotes necessários para trabalhar com todos bancos de dados:
   * Microsoft.AspNetCore.Identity.EntityFrameworkCore
   * Microsoft.EntityFrameworkCore.Sqlite
   * Microsoft.EntityFrameworkCore.SqlServer
   * Pomelo.EntityFrameworkCore.MySql

   Importante observar que os pacotes que precisarem ser instalados em mais de uma camada, devem ser instalados na mesma versão em cada uma.

## Execução
   Clonar este repositório: https://github.com/medinasp/API_HealthLink_Repository_ID_IOC.git
   Não são necessárias alterações se você quiser rodar com o banco local SQLite, basta executar.
   Caso queira usar outro banco, será necessário comentar as linhas que fazem referência ao SQLite e descomentar as linhas do banco que você quer usar nos seguintes arquivos e classes:
   * apsettings.json (Camada de Apresentação HealthLinkApi)
   * Program.cs (Camada de Apresentação HealthLinkApi)
   * ContextBase (Camada de Infra/Configuration).

   Depois disso você deverá acessar a camada de Infra/Migration, remover os arquivos de migration que já constam no diretório,  abrir o console do Package Manager e rodar os comandos para executar nova migration no banco que você escolheu
      Add-migration initial
      Update-database

   Próximo passo é executar a aplicação, abrir a coleção de endpoints que está na pasta EndpointTestes e importar no seu testador preferido.

## Extras
   ### Testes

   Ficará também disponível para download dentro do próprio repositório (/EndpointTestes), a coleção de testes com as rotas e json preparados para testar todos endpoints da aplicação, basta aplicar dentro do seu testador preferido

   ### Testes de integração automatizados
   Projeto de testes disponíveis dentro da solução para os use cases de Doctor e Patient

## Ferramentas utilizadas

<a href="https://www.w3schools.com/cs/" target="_blank" rel="noreferrer"> <img src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white"/></a>
<a href="https://dotnet.microsoft.com/" target="_blank" rel="noreferrer"> <img src="https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white"></a>
<a href="https://sqlite.org/" target="_blank" rel="noreferrer"> <img src="https://img.shields.io/badge/SQLite-07405E?style=for-the-badge&logo=sqlite&logoColor=white"/></a><a href="https://www.microsoft.com/pt-br/sql-server/sql-server-downloads" target="_blank" rel="noreferrer"> <img src="https://img.shields.io/badge/Microsoft%20SQL%20Server-CC2927?style=for-the-badge&logo=microsoft%20sql%20server&logoColor=white"/></a>
<a href="https://www.mysql.com/" target="_blank" rel="noreferrer"> <img src="https://img.shields.io/badge/MySQL-005C84?style=for-the-badge&logo=mysql&logoColor=white"/></a>
