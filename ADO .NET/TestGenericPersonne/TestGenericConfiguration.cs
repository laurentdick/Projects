using System;
using System.Collections;
using System.Collections.Generic;

using PatternLibrary;

namespace TestGenericPersonne
{
    public class Configuration : GenericSingleton<Configuration>, IEnumerable
    {
        /// <summary>
        /// Dictionnaire interne
        /// </summary>
        private static Dictionary<string, object> _keyWords;

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        private Configuration()
        {
            _keyWords = new Dictionary<string, object>();
        }

        /// <summary>
        /// Retourne un Enumérateur sur le Dictionnaire interne
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            return _keyWords.GetEnumerator();
        }

        /// <summary>
        /// Accesseur Clé/Valeur
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public object this[string key]
        {
            get
            {
                return _keyWords[key];
            }
            set
            {
                _keyWords[key] = value;
            }
        }
    }

    /// <summary>
    /// Fonction de Test de la Classe Générique Configuration
    /// </summary>
    internal static class TestGenericConfiguration
    {
        public static void Test()
        {
            new Title("Test Generic Configuration");

            Configuration.Instance["Nom"] = "DICK";
            Configuration.Instance["Prénom"] = "Laurent";
            Configuration.Instance["Code Postal"] = 57580;

            foreach (KeyValuePair<string, object> keyValue in Configuration.Instance)
            {
                Console.WriteLine("{0} = {1}", keyValue.Key, keyValue.Value);
            }

            new Title("Fin Test Generic Configuration");
        }
    }
}
