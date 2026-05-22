using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaEscola
{
    class program
    {
        static List<Professor> professores = new List<Professor>();
        static List<Estudante> estudantes = new List<Estudante>();
        static List<Disciplina> disciplinas = new List<Disciplina>();
        static List<Turma> turmas = new List<Turma>();
        static List<Boletim> boletins = new List<Boletim>();

        static int proximoRaProfessor = 1;
        static int proximoRaEstudante = 1;

        static void Main(string[] args)
        {
            bool continuar = true;

            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("╔════════════════════════════════════╗");
                Console.WriteLine("║   SISTEMA DE ESCOLA - MENU PRINCIPAL ║");
                Console.WriteLine("╚════════════════════════════════════╝\n");

                Console.WriteLine("1 - Cadastrar Professor");
                Console.WriteLine("2 - Cadastrar Estudante");
                Console.WriteLine("3 - Criar Disciplina");
                Console.WriteLine("4 - Criar Turma");
                Console.WriteLine("5 - Adicionar Estudante à Turma");
                Console.WriteLine("6 - Adicionar Disciplina à Turma");
                Console.WriteLine("7 - Registrar Nota");
                Console.WriteLine("8 - Gerar Boletim");
                Console.WriteLine("9 - Listar Professores");
                Console.WriteLine("10 - Listar Estudantes");
                Console.WriteLine("11 - Listar Disciplinas");
                Console.WriteLine("12 - Listar Turmas");
                Console.WriteLine("13 - Sair");
                Console.WriteLine("\nEscolha uma opção: ");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        CadastrarProfessor();
                        break;
                    case "2":
                        CadastrarEstudante();
                        break;
                    case "3":
                        CriarDisciplina();
                        break;
                    case "4":
                        CriarTurma();
                        break;
                    case "5":
                        AdicionarEstudanteAoTurma();
                        break;
                    case "6":
                        AdicionarDisciplinaAoTurma();
                        break;
                    case "7":
                        RegistrarNota();
                        break;
                    case "8":
                        GerarBoletim();
                        break;
                    case "9":
                        ListarProfessores();
                        break;
                    case "10":
                        ListarEstudantes();
                        break;
                    case "11":
                        ListarDisciplinas();
                        break;
                    case "12":
                        ListarTurmas();
                        break;
                    case "13":
                        continuar = false;
                        Console.WriteLine("\nAté logo!");
                        break;
                    default:
                        Console.WriteLine("\nOpção inválida! Pressione ENTER para continuar.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        static void CadastrarProfessor()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("═════════════ CADASTRO DE PROFESSOR ═════════════\n");

                Console.Write("Nome: ");
                string nome = Console.ReadLine();

                Console.Write("CPF: ");
                string cpf = Console.ReadLine();

                Console.Write("Email: ");
                string email = Console.ReadLine();

                string ra = $"P{proximoRaProfessor:D3}";
                proximoRaProfessor++;

                Professor prof = new Professor(nome, ra, cpf, email);
                professores.Add(prof);

                Console.WriteLine($"\n✓ Professor cadastrado com sucesso!");
                Console.WriteLine($"RA atribuído: {ra}");
                prof.ExibirDados();

                Console.WriteLine("\nPressione ENTER para voltar ao menu...");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n✗ Erro: {ex.Message}");
                Console.WriteLine("Pressione ENTER para voltar ao menu...");
                Console.ReadLine();
            }
        }

        static void CadastrarEstudante()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("═════════════ CADASTRO DE ESTUDANTE ═════════════\n");

                Console.Write("Nome: ");
                string nome = Console.ReadLine();

                Console.Write("CPF: ");
                string cpf = Console.ReadLine();

                Console.Write("Email: ");
                string email = Console.ReadLine();

                string ra = $"E{proximoRaEstudante:D3}";
                proximoRaEstudante++;

                Estudante est = new Estudante(nome, ra, cpf, email);
                estudantes.Add(est);

                Console.WriteLine($"\n✓ Estudante cadastrado com sucesso!");
                Console.WriteLine($"RA atribuído: {ra}");
                est.ExibirDados();

                Console.WriteLine("\nPressione ENTER para voltar ao menu...");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n✗ Erro: {ex.Message}");
                Console.WriteLine("Pressione ENTER para voltar ao menu...");
                Console.ReadLine();
            }
        }

        static void CriarDisciplina()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("═════════════ CRIAR DISCIPLINA ═════════════\n");

                if (professores.Count == 0)
                {
                    Console.WriteLine("✗ Nenhum professor cadastrado!");
                    Console.WriteLine("Pressione ENTER para voltar...");
                    Console.ReadLine();
                    return;
                }

                Console.Write("Nome da Disciplina: ");
                string nome = Console.ReadLine();

                Console.Write("Código: ");
                string codigo = Console.ReadLine();

                Console.Write("Carga Horária: ");
                int cargaHoraria = int.Parse(Console.ReadLine());

                Console.WriteLine("\n--- Selecione o Professor ---");
                for (int i = 0; i < professores.Count; i++)
                {
                    Console.WriteLine($"{i + 1} - {professores[i].Nome} (RA: {professores[i].Ra})");
                }
                Console.Write("\nOpção: ");
                int opcao = int.Parse(Console.ReadLine()) - 1;

                if (opcao < 0 || opcao >= professores.Count)
                {
                    Console.WriteLine("✗ Professor inválido!");
                    Console.ReadLine();
                    return;
                }

                Disciplina disc = new Disciplina(nome, codigo, professores[opcao], cargaHoraria);
                disciplinas.Add(disc);

                Console.WriteLine("\n✓ Disciplina criada com sucesso!");
                disc.ExibirDados();

                Console.WriteLine("\nPressione ENTER para voltar ao menu...");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n✗ Erro: {ex.Message}");
                Console.WriteLine("Pressione ENTER para voltar ao menu...");
                Console.ReadLine();
            }
        }

        static void CriarTurma()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("═════════════ CRIAR TURMA ═════════════\n");

                Console.Write("Código da Turma (ex: 1-A): ");
                string codigo = Console.ReadLine();

                Console.Write("Período (Matutino/Vespertino/Noturno): ");
                string periodo = Console.ReadLine();

                Turma turma = new Turma(codigo, periodo);
                turmas.Add(turma);

                Console.WriteLine("\n✓ Turma criada com sucesso!");
                turma.ExibirDados();

                Console.WriteLine("\nPressione ENTER para voltar ao menu...");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n✗ Erro: {ex.Message}");
                Console.WriteLine("Pressione ENTER para voltar ao menu...");
                Console.ReadLine();
            }
        }

        static void AdicionarEstudanteAoTurma()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("═════════════ ADICIONAR ESTUDANTE À TURMA ═════════════\n");

                if (turmas.Count == 0)
                {
                    Console.WriteLine("✗ Nenhuma turma cadastrada!");
                    Console.ReadLine();
                    return;
                }

                if (estudantes.Count == 0)
                {
                    Console.WriteLine("✗ Nenhum estudante cadastrado!");
                    Console.ReadLine();
                    return;
                }

                Console.WriteLine("--- Selecione a Turma ---");
                for (int i = 0; i < turmas.Count; i++)
                {
                    Console.WriteLine($"{i + 1} - {turmas[i].Codigo} ({turmas[i].Periodo})");
                }
                Console.Write("\nOpção: ");
                int opcaoTurma = int.Parse(Console.ReadLine()) - 1;

                if (opcaoTurma < 0 || opcaoTurma >= turmas.Count)
                {
                    Console.WriteLine("✗ Turma inválida!");
                    Console.ReadLine();
                    return;
                }

                Console.WriteLine("\n--- Selecione o Estudante ---");
                for (int i = 0; i < estudantes.Count; i++)
                {
                    Console.WriteLine($"{i + 1} - {estudantes[i].Nome} (RA: {estudantes[i].Ra})");
                }
                Console.Write("\nOpção: ");
                int opcaoEstudante = int.Parse(Console.ReadLine()) - 1;

                if (opcaoEstudante < 0 || opcaoEstudante >= estudantes.Count)
                {
                    Console.WriteLine("✗ Estudante inválido!");
                    Console.ReadLine();
                    return;
                }

                turmas[opcaoTurma].AdicionarEstudante(estudantes[opcaoEstudante]);
                Console.WriteLine("\n✓ Estudante adicionado à turma com sucesso!");

                Console.WriteLine("\nPressione ENTER para voltar ao menu...");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n✗ Erro: {ex.Message}");
                Console.WriteLine("Pressione ENTER para voltar ao menu...");
                Console.ReadLine();
            }
        }

        static void AdicionarDisciplinaAoTurma()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("═════════════ ADICIONAR DISCIPLINA À TURMA ═════════════\n");

                if (turmas.Count == 0)
                {
                    Console.WriteLine("✗ Nenhuma turma cadastrada!");
                    Console.ReadLine();
                    return;
                }

                if (disciplinas.Count == 0)
                {
                    Console.WriteLine("✗ Nenhuma disciplina cadastrada!");
                    Console.ReadLine();
                    return;
                }

                Console.WriteLine("--- Selecione a Turma ---");
                for (int i = 0; i < turmas.Count; i++)
                {
                    Console.WriteLine($"{i + 1} - {turmas[i].Codigo} ({turmas[i].Periodo})");
                }
                Console.Write("\nOpção: ");
                int opcaoTurma = int.Parse(Console.ReadLine()) - 1;

                if (opcaoTurma < 0 || opcaoTurma >= turmas.Count)
                {
                    Console.WriteLine("✗ Turma inválida!");
                    Console.ReadLine();
                    return;
                }

                Console.WriteLine("\n--- Selecione a Disciplina ---");
                for (int i = 0; i < disciplinas.Count; i++)
                {
                    Console.WriteLine($"{i + 1} - {disciplinas[i].Nome} ({disciplinas[i].Codigo})");
                }
                Console.Write("\nOpção: ");
                int opcaoDisciplina = int.Parse(Console.ReadLine()) - 1;

                if (opcaoDisciplina < 0 || opcaoDisciplina >= disciplinas.Count)
                {
                    Console.WriteLine("✗ Disciplina inválida!");
                    Console.ReadLine();
                    return;
                }

                turmas[opcaoTurma].AdicionarDisciplina(disciplinas[opcaoDisciplina]);
                Console.WriteLine("\n✓ Disciplina adicionada à turma com sucesso!");

                Console.WriteLine("\nPressione ENTER para voltar ao menu...");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n✗ Erro: {ex.Message}");
                Console.WriteLine("Pressione ENTER para voltar ao menu...");
                Console.ReadLine();
            }
        }

        static void RegistrarNota()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("═════════════ REGISTRAR NOTA ═════════════\n");

                if (estudantes.Count == 0)
                {
                    Console.WriteLine("✗ Nenhum estudante cadastrado!");
                    Console.ReadLine();
                    return;
                }

                if (disciplinas.Count == 0)
                {
                    Console.WriteLine("✗ Nenhuma disciplina cadastrada!");
                    Console.ReadLine();
                    return;
                }

                Console.WriteLine("--- Selecione o Estudante ---");
                for (int i = 0; i < estudantes.Count; i++)
                {
                    Console.WriteLine($"{i + 1} - {estudantes[i].Nome} (RA: {estudantes[i].Ra})");
                }
                Console.Write("\nOpção: ");
                int opcaoEstudante = int.Parse(Console.ReadLine()) - 1;

                if (opcaoEstudante < 0 || opcaoEstudante >= estudantes.Count)
                {
                    Console.WriteLine("✗ Estudante inválido!");
                    Console.ReadLine();
                    return;
                }

                Console.WriteLine("\n--- Selecione a Disciplina ---");
                for (int i = 0; i < disciplinas.Count; i++)
                {
                    Console.WriteLine($"{i + 1} - {disciplinas[i].Nome}");
                }
                Console.Write("\nOpção: ");
                int opcaoDisciplina = int.Parse(Console.ReadLine()) - 1;

                if (opcaoDisciplina < 0 || opcaoDisciplina >= disciplinas.Count)
                {
                    Console.WriteLine("✗ Disciplina inválida!");
                    Console.ReadLine();
                    return;
                }

                Console.Write("\nTipo de Avaliação (Prova/Trabalho/Participação): ");
                string tipo = Console.ReadLine();

                Console.Write("Valor da Nota (0-10): ");
                double valor = double.Parse(Console.ReadLine());

                Nota nota = new Nota(estudantes[opcaoEstudante], disciplinas[opcaoDisciplina], valor, tipo);
                
                // Encontrar ou criar boletim
                Boletim boletimExistente = boletins.FirstOrDefault(b => 
                    b.Estudante.Ra == estudantes[opcaoEstudante].Ra);

                if (boletimExistente != null)
                {
                    boletimExistente.AdicionarNota(nota);
                }
                else
                {
                    // Se não tiver boletim, criar um
                    Turma turmaPrincipal = turmas.FirstOrDefault();
                    if (turmaPrincipal != null)
                    {
                        Boletim novoBoletim = new Boletim(estudantes[opcaoEstudante], turmaPrincipal, "2026-1");
                        novoBoletim.AdicionarNota(nota);
                        boletins.Add(novoBoletim);
                    }
                }

                Console.WriteLine("\n✓ Nota registrada com sucesso!");
                nota.ExibirDados();

                Console.WriteLine("\nPressione ENTER para voltar ao menu...");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n✗ Erro: {ex.Message}");
                Console.WriteLine("Pressione ENTER para voltar ao menu...");
                Console.ReadLine();
            }
        }

        static void GerarBoletim()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("═════════════ GERAR BOLETIM ═════════════\n");

                if (estudantes.Count == 0)
                {
                    Console.WriteLine("✗ Nenhum estudante cadastrado!");
                    Console.ReadLine();
                    return;
                }

                Console.WriteLine("--- Selecione o Estudante ---");
                for (int i = 0; i < estudantes.Count; i++)
                {
                    Console.WriteLine($"{i + 1} - {estudantes[i].Nome} (RA: {estudantes[i].Ra})");
                }
                Console.Write("\nOpção: ");
                int opcao = int.Parse(Console.ReadLine()) - 1;

                if (opcao < 0 || opcao >= estudantes.Count)
                {
                    Console.WriteLine("✗ Estudante inválido!");
                    Console.ReadLine();
                    return;
                }

                Boletim boletim = boletins.FirstOrDefault(b => 
                    b.Estudante.Ra == estudantes[opcao].Ra);

                if (boletim == null)
                {
                    Console.WriteLine("✗ Nenhum boletim encontrado para este estudante!");
                }
                else
                {
                    boletim.ExibirBoletim();
                }

                Console.WriteLine("\nPressione ENTER para voltar ao menu...");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n✗ Erro: {ex.Message}");
                Console.WriteLine("Pressione ENTER para voltar ao menu...");
                Console.ReadLine();
            }
        }

        static void ListarProfessores()
        {
            Console.Clear();
            Console.WriteLine("═════════════ PROFESSORES CADASTRADOS ═════════════\n");

            if (professores.Count == 0)
            {
                Console.WriteLine("Nenhum professor cadastrado.");
            }
            else
            {
                for (int i = 0; i < professores.Count; i++)
                {
                    Console.WriteLine($"\n--- Professor {i + 1} ---");
                    professores[i].ExibirDados();
                }
            }

            Console.WriteLine("\nPressione ENTER para voltar ao menu...");
            Console.ReadLine();
        }

        static void ListarEstudantes()
        {
            Console.Clear();
            Console.WriteLine("═════════════ ESTUDANTES CADASTRADOS ═════════════\n");

            if (estudantes.Count == 0)
            {
                Console.WriteLine("Nenhum estudante cadastrado.");
            }
            else
            {
                for (int i = 0; i < estudantes.Count; i++)
                {
                    Console.WriteLine($"\n--- Estudante {i + 1} ---");
                    estudantes[i].ExibirDados();
                }
            }

            Console.WriteLine("\nPressione ENTER para voltar ao menu...");
            Console.ReadLine();
        }

        static void ListarDisciplinas()
        {
            Console.Clear();
            Console.WriteLine("═════════════ DISCIPLINAS CADASTRADAS ═════════════\n");

            if (disciplinas.Count == 0)
            {
                Console.WriteLine("Nenhuma disciplina cadastrada.");
            }
            else
            {
                for (int i = 0; i < disciplinas.Count; i++)
                {
                    Console.WriteLine($"\n--- Disciplina {i + 1} ---");
                    disciplinas[i].ExibirDados();
                }
            }

            Console.WriteLine("\nPressione ENTER para voltar ao menu...");
            Console.ReadLine();
        }

        static void ListarTurmas()
        {
            Console.Clear();
            Console.WriteLine("═════════════ TURMAS CADASTRADAS ═════════════\n");

            if (turmas.Count == 0)
            {
                Console.WriteLine("Nenhuma turma cadastrada.");
            }
            else
            {
                for (int i = 0; i < turmas.Count; i++)
                {
                    Console.WriteLine($"\n--- Turma {i + 1} ---");
                    turmas[i].ExibirDados();
                    turmas[i].ListarEstudantes();
                    turmas[i].ListarDisciplinas();
                }
            }

            Console.WriteLine("\nPressione ENTER para voltar ao menu...");
            Console.ReadLine();
        }
    }
}