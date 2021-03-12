namespace DIO.ContasBancarias.Model.Interfaces
{
    public interface IObserver
    {
         // Receive update from subject
        void Update(ISubject subject);
    }
}