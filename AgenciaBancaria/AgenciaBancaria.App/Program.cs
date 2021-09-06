using AgenciaBancaria.Dominio;
using System;

namespace AgenciaBancaria.App
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Endereço endereço = new Endereço( "Rua teste", "12345678", "São Paulo", "SP");
                Cliente cliente = new Cliente("Lucas", "123456", "456789", endereço);

                ContaCorrente conta = new ContaCorrente(cliente, 1000);

                Console.WriteLine("Conta " + conta.Situacao + ": " + conta.NumeroConta + "-" + conta.DigitoVerificador);

                string senha = "abc123456789";
                conta.Abrir(senha);

                Console.WriteLine("Conta " + conta.Situacao + ": " + conta.NumeroConta + "-" + conta.DigitoVerificador);

                conta.Sacar(10, senha);

                Console.WriteLine("Saldo: " + conta.Saldo);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
