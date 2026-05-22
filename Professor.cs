using System;
using System.Security.Cryptography;

namespace SistemaEscola
{
    class Professor : Pessoa
    {
        public Professor(string nome, string ra, string cpf, string email)
            : base(nome, ra, cpf, email)
        {
        }

        public override void ExibirDados()
        {
            Console.WriteLine("=== PROFESSOR ===");
            base.ExibirDados();
        }
    }
}