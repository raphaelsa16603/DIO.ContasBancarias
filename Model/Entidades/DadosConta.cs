using DIO.ContasBancarias.Model.Entidades;
using DIO.ContasBancarias.Model.Interfaces;

namespace DIO.ContasBancarias.Model.Entidades
{
    public class DadosConta: IConta
    {
        // Atributos
		public Enum.TipoConta TipoConta { get; set; }
		public double Saldo { get; set; }
		public double Credito { get; set; }
		public string Nome { get; set; }

        public  string MensagemDaOperacao { get; set; }

        // Métodos
		public DadosConta(Enum.TipoConta tipoConta, double saldo, double credito, string nome)
		{
			this.TipoConta = tipoConta;
			this.Saldo = saldo;
			this.Credito = credito;
			this.Nome = nome;

            this.MensagemDaOperacao = "";
		}

        public bool Sacar(double valorSaque)
        {
            throw new System.NotImplementedException();
        }

        public void Depositar(double valorDeposito)
        {
            throw new System.NotImplementedException();
        }

        public void Transferir(double valorTransferencia, IConta contaDestino)
        {
            throw new System.NotImplementedException();
        }
    }
}