using System;

using PatternLibrary;

namespace TestGenericPersonne
{
    /// <summary>
    /// Class concrète de Composant
    /// </summary>
    class ConcreteComposant : Composant
    {
    }

    /// <summary>
    /// Class concrète de Composite
    /// </summary>
    class ConcreteComposite : Composite
    {
    }

    /// <summary>
    /// Classe concrète de Visiteur de Composite
    /// </summary>
    class ConcreteCompositeVisitor : CompositeVisitor
    {
        /// <summary>
        /// Méthode appelée à chaque visite d'un Composant
        /// </summary>
        /// <param name="element"></param>
        public override void Visit(IElement element)
        {
            Console.WriteLine("".PadLeft((element as Composant).Depth * 2) + "\"{0}\"", element.Name);
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

            IElement rootElement = new ConcreteComposite()
            {
                Name = "C:",
                SubComponents = new IElement[]
                {
                    new ConcreteComposite()
                    {
                        Name = "Program Files (x86)",
                        SubComponents = new IElement[]
                        {
                            new ConcreteComposant()   { Name = "Internet Explorer" },
                        },
                    },
                    new ConcreteComposite()
                    {
                        Name = "Program Files",
                        SubComponents = new IElement[]
                        {
                            new ConcreteComposant()   { Name = "Windows Defender" },
                            new ConcreteComposant()   { Name = "Windows NT" },
                        },
                    },
                    new ConcreteComposite()
                    {
                        Name = "Windows",
                        SubComponents = new IElement[]
                        {
                            new ConcreteComposite()
                            {
                                Name = "System",
                                SubComponents = new IElement[]
                                {
                                    new ConcreteComposite()   {
                                        Name = "Drivers",
                                        SubComponents = new IElement[]
                                        {
                                            new ConcreteComposite()   { Name = "Etc" },
                                        },
                                    },
                                },
                            },
                            new ConcreteComposant()   { Name = "System32" },
                            new ConcreteComposant()   { Name = "SysWOW64" },
                        },
                    },
                },
            };

            rootElement.Accept(new ConcreteCompositeVisitor() { Name = "Visiteur A" });

            new Title("Fin Test Generic Composite");
        }
    }
}
