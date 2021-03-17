using DIO.ContasBancarias.Model.Enum;
using DIO.ContasBancarias.Model.Interfaces;
using System.Xml;
using System.Xml.Serialization;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using DIO.ContasBancarias.Model.Entidades;

namespace DIO.ContasBancarias.Data.LDados
{
    public class DLConta : IDLConta
    {
        [XmlAttribute]
        public TipoConta TipoConta { get; set;  }
        [XmlAttribute]
        public double Saldo { get; set; }
        [XmlAttribute]
        public double Credito { get; set; }
        [XmlAttribute]
        public string Nome { get; set; }
        [XmlAttribute]
        public int IdConta { get; set; }

        [XmlAttribute]
        public bool Excluido { get; set; }

        [XmlArrayAttribute("Movimentacoes")]
        public List<DLMovimento> Movimentacoes { get; set; }

        public DLConta()
        { 

        }

        public DLConta(TipoConta tipoConta, double saldo, double credito, string nome, int id, bool excluido)
		{
			this.TipoConta = tipoConta;
			this.Saldo = saldo;
			this.Credito = credito;
			this.Nome = nome;
            this.IdConta = id;
            this.Excluido = excluido;
		}

        public void Excluir() {
            this.Excluido = true;
        }

        public override string ToString()
		{
			string retorno = "";
            retorno += "Id: " + this.IdConta + Environment.NewLine;
            retorno += "Nome: " + this.Nome + Environment.NewLine;
            retorno += "Tipo: " + this.TipoConta + Environment.NewLine;
            retorno += "Saldo: " + this.Saldo + Environment.NewLine;
            retorno += "Crédito: " + this.Credito + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;
			return retorno;
		}


        public void AtualizaMovimentacoes(List<MovimentoConta> list)
        {
            if(this.Movimentacoes == null)
            {
                this.Movimentacoes = new List<DLMovimento>();
            }
            foreach(MovimentoConta mv in list)
            {
                DLMovimento mvDB = new DLMovimento(
                    mv.DataHoraEvento,
                    mv.NomeConta,
                    mv.IdConta,
                    mv.Movimentacao,
                    mv.SaldoAntes,
                    mv.CreditoAntes);
                
                this.Movimentacoes.Add(mvDB);
            }
        }

        public List<DLMovimento> ListaMovimentos()
        {
            List<DLMovimento> movimentos = new List<DLMovimento>();
            if(this.Movimentacoes != null)
            {
                foreach(DLMovimento mv in this.Movimentacoes)
                {
                    DLMovimento NovoMv = new DLMovimento(
                            mv.DataHoraEvento, 
                            mv.NomeConta, 
                            mv.IdConta, 
                            mv.Movimentacao, 
                            mv.SaldoAntes, 
                            mv.CreditoAntes);
                    movimentos.Add(NovoMv);
                }
            }
            return movimentos;
        }

    }
}