using System;

using PatternLibrary;

namespace TestGenericPersonne
{
    /// <summary>
    /// Classe de Composant
    /// </summary>
    class ConcreteComposant : Composant
    {
        protected override void DoOperation()
        {
            Console.Write("".PadLeft(depth * 2) + "\"{0}\"", Name);
        }
    }

    /// <summary>
    /// Classe Composite
    /// </summary>
    class ConcreteComposite : Composite
    {
        protected override void DoOperation()
        {
            Console.Write("".PadLeft(depth * 2) + "\"{0}\"", Name);
        }
    }

    /// <summary>
    /// Classe Visiteur du Composite
    /// </summary>
    class ConcreteCompositeVisitor : CompositeVisitor
    {
        public override void Visit(IElement element)
        {
            Console.WriteLine(
                //" visité par \"{0}\"", Name
            );
        }
    }

    /// <summary>
    /// Fonction de Test du Pattern Composite
    /// </summary>
    internal static class TestGenericComposite
    {
        public static void Test()
        {
            new Title("Test Generic Composite");

            Composite composite = new ConcreteComposite()
            {
                Name = "C:",
                SubComponents = new Composant[]
                {
                    new ConcreteComposite()
                    {
                        Name = "Program Files (x86)",
                        SubComponents = new Composant[]
                        {
                            new ConcreteComposant()   { Name = "Internet Explorer" },
                        }
                    },
                    new ConcreteComposite()
                    {
                        Name = "Program Files",
                        SubComponents = new Composant[]
                        {
                            new ConcreteComposant()   { Name = "Windows Defender" },
                            new ConcreteComposant()   { Name = "Windows NT" },
                        }
                    },
                    new ConcreteComposite()
                    {
                        Name = "Windows",
                        SubComponents = new Composant[]
                        {
                            new ConcreteComposant()   { Name = "System" },
                            new ConcreteComposant()   { Name = "System32" },
                            new ConcreteComposant()   { Name = "SysWOW64" },
                        }
                    },
                }
            };

            composite.Accept(new ConcreteCompositeVisitor() { Name = "Visiteur A" });

            new Title("Fin Test Generic Composite");
        }
    }
}
