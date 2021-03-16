namespace DIO.ContasBancarias.Data.LDados
{
    public class DLConfiguracoes : IDLConfiguracoes
    {
        public string DiretorioApp { get; set; }
        public string DiretorioDB { get; set; }
        public string ArquivoContasDB {  get; set; }
        public string ArquivoMovimentacoesDB {  get; set; }

        private DLConfiguracoes()
        {

        }
        
        public void InitDLConfiguracoes(string dirApp, string dirDB, string arqContas, string arqMov)
        {  
            this.DiretorioApp = dirApp;
            this.DiretorioDB = dirDB;
            this.ArquivoContasDB = arqContas;
            this.ArquivoMovimentacoesDB = arqMov;
        }

        // The Singleton's instance is stored in a static field.
        private static DLConfiguracoes _instance;

        // This is the static method that controls the access to the singleton
        // instance.
        public static DLConfiguracoes GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DLConfiguracoes();
            }
            return _instance;
        }

        public string getPathFile()
        {
            string pathString = System.IO.Path.Combine(this.DiretorioDB, this.ArquivoContasDB);
            return pathString;
        }
    }
}