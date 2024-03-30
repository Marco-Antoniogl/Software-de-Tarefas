using System.Configuration;
using Microsoft.Data.SqlClient;


namespace TaskProgram
{
    internal class Program
    {
        
        public static string username, password;
        static void Main(string[] args)
        {
            Login(username, password);
        }

        public static void DigitarDadosParaLogin(ref string username, ref string password)
        {
            Console.WriteLine("Nome: ");
            username = Console.ReadLine();

            Console.WriteLine("Senha: ");
            password = Console.ReadLine();
        }

        public static void Login(string username, string password)
        {
            DigitarDadosParaLogin(ref username, ref password);

            string connectionString = "Data Source=DESKTOP-0J2H3A3;Initial Catalog=master;Integrated Security=SSPI;TrustServerCertificate=True";


            using(SqlConnection connection = new SqlConnection(connectionString))
            {

                string query = "SELECT COUNT(*) FROM usuarios WHERE userName = @username AND password = @password";
                using(SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("username", username);
                    command.Parameters.AddWithValue("password", password);

                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    connection.Close();

                    if (count > 0)
                    {
                        Console.WriteLine("Usuário Autenticado com sucesso!");
                        MenuInicial(username);
                    }

                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Nome de usuário ou senha incorretos.");
                        Login(username, password);
                    }
                }
            }
        }
        public static void MenuInicial(string username)
        {
            Console.Clear();
            Console.WriteLine(value: $"Bem vindo ao menu {username}, escolha uma das opções!");
            Console.WriteLine("1 - Verificar task \n 2 - Adicionar nova task \n 3 - Sai");
            int NumeroEscolha = int.Parse(Console.ReadLine());

            if (NumeroEscolha == 1)
            {
                Console.WriteLine("Você Escolheu a opção verificar task.");
                ClassOpcaoVerificaoDetask.OpcaoVerificacaoDeTask(username);
            }

            if (NumeroEscolha == 2)
            {
                Console.WriteLine("Você Escolheu a opção adicionar nova task.");
                AdicionarNovaTask.CadastroAdicionarNovaTask(username);
            }
            else
            {
                Console.WriteLine("fechar?");
            }
        }
    }
}
