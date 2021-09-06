using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AgenciaBancaria.Dominio
{
    public abstract class ContaBancaria
    {
        public ContaBancaria(Cliente cliente)
        {
            Random random = new Random();
            NumeroConta = random.Next(50000, 100000);
            DigitoVerificador = random.Next(0, 9);

            Situacao = SituacaoConta.Criada;

            Cliente = cliente ?? throw new Exception("Cliente deve ser informado.");
        }

        public void Abrir(string senha)
        {
            SetaSenha(senha);

            Situacao = SituacaoConta.Aberta;
            DatadeAbertura = DateTime.Now;
        }

        private void SetaSenha(string senha)
        {
            senha = string.IsNullOrWhiteSpace(senha) ? throw new Exception("Propriedade deve estar preenchida.") : senha;

            if (!Regex.IsMatch(senha, @"^(?=.*?[a-z])(?=.*?[0-9]).{8,}$"))
            {
                throw new Exception("Senha invalida");
            }

            Senha = senha;
        }

        public virtual void Sacar(decimal valor, string senha)
        {
            if (Senha != senha)
            {
                throw new Exception("Senha invalida.");
            }
            if(Saldo < valor)
            {
                throw new Exception("Saldo Insuficiente.");
            }

            Saldo -= valor;
        }

        public int NumeroConta { get; set; }
        public int DigitoVerificador { get; set; }
        public decimal Saldo { get; protected set; }
        public DateTime? DatadeAbertura { get; private set; }
        public DateTime? DatadeEncerramento { get; private set; }
        public SituacaoConta Situacao { get; private set; }
        public string Senha { get; private set; }
        public Cliente Cliente { get; set; }
    }
}
