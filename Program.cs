using System;
using System.Diagnostics;
using static System.Console;
using System.Text;
using System.IO;

namespace ConsoleCRUD
{
    class MainClass
    {
        public static void printMenu(String[] options)
        {
            foreach (String option in options)
            {
                WriteLine(option);
            }
            WriteLine("Escolha a sua opção:");
        }

        public static void Main(String[] args)
        {
            WriteLine(">>>> CADASTRO DE PESSOAS >>>>");
            String[] options = {"1 - Cadastrar",
                                "2 - Editar",
                                "3 - Excluir",
                                "4 - Listar",
                                "5 - Gravar",
                                "6 - Ler",
                                "7 - Sair"};
            int option = 0;
            while (true)
            {
                printMenu(options);
                try
                {
                    option = Convert.ToInt32(ReadLine());
                }
                catch (System.FormatException)
                {
                    WriteLine("Por favor, digite uma opção entre 1 e " + options.Length);
                    continue;
                }
                catch (Exception)
                {
                    WriteLine("Um erro aconteceu!");
                    continue;
                }
                switch (option)
                {
                    case 1:
                        Cadastrar();
                        break;
                    case 2:
                        Editar();
                        break;
                    case 3:
                        Excluir();
                        break;
                    case 4:
                        Listar();
                        break;
                    case 5:
                        Gravar();
                        break;
                    case 6:
                        Ler();
                        break;
                    case 7:
                        Environment.Exit(0);
                        break;
                    default:
                        WriteLine("Por favor, digite uma opção entre 1 e " + options.Length);
                        break;
                }
            }
        }

        
       

 static List<string> nomes = new List<string>();
        static List<string> cpfs = new List<string>();
        static List<string> cidades = new List<string>();

        private static void Cadastrar()
        {
            Console.Clear();
            Console.WriteLine(">>>> CADASTRO DE PESSOAS <<<<");
            Console.WriteLine();
            Console.WriteLine("Digite o nome da pessoa:");
            string nome = Console.ReadLine();
            var repetido = nomes.Any(x => x.Contains(nome));
            if (repetido)
            {
                Console.WriteLine("Esta pessoa já existe em nossa base de dados!\n");
                return;
            }
            else
            {
                nomes.Add(nome);
            }
            Console.WriteLine("Digite o CPF da pessoa:");
            string cpf = Console.ReadLine();
             var repetido2 = nomes.Any(x => x.Contains(nome));
            if (cpf.Length !=11 )
             {
                Console.WriteLine("O cpf deve conter 11 dígitos!\n");
                return;
            }
            else
            {
                cpfs.Add(cpf);
            }

            Console.WriteLine("Digite a Cidade da pessoa:");
            string cidade = Console.ReadLine();
            cidades.Add(cidade);
            Console.Clear();
        }

        private static void  Listar()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(">>>> LISTAGEM DAS PESSOAS <<<<");
            int pos = 0;
            foreach (var item in nomes)
            {
                Console.WriteLine($"Nome: {item}, CPF: {cpfs[pos]}, Cidade: {cidades[pos]}");
                pos++;
            }
            Console.WriteLine();
        }
        private static void Editar()
        {
            Clear();
            WriteLine();
            ForegroundColor = ConsoleColor.Green;
            WriteLine(">>>> EDIÇÃO DE PESSOAS <<<<");
            WriteLine();
            ResetColor();
            string nome = "";
            WriteLine("Digite o nome que você deseja editar:");
            nome = ReadLine();
            int index = nomes.IndexOf(nome);
            if (index >= 0)
            {
                WriteLine(">>>> REGISTRO QUE SERÁ EDITADO <<<<");
                WriteLine($"Nome: {nomes[index]}");
                WriteLine($"Idade: {cpfs[index]}");
                WriteLine();
                WriteLine("Digite o nome da pessoa:");
                nomes[index] = ReadLine();
                WriteLine("Digite o cpf da pessoa:");
                cpfs[index] = ReadLine();
                WriteLine();
                WriteLine("Pessoa editada com sucesso!");
            }
            else
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("Pessoa não encontrada!!!");
                ResetColor();
            }
            Clear();
        }

        private static void Excluir()
        {
            Clear();
            WriteLine();
            ForegroundColor = ConsoleColor.Green;
            WriteLine(">>>> EXCLUSÃO DE PESSOAS <<<<");
            WriteLine();
            ResetColor();
            string nome = "";
            WriteLine("Digite o nome que você deseja excluir:");
            nome = ReadLine();
            int index = nomes.IndexOf(nome);
            Clear();
            if (index >= 0)
            {
                WriteLine(">>>> REGISTRO QUE SERÁ EXCLUÍDO <<<<");
                WriteLine($"Nome: {nomes[index]}");
                WriteLine($"Idade: {cpfs[index]}");
                WriteLine();
                nomes.RemoveAt(index);
                cpfs.RemoveAt(index);
                WriteLine();
                WriteLine("Pessoa excluído com sucesso!");
            }
            else
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("Pessoa não encontrada!!!");
                ResetColor();
            }
        }

        private static void Gravar()
        {
            Clear();
            WriteLine();
            WriteLine(">>>> GRAVAR OS DADOS <<<<");
            try
            {
                StreamWriter dados;
                string arq = @"C:\coddee\dados.txt";
                dados = File.CreateText(arq);
                foreach (var item in nomes)
                {
                    dados.WriteLine($"{item}");
                }
                dados.Close();
                StreamWriter dados2;
                string arq2 = @"C:\coddee\dados2.txt";
                dados2 = File.CreateText(arq2);
                foreach (var item2 in cpfs)
                {
                    dados2.WriteLine($"{item2}");
                }
                dados2.Close();
                StreamWriter dados3;
                string arq3 = @"C:\coddee\dados3.txt";
                dados3 = File.CreateText(arq3);
                foreach (var item3 in cidades)
                {
                    dados3.WriteLine($"{item3}");
                }
                dados3.Close();
            }
            catch (Exception erro)
            {
                WriteLine(erro.Message);
            }
            finally
            {
                WriteLine("Dados gravados com sucesso!");
            }
        }

        private static void Ler()
        {
            Clear();
            WriteLine();
            WriteLine(">>>> LER O ARQUIVO <<<<");
            WriteLine();
            var nome = File.ReadAllLines(@"C:\coddee\dados.txt");
            for (int i = 0; i < nome.Length; i++)
            {
                nomes.Add(nome[i]);
            }
            var cpf = File.ReadAllLines(@"C:\coddee\dados2.txt");
            for (int x = 0; x < cpf.Length; x++)
            {
                cpfs.Add(cpf[x]);
            }
            var cidade = File.ReadAllLines(@"C:\coddee\dados3.txt");
            for (int y = 0; y < cpf.Length; y++)
            {
                cidades.Add(cidade[y]);
            }
            
            
            WriteLine();
            WriteLine("Leitura de dados concluída com sucesso!");
        }
    }
}