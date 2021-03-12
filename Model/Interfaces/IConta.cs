using DIO.ContasBancarias.Model.Enum;

namespace DIO.ContasBancarias.Model.Interfaces
{
    public interface IConta
    {
		// Atributos
		public TipoConta TipoConta { get; set; }
		public  double Saldo { get; set; }
		public  double Credito { get; set; }
		public  string Nome { get; set; }


		
		public bool Sacar(double valorSaque);

		public void Depositar(double valorDeposito);
		public void Transferir(double valorTransferencia, IConta contaDestino);

        public string ToString();
    }
}