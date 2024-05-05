using Microsoft.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace TaskProgram
{
    public class OpcaoRelatorio
    {
        
        public static void RelatorioMetodos()
        {
            Console.WriteLine("Escolha a opção de relatorio: \n 1 - Relatorio por tarefa concluida. \n 2 - Relatorio por Tarefa em aberto. \n 3 - Relatorio total por departamento \n 4 - Sair  ");
            int respostaRelatorio = int.Parse(Console.ReadLine());
            string connectionString = "Data Source=DESKTOP-0J2H3A3;Initial Catalog=master;Integrated Security=SSPI;TrustServerCertificate=True";

            using (SqlConnection connection = new SqlConnection(connectionString)) 
            {
                if (respostaRelatorio == 1)
                {
                    RelatorioTaskConcluidas();
                }
                if (respostaRelatorio == 2)
                {
                    RelatorioTaskEmAbertos();
                }
                if (respostaRelatorio == 3)
                {
                    RelatorioTaskTotalPorDepartamento();
                }
                else
                {

                }
            }
        }

        public static void RelatorioTaskConcluidas()
        {
            Console.WriteLine("Você escolheu a opção relatorio de tarefas concluidas.");

            // AINDA NÃO TEM A OPÇÃO CONCLUIR TAREFA NO PROJETO
        }

        public static void RelatorioTaskEmAbertos()
        {
            Console.WriteLine("Você escolheu a opção relatorio de tarefas em aberto.");
        }

        public static void RelatorioTaskTotalPorDepartamento()
        {
            Console.WriteLine("Você escolheu a opção relatorio de tarefas total por departamento.");
        }
    }
}
