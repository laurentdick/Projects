using System.Collections.Generic;
using System.Data;

namespace ClassMetierLibrary
{
    public class GenericFournisseur : GenericBaseIndexeur<object, object>
    {
        public GenericFournisseur(DataTable table)
        {
            foreach (DataColumn column in table.Columns)
            {
                base.Add(column.ColumnName, table.Rows[0][column.ColumnName]);
            }
        }
    }

    /// <summary>
    /// Représentation d'un enregistrement d'un Fournisseur en base de données
    /// </summary>
    public class Fournisseur
    {
        /// <summary>
        /// Numéro de Fournisseur
        /// </summary>
        public string NumFou        { get; set; }

        /// <summary>
        /// Nom du Fournisseur
        /// </summary>
        public string NomFou        { get; set; }
        
        /// <summary>
        /// Adresse du Fournisseur
        /// </summary>
        public string RueFou        { get; set; }
        
        /// <summary>
        /// Code Postal Fournisseur
        /// </summary>
        public string PosFou        { get; set; }
        
        /// <summary>
        /// Ville Fournisseur
        /// </summary>
        public string VilFou        { get; set; }
        
        /// <summary>
        /// Contact Fournisseur
        /// </summary>
        public string ConFou        { get; set; }
        
        /// <summary>
        /// Côte Satisfaction Fournisseur
        /// </summary>
        public string Satisf        { get; set; }

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Fournisseur()
        {
        }

        /// <summary>
        /// Constructeur paramétré
        /// </summary>
        /// <param name="values"></param>
        public Fournisseur(Dictionary<string, object> values)
        {
            foreach (KeyValuePair<string, object> keyValue in values)
            {
                this[keyValue.Key] = keyValue.Value.ToString();
            }
        }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="values"></param>
        public Fournisseur(IDataRecord values)
        {
            NumFou = GetValue(values, "NUMFOU");
            NomFou = GetValue(values, "NOMFOU");
            RueFou = GetValue(values, "RUEFOU");
            PosFou = GetValue(values, "POSFOU");
            VilFou = GetValue(values, "VILFOU");
            ConFou = GetValue(values, "CONFOU");
            Satisf = GetValue(values, "SATISF");
        }

        /// <summary>
        /// Méthode d'extraction et formatage des champs
        /// </summary>
        /// <param name="values"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private string GetValue(IDataRecord values, string name)
        {
            string result = "null";

            if (!values.IsDBNull(values.GetOrdinal(name)))
            {
                result = values[name].ToString();
            }

            return result;
        }

        private string IsNull(string text)
        {
            return (text.Length > 0 ? text : "null");
        }

        public string this[string key]
        {
            set
            {
                switch (key)
                {
                    case "NUMFOU":
                        NumFou = IsNull(value);
                        break;
                    case "NOMFOU":
                        NomFou = IsNull(value);
                        break;
                    case "RUEFOU":
                        RueFou = IsNull(value);
                        break;
                    case "POSFOU":
                        PosFou = IsNull(value);
                        break;
                    case "VILFOU":
                        VilFou = IsNull(value);
                        break;
                    case "CONFOU":
                        ConFou = IsNull(value);
                        break;
                    case "SATISF":
                        Satisf = IsNull(value);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
