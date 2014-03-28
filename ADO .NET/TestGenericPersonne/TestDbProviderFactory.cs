using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace TestGenericPersonne
{
    internal static class TestDbProviderFactory
    {
        [DllImport("odbccp32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern bool SQLGetInstalledDriversW(char[] lpszBuf, ushort cbufMax, out ushort pcbBufOut);

        /// <summary>
        /// Gets the ODBC driver names from the SQLGetInstalledDrivers function.
        /// </summary>
        /// <returns>a string array containing the ODBC driver names, if the call to SQLGetInstalledDrivers was successfull; null, otherwise.</returns>
        public static string[] GetOdbcDriverNames()
        {
            string[] odbcDriverNames = null;
            char[] driverNamesBuffer = new char[ushort.MaxValue];
            ushort size;

            bool succeeded = SQLGetInstalledDriversW(driverNamesBuffer, ushort.MaxValue, out size);

            if (succeeded == true)
            {
                char[] driverNames = new char[size - 1];
                Array.Copy(driverNamesBuffer, driverNames, size - 1);
                odbcDriverNames = (new string(driverNames)).Split('\0');
            }

            return odbcDriverNames;
        }

        /// <summary>
        /// Gets the name of an ODBC driver for Microsoft SQL Server giving preference to the most recent one.
        /// </summary>
        /// <returns>the name of an ODBC driver for Microsoft SQL Server, if one is present; null, otherwise.</returns>
        public static string GetOdbcSqlDriverName()
        {
            List<string> driverPrecedence = new List<string>() { "SQL Server Native Client 11.0", "SQL Server Native Client 10.0", "SQL Server Native Client 9.0", "SQL Server" };
            string[] availableOdbcDrivers = GetOdbcDriverNames();
            string driverName = null;

            if (availableOdbcDrivers != null)
            {
//                driverName = driverPrecedence.Intersect(availableOdbcDrivers).FirstOrDefault();
            }

            return driverName;
        }
        
        public static void Test()
        {
            foreach (string driverName in GetOdbcDriverNames())
            {
                Console.WriteLine(driverName);
            }

            Console.WriteLine();

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
