using System;
using System.Collections.Generic;
using DIO.ContasBancarias.Model.Entidades;
using DIO.ContasBancarias.Model.Interfaces;

namespace DIO.ContasBancarias.View
{
    public class ContasInterface : IContas, Model.Interfaces.IObserver
    {
        public IContas ControleContas = new Contas();

        public ContasInterface()
        {
            ((Model.Interfaces.ISubject)this.ControleContas).Attach(this);
        }
        
        public void Depositar(int indiceConta, double valorDeposito)
		{
            //EnviaMensagem($"Depositar na conta ({indiceConta}) o valor de R$ {valorDeposito}.");
            ControleContas.Depositar(indiceConta, valorDeposito);
		}

		public void Sacar(int indiceConta, double valorSaque)
		{
            // EnviaMensagem($"Sacar da conta ({indiceConta}) o valor de R$ {valorSaque}.");
            ControleContas.Sacar(indiceConta, valorSaque);
		}

		public  void Transferir(int indiceContaOrigem, int indiceContaDestino, double valorTransferencia)
		{
            //EnviaMensagem($"Transferir da conta ({indiceContaOrigem}) para a conta ({indiceContaDestino}) o valor de R$ {valorTransferencia}.");
            ControleContas.Transferir(indiceContaOrigem, indiceContaDestino, valorTransferencia);
		}

		public  void InserirConta(int entradaTipoConta, string entradaNome, double entradaSaldo, double entradaCredito)
		{
            ControleContas.InserirConta(entradaTipoConta, entradaNome, entradaSaldo,  entradaCredito);
		}

		public List<IConta> ListarContas()
		{
            List<IConta> listDadosConta = ControleContas.ListarContas();

			if (listDadosConta.Count == 0)
			{
				// EnviaMensagem("Nenhuma conta cadastrada.");
				return listDadosConta;
			}

			for (int i = 0; i < listDadosConta.Count; i++)
			{
				// IConta conta = listContas[i];

                // IConta novaConta = new DadosConta
                //                     (conta.TipoConta,
				// 						saldo: conta.Saldo,
				// 						credito: conta.Credito,
				// 						nome: conta.Nome);

			    // listDadosConta.Add(novaConta);

                //EnviaMensagem($"#{i} - {conta.ToString()}");
			}

            return listDadosConta;
		}


        public void Update(ISubject subject)
        {
            if ((subject as Conta).State <= 1)
            {
                try
                {
                    string msg = ((IMensagem) (subject as Conta)).MensagemDaOperacao;
                    Console.WriteLine($"{msg}");
                }
                catch (System.Exception e)
                {
                    Console.WriteLine($"{e.Message} - {e.Source}");
                }
                
            }
        }
    }
}