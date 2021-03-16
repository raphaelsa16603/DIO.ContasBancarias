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
        private IDLContasRepositorio asContasXML = null;
        private string pathString;

        public XmlContasTools(IContas oContas, string FilePath)
        {
            this.asContas = oContas;
            this.pathString = FilePath;
        }

        public void LerArquivoXml()
        {
            //string txtjson = LerArquioTexto();

            XmlSerializer serializer = new XmlSerializer(typeof(IDLContasRepositorio));
            FileStream fs = new FileStream(this.pathString, FileMode.Open);
            this.asContasXML = (IDLContasRepositorio) serializer.Deserialize(fs);
            List<IDLConta> contas = this.asContasXML.Lista();

            ConverterListaDeObjetos(contas);
        }

        private void ConverterListaDeObjetos(List<IDLConta> contas)
        {
            if (this.asContas == null)
            {
                this.asContas = new Contas();
            }

            foreach (IDLConta conta in contas)
            {
                // IConta contaNormal = new Conta
                //     (conta.TipoConta, 
                //      conta.Saldo, 
                //      conta.Credito, 
                //      conta.Nome);
                if(!conta.Excluido)
                {
                    this.asContas.InserirConta
                    (conta.TipoConta == Model.Enum.TipoConta.PessoaFisica ? 1 : 2, 
                     conta.Nome,
                     conta.Saldo, 
                     conta.Credito);
                }
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
            XmlSerializer serializer = new XmlSerializer(typeof(IDLContasRepositorio));
            TextWriter writer = new StreamWriter(this.pathString);
            
            serializer.Serialize(writer, this.asContasXML);
            writer.Close();
            //EscreverArquivoTexto(this.pathString, txtjson);
        }

        private string SerializandoObjetosDeContas()
        {
            string txtjson;
            //Serializar Lista de Filmes
            // Inicializando do zero filmes serializaveis
            this.asContasXML = new DLContasRepositorio();
            List<IConta> contas = this.asContas.Lista();
            foreach (IConta conta in contas)
            {
                IDLConta ContaXml = new DLConta();
                
                if (filme.Excluido)
                {
                    FilmeJson.Excluir();
                }
                this.osFilmesSerializaveis.Insere(FilmeJson);
            }
            txtjson = JsonSerializer.Serialize<MoviesJson>
                    (this.osFilmesSerializaveis, options);
            return txtjson;
        }

        private static async void EscreverArquivoTexto(string FilePath, string TextoJson)
        {
            await File.WriteAllTextAsync(FilePath, TextoJson);
        }


        public Movies.Movies GetMovies()
        {
            return this.osFilmes;
        }

        public void AtualizarMovies(Movies.Movies filmes)
        {
            this.osFilmes = filmes;
        }        
    }


}