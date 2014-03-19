using System;
using System.Reflection;
using System.Threading;

namespace PatternLibrary
{
    /// <summary>
    /// Exception
    /// </summary>
    public class ConstructorNotFoundException : Exception
    {
        private const string ConstructorNotFoundMessage = "Les types dérivés de Singleton<T> requièrent un constructeur par défaut non public.";

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        /// <param name="auxMessage"></param>
        public ConstructorNotFoundException() :
            base(ConstructorNotFoundMessage)
        {
        }
        
        public ConstructorNotFoundException(string auxMessage) :
            base(String.Format("{0} - {1}", ConstructorNotFoundMessage, auxMessage))
        {
        }
        
        public ConstructorNotFoundException(string auxMessage, Exception inner) :
            base(String.Format("{0} - {1}", ConstructorNotFoundMessage, auxMessage), inner)
        {
        }
    }

    /// <summary>
    /// Class générique d'un Singleton
    /// </summary>
    /// <typeparam name="TClass">Type du Singleton</typeparam>
    public abstract class GenericSingleton<TClass> where TClass : class
    {
        /// <summary>
        /// Instance unique du Singleton
        /// </summary>
        private static readonly Lazy<TClass> _instance = new Lazy<TClass>(() =>
        {
            // Get non-public constructors for T.
            var ctors = typeof(TClass).GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic);

            // If we can't find the right type of construcor, throw an exception.
            if (!Array.Exists(ctors, (ci) => ci.GetParameters().Length == 0))
            {
                throw new ConstructorNotFoundException("Non-public ctor() not found.");
            }

            // Get reference to default non-public constructor.
            var ctor = Array.Find(ctors, (ci) => ci.GetParameters().Length == 0);

            // Invoke constructor and return resulting object.
            return ctor.Invoke(new object[] { }) as TClass;
        }, LazyThreadSafetyMode.ExecutionAndPublication);

        /// <summary>
        /// Constructeur statique
        /// </summary>
        static GenericSingleton()
        {
        }

        /// <summary>
        /// Accesseur public statique de récupération de l'instance unique
        /// </summary>
        /// <returns></returns>
        public static TClass Instance
        {
            get
            {
                return _instance.Value;
            }
        }
    }
}

