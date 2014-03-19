
namespace PatternLibrary
{
    /// <summary>
    /// Interface Element à visiter
    /// </summary>
    public interface IElement
    {
        void Accept(IVisitor visitor);
    }

    /// <summary>
    /// Interface du Visiteur d'élément
    /// </summary>
    public interface IVisitor
    {
        void Visit(IElement element);
    }

    /// <summary>
    /// Classe Abstraite d'un élément à visiter
    /// </summary>
    public abstract class Element : IElement
    {
        public virtual void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
