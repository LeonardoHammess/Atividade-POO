using System;

namespace SistemaEscola
{
    abstract class Pessoa
    {
        public string Nome { get; protected set; }
        public string Ra { get; protected set; }
        public string Cpf { get; protected set; }
        public string Email { get; protected set; }

        public Pessoa(string nome, string ra, string cpf, string email)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome inválido");

            if (string.IsNullOrWhiteSpace(ra))
                throw new ArgumentException("Ra inválido");

            if (string.IsNullOrWhiteSpace(cpf))
                throw new ArgumentException("Cpf inválido");

            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email inválido");

            Nome = nome;
            Ra = ra;
            Cpf = cpf;
            Email = email;
        }

        public void AlterarEmail(string novoEmail)
        {
            if (string.IsNullOrWhiteSpace(novoEmail))
                throw new ArgumentException("Novo email inválido");

            Email = novoEmail;
        }

        public virtual void ExibirDados()
        {
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"Ra: {Ra}");
            Console.WriteLine($"Cpf: {Cpf}");
            Console.WriteLine($"Email: {Email}");
        }
    }
}
