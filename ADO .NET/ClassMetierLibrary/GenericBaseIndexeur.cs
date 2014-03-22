using System;
using System.Collections;
using System.Collections.Generic;

namespace ClassMetierLibrary
{
    /// <summary>
    /// Classe générique de Dictionaire
    /// </summary>
    public class GenericBaseIndexeur<T, V> : IEnumerable<KeyValuePair<T, V>>, IEnumerable
    {
        /// <summary>
        /// Dictionnaire interne
        /// </summary>
        internal IDictionary<T, V> dictionnary;

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        protected GenericBaseIndexeur()
        {
            dictionnary = new Dictionary<T, V>();
        }

        /// <summary>
        /// Constructeur Paramétré
        /// </summary>
        /// <param name="keys"></param>
        public GenericBaseIndexeur(T[] keys) : this()
        {
            foreach (T key in keys)
            {
                Add(key, default(V));
            }
        }

        /// <summary>
        /// Ajoute une paire clé, valeur dans le dictionnaire
        /// Vérifie que la clé n'est pas déjà dans le dictionnaire
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        protected void Add(T key, V value)
        {
            if (!dictionnary.ContainsKey(key))
            {
                dictionnary.Add(key, value);
            }
            else
                throw new Exception("Key is not available.");
        }

        /// <summary>
        /// Indexeur
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public virtual V this [T key]
        {
            get
            {
                V value = default(V);

                if (dictionnary.ContainsKey(key))
                {
                    value = dictionnary[key];
                }
                else
                    throw new KeyNotFoundException();

                return value;
            }

            set
            {
                if (dictionnary.ContainsKey(key))
                {
                    dictionnary[key] = value;
                }
                else
                    throw new KeyNotFoundException();
            }
        }


        /// <summary>
        /// Renvoi un itérateur sur l'objet T
        /// </summary>
        /// <returns></returns>
        public IEnumerator<KeyValuePair<T, V>> GetEnumerator()
        {
            return dictionnary.GetEnumerator();
        }

        /// <summary>
        /// Implémentation de l'interface IEnumerable
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
