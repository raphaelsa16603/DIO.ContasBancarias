using System.Collections.Generic;
using DIO.ContasBancarias.Model.Interfaces;

namespace DIO.ContasBancarias.Model.Entidades
{
public class Conta: Interfaces.ISubject, Interfaces.IMensagem, Interfaces.IConta
    {
		// Atributos
		public Enum.TipoConta TipoConta { get; set; }
		public double Saldo { get; set; }
		public double Credito { get; set; }
		public string Nome { get; set; }

        public  string MensagemDaOperacao { get; set; }

		// Métodos
		public Conta(Enum.TipoConta tipoConta, double saldo, double credito, string nome)
		{
			this.TipoConta = tipoConta;
			this.Saldo = saldo;
			this.Credito = credito;
			this.Nome = nome;

            this.MensagemDaOperacao = "";
		}

        public Conta(Enum.TipoConta tipoConta, double saldo, double credito, string nome, int id, bool excluido)
		{
			this.TipoConta = tipoConta;
			this.Saldo = saldo;
			this.Credito = credito;
			this.Nome = nome;
            this.IdConta = id;
            this.Excluido = excluido;

            this.MensagemDaOperacao = "";
		}

		public bool Sacar(double valorSaque)
		{
            // Validação de saldo suficiente
            if (this.Saldo - valorSaque < (this.Credito *-1)){
                EnviaMensagem("Saldo insuficiente!");
                return false;
            }
            this.Saldo -= valorSaque;

            EnviaMensagem($"Saldo atual da conta de {this.Nome} é {this.Saldo}");
            
            return true;
		}

		public void Depositar(double valorDeposito)
		{
			this.Saldo += valorDeposito;

            EnviaMensagem($"Saldo atual da conta de {this.Nome} é {this.Saldo}");
		}

		public void Transferir(double valorTransferencia, IConta contaDestino)
		{
			if (this.Sacar(valorTransferencia)){
                contaDestino.Depositar(valorTransferencia);
            }
		}

        public override string ToString()
		{
            string retorno = "";
            retorno += "Id " + this.IdConta + " | ";
            retorno += "TipoConta " + this.TipoConta + " | ";
            retorno += "Nome " + this.Nome + " | ";
            retorno += "Saldo " + this.Saldo + " | ";
            retorno += "Crédito " + this.Credito;
			return retorno;
		}



        public int State { get; set; } = -0;
        public int IdConta { get; set; }
        public bool Excluido { get; set; }

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
                    catch (System.Exception)
                    {
                        
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

        public void Excluir()
        {
            this.Excluido = true;
        }
    }
}