namespace DIO.ContasBancarias.Data.LLogs
{
    public interface ILLConfiguracoes
    {
        public string DiretorioApp { get; set; }

        public string DiretorioLog { get; set; }

        // Iníco do nome do arquivo de log "log_"
        // Arquivo com o padrão _Hora_Dia-Mes-Ano.log
        // Ou Arquivo _Dia_Mes-Ano.log
        public string InicioNomeArquivoLog { get; set; }

        // Se "true" arquivo por hora e diretório por dia, 
        // Se "false" arquivo por dia e diretório por mês
        public string OpacoArquivoPorHora { get; set; }
         
    }
}