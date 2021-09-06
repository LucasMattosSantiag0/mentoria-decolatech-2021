using System;
using System.Collections.Generic;
using System.Text;

namespace AgenciaBancaria.Dominio
{
    public class Endereço
    {
        public Endereço(string logradouro, string cep, string cidade, string estado)
        {
            Logradouro = string.IsNullOrWhiteSpace(logradouro) ? throw new Exception("Propriedade deve estar preenchida.") : logradouro;
            CEP = string.IsNullOrWhiteSpace(cep) ? throw new Exception("Propriedade deve estar preenchida.") : cep;
            Cidade = string.IsNullOrWhiteSpace(cidade) ? throw new Exception("Propriedade deve estar preenchida.") : cidade;
            Estado = string.IsNullOrWhiteSpace(estado) ? throw new Exception("Propriedade deve estar preenchida.") : estado;
        }

        public string Logradouro { get; private set; }
        public string CEP { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
    }
}
