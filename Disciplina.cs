using System;

namespace SistemaEscola
{
    class Disciplina
    {
        public string Nome { get; private set; }
        public string Codigo { get; private set; }
        public Professor Professor { get; private set; }
        public int CargaHoraria { get; private set; }

        public Disciplina(string nome, string codigo, Professor professor, int cargaHoraria)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome da disciplina inválido");

            if (string.IsNullOrWhiteSpace(codigo))
                throw new ArgumentException("Código inválido");

            if (professor == null)
                throw new ArgumentNullException(nameof(professor), "Professor não pode ser nulo");

            if (cargaHoraria <= 0)
                throw new ArgumentException("Carga horária deve ser maior que zero");

            Nome = nome;
            Codigo = codigo;
            Professor = professor;
            CargaHoraria = cargaHoraria;
        }

        public void ExibirDados()
        {
            Console.WriteLine($"Disciplina: {Nome}");
            Console.WriteLine($"Código: {Codigo}");
            Console.WriteLine($"Professor: {Professor.Nome}");
            Console.WriteLine($"Carga Horária: {CargaHoraria}h");
        }
    }
}
