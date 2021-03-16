namespace DIO.ContasBancarias.Data.LDados
{
    public class DLConfiguracoes : IDLConfiguracoes
    {
        public string DiretorioApp { get; set; }
        public string DiretorioDB { get; set; }
        public string ArquivoContasDB {  get; set; }
        public string ArquivoMovimentacoesDB {  get; set; }

        DLConfiguracoes(string dirApp, string dirDB, string arqContas, string arqMov)
        {  
            this.DiretorioApp = dirApp;
            this.DiretorioDB = dirDB;
            this.ArquivoContasDB = arqContas;
            this.ArquivoMovimentacoesDB = arqMov;
        }
    }
}