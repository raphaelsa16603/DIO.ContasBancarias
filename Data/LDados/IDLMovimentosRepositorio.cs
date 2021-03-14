using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
namespace DIO.ContasBancarias.Data.LDados
{
    public interface IDLMovimentosRepositorio : IRepositorio<IDLMovimento>
    {
        [XmlArrayAttribute("Movimentos")]
        public List<IDLMovimento> Movimentos { get; set; }
    }
}