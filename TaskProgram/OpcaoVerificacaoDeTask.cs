using Microsoft.Data.SqlClient;
using System;

namespace TaskProgram
{
    public class ClassOpcaoVerificaoDetask
    {
        public static void OpcaoVerificacaoDeTask(string username)
        {
            string departamento;
            Console.WriteLine("Escolha o Departamento:\n 1 - Financeiro\n 2 - Departamento Pessoal\n 3 - Recursos Humanos\n 4 - Administrativo\n 5 - Voltar");
            departamento = Console.ReadLine();

            ConsultarTarefaPorDepartamento(departamento);
        }


        public static void ConsultarTarefaPorDepartamento(string departamento)
        {
            string connectionString = "Data Source=DESKTOP-0J2H3A3;Initial Catalog=master;Integrated Security=SSPI;TrustServerCertificate=True";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT id, descricacao, data FROM task WHERE departamento = @departamento";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@departamento", departamento);

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                string descricacao = reader.GetString(1);
                                DateTime data = reader.GetDateTime(2);

                                Console.WriteLine($"ID: {id}, Descrição: {descricacao}, Data: {data}");
                            }
                        }
                    }
                }
            }
            
            catch(Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro ao consultar tarefas por departamento: {ex.Message}");
            }
        }
    }
}
