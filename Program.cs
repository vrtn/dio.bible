using System;

namespace DIO.Bible
{
    class Program
    {
        static LivroRepositorio repositorio = new LivroRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarLivros();
                        break;
                    case "2":
                        InserirLivro();
                        break;
                    case "3":
                        AtualizarLivro();
                        break;
                    case "4":
                        ExcluirLivro();
                        break;
                    case "5":
                        VisualizarLivro();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        Console.WriteLine("\nTecle [ENTER] para retornar ao menu.");
                        break;
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.Clear();
            Console.WriteLine("Obrigado por utilizar nosso serviço!");
        }



        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("------------------------ ");
            Console.WriteLine("DIO Bíblia, graça e paz!");
            Console.WriteLine("------------------------ ");
            Console.WriteLine("Informe a opção desejada: \n");

            Console.WriteLine("[1] - Listar livros");
            Console.WriteLine("[2] - Inserir um novo livro");
            Console.WriteLine("[3] - Atualizar um livro");
            Console.WriteLine("[4] - Excluir um livro");
            Console.WriteLine("[5] - Visualizar um livro");
            Console.WriteLine("[C] - Limpar a tela");
            Console.WriteLine("[X] - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();

            return opcaoUsuario;
        }

        private static void ListarLivros()
        {
            Console.Clear();
            Console.WriteLine("------------------------------");
            Console.WriteLine("-------- Listar Livros -------");
            Console.WriteLine("------------------------------");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum livro cadastrado.\n\n");
                Console.WriteLine("Tecle [ENTER] para retornar ao menu.");
                Console.ReadKey();
                return;
            }

            foreach (var livro in lista)
            {
                if (!livro.retornaExcluido())
                {
                    Console.WriteLine("#ID {0}: {1}", livro.retornaId(), livro.retornaNome());
                }
            }

            Console.WriteLine("\n\nTecle [ENTER] para retornar ao menu.");
            Console.ReadKey();
        }

        private static void InserirLivro()
        {
            Console.Clear();
            Console.WriteLine("------------------------------");
            Console.WriteLine("---- Inserir novo livro ------");
            Console.WriteLine("------------------------------");

            foreach (int i in Enum.GetValues(typeof(Testamento)))
            {
                Console.WriteLine("[{0}] - {1}", i, Enum.GetName(typeof(Testamento), i));
            }
            Console.Write("\nDigite o Testamento entre as opções acima: ");
            int entradaTestamento = int.Parse(Console.ReadLine());

            Console.Write("Digite o Nome do livro: ");
            string entradaNome = Console.ReadLine().ToUpper();

            Console.Write("Digite o Autor do Livro: ");
            string entradaAutor = Console.ReadLine().ToUpper();

            Console.Write("Digite a quantidade de Versículos: ");
            int entradaVersiculos = int.Parse(Console.ReadLine());

            Livro livro = new Livro(id: repositorio.ProximoId(),
                                    testamento: (Testamento)entradaTestamento,
                                    nome: entradaNome,
                                    autor: entradaAutor,
                                    versiculos: entradaVersiculos);

            repositorio.Insere(livro);

            Console.Clear();

            Console.WriteLine("\n\nLivro incluído com sucesso! \nTecle [ENTER] para retornar ao menu.");
            Console.ReadKey();
        }
        private static void VisualizarLivro()
        {
            Console.Clear();
            Console.WriteLine("------------------------------");
            Console.WriteLine("----- Visualizar Livro -------");
            Console.WriteLine("------------------------------");

            Console.Write("Digite o Id do Livro: ");
            int entradaId = int.Parse(Console.ReadLine());

            var livro = repositorio.RetornaPorId(entradaId);

            Console.WriteLine(livro);

            Console.WriteLine("\n\nTecle [ENTER] para retornar ao menu.");
            Console.ReadKey();

            repositorio.Lista();
        }

        private static void ExcluirLivro()
        {   
            Console.Clear();
            Console.WriteLine("------------------------------");
            Console.WriteLine("------ Exluir um livro -------");
            Console.WriteLine("------------------------------");

            Console.Write("Digite o Id do Livro: ");
            int entradaId = int.Parse(Console.ReadLine());

            Console.WriteLine("\nDeseja exluir realmente o livro?\n[S] - Sim \n[N] - Não\n\n");
            string entradaExclusao = Console.ReadLine();

            if (entradaExclusao == "N")
            {
                return;
            }

            repositorio.Exclui(entradaId);

            Console.Clear();

            Console.WriteLine("\n\nLivro excluído com sucesso! \nTecle [ENTER] para retornar ao menu.");
            Console.ReadKey();
        }

        private static void AtualizarLivro()
        {
            Console.Clear();
            Console.WriteLine("------------------------------");
            Console.WriteLine("------ Atualizar livro -------");
            Console.WriteLine("------------------------------");

            Console.Write("Digite o Id do Livro que deseja alterar: ");
            int entradaId = int.Parse(Console.ReadLine());
            Console.WriteLine();

            foreach (int i in Enum.GetValues(typeof(Testamento)))
            {
                Console.WriteLine("[{0}] - {1}", i, Enum.GetName(typeof(Testamento), i));
            }
            Console.Write("\nDigite o Testamento entre as opções acima: ");
            int entradaTestamento = int.Parse(Console.ReadLine());

            Console.Write("Digite o Nome do livro: ");
            string entradaNome = Console.ReadLine().ToUpper();

            Console.Write("Digite o Autor do Livro: ");
            string entradaAutor = Console.ReadLine().ToUpper();

            Console.Write("Digite a quantidade de Versículos: ");
            int entradaVersiculos = int.Parse(Console.ReadLine());

            Livro atualizaLivro = new Livro(id: entradaId,
                                    testamento: (Testamento)entradaTestamento,
                                    nome: entradaNome,
                                    autor: entradaAutor,
                                    versiculos: entradaVersiculos);

            repositorio.Atualiza(entradaId, atualizaLivro);

            Console.WriteLine("\n\nLivro \"{0}\" alterado com sucesso! \n\n\nTecle [ENTER] para retornar ao menu.", entradaNome);
            Console.ReadKey();

            Console.Clear();
        }
    }
}
