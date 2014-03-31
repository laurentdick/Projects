using System;
using System.Data.Common;

namespace TestGenericPersonne
{
    internal static class TestOLE
    {
        delegate object GetterValue(int ordinal);

        private static void PrintValues(DbDataReader dbDataReader, GetterValue getter)
        {
            for (int i = 0; i < dbDataReader.FieldCount; i++)
            {
                Console.Write(getter(i));
                Console.Write('\t');
            }

            Console.WriteLine();
        }

        public static string GetCommand()
        {
            Console.Write("mysql> ");

            string command = Console.ReadLine().Trim();

            switch (command.ToUpper())
            {
                case "EXIT":
                case "QUIT":
                case "Q":
                case "X": command = null; break;
            }

            return command;
        }

        public static void Test()
        {
            // OLE Connections
            //string connectionString = @"Provider=MySqlProv; Location=192.168.23.128; Database=Papyrus; User ID=root; Password=";
            //string connectionString = @"Provider=MySQL Provider; Data Source=192.168.23.128; Initial Catalog=Papyrus; User ID=root; Password=; Activation=SKAR-TUB4-PR2A-WY9X";
            //string connectionString = @"Provider=SQLOLEDB; Data Source=(local)\SQLEXPRESS; Integrated Security=SSPI;Initial Catalog=Papyrus";
            //string connectionString = "Provider=PostgreSQL; Data Source=192.168.23.128; Location=Papyrus; User ID=postgres; Password=Cdi1234; Connect Timeout=3";

            // OBDC Connections
            //string connectionString = "Driver={PostgreSQL Unicode}; Server=192.168.23.128; Database=Papyrus; Uid=postgres; Pwd=Cdi1234";

            string connectionString = "Server=192.168.23.128; Database=Papyrus;  Uid=root; Pwd=";

            try
            {
                //DbProviderFactory dbProviderFactory = DbProviderFactories.GetFactory("System.Data.Odbc");
                //DbProviderFactory dbProviderFactory = DbProviderFactories.GetFactory("System.Data.OleDb");
                DbProviderFactory dbProviderFactory = DbProviderFactories.GetFactory("MySql.Data.MySqlClient");

                using (DbConnection dbConnection = dbProviderFactory.CreateConnection())
                {
                    dbConnection.ConnectionString = connectionString;
                    dbConnection.Open();

                    string command = null;
                    while ((command = GetCommand()) != null)
                    {
                        if (command != "")
                        {
                            try
                            {
                                DbCommand dbCommand = dbConnection.CreateCommand();
                                dbCommand.CommandText = command;
                                dbCommand.Connection = dbConnection;

                                using (DbDataReader dbDataReader = dbCommand.ExecuteReader())
                                {
                                    // Affiche le nom des colonnes
                                    PrintValues(dbDataReader, dbDataReader.GetName);

                                    while (dbDataReader.Read())
                                    {
                                        // Affiche les valeurs de la ligne de résultat
                                        PrintValues(dbDataReader, dbDataReader.GetValue);
                                    }
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
