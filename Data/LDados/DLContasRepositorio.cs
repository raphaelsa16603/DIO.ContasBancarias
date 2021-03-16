using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace DIO.ContasBancarias.Data.LDados
{
    public class DLContasRepositorio : IDLContasRepositorio
    {
        [XmlArrayAttribute("Contas")]
        public List<IDLConta> Contas { get; set; }

        public void Atualiza(int id, IDLConta entidade)
        {
            this.Contas[id] = entidade;
        }

        public void Exclui(int id)
        {
            this.Contas[id].Excluir();
        }

        public void Insere(IDLConta entidade)
        {
            this.Contas.Add(entidade);
        }

        public List<IDLConta> Lista()
        {
            return this.Contas;
        }

        public int ProximoId()
        {
            return this.Contas.Count;
        }

        public IDLConta RetornaPorId(int id)
        {
            return this.Contas[id];
        }
    }
}