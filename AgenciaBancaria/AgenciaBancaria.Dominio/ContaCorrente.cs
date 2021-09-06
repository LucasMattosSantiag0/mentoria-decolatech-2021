using System;
using System.Collections.Generic;
using System.Text;

namespace AgenciaBancaria.Dominio
{
    public class ContaCorrente :ContaBancaria
    {
        public ContaCorrente(Cliente cliente, decimal limite): base (cliente)
        {
            ValorTaxaManutenção = 0.05M;
            Limite = limite;
        }

        public override void Sacar(decimal valor, string senha)
        {
            if (Senha != senha)
            {
                throw new Exception("Senha invalida.");
            }
            if ((Saldo + Limite) < valor)
            {
                throw new Exception("Saldo Insuficiente.");
            }

            Saldo -= valor;
        }

        public decimal Limite { get; private set; }

        public decimal ValorTaxaManutenção { get; private set; }
    }
}
