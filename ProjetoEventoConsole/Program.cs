using System;
using System.Collections.Generic;
using ProjetoEvento.ClassePai.ClassesFilhas;

namespace ProjetoEventoConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcao = 0;

            do{
                Console.WriteLine("\nDigite a opção:\n");
                System.Console.WriteLine("1 - Show");
                System.Console.WriteLine("2 - Teatro");
                System.Console.WriteLine("3 - Cinema");
                System.Console.WriteLine("9 - Sair\n");

                opcao = Convert.ToInt16(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Opcao("Show");
                        break;

                    case 2:
                        Opcao("Teatro");
                        break;

                    case 3:
                        Opcao("Cinema");
                        break;

                    case 9:
                        break;

                    default:
                        System.Console.WriteLine("Opção inválida.\n");
                        break;
                }

            }while(opcao != 9);
        }

        static void Opcao(string categoria)
        {
            int opcao = 0;

            do
            {
                Console.WriteLine("\nDigite a opção:\n ");
                System.Console.WriteLine("1 - Cadastrar " + categoria + " ");
                System.Console.WriteLine("2 - Pesquisar " + categoria + " por TITULO");
                System.Console.WriteLine("3 - Pesquisar " + categoria + " por DATA");
                System.Console.WriteLine("9 - Voltar\n");

                opcao = Convert.ToInt16(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                    {
                        bool cadastrosucesso = false;

                        System.Console.Write("\nTítulo: ");
                        string titulo = Console.ReadLine();
                        System.Console.Write("Local: ");
                        string local = Console.ReadLine();
                        System.Console.Write("Lotação: ");
                        int lotacao = Convert.ToInt16(Console.ReadLine());
                        System.Console.Write("Duração: ");
                        string duracao = Console.ReadLine();
                        System.Console.Write("Data (dd/mm/aaaa): ");
                        DateTime data = Convert.ToDateTime(Console.ReadLine());
                        System.Console.Write("Classificação: ");
                        int classificacao = Convert.ToInt16(Console.ReadLine());

                        switch (categoria)
                        {
                            case "Show":
                            {
                                System.Console.Write("Artista: ");
                                string artista = Console.ReadLine();
                                System.Console.Write("Gênero: ");
                                string generomusical = Console.ReadLine();

                                Show show = new Show(titulo, local, lotacao, duracao, classificacao, 
                                                    data, artista, generomusical);

                                cadastrosucesso = show.Cadastrar(); 
                                break;
                            }
                                
                            case "Teatro":
                            {
                                System.Console.Write("Diretor: ");
                                string diretor = Console.ReadLine();
                                System.Console.Write("Elenco (Digite o nome +Enter ou 0 +Enter para concluir): ");
                                string pessoa = Console.ReadLine();
                                List<string> elenco = new List<string>();
                                elenco.Add(pessoa);

                                while(pessoa != "0")
                                {
                                    System.Console.Write("Nome: ");
                                    pessoa = Console.ReadLine();
                                    if (pessoa != "0")
                                        elenco.Add(pessoa);
                                }
                                
                                Teatro teatro = new Teatro(titulo, local, lotacao, duracao, classificacao, 
                                                    data, diretor, elenco.ToArray());

                                cadastrosucesso = teatro.Cadastrar();
                                break;
                            }

                            case "Cinema":
                            {
                                System.Console.Write("Gênero: ");
                                string genero = Console.ReadLine();
                                System.Console.Write("Sessão (hh:mm:ss): ");
                                string stringSessao = (Console.ReadLine()); 
                                DateTime[] sessao = new DateTime[1];
                                
                                int i = 0;
                                while(stringSessao != "0")
                                {
                                    sessao[i] = Convert.ToDateTime(stringSessao);
                                    sessao[i].ToShortTimeString();
                                    i++;
                                
                                    System.Console.Write("Sessão (hh:mm:ss) ou 0+Enter para concluir: ");
                                    stringSessao = (Console.ReadLine());
                                    
                                    if (stringSessao != "0")
                                        Array.Resize(ref sessao, sessao.Length + 1);
                                }

                                Cinema cinema = new Cinema(titulo, local, lotacao, duracao, classificacao, data, sessao, genero);

                                cadastrosucesso = cinema.Cadastrar();
                                break;
                            }
                        }

                        if(cadastrosucesso)
                            System.Console.WriteLine("\nCadastrado com sucesso.");
                        else
                            System.Console.WriteLine("\nErro.");

                        break;
                    }
                    case 2:
                    {
                        System.Console.Write("\n" + categoria + " Título: ");
                        string titulo = Console.ReadLine();
                        string resultado = "";

                        if(categoria == "Show"){
                            Show show = new Show();
                            resultado = show.Pesquisar(titulo);
                        }else if(categoria == "Teatro"){
                            Teatro teatro = new Teatro();
                            resultado = teatro.Pesquisar(titulo);
                        }else{
                            Cinema cinema = new Cinema();
                            resultado = cinema.Pesquisar(titulo);
                        }
                            
                        System.Console.WriteLine("\n" + resultado);
                        break;
                    }

                    case 3:
                    {
                        System.Console.Write("\n" + categoria + " Data (dd/mm/aaaa): ");
                        string stringData = Console.ReadLine();
                        DateTime data = Convert.ToDateTime(stringData);
                        string resultado = "";

                        if(categoria == "Show"){
                            Show show = new Show();
                            resultado = show.Pesquisar(data);
                        }else if(categoria == "Teatro"){
                            Teatro teatro = new Teatro();
                            resultado = teatro.Pesquisar(data);
                        }else{
                            Cinema cinema = new Cinema();
                            resultado = cinema.Pesquisar(data);
                        }
                        
                        System.Console.WriteLine("\n" + resultado);
                        break;
                    }
                    case 9:
                        break;

                    default:
                        break;
                }

            }while(opcao != 9);
        }
    }
}
