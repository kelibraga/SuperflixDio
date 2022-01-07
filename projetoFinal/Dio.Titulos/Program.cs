using System;

namespace Dio.Titulos
{
    class Program
    {
        static TituloRepositorio repositorio = new TituloRepositorio();
        static void Main(string[] args)
        {
           string opcaoUsuario = ObterOpcaoUsuario();
           while (opcaoUsuario.ToUpper() != "X")
           {
               switch (opcaoUsuario)
               {
                    case "1":
                        ListarTitulos();
                        break;
                    case "2":
                        InserirTitulo();
                        break;
                    case "3":
                        AtualizarTitulo();
                        break;
                    case "4":
                        ExcluirTitulo();
                        break;
                    case "5":
                        VisualizarTitulo();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    
                    default:
                        throw new ArgumentOutOfRangeException();
               }
               opcaoUsuario = ObterOpcaoUsuario();
           }
           Console.WriteLine("Obrigado por utilizar nossos serviços!");
           Console.WriteLine();         
       }
       private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Superflix da DIO");
            Console.WriteLine("O que você deseja fazer?");

            Console.WriteLine("1- Listar títulos");
            Console.WriteLine("2- Inserir novo título");
            Console.WriteLine("3- Atualizar título");
            Console.WriteLine("4- Excluir título");
            Console.WriteLine("5- Visualizar título");
            Console.WriteLine("C- Limpar a tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
        private static void ListarTitulos()
        {
            Console.WriteLine("Listar todos os títulos");

            var lista = repositorio.Lista();

            if (lista.Count == 0 )
            {
                Console.WriteLine("Ops! Nenhum título cadastrado.");
                return;
            }

            foreach (var titulo in lista)
            {
                var excluido = titulo.retornaExcluido();
                
                Console.WriteLine("#ID {0}: - {1} {2}", titulo.retornaId(), titulo.retornaTitulo(), (excluido ? "*Excluido*" : ""));
            }         
        }
        private static void InserirTitulo()
        {
            Console.WriteLine("Inserir novo título");

            foreach (int i in Enum.GetValues(typeof(Formato)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Formato), i));
            }

            Console.Write("Primeiro escolha o formato entre as opções acima: ");
            int entradaFormato = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            
            Console.Write("Agora escolha o gênero do seu título: ");
            int entradaGenero = int.Parse(Console.ReadLine());
            
            Console.Write("Digite o nome do título: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o ano de lançamento do título: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite descrição do título: ");
            string entradaDescricao = Console.ReadLine();

            Titulo novoTitulo = new Titulo(
                                    id: repositorio.ProximoId(),
                                    genero: (Genero)entradaGenero,
                                    nome: entradaNome,
                                    ano: entradaAno,
                                    formato: (Formato)entradaFormato,
                                    descricao: entradaDescricao
                                );

            repositorio.Insere(novoTitulo);
        }

        private static void AtualizarTitulo()
        {
            Console.Write("Digite o id do título que você deseja alterar: ");
            int indiceTitulo = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Formato)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Formato), i));
            }

            Console.Write("Escolha o formato do título entre as opções acima: ");
            int entradaFormato = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Escolha o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Nome do título: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Ano de lançamento do título: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Descrição do título: ");
            string entradaDescricao = Console.ReadLine();

            Titulo atualizaTitulo = new Titulo( 
                                        id: indiceTitulo,
                                        genero: (Genero)entradaGenero,
                                        nome: entradaNome,
                                        ano: entradaAno,
                                        formato: (Formato)entradaFormato,
                                        descricao: entradaDescricao
                                    );
            repositorio.Atualiza(indiceTitulo, atualizaTitulo);
        }
        private static void ExcluirTitulo()
        {
            Console.Write("Digite o id do título que você deseja excluir: ");
            int indiceTitulo = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceTitulo);
        }
        private static void VisualizarTitulo()
        {
            Console.Write("Digite o id do título que você deseja visualizar: ");
            int indiceTitulo = int.Parse(Console.ReadLine());

            var titulo = repositorio.RetornaPorId(indiceTitulo);

            Console.WriteLine(titulo);
        }
      
    }
}
