using System;

namespace DIO.ContasBancarias.Model.Interfaces
{
    public interface IMovimentoConta
    {
        public DateTime DataHoraEvento { get; set; }
        public string NomeConta { get; set; }
        public int IdConta { get; set; }
        public double Movimentacao { get; set; }
        public double SaldoAntes { get; set; }
		public double CreditoAntes { get; set; }
		        
    }
}