
# Modelagem

- [Atores](#atores)

- [Entidades](#entidades)

- [Regras de interação](#regras-de-interação)

- [Endpoints](#endpoints)

- [Testes](#testes)

- [Regras de validação](#regras-de-validação)

- [Padrões](#padrões)

- [Tecnologias utilizadas](#tecnologias-utilizadas)

<br>

## Atores 
* Doctor
* Patient
<br>

## Entidades
* Doctor
   * Id (int)
   * Name (string)
   * CRM (string)

* Patient
   * Id (int)
   * Name (string)
   * CPF (string)
   * Data de Nascimento (DateTime)

* Appointment
   *  Id (int)
   *  Id Doctor (int)
   *  Id Patient (int)
   *  DateTime Appointment (DateTime)
<br>

![screen_RabbitMQ](Img/ModelagemDados.jpg)

## Regras de interação
* Um médico pode ter várias consultas com diferentes pacientes
* Um paciente pode ter várias consultas com diferentes médicos
<br>

## Endpoints
* Cadastro de médico: POST /medico
* Edição de médico: PUT /medico/{id}
* Leitura geral de médicos: GET /medicos
* Leitura específica de médico: GET /medico/{id}
* Remoção de médico: DEL /medico/{id}
* Cadastro de paciente: POST /paciente
* Edição de paciente: PUT /paciente/{id}
* Leitura geral de pacientes: GET /pacientes
* Leitura específica de paciente: GET /paciente/{id}
* Remoção de paciente: DEL /paciente/{id}
* Cadastro de consulta: POST /consulta
* Edição de consulta: PUT /consulta/{id}
* Leitura geral de consultas: GET /consultas
* Leitura específica de consulta: GET /consulta/{id}
* Remoção de consulta: DEL /consulta/{id}

## Testes
   Resultados da migration e dos testes feitos com os 3 bancos:
   * SQLite <br>
      ![screen_RabbitMQ](Img/SqlLite.jpg)
   * SQLServer <br>
      ![screen_RabbitMQ](Img/SqlServer.jpg)
   * MySql <br>
      ![screen_RabbitMQ](Img/MySql.jpg)

## Regras de validação
* Todos os campos obrigatórios devem ser fornecidos ao cadastrar um médico, paciente ou consulta
* A data e hora da consulta não pode ser anterior à data atual

## Padrões
* O padrão Repository deve ser utilizado para abstrair o acesso à base de dados e facilitar a troca de provedores de persistência
* O padrão IoC deve ser utilizado para facilitar a injeção de dependências, permitindo a substituição de implementações de forma fácil e modular
* O padrão ID deve ser utilizado para garantir a unicidade das entidades e facilitar a implementação do Repository.

## Tecnologias utilizadas

<a href="https://www.w3schools.com/cs/" target="_blank" rel="noreferrer"> <img src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white"/></a>
<a href="https://dotnet.microsoft.com/" target="_blank" rel="noreferrer"> <img src="https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white"></a>
<a href="https://www.microsoft.com/pt-br/sql-server/sql-server-downloads" target="_blank" rel="noreferrer"> <img src="https://img.shields.io/badge/Microsoft%20SQL%20Server-CC2927?style=for-the-badge&logo=microsoft%20sql%20server&logoColor=white"/></a>
<a href="https://www.mysql.com/" target="_blank" rel="noreferrer"> <img src="https://img.shields.io/badge/MySQL-005C84?style=for-the-badge&logo=mysql&logoColor=white"/></a>
<a href="https://sqlite.org/" target="_blank" rel="noreferrer"> <img src="https://img.shields.io/badge/SQLite-07405E?style=for-the-badge&logo=sqlite&logoColor=white"/></a>
