using System;
using System.Reflection;
using System.Threading;

namespace PatternLibrary
{
    /// <summary>
    /// Class générique d'un Singleton
    /// </summary>
    /// <typeparam name="TClass">Type du Singleton</typeparam>
    public abstract class GenericSingleton<TClass>
        where TClass : class
    {
        /// <summary>
        /// Instance unique du Singleton
        /// </summary>
        private static readonly Lazy<TClass> _instance =
            new Lazy<TClass>(() =>
            {
                // Get non-public constructors for T.
                ConstructorInfo[] ctors = typeof(TClass).GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic);

                // If we can't find the right type of construcor, throw an exception.
                if (!Array.Exists(ctors, (ci) => ci.GetParameters().Length == 0))
                {
                    throw new ConstructorNotFoundException("Non-public ctor() not found.");
                }

                // Get reference to default non-public constructor.
                ConstructorInfo ctor = Array.Find(ctors, (ci) => ci.GetParameters().Length == 0);

                // Invoke constructor and return resulting object.
                return ctor.Invoke(new object[] { }) as TClass;
            }, LazyThreadSafetyMode.ExecutionAndPublication);

        /// <summary>
        /// Constructeur static
        /// </summary>
        static GenericSingleton()
        {
        }

        /// <summary>
        /// Accesseur public static de récupération de l'instance unique
        /// </summary>
        /// <returns></returns>
        public static TClass Instance
        {
            get { return _instance.Value; }
        }
    }
}

