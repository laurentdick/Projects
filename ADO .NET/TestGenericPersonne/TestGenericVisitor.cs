using System;
using System.Collections;

using PatternLibrary;

namespace TestGenericPersonne
{
    class ConcreteElement : IElement
    {
        public string Name { get; set; }

        public void Accept(IVisitor visitor)
        {
        }
    }

    class ConcreteVisitor : IVisitor
    {
        public string Name { get; set; }

        public void Visit(IElement element)
        {
            Console.WriteLine("{0} visited by {1}", (element as ConcreteElement).Name, Name);
        }
    }

    public class ObjectStructure : IElement
    {
        protected IList elements;

        public string Name { get; set; }

        public ObjectStructure()
        {
            elements = new ArrayList();
        }

        public ObjectStructure(params IElement[] elements)
        {
            this.elements = elements;
        }

        public void Attach(IElement element)
        {
            this.elements.Add(element);
        }

        public void Attach(params IElement[] elements)
        {
            foreach (IElement element in elements)
            {
                Attach(element);
            }
        }

        public void Detach(IElement element)
        {
            this.elements.Remove(element);
        }

        public void Detach(params IElement[] elements)
        {
            foreach (IElement element in elements)
            {
                Detach(element);
            }
        }

        public virtual void Accept(IVisitor visitor)
        {
            foreach (IElement element in elements)
            {
                element.Accept(visitor);
            }
        }

        public virtual void Accept(params IVisitor[] visitors)
        {
            foreach (IVisitor visitor in visitors)
            {
                Accept(visitor);
            }
        }
    }

    /// <summary>
    /// Fonction de Test du Pattern Visiteur
    /// </summary>
    internal static class TestGenericVisitor
    {
        public static void Test()
        {
            new Title("Test Generic Visitor");

            ObjectStructure o = new ObjectStructure(
                new ConcreteElement() { Name = "ConcreteElementA" },
                new ConcreteElement() { Name = "ConcreteElementB" },
                new ConcreteElement() { Name = "ConcreteElementC" }
            );

            o.Accept(
                new ConcreteVisitor() { Name = "ConcreteVisitorA" },
                new ConcreteVisitor() { Name = "ConcreteVisitorB" }
            );

            new Title("Fin Test Generic Visitor");
        }
    }
}
