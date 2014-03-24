using System.Collections.Generic;

namespace PatternLibrary
{
    public interface IComposantInfo : IName
    {
        int Depth { get; }
    }

    public class ComposantInfo : IComposantInfo
    {
        public int Depth { get; private set; }
        public string Name { get; private set; }

        public ComposantInfo(Composant composant)
        {
            Name = composant.Name;
            Depth = composant.Depth;
        }
    }

    /// <summary>
    /// Classe de paramètres du gestionnaire d'évènement
    /// </summary>
    public class VisitedEventArgs
    {
        public IComposantInfo ComposantInfo { get; private set; }
        public IVisitor Visitor { get; private set; }

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        /// <param name="composant"></param>
        /// <param name="visitor"></param>
        public VisitedEventArgs(Composant composant, IVisitor visitor)
        {
            ComposantInfo = new ComposantInfo(composant);
            Visitor = visitor;
        }
    }

    /// <summary>
    /// Signature du délégué du gestionnaire d'évènement
    /// </summary>
    /// <param name="element"></param>
    /// <param name="visitor"></param>
    public delegate void VisitedEventHandler(VisitedEventArgs e);

    /// <summary>
    /// Classe abstraite d'un Elément Composant
    /// </summary>
    public abstract class Composant : IElement
    {
        /// <summary>
        /// Profondeur d'imbrication du Composant dans la hiérarchie du Composite
        /// </summary>
        protected static int depth = 0;

        /// <summary>
        /// Accesseur de champ profondeur d'imbrication de l'élément
        /// </summary>
        public int Depth { get { return depth; } private set { depth = value; } }

        /// <summary>
        /// Nom du Composant
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gestionnaire d'évènement
        /// </summary>
        public event VisitedEventHandler OnVisitedEventHandler;

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Composant()
        {
        }

        /// <summary>
        /// Constructeur paramétré
        /// </summary>
        /// <param name="handler"></param>
        public Composant(VisitedEventHandler handler)
        {
            OnVisitedEventHandler += handler;
        }

        /// <summary>
        /// Méthode d'appel du Visiteur
        /// </summary>
        /// <param name="visitor"></param>
        public virtual void Accept(IVisitor visitor)
        {
            OnVisited(visitor);
            visitor.Visit(this);
        }

        /// <summary>
        /// Méthode virtuelle de visite d'un Composant
        /// </summary>
        protected virtual void OnVisited(IVisitor visitor)
        {
            if (OnVisitedEventHandler != null)
            {
                OnVisitedEventHandler(new VisitedEventArgs(this, visitor));
            }
        }
    }

    /// <summary>
    /// Classe abstraite d'un Elément Composite
    /// </summary>
    public abstract class Composite : Composant
    {
        /// <summary>
        /// Liste des Composants du Pattern Composite
        /// </summary>
        private IList<IElement> elements;

        /// <summary>
        /// Accesseur de la liste des Composants
        /// </summary>
        public IList<IElement> SubComponents
        {
            get { return elements; }
            set { elements = value; }
        }

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Composite()
            : this(null)
        {
        }

        /// <summary>
        /// Constructeur paramétré
        /// </summary>
        /// <param name="handler"></param>
        public Composite(VisitedEventHandler handler)
            : base(handler)
        {
            elements = new List<IElement>();
        }

        /// <summary>
        /// Méthode exécutée par le Pattern Visiteur
        /// </summary>
        /// <param name="visitor"></param>
        public override void Accept(IVisitor visitor)
        {
            base.Accept(visitor);

            depth++;

            if (elements != null)
            {
                foreach (IElement element in elements)
                {
                    element.Accept(visitor);
                }
            }

            depth--;
        }
    }

    /// <summary>
    /// Classe abstraite de support pour le Pattern Visiteur sur le Composite
    /// </summary>
    public abstract class CompositeVisitor : IVisitor
    {
        /// <summary>
        /// Nom de l'instance
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Méthode visitant un Composant du Composite
        /// </summary>
        /// <param name="element"></param>
        public abstract void Visit(IElement element);
    }
}
