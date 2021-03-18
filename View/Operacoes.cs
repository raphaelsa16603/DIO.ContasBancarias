using System;
using System.Collections.Generic;
using DIO.ContasBancarias.Model.Entidades;
using DIO.ContasBancarias.Model.Enum;
using DIO.ContasBancarias.Model.Interfaces;

namespace DIO.ContasBancarias.View
{
    
	//TODO: 1) Opção de excluir conta; 
	//TODO: 2) Lista só contas não excluidas;
	//TODO: 3) Extrato de conta, lista de movimentações do mês ou ano;
	//
    public class Operacoes
    {
        //private List<ContaInterface> listContas = new List<ContaInterface>();
		public ContasInterface controleContas = new ContasInterface();

        private Operacoes() { }

        // The Singleton's instance is stored in a static field.
        private static Operacoes _instance;

        // This is the static method that controls the access to the singleton
        // instance.
        public static Operacoes GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Operacoes();
            }
            return _instance;
        }

        public void Depositar()
		{
			Console.Write("Digite o número da conta: ");
			int indiceConta = int.Parse(Console.ReadLine());

			Console.Write("Digite o valor a ser depositado: ");
			double valorDeposito = double.Parse(Console.ReadLine());

            //listContas[indiceConta].Depositar(valorDeposito);
			controleContas.Depositar(indiceConta, valorDeposito);
		}

		public void Sacar()
		{
			Console.Write("Digite o número da conta: ");
			int indiceConta = int.Parse(Console.ReadLine());

			Console.Write("Digite o valor a ser sacado: ");
			double valorSaque = double.Parse(Console.ReadLine());

            //listContas[indiceConta].Sacar(valorSaque);
			controleContas.Sacar(indiceConta, valorSaque);
		}

		public  void Transferir()
		{
			Console.Write("Digite o número da conta de origem: ");
			int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de destino: ");
			int indiceContaDestino = int.Parse(Console.ReadLine());

			Console.Write("Digite o valor a ser transferido: ");
			double valorTransferencia = double.Parse(Console.ReadLine());

            //listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);
			controleContas.Transferir(indiceContaOrigem, indiceContaDestino, valorTransferencia);
		}

		public  void InserirConta()
		{
			Console.WriteLine("Inserir nova conta");

			Console.Write("Digite 1 para Conta Fisica ou 2 para Juridica: ");
			int entradaTipoConta = int.Parse(Console.ReadLine());
			// Conversão necessária para o Enum ser serializado...
			entradaTipoConta = entradaTipoConta == 1 ? 0 : 1;

			Console.Write("Digite o Nome do Cliente: ");
			string entradaNome = Console.ReadLine();

			Console.Write("Digite o saldo inicial: ");
			double entradaSaldo = double.Parse(Console.ReadLine());

			Console.Write("Digite o crédito: ");
			double entradaCredito = double.Parse(Console.ReadLine());
			// TipoConta tp = (TipoConta)( entradaTipoConta == 0 ?  
            //            TipoConta.PessoaFisica : TipoConta.PessoaJuridica);
			// ContaInterface novaConta = new ContaInterface
            //                         (tipoConta: (TipoConta)entradaTipoConta,
			// 							saldo: entradaSaldo,
			// 							credito: entradaCredito,
			// 							nome: entradaNome);

			//listContas.Add(novaConta);
			controleContas.InserirConta(entradaTipoConta,
										entradaNome,
										entradaSaldo,
										entradaCredito);
		}

		public void ListarContas(bool extratos)
		{
			Console.WriteLine("Listar contas");

			if(controleContas != null)
			{
				if(controleContas.ControleContas != null)
				{
					List<Model.Interfaces.IConta> listaContas = controleContas.ListarContas();

					if (listaContas.Count == 0)
					{
						Console.WriteLine("Nenhuma conta cadastrada.");
						return;
					}

					for (int i = 0; i < listaContas.Count; i++)
                    {
                        Model.Interfaces.IConta conta = listaContas[i];
                        Console.Write("#{0} - ", conta.IdConta);
                        Console.WriteLine(conta);
						if(extratos)
                        	ExtratoDaConta(conta);
                    }
                }
				else
				{
					Console.WriteLine("Nenhuma conta cadastrada.");
				}
			}
			else
			{
				Console.WriteLine("Nenhuma conta cadastrada.");
			}
		}

        private static void ExtratoDaConta(IConta conta)
        {
            List<MovimentoConta> movs = ((Conta)conta).ListaMovimentos();
            foreach (MovimentoConta mv in movs)
            {
                Console.Write("---- Movmento {0} - ", mv.DataHoraEvento.ToString("dd/MM/yyyy - hh:mm"));
                Console.WriteLine(" - Valor - {0}", mv.Movimentacao);
            }
        }
    }
}