using System;
using System.Data.SqlClient;
using System.IO;

namespace _03.MinionNames
{
    public class StartUp
    {
        private const string ConnectionString = @"
            Server=DESKTOP-OSBRO1S\SQLEXPRESS; 
            Database=MinionsDB; 
            Integrated Security=true;";
        private const string SelectionQueryPath = @"D:\Георги\Software University\Database\Projects\DatabaseEntityFramework\IntroductionToDBAppsSQL\IntroductionToDBAppsSQL\03.GetMinionNames.sql";

        static void Main(string[] args)
        {
            Console.Write("Enter a Villain ID: ");
            int villainId = int.Parse(Console.ReadLine());


            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string cmdText = string.Format(File.ReadAllText(SelectionQueryPath), villainId);
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    command.Parameters.AddWithValue("@villainId", villainId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        ProcessSelection(reader, villainId);
                    }
                }
            }
        }

        private static void ProcessSelection(SqlDataReader reader, int villainId)
        {
            if (reader.HasRows)
            {
                reader.Read();
                Console.WriteLine($"Villain: {reader["VillainName"]}");
                if (reader.IsDBNull(1))
                {
                    Console.WriteLine("(no minions)");
                }
                else
                {
                    int minionNumber = 1;
                    while (true)
                    {
                        Console.WriteLine($"{minionNumber++}. {reader["MinionName"]} {reader["MinionAge"]}");
                        if (!reader.Read())
                        {
                            break;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine($"No villain with ID {villainId} exists in the database.");
            }
        }
    }
}
