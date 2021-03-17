using System;
using System.Collections.Generic;
using DIO.ContasBancarias.Data.LDados;
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

        public List<MovimentoConta> listMovimentos = new List<MovimentoConta>();

        public void AtualizaMovimentacoesDB(List<DLMovimento> list)
        {
            if(this.listMovimentos == null)
            {
                this.listMovimentos = new List<MovimentoConta>();
            }
            foreach(DLMovimento mv in list)
            {
                MovimentoConta mvEntidade = new MovimentoConta(
                    mv.DataHoraEvento,
                    mv.NomeConta,
                    mv.IdConta,
                    mv.Movimentacao,
                    mv.SaldoAntes,
                    mv.CreditoAntes);
                
                this.listMovimentos.Add(mvEntidade);
            }
        }
        public void AtualizaMovimentacoesDB(List<IDLMovimento> list)
        {
            if(this.listMovimentos == null)
            {
                this.listMovimentos = new List<MovimentoConta>();
            }
            foreach(IDLMovimento mv in list)
            {
                MovimentoConta mvEntidade = new MovimentoConta(
                    mv.DataHoraEvento,
                    mv.NomeConta,
                    mv.IdConta,
                    mv.Movimentacao,
                    mv.SaldoAntes,
                    mv.CreditoAntes);
                
                this.listMovimentos.Add(mvEntidade);
            }
        }

        public void AtualizaMovimentacoes(List<MovimentoConta> list)
        {
            if(this.listMovimentos == null)
            {
                this.listMovimentos = new List<MovimentoConta>();
            }
            foreach(MovimentoConta mv in list)
            {
                MovimentoConta mvEntidade = new MovimentoConta(
                    mv.DataHoraEvento,
                    mv.NomeConta,
                    mv.IdConta,
                    mv.Movimentacao,
                    mv.SaldoAntes,
                    mv.CreditoAntes);
                
                this.listMovimentos.Add(mvEntidade);
            }
        }

        public List<MovimentoConta> ListaMovimentos()
        {
            List<MovimentoConta> movimentos = new List<MovimentoConta>();
            if(this.listMovimentos != null)
            {
                foreach(MovimentoConta mv in this.listMovimentos)
                {
                    MovimentoConta NovoMv = new MovimentoConta(
                            mv.DataHoraEvento, 
                            mv.NomeConta, 
                            mv.IdConta, 
                            mv.Movimentacao, 
                            mv.SaldoAntes, 
                            mv.CreditoAntes);
                    movimentos.Add(NovoMv);
                }
            }
            return movimentos;
        }

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
            // Inserindo Movimentação
            this.Movimentacao(valorSaque * -1);
            this.Saldo -= valorSaque;

            EnviaMensagem($"Saldo atual da conta de {this.Nome} é {this.Saldo}");
            
            return true;
		}

        // Rodar operação antes do saque na conta!
        private void Movimentacao(double valorSaque)
        {
            MovimentoConta mvSaque = new MovimentoConta(
                    DateTime.Now,
                    this.Nome,
                    this.IdConta,
                    valorSaque,
                    this.Saldo,
                    this.Credito);
            if(this.listMovimentos == null)
            {
                this.listMovimentos = new List<MovimentoConta>();
            }
            this.listMovimentos.Add(mvSaque);
        }

		public void Depositar(double valorDeposito)
		{
            // Inserindo Movimentação
            this.Movimentacao(valorDeposito);
			this.Saldo += valorDeposito;

            EnviaMensagem($"Saldo atual da conta de {this.Nome} é {this.Saldo}");
		}

		public void Transferir(double valorTransferencia, IConta contaDestino)
		{
            // Inserindo Movimentação
            // -- Desnecessário!! Pois as operações sacas e depositar 
            // -- fazem o registro das movimentações
            // this.Movimentacao(valorTransferencia * -1);
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

        public void Excluir()
        {
            this.Excluido = true;
        }
    }
}