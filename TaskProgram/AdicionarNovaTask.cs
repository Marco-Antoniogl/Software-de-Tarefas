using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProgram
{
    public class AdicionarNovaTask
    {
        public static void OpcaoAdicionarNovaTask(string username)
        {
            string departamento;
            Console.WriteLine("Bem vindo a opcao adicionar nova task.");
            /*departamento = Console.ReadLine();
            if(departamento == "1" || departamento == "2" || departamento == "3" || departamento == "4" || departamento == "5")
            {
                CadastroAdicionarNovaTask(departamento);
            }
            else
            {
                Console.WriteLine("Escolha uma opção valida.");
            }
            */
        }

        public class AdicicionarNoBancoDeDados
        {
            private readonly string connectionString;
            public AdicicionarNoBancoDeDados(string connectionString)
            {
                this.connectionString = connectionString;
            }

            public void InserirAsTarefas(string departamento, string descricacao, string data) // Corrigir a opcao stringa para date
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO task (departamento, descricacao, data) VALUES (@departamento, @descricacao, @data)"; //se nada for adicionado o problema segue na conexão ou add no banco de dados.
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("departamento", departamento);
                    command.Parameters.AddWithValue("descricacao", descricacao);
                    command.Parameters.AddWithValue("data", data);
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void CadastroAdicionarNovaTask(string username)
        {
            try
            {
                string departamento, descricacao, data;

                while (true) { 
                    Console.WriteLine("Escolha o departamento para adicionar a task:\n 1 - Financeiro\n 2 - Departamento Pessoal\n 3 - Recursos Humanos\n 4 - Administrativo: ");
                    departamento = Console.ReadLine();

                    if (departamento == "1" || departamento == "2" || departamento == "3" || departamento == "4" || departamento == "5")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Opção invalida, escolha uma opção valida");
                    }
                }

                Console.WriteLine("Escreva a descricao da task a ser realizada: ");
                descricacao = Console.ReadLine();
                while (true)
                {
                    Console.WriteLine("Escolha a data a se adicionado (no formato dd/mm/aaaa): ");
                    data = Console.ReadLine();

                    if (DateTime.TryParseExact(data, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out _))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Formato de data inválido, inserir no formato dd/mm/aaaa "); 
                    }
                }

                string connectionString = "Data Source=DESKTOP-0J2H3A3;Initial Catalog=master;Integrated Security=SSPI;TrustServerCertificate=True";

                AdicicionarNoBancoDeDados AddBD = new AdicicionarNoBancoDeDados(connectionString);
                AddBD.InserirAsTarefas(departamento, descricacao, data);

                Console.WriteLine("Tarefa adicionada com sucesso.");

            }

            catch(Exception ex)
            {
                Console.Write($"Ocorreu um erro ao adicionar a task ao banco de dados.: {ex.Message}");
            }

        }
    }
}
