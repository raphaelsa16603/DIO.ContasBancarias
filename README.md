# Projeto da DIO Criando uma aplicação de transferências bancárias com .NET
## Raphael Simões Andrade

### Pontos
 - Serializar com XML os Dados da Conta e Movimentações e persistir em XML...
 - Padrão de projeto para logar tudo... Logar usando Json...
 - Tentativa de criar uma arquitetura tipo Clean Architecture


##### instalando o System.Configuration no projeto
##### --
 - dotnet add package System.Configuration.ConfigurationManager --version 5.0.0

##### instalando o System.Text.Json no projeto
##### --
- dotnet add package System.Text.Json --version 5.0.1


##### instalando o System.Xml.XmlSerializer no projeto
##### -- https://docs.microsoft.com/pt-br/dotnet/api/system.xml.serialization.xmlserializer?view=net-5.0
##### --
- dotnet add package System.Xml.XmlSerializer --version 4.3.0


##### Dica do Visual Studio Code
####### - Abra .vscode/launch.json.
####### - Altere a console configuração de internalConsole para integratedTerminal :
####### JSON
#######     "console": "integratedTerminal",
####### - Salve as alterações.
