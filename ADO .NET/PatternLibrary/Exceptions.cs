using System;

namespace PatternLibrary
{
    /// <summary>
    /// Exception de la classe Singleton
    /// </summary>
    public class ConstructorNotFoundException : Exception
    {
        private const string ConstructorNotFoundMessage =
            "Les types dérivés de Singleton<T> requièrent un constructeur par défaut non public.";

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        /// <param name="auxMessage"></param>
        public ConstructorNotFoundException() :
            base(ConstructorNotFoundMessage)
        {
        }

        /// <summary>
        /// Constructeur paramétré
        /// </summary>
        /// <param name="auxMessage"></param>
        public ConstructorNotFoundException(string auxMessage) :
            base(String.Format("{0} - {1}", ConstructorNotFoundMessage, auxMessage))
        {
        }

        /// <summary>
        /// Constructeur paramétré
        /// </summary>
        /// <param name="auxMessage"></param>
        /// <param name="inner"></param>
        public ConstructorNotFoundException(string auxMessage, Exception inner) :
            base(String.Format("{0} - {1}", ConstructorNotFoundMessage, auxMessage), inner)
        {
        }
    }

}
