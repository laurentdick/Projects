using System;
using System.Data;
using System.Data.Common;
using System.Configuration;

namespace TestGenericPersonne
{
    internal static class TestDbProviderFactory
    {
        public static void Test()
        {
            foreach (ConnectionStringSettings connectionString in ConfigurationManager.ConnectionStrings)
            {
                Console.WriteLine(connectionString.Name);
            }

            Console.WriteLine();

            foreach (DataRow row in DbProviderFactories.GetFactoryClasses().Rows)
            {
                foreach (object obj in row.ItemArray)
                {
                    Console.WriteLine(obj);
                }

                Console.WriteLine();
            }
        }
    }
}
