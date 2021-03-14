namespace DIO.ContasBancarias.Data.LLogs
{
    public interface ILLControle
    {
        public string DiretorioAtualLog { get; set; }
        public string ArquivoAtualLog { get; set; }

        public void LerArquivoJson();
        public void EscreverArquivoJson();

        public void LogarMensagem(string msg);
    }
}