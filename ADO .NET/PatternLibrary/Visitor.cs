
namespace PatternLibrary
{
    /// <summary>
    /// Interface Element à visiter
    /// </summary>
    public interface IElement
    {
        string Name { get; }

        void Accept(IVisitor visitor);
    }

    /// <summary>
    /// Interface du Visiteur d'élément
    /// </summary>
    public interface IVisitor
    {
        string Name { get; }

        void Visit(IElement element);
    }
}
