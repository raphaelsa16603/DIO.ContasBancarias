using System.IO;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using DIO.ContasBancarias.Model.Entidades;
using DIO.ContasBancarias.Model.Interfaces;

namespace DIO.ContasBancarias.Data.LDados
{
    public class XmlContasTools
    {

        private IContas asContas = null;
        private DLContasRepositorio asContasXML = null;
        private string pathString;

        public XmlContasTools(IContas oContas, string FilePath)
        {
            this.asContas = oContas;
            this.pathString = FilePath;
        }


        public void LerArquivoXml()
        {
            //string txtjson = LerArquioTexto();

            if(this.asContasXML == null)
                this.asContasXML = new DLContasRepositorio();
            XmlSerializer serializer = new XmlSerializer(this.asContasXML.GetType());
            FileStream fs = new FileStream(this.pathString, FileMode.Open);
            this.asContasXML = (DLContasRepositorio) serializer.Deserialize(fs);
            List<DLConta> contas = this.asContasXML.Lista();

            ConverterListaDeObjetos(contas);
        }

        private void ConverterListaDeObjetos(List<DLConta> contas)
        {
            if (this.asContas == null)
            {
                this.asContas = new Contas();
            }



            foreach (IDLConta conta in contas)
            {
                IConta contaNormal = new Conta
                    (conta.TipoConta, 
                     conta.Saldo, 
                     conta.Credito, 
                     conta.Nome, 
                     conta.IdConta,
                     conta.Excluido);

                ((Contas)this.asContas).InsereDB(contaNormal);
            }
        }


        private string LerArquioTexto()
        {
            string text = System.IO.File.ReadAllText(this.pathString);

            return text;
        }

        public void EscreverArquivoXml()
        {
            // string txtjson = "";
            if(this.asContas != null)
            {
                if(this.asContasXML == null)
                {
                    SerializandoObjetosDeContas();
                }
                XmlSerializer serializer = new XmlSerializer(this.asContasXML.GetType());
                try
                {
                    TextWriter writer = new StreamWriter(this.pathString);
                    serializer.Serialize(writer, this.asContasXML);
                    writer.Close();                
                }
                catch (System.Exception)
                {
                    string txtXml = XmlContasTools.SerializeObject(this.asContasXML);
                    EscreverArquivoTexto(this.pathString, txtXml);
                }
            }
        }

        public static string SerializeObject(DLContasRepositorio toSerialize)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(toSerialize.GetType());

            using(StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, toSerialize);
                return textWriter.ToString();
            }
        }

        private void SerializandoObjetosDeContas()
        {
            this.asContasXML = new DLContasRepositorio();
            List<IConta> contas = this.asContas.ListarContas();
            foreach (IConta conta in contas)
            {
                DLConta ContaXml = new DLConta();
                
                if (conta.Excluido)
                {
                    ContaXml.Excluir();
                }
                this.asContasXML.Insere(ContaXml);
            }

        }

        private static async void EscreverArquivoTexto(string FilePath, string TextoJson)
        {
            await File.WriteAllTextAsync(FilePath, TextoJson);
        }


        public IContas GetContas()
        {
            return this.asContas;
        }

        public void AtualizarContas(IContas contas)
        {
            this.asContas = contas;
        }        
    }


}