using System;
using DIO.ContasBancarias.Model.Entidades;
using DIO.ContasBancarias.Model.Interfaces;

namespace DIO.ContasBancarias.View
{
    public class ContaInterface : IConta, Model.Interfaces.IObserver
    {

        public Model.Enum.TipoConta TipoConta { get; set; }
		public  double Saldo { get; set; }
		public  double Credito { get; set; }
		public  string Nome { get; set; }

        private IConta EntidadeConta { get; set;}

        // Criar um Observer para exibir as mensagens geradas internamente...
        public  string MensagemDaOperacao { get; set; }
        public int IdConta { get; set; }
        public bool Excluido { get; set; }


        // Métodos
        public ContaInterface(Model.Enum.TipoConta tipoConta, double saldo, double credito, string nome)
		{
            this.Nome = nome;
			this.TipoConta = tipoConta;
			this.Saldo = saldo;
			this.Credito = credito;

            this.EntidadeConta = new Conta (
                                        tipoConta: (Model.Enum.TipoConta)tipoConta,
										saldo: saldo,
										credito: credito,
										nome: nome);

			((Model.Interfaces.ISubject)this.EntidadeConta).Attach(this);
            
		}

        public ContaInterface(Model.Enum.TipoConta tipoConta, double saldo, double credito, string nome, int id, bool excluido)
		{
            this.Nome = nome;
			this.TipoConta = tipoConta;
			this.Saldo = saldo;
			this.Credito = credito;
            this.IdConta = id;
            this.Excluido = excluido;

            this.EntidadeConta = new Conta (
                                        tipoConta: (Model.Enum.TipoConta)tipoConta,
										saldo: saldo,
										credito: credito,
										nome: nome, 
                                        id: id,
                                        excluido: excluido);

			((Model.Interfaces.ISubject)this.EntidadeConta).Attach(this);
            
		}


        public void Depositar(double valorDeposito)
        {
            EntidadeConta.Depositar(valorDeposito);
        }

        public bool Sacar(double valorSaque)
        {
            return EntidadeConta.Sacar(valorSaque);
        }

        public override string ToString()
        {
            return EntidadeConta.ToString();
        }

        public void Transferir(double valorTransferencia, IConta contaDestino)
        {
            EntidadeConta.Transferir(valorTransferencia, (IConta) contaDestino);
        }

        public void Update(ISubject subject)
        {
            if ((subject as Conta).State <= 1)
            {
                string msg = ((IMensagem) (subject as Conta)).MensagemDaOperacao;
                Console.WriteLine($"{msg}");
            }
        }

        public void Excluir()
        {
            EntidadeConta.Excluir();
        }
    }
}