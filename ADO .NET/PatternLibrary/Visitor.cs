
namespace PatternLibrary
{
    /// <summary>
    /// Interface de classe avec propriété Name
    /// </summary>
    public interface IName
    {
        string Name { get; }
    }

    /// <summary>
    /// Interface Element à visiter
    /// </summary>
    public interface IElement : IName
    {
        void Accept(IVisitor visitor);
    }

    /// <summary>
    /// Interface du Visiteur d'élément
    /// </summary>
    public interface IVisitor: IName
    {
        void Visit(IElement element);
    }
}
