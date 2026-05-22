using System;

namespace SistemaEscola
{
    class Nota
    {
        public Estudante Estudante { get; private set; }
        public Disciplina Disciplina { get; private set; }
        public double Valor { get; private set; }
        public string Tipo { get; private set; }
        public DateTime Data { get; private set; }

        public Nota(Estudante estudante, Disciplina disciplina, double valor, string tipo)
        {
            if (estudante == null)
                throw new ArgumentNullException(nameof(estudante));

            if (disciplina == null)
                throw new ArgumentNullException(nameof(disciplina));

            if (valor < 0 || valor > 10)
                throw new ArgumentException("Nota deve estar entre 0 e 10");

            if (string.IsNullOrWhiteSpace(tipo))
                throw new ArgumentException("Tipo de nota inválido");

            Estudante = estudante;
            Disciplina = disciplina;
            Valor = valor;
            Tipo = tipo;
            Data = DateTime.Now;
        }

        public void ExibirDados()
        {
            Console.WriteLine($"Estudante: {Estudante.Nome}");
            Console.WriteLine($"Disciplina: {Disciplina.Nome}");
            Console.WriteLine($"Nota ({Tipo}): {Valor:F2}");
            Console.WriteLine($"Data: {Data:dd/MM/yyyy}");
        }

        public bool Aprovado()
        {
            return Valor >= 6.0;
        }
    }
}
