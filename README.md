# SistemaSaude
 REST API de sistema de saúde.
 
# Tecnologias utilizadas
 Projeto criado na linguagem C# utilizando ASP.NET Framework 6.0 e SQL Server.
 Projeto Utiliza Entity Framework Core.
 
# Estrutura das tabelas
 A aplicação possui três tabelas, uma para pacientes, uma para médicos cadastrados, e outra para as consultas.
 As informações contidas nessas tabelas foram as que imaginei ser cruciais para um agendamento de consulta em um sistema de saúde.
 ## Tabela Paciente:
  [ Nome,
  Data de nascimento,
  RG,
  Cartão do SUS,
  ID ]
 ## Tabela Médico
  [ Nome,
  Data de nascimento,
  RG,
  Cargo,
  ID ]
 ## Tabela Consulta
  [ Tipo de consulta,
  Paciente,
  Médico,
  Data da consulta,
  Status,
  ID ]
# CRUD de pacientes e médicos contém as seguintes opções
 [ Adicionar,
 Buscar todos,
 Buscar por ID,
 Atualizar,
 Apagar ]
# Requisitos
 Máquina deve ter instalada SQL Server e SQL Management Studio
 A linha de código a seguir deve se executada no console do gerenciador de pacotes do visual studio parar criar as tabelas:
   Update-Database -Context SistemaSaudeDBContext
# Anotações
 Por boas práticas, após commit inicial, todos outros commits foram feitos na branch develop, e quando finalizado foi feito o merge final de volta para a main.
