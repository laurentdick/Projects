using System;
using System.Data.Common;
using System.Configuration;

namespace GenericSQL
{
    class SqlCommand
    {
        static void Main(string[] args)
        {
            string factory = null;
            string connectionString = null;
            DbProviderFactory connecteur = null;

            if (args.Length != 2)
            {
                Console.WriteLine("Syntaxe : GenericSQL factory connectionString");
                return;
            }

            try
            {
                factory = ConfigurationManager.AppSettings[args[0]];
                connecteur = DbProviderFactories.GetFactory(factory);
                connectionString = ConfigurationManager.ConnectionStrings[args[1]].ConnectionString;
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur de configuration: " + e.Message);
            }

            Console.WriteLine("Chaîne de connexion à la base : [{0}]", connectionString);
            Console.WriteLine("Provider factory : [{0}]", factory);

            DbConnectionStringBuilder builder = new DbConnectionStringBuilder();
            builder.ConnectionString = connectionString;

            foreach (string key in builder.Keys)
            {
                Console.WriteLine(key + " => " + builder[key]);
            }

            bool doExit= false;
            do
            {
                Console.Write(Environment.NewLine + "sql > ");
                string request = Console.ReadLine().Trim();

                if ((request.ToLower() == "quit") ||
                    (request.ToLower() == "exit") ||
                    (request.ToLower() == "bye"))
                {
                    doExit = !doExit;
                }
                else if (request.Length > 0)
                {
                    ExecuteSelect(connecteur, connectionString, request);
                }
            }
            while (!doExit);

            Console.WriteLine("Fin du programme.");
            Console.Read();
        }

        static void ExecuteSelect(DbProviderFactory connecteur, string connectionString, string request)
        {
            // on gère les éventuelles exceptions
            try
            {
                using (DbConnection connexion = connecteur.CreateConnection())
                {
                    // configuration connexion
                    connexion.ConnectionString = connectionString;

                    // ouverture connexion
                    connexion.Open();

                    // configuration Command
                    DbCommand sqlCommand = connecteur.CreateCommand();
                    sqlCommand.CommandText = request;
                    sqlCommand.Connection = connexion;

                    // exécution requête
                    DbDataReader reader = sqlCommand.ExecuteReader();

                    // affichage des résultats
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.Write(reader.GetName(i).PadRight(20));
                    }

                    Console.WriteLine();

                    int rows = 0;
                    while (reader.Read())
                    {
                        rows++;
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            Console.Write(reader.GetValue(i).ToString().PadRight(20).Remove(19).PadRight(20));
                        }

                        Console.WriteLine();
                    }

                    Console.WriteLine(Environment.NewLine + "Command OK. {0} row(s) affected", rows);
                }
            }
            catch (Exception ex)
            {
                // msg d'erreur
                Console.WriteLine("Erreur d'accès à la base de données (" + ex.Message + ")");
            }
        }
    }
}
