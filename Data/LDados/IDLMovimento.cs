using System;
using System.Xml;
using System.Xml.Serialization;

namespace DIO.ContasBancarias.Data.LDados
{
    public interface IDLMovimento
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
        public double SaldoAntes { get; set; }
        [XmlAttribute]
		public double CreditoAntes { get; set; }
		        
    }
}