using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
namespace DIO.ContasBancarias.Data.LDados
{
    public interface IDLContasRepositorio: IRepositorio<IDLConta>
    {
        [XmlArrayAttribute("Contas")]
        public List<IDLConta> Contas { get; set; }
        
    }
}