using System.Collections.Generic;

namespace PatternLibrary
{
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
        /// Nom du Composant
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Méthode d'appel du Visiteur
        /// </summary>
        /// <param name="visitor"></param>
        public virtual void Accept(IVisitor visitor)
        {
            DoOperation();
            visitor.Visit(this);
        }

        /// <summary>
        /// Méthode abstraite à personnaliser d'un Composant
        /// </summary>
        protected abstract void DoOperation();
    }

    /// <summary>
    /// Classe abstraite d'un Elément Composite
    /// </summary>
    public abstract class Composite : Composant
    {
        /// <summary>
        /// Liste des Composants du Pattern Composite
        /// </summary>
        private IList<IElement> elements = new List<IElement>();

        /// <summary>
        /// Accesseur de la liste des Composants
        /// </summary>
        public IList<IElement> SubComponents
        {
            get { return elements; }
            set { elements = value; }
        }

        /// <summary>
        /// Méthode exécutée par le Pattern Visiteur
        /// </summary>
        /// <param name="visitor"></param>
        public override void Accept(IVisitor visitor)
        {
            base.Accept(visitor);

            depth++;

            foreach (IElement element in elements)
            {
                element.Accept(visitor);
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
