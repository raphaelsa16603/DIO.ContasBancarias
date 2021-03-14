namespace DIO.ContasBancarias.Data.LDados
{
    public interface IDLConfiguracoes
    {
        public string DiretorioApp { get; set; }

        public string DiretorioDB { get; set; }

        // Arquivo das contas *.xml
        public string ArquivoContasDB { get; set; }

        // Padrão do arquivo de Movimentações = "Padrao_Id{idConta}.xml"
        public string ArquivoMovimentacoesDB { get; set; }
        
    }
}