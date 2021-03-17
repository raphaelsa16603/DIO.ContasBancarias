using System;
using System.Xml;
using System.Xml.Serialization;

namespace DIO.ContasBancarias.Data.LDados
{
    public class DLMovimento : IDLMovimento
    {
        [XmlAttribute]
        public DateTime DataHoraEvento { get; set; }
        [XmlAttribute]
        public string NomeConta { get; set; }
        [XmlAttribute]
        public int IdConta { get; set; }
        [XmlAttribute]
        public double Movimentacao { get; set; }
        [XmlAttribute]
        public double SaldoAntes  { get; set; }
        [XmlAttribute]
        public double CreditoAntes  { get; set; }

        // Construtor sem parâmetros para serialização XML
        public DLMovimento() {}
        public DLMovimento(DateTime data, string nome, int id, double mov, double saldo, double credito)
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