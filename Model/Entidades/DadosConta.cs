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
        public int IdConta { get; set; }
        public bool Excluido { get; set; }


        // Métodos
        public DadosConta(Enum.TipoConta tipoConta, double saldo, double credito, string nome)
		{
			this.TipoConta = tipoConta;
			this.Saldo = saldo;
			this.Credito = credito;
			this.Nome = nome;

            this.MensagemDaOperacao = "";
		}

        public DadosConta(Enum.TipoConta tipoConta, double saldo, double credito, string nome, int id, bool excluido)
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

        public void Excluir()
        {
            throw new System.NotImplementedException();
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
    }
}