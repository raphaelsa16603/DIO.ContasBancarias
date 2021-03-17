using System;
using DIO.ContasBancarias.Model.Interfaces;

namespace DIO.ContasBancarias.Model.Entidades
{
    public class MovimentoConta : IMovimentoConta
    {
        public DateTime DataHoraEvento  { get; set; }
        public string NomeConta  { get; set; }
        public int IdConta  { get; set; }
        public double Movimentacao  { get; set; }
        public double SaldoAntes  { get; set; }
        public double CreditoAntes  { get; set; }

        public MovimentoConta(DateTime data, string nome, int id, double mov, double saldo, double credito)
        { 
            this.DataHoraEvento = data;
            this.NomeConta = nome;
            this.IdConta = id;
            this.Movimentacao = mov;
            this.SaldoAntes = saldo;
            this.CreditoAntes = credito;
        }
        
    }
}