using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaEscola
{
    class Boletim
    {
        public Estudante Estudante { get; private set; }
        public Turma Turma { get; private set; }
        public List<Nota> Notas { get; private set; }
        public string Semestre { get; private set; }

        public Boletim(Estudante estudante, Turma turma, string semestre)
        {
            if (estudante == null)
                throw new ArgumentNullException(nameof(estudante));

            if (turma == null)
                throw new ArgumentNullException(nameof(turma));

            if (string.IsNullOrWhiteSpace(semestre))
                throw new ArgumentException("Semestre inválido");

            Estudante = estudante;
            Turma = turma;
            Semestre = semestre;
            Notas = new List<Nota>();
        }

        public void AdicionarNota(Nota nota)
        {
            if (nota == null)
                throw new ArgumentNullException(nameof(nota));

            if (nota.Estudante.Ra != Estudante.Ra)
                throw new ArgumentException("Esta nota não pertence a este estudante");

            Notas.Add(nota);
        }

        public double CalcularMedia()
        {
            if (Notas.Count == 0)
                return 0;

            return Notas.Average(n => n.Valor);
        }

        public string ObterSituacao()
        {
            double media = CalcularMedia();

            if (media >= 7.0)
                return "APROVADO";
            else if (media >= 5.0)
                return "RECUPERAÇÃO";
            else
                return "REPROVADO";
        }

        public void ExibirBoletim()
        {
            Console.WriteLine($"\n========== BOLETIM ==========");
            Console.WriteLine($"Estudante: {Estudante.Nome}");
            Console.WriteLine($"RA: {Estudante.Ra}");
            Console.WriteLine($"Turma: {Turma.Codigo}");
            Console.WriteLine($"Semestre: {Semestre}");
            Console.WriteLine($"----------------------------");

            var notasPorDisciplina = Notas.GroupBy(n => n.Disciplina.Nome);

            foreach (var grupo in notasPorDisciplina)
            {
                double mediaDisc = grupo.Average(n => n.Valor);
                Console.WriteLine($"\n{grupo.Key}: {mediaDisc:F2}");
                foreach (var nota in grupo)
                {
                    Console.WriteLine($"  - {nota.Tipo}: {nota.Valor:F2}");
                }
            }

            Console.WriteLine($"\n----------------------------");
            Console.WriteLine($"Média Geral: {CalcularMedia():F2}");
            Console.WriteLine($"Situação: {ObterSituacao()}");
            Console.WriteLine($"=============================\n");
        }
    }
}
