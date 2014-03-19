
namespace ClassMetierLibrary
{
    /// <summary>
    /// Classe générique représentant une Personne
    /// </summary>
    public class GenericPersonne : GenericBaseIndexeur<object, object>
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        public GenericPersonne()
            : base(new object[] { "Nom", "Prénom", "Adresse", "Code Postal", "Ville", "Téléphone", "e-mail" })
        {
        }
    }
}
