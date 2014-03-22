
namespace ClassMetierLibrary
{
    /// <summary>
    /// Représentation d'une personne
    /// </summary>
    public class Personne
    {
        /// <summary>
        /// Enumération des Genres
        /// </summary>
        public enum TypePersonne { Mr = 1, Mme, Mlle };

        /// <summary>
        /// Genre de la personne
        /// </summary>
        public TypePersonne Genre { get; set; }

        /// <summary>
        /// Nom
        /// </summary>
        public string Nom { get; set; }

        /// <summary>
        /// Prénom
        /// </summary>
        public string Prenom { get; set; }

        /// <summary>
        /// Adresse
        /// </summary>
        public string Adresse { get; set; }

        /// <summary>
        /// Code Postal de résidence
        /// </summary>
        public string CodePostal { get; set; }

        /// <summary>
        /// Ville de résidence
        /// </summary>
        public string Ville { get; set; }

        /// <summary>
        /// Numéro de Téléphone
        /// </summary>
        public string NumTelephone { get; set; }

        /// <summary>
        /// Email de contact
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Personne()
        {
        }
    }
}
