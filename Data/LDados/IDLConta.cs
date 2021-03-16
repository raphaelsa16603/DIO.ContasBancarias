using DIO.ContasBancarias.Model.Interfaces;
using System.Xml;
using System.Xml.Serialization;
namespace DIO.ContasBancarias.Data.LDados
{
    public interface IDLConta
    {
        [XmlAttribute]
        public Model.Enum.TipoConta TipoConta { get; set; }
        [XmlAttribute]
		public double Saldo { get; set; }
        [XmlAttribute]
		public double Credito { get; set; }
        [XmlAttribute]
		public string Nome { get; set; }
        [XmlAttribute]
        public int IdConta { get; set; }

        [XmlAttribute]
        public bool Excluido { get; set; }

        public void Excluir();
    }
}