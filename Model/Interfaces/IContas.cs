using System;
using System.Collections.Generic;

namespace DIO.ContasBancarias.Model.Interfaces
{
    public interface IContas
    {
        public void Depositar(int indiceConta, double valorDeposito);

        public void Sacar(int indiceConta, double valorSaque);

        public  void Transferir(int indiceContaOrigem, int indiceContaDestino, double valorTransferencia);

        public  void InserirConta(int entradaTipoConta, string entradaNome, double entradaSaldo, double entradaCredito);

        public List<IConta> ListarContas();
        
    }
}