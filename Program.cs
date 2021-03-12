using System;
using DIO.ContasBancarias.View;

namespace DIO.ContasBancarias
{
    class Program
    {
        static void Main(string[] args)
        {
            string opcaoUsuario = Menu.ObterOpcaoUsuario();

            Operacoes Op = Operacoes.GetInstance();

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

