namespace DIO.ContasBancarias.Model.Interfaces
{
    public interface IContasDB
    {
         
        void InsereDB(IConta entidade);  

        int ProximoId(); 
    }
}