using System;
using System.Configuration;
using DIO.ContasBancarias.Data.LDados;
using DIO.ContasBancarias.View;

namespace DIO.ContasBancarias
{
    class Program
    {
        static void Main(string[] args)
        {
			// Configurações
            string diretorioDB = ConfigurationManager.AppSettings["DiretorioDB"];
			string diretorioApp = ConfigurationManager.AppSettings["DiretorioApp"];
            string arquivoDB = ConfigurationManager.AppSettings["ArquivoContasDB"];
			string arquivoMovimentacoesDB = ConfigurationManager.AppSettings["ArquivoMovimentacoesDB"];
            string pathString = System.IO.Path.Combine(diretorioDB, arquivoDB);
            System.Console.WriteLine($"Arquivo : {pathString}");
            System.Console.WriteLine("");
			XmlContasTools toolsContas;

			// inicializando Configurações do DB
			DLConfiguracoes configDB = DLConfiguracoes.GetInstance();
			configDB.InitDLConfiguracoes(dirApp: diretorioApp,
										 dirDB:  diretorioDB,
										 arqContas: arquivoDB,
										 arqMov: arquivoMovimentacoesDB);
            // Criar Diretório se não existe
            if(!System.IO.Directory.Exists(diretorioDB))
                System.IO.Directory.CreateDirectory(diretorioDB);

			Operacoes Op = Operacoes.GetInstance();

            // Criar arquivo se não existe 
			//try
			//{
				if (!System.IO.File.Exists(pathString))
				{
					System.IO.File.CreateText(pathString);
				} else // Ler o arquivo e guarda na mémória
				{
					try
					{
						toolsContas = new XmlContasTools(Op.controleContas.ControleContas, pathString);
						toolsContas.LerArquivoXml();	
					}
					catch (System.Exception e)
					{
						System.Console.WriteLine($"Erro: {e.Message} - {e.StackTrace}");
						System.IO.File.CreateText(pathString);
					}
					
				}	
			//}
			// catch (System.Exception)
			// {
			// 	System.IO.File.CreateText(pathString);
			// }
            

            string opcaoUsuario = Menu.ObterOpcaoUsuario();

            
			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						Op.ListarContas();
						break;
					case "2":
						Op.InserirConta();
						break;
					case "3":
						Op.Transferir();
						break;
					case "4":
						Op.Sacar();
						break;
					case "5":
						Op.Depositar();
						break;
                    case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = Menu.ObterOpcaoUsuario();
			}
			
			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();

        }
    }
}

