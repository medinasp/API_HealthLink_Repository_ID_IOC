
# Modelagem

- [Atores](#atores)

- [Entidades](#entidades)

- [Regras de interação](#regras-de-interação)

- [Endpoints](#endpoints)

- [Regras de validação](#regras-de-validação)

- [Padrões](#padrões)

<br>

## Atores 
* Médico
* Paciente
<br>

## Entidades
* Médico
   * Id (int)
   * Nome (string)
   * CRM (string)

* Paciente
   * Id (int)
   * Nome (string)
   * CPF (string)
   * Data de Nascimento (DateTime)

* Consulta
   *  Id (int)
   *  Id do Médico (int)
   *  Id do Paciente (int)
   *  Data e hora da consulta (DateTime)
   *  Descrição (string)
<br>

## Regras de interação
* Um médico pode ter várias consultas com diferentes pacientes
* Um paciente pode ter várias consultas com diferentes médicos
<br>

## Endpoints
* Cadastro de médico: POST /medicos
* Edição de médico: PUT /medicos/{id}
* Leitura de médico: GET /medicos/{id}
* Cadastro de paciente: POST /pacientes
* Edição de paciente: PUT /pacientes/{id}
* Leitura de paciente: GET /pacientes/{id}
* Cadastro de consulta: POST /consultas
* Edição de consulta: PUT /consultas/{id}
* Leitura de consulta: GET /consultas/{id}

## Regras de validação
* Todos os campos obrigatórios devem ser fornecidos ao cadastrar um médico, paciente ou consulta
* O CRM do médico e o CPF do paciente devem ser únicos na base de dados
* A data e hora da consulta não pode ser anterior à data atual
* O médico e o paciente devem existir na base de dados para cadastrar uma consulta
* O médico e o paciente só podem ser editados se não estiverem associados a nenhuma consulta

## Padrões
* O padrão Repository deve ser utilizado para abstrair o acesso à base de dados e facilitar a troca de provedores de persistência
* O padrão IoC deve ser utilizado para facilitar a injeção de dependências, permitindo a substituição de implementações de forma fácil e modular
* O padrão ID deve ser utilizado para garantir a unicidade das entidades e facilitar a implementação do Repository.

<a href="https://www.w3schools.com/cs/" target="_blank" rel="noreferrer"> <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/csharp/csharp-original.svg" alt="csharp" width="40" height="40"/></a>
<a href="https://dotnet.microsoft.com/" target="_blank" rel="noreferrer"> <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/dot-net/dot-net-original-wordmark.svg" alt="dotnet" width="40" height="40"/></a>