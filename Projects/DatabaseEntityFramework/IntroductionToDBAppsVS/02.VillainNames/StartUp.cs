using System;
using System.Data.SqlClient;
using System.IO;

namespace _02.VillainNames
{
    public class StartUp
    {
        private const string ConnectionString = @"
            Server=DESKTOP-OSBRO1S\SQLEXPRESS; 
            Database=MinionsDB; 
            Integrated Security=true;";

        static void Main(string[] args)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string cmdText = File.ReadAllText(@"D:\Георги\Software University\Database\Projects\DatabaseEntityFramework\IntroductionToDBAppsSQL\IntroductionToDBAppsSQL\02.MinionsPerVillain.sql");
                using(SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                Console.Write($"{reader.GetName(i),-20}");
                            }
                            Console.WriteLine();
                            while (reader.Read())
                            {
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    Console.Write($"{reader[i],-20}");
                                }
                                Console.WriteLine();
                            }
                        }
                    }
                }
            }
        }
    }
}
