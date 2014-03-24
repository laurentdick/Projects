
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


    /// <summary>
    /// Version générique de l'Interface Element à visiter
    /// </summary>
    public interface IElement<IComposant> : IName where IComposant : class
    {
        void Accept(IVisitor<IComposant> visitor);
    }

    /// <summary>
    /// Version générique de l'Interface du Visiteur d'élément
    /// </summary>
    public interface IVisitor<IComposant> : IName where IComposant : class
    {
        void Visit(IElement<IComposant> element);
    }
}
