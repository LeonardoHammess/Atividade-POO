using System;
using System.Collections.Generic;

namespace SistemaEscola
{
    class Turma
    {
        public string Codigo { get; private set; }
        public string Periodo { get; private set; }
        public List<Estudante> Estudantes { get; private set; }
        public List<Disciplina> Disciplinas { get; private set; }

        public Turma(string codigo, string periodo)
        {
            if (string.IsNullOrWhiteSpace(codigo))
                throw new ArgumentException("Código de turma inválido");

            if (string.IsNullOrWhiteSpace(periodo))
                throw new ArgumentException("Período inválido");

            Codigo = codigo;
            Periodo = periodo;
            Estudantes = new List<Estudante>();
            Disciplinas = new List<Disciplina>();
        }

        public void AdicionarEstudante(Estudante estudante)
        {
            if (estudante == null)
                throw new ArgumentNullException(nameof(estudante));

            if (!Estudantes.Contains(estudante))
                Estudantes.Add(estudante);
            else
                Console.WriteLine("Este estudante já está na turma");
        }

        public void AdicionarDisciplina(Disciplina disciplina)
        {
            if (disciplina == null)
                throw new ArgumentNullException(nameof(disciplina));

            if (!Disciplinas.Contains(disciplina))
                Disciplinas.Add(disciplina);
            else
                Console.WriteLine("Esta disciplina já está na turma");
        }

        public void ExibirDados()
        {
            Console.WriteLine($"\n=== Turma {Codigo} - Período: {Periodo} ===");
            Console.WriteLine($"Total de Estudantes: {Estudantes.Count}");
            Console.WriteLine($"Total de Disciplinas: {Disciplinas.Count}");
        }

        public void ListarEstudantes()
        {
            Console.WriteLine($"\n--- Estudantes da Turma {Codigo} ---");
            foreach (var est in Estudantes)
            {
                Console.WriteLine($"- {est.Nome} (RA: {est.Ra})");
            }
        }

        public void ListarDisciplinas()
        {
            Console.WriteLine($"\n--- Disciplinas da Turma {Codigo} ---");
            foreach (var disc in Disciplinas)
            {
                Console.WriteLine($"- {disc.Nome} (Prof: {disc.Professor.Nome})");
            }
        }
    }
}
