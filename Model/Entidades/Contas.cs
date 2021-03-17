using System;
using System.Collections.Generic;
using DIO.ContasBancarias.Data.LDados;
using DIO.ContasBancarias.Model.Enum;
using DIO.ContasBancarias.Model.Interfaces;

namespace DIO.ContasBancarias.Model.Entidades
{
    public class Contas :  Interfaces.ISubject, Interfaces.IMensagem, Interfaces.IContas, Interfaces.IObserver, Interfaces.IContasDB
    {
        private List<IConta> listContas = new List<IConta>();

        public Contas ()
        {

        }

        public Contas (List<IConta> ContasDB)
        {
            LerContasDoBD(ContasDB);
        }

        public void LerContasDoBD (List<IConta> ContasBD)
        {
            if (ContasBD.Count == 0)
			{
				EnviaMensagem("Nenhuma conta cadastrada no Banco de Dados.");
				return;
			}

			for (int i = 0; i < ContasBD.Count; i++)
			{
				IConta conta = ContasBD[i];

                IConta novaConta = new Conta
                                    (conta.TipoConta,
										saldo: conta.Saldo,
										credito: conta.Credito,
										nome: conta.Nome,
                                        id: conta.IdConta,
                                        excluido: conta.Excluido);

			    listContas.Add(novaConta);

                //Observar conta
                ((Model.Interfaces.ISubject)novaConta).Attach(this);

                EnviaMensagem($"Lendo do BD a conta #{i}/{conta.IdConta} - {conta.ToString()}");
			}
        }


        public void Depositar(int indiceConta, double valorDeposito)
		{
            EnviaMensagem($"Depositar na conta ({indiceConta}) o valor de R$ {valorDeposito}.");
            listContas[indiceConta].Depositar(valorDeposito);
            UpdateDB();
		}

		public void Sacar(int indiceConta, double valorSaque)
		{
            EnviaMensagem($"Sacar da conta ({indiceConta}) o valor de R$ {valorSaque}.");
            listContas[indiceConta].Sacar(valorSaque);
            UpdateDB();
		}

		public  void Transferir(int indiceContaOrigem, int indiceContaDestino, double valorTransferencia)
		{
            EnviaMensagem($"Transferir da conta ({indiceContaOrigem}) para a conta ({indiceContaDestino}) o valor de R$ {valorTransferencia}.");
            listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);
            UpdateDB();
		}

		public  void InserirConta(int entradaTipoConta, string entradaNome, double entradaSaldo, double entradaCredito)
		{
            EnviaMensagem($"Inserir conta (Tipo {entradaTipoConta}) (Nome {entradaNome}) " + 
                $"com saldo no valor de R$ {entradaSaldo} e crédido no valor de R$ {entradaCredito}.");
            int idProx = this.ProximoId();
			IConta novaConta = new Conta
                                    (tipoConta: (TipoConta)entradaTipoConta,
										saldo: entradaSaldo,
										credito: entradaCredito,
										nome: entradaNome,
                                        id: idProx,
                                        excluido: false);
            // Na criação cadastrar o primeiro movimento de criação
            ((Conta)novaConta).listMovimentos = new List<MovimentoConta>();
            MovimentoConta mvInicial = new MovimentoConta(
                    DateTime.Now,
                    novaConta.Nome,
                    novaConta.IdConta,
                    entradaSaldo,
                    0.00,
                    entradaCredito
            );
            // Adiciona movimento inivial de abertura de conta
            ((Conta)novaConta).listMovimentos.Add(mvInicial);
			listContas.Add(novaConta);

            

            UpdateDB();
		}

		public List<IConta> ListarContas()
		{
            List<IConta> listDadosConta = new List<IConta>();

			if (listContas.Count == 0)
			{
				EnviaMensagem("Nenhuma conta cadastrada.");
				return listDadosConta;
			}

			for (int i = 0; i < listContas.Count; i++)
			{
				IConta conta = listContas[i];

                IConta novaConta = new Conta
                                    (conta.TipoConta,
										saldo: conta.Saldo,
										credito: conta.Credito,
										nome: conta.Nome, 
                                        id: conta.IdConta,
                                        excluido: conta.Excluido);

                ((Conta)novaConta).AtualizaMovimentacoes
                        (((Conta)conta).listMovimentos);

			    listDadosConta.Add(novaConta);

                EnviaMensagem($"#{i} - {conta.ToString()}");
			}

            return listDadosConta;
		}



        public int State { get; set; } = -0;
        public string MensagemDaOperacao { get; set; }

        private List<IObserver> _observers = new List<IObserver>();
        
        public void Attach(IObserver observer)
        {
            this._observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            this._observers.Remove(observer);
        }

        public void Notify()
        {
            if(_observers != null)
            {
                foreach (var observer in _observers)
                {
                    try
                    {
                        observer.Update(this);    
                    }
                    catch (System.Exception e)
                    {
                        // Temporário... até resolver o envio das mensagens para os Observadores
                        System.Console.WriteLine($" Erro: {e.Message} - {e.StackTrace}");
                    }
                    
                }
            }
        }

        public void EnviaMensagem(string msg)
        {
            this.State = 1; 
            this.MensagemDaOperacao = msg;

            Notify();
        }

        public void Update(ISubject subject)
        {
            Conta conta = subject as Conta;
            if (conta != null)
            {
                if (conta.State <= 1)
                {
                    string msg = ((IMensagem) (subject as Conta)).MensagemDaOperacao;
                    EnviaMensagem($"{msg}");
                }
            }
        }

        public void InsereDB(IConta entidade){
            IConta novaConta = new Conta
                                    (tipoConta: (TipoConta)entidade.TipoConta,
										saldo: entidade.Saldo,
										credito: entidade.Credito,
										nome: entidade.Nome,
                                        id: entidade.IdConta, 
                                        excluido: entidade.Excluido);

			listContas.Add(novaConta);
        }

        public int ProximoId()
        {
            if(this.listContas == null)
            {
                this.listContas = new List<IConta>();
            }
            return this.listContas.Count;
        }

        private void UpdateDB()
        {
            // Atualizar arquivo de dados em XML
            XmlContasTools tools = 
                new XmlContasTools(this, DLConfiguracoes.GetInstance().getPathFile());
            tools.EscreverArquivoXml();
        }
    }
}