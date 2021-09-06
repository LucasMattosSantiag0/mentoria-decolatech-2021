using System;
using System.Collections.Generic;
using System.Text;

namespace AgenciaBancaria.Dominio
{
    public class Cliente
    {
        public Cliente(string nome, string cpf, string rg, Endereço endereço)
        {
            Nome = string.IsNullOrWhiteSpace(nome) ? throw new Exception("Propriedade deve estar preenchida.") : nome;
            CPF = string.IsNullOrWhiteSpace(cpf) ? throw new Exception("Propriedade deve estar preenchida.") : cpf;
            RG = string.IsNullOrWhiteSpace(rg) ? throw new Exception("Propriedade deve estar preenchida.") : rg;
            Endereço = endereço ?? throw new Exception("Endereço deve ser informado.");
        }

        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public string RG { get; private set; }

        public Endereço Endereço { get; private set; }
    }
}
