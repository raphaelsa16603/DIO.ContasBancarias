namespace DIO.ContasBancarias.Model.Interfaces
{
    public class Mensagem : IMensagem
    {
    
        public Mensagem(string msg)
        {
            this.MensagemDaOperacao = msg;
        }
        public string MensagemDaOperacao { get; set; }
        
    }
}