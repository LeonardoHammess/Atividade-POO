using System;
using System.Runtime.CompilerServices;

namespace SistemaEscola
{
    class Estudante : Pessoa
    {
        public Estudante(string nome, string ra, string cpf, string email)
            : base(nome, ra, cpf, email)
        {
        }

        public override void ExibirDados()
        {
            Console.WriteLine("=== ESTUDANTE ===");
            base.ExibirDados();
        }
    }
}


