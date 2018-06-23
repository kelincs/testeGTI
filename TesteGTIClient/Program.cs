using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteGTIClient.HTTPClient;
using TesteGTIClient.Model;

namespace TesteGTIClient
{
    class Program
    {
        private static double _latitude;
        private static double _longitude;
        private static string _nome;
        private static int _numeroAmigos = 0;

        static void Main(string[] args)
        {

            ConsoleKey key;
            bool confirma;
            Amigo amigo;
            HTTPClient.HTTPClient client = new HTTPClient.HTTPClient();
            Int32.TryParse(ConfigurationManager.AppSettings["numeroAmigos"], out _numeroAmigos);

            do
            {
                Console.Write("Não há amigos cadastrados. Deseja cadastrar um novo amigo? [s/n] ");
                key = Console.ReadKey(false).Key;   // true is intercept key (dont show), false is show
                if (key != ConsoleKey.Enter)
                    Console.WriteLine();

            } while (key != ConsoleKey.S && key != ConsoleKey.N);

            if (key == ConsoleKey.S)
            {
                confirma = false;
                do
                {
                    Console.Write("Nome do amigo: ");
                    _nome = Console.ReadLine();

                    Console.Write("Digite a latitude em formato numérico.");
                    do
                    {
                        Console.Write("Latitude: ");

                    } while (!double.TryParse(Console.ReadLine(), out _latitude));

                    Console.Write("Digite a longitude em formato numérico.");
                    do
                    {
                        Console.Write("Longitude: ");

                    } while (!double.TryParse(Console.ReadLine(), out _longitude));

                    amigo = new Amigo();
                    amigo.Nome = _nome;
                    amigo.Latitude = _latitude;
                    amigo.Longitude = _longitude;

                    try
                    {
                        client.AdicionaAmigo(amigo).Wait();
                    }
                    catch (Exception ex)
                    {
                        Console.Write(string.Format("Ocorreu um erro ao tentar adicionar o amigo. Erro {0}.", ex.Message));
                    }


                    Console.Write("Deseja cadastrar um novo amigo? [s/n] ");
                    key = Console.ReadKey(false).Key;   // true is intercept key (dont show), false is show
                    if (key != ConsoleKey.Enter)
                        Console.WriteLine();

                    confirma = key == ConsoleKey.S;
                } while (confirma);

            }
            if (key == ConsoleKey.N)
            {
                confirma = false;

                do
                {
                    Console.Write("Deseja pesquisar os amigos mais próximos (através da latitude e longitude)? [s/n]");
                    key = Console.ReadKey(false).Key;   // true is intercept key (dont show), false is show
                    if (key != ConsoleKey.Enter)
                        Console.WriteLine();

                } while (key != ConsoleKey.S && key != ConsoleKey.N);

                if (key == ConsoleKey.S)
                {
                    ICollection<Amigo> amigos;

                    do
                    {
                        _nome = string.Empty;

                        Console.Write("Digite a latitude em formato numérico.");
                        do
                        {
                            Console.Write("Latitude: ");

                        } while (!double.TryParse(Console.ReadLine(), out _latitude));


                        Console.Write("Digite a longitude em formato numérico.");
                        do
                        {
                            Console.Write("Longitude: ");

                        } while (!double.TryParse(Console.ReadLine(), out _longitude));

                        amigo = new Amigo();
                        amigo.Latitude = _latitude;
                        amigo.Longitude = _longitude;



                        try
                        {
                            amigos = client.BuscaAmigos(amigo);
                            if (amigos != null)
                            {
                                if (amigos.Count == 0)
                                {
                                    Console.Write("Não há amigos cadastrados.");
                                }
                                else
                                {
                                    if (amigos.Count < _numeroAmigos)
                                    {
                                        Console.Write(string.Format("Não há {0} amigos próximos: \t", _numeroAmigos));
                                    }


                                    Console.Write(string.Format("Seus {0} amigos mais próximos são: \t", amigos.Count));
                                    foreach (var item in amigos)
                                    {
                                        Console.WriteLine("{0} - Distância: {1}\t", item.Nome, item.Distancia);
                                    }
                                }

                               
                            }



                        }
                        catch (Exception ex)
                        {
                            Console.Write(string.Format("Ocorreu um erro ao pesquisar amigos. Erro {0}.", ex.Message));
                        }


                        Console.Write("Deseja pesquisar novamente? [s/n] ");
                        key = Console.ReadKey(false).Key;   // true is intercept key (dont show), false is show
                        if (key != ConsoleKey.Enter)
                            Console.WriteLine();

                        confirma = key == ConsoleKey.S;
                    } while (confirma);
                }

            }

        }


    }
}
