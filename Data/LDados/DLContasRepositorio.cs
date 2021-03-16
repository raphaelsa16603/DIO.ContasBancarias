using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using DIO.ContasBancarias.Model.Entidades;

namespace DIO.ContasBancarias.Data.LDados
{
    public class DLContasRepositorio : IDLContasRepositorio
    {
        [XmlArrayAttribute("Contas")]
        public List<DLConta> Contas { get; set; }

        public void Atualiza(int id, DLConta entidade)
        {
            this.Contas[id] = (DLConta) entidade;
        }

        public void Exclui(int id)
        {
            this.Contas[id].Excluir();
        }

        public void Insere(DLConta entidade)
        {
            if(this.Contas == null)
                this.Contas = new List<DLConta>();
            this.Contas.Add((DLConta)entidade);
        }

        public List<DLConta> Lista()
        {
            return this.Contas;
        }

        public int ProximoId()
        {
            return this.Contas.Count;
        }

        public DLConta RetornaPorId(int id)
        {
            return this.Contas[id];
        }
    }
}