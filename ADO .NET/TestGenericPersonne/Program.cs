using System;

namespace TestGenericPersonne
{
    class Program
    {
        public delegate void Writer(string s);
        public static Writer WriteLine = (x) => { Console.WriteLine(x); };

        static void Main(string[] args)
        {

            //TestGenericVisitor.Test();
            TestGenericComposite.Test();
            //TestGenericSerializationXML.Test();
            //TestGenericState.Test();

            WriteLine("Fin du programme.");
            Console.Read();
        }
    }
}
