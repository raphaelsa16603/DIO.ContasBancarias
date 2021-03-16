using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
namespace DIO.ContasBancarias.Data.LDados
{
    public interface IDLContasRepositorio: IRepositorio<DLConta>
    {
        [XmlArrayAttribute("Contas")]
        public List<DLConta> Contas { get; set; }
        
    }
}