using System;
using System.Data;
using System.Windows.Forms;

using ClassMetierLibrary;

namespace ModeConnecte
{
    public partial class CommandesForm : Form
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        public CommandesForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Affichage du Formulaire
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListeCommandesForm_Shown(object sender, EventArgs e)
        {
            DataTable table = null;

            if ((Owner is ConnectionForm) &&
                (Owner as ConnectionForm).RechercherListeFournisseurs(ref table))
            {
                foreach (DataRow row in table.Rows)
                {
                    cbx_ListeFournisseurs.Items.Add(row["NOMFOU"]);
                }
            }

            cbx_ListeFournisseurs.SelectedIndex = 0;
        }

        /// <summary>
        /// Recherche de la liste des commandes à la sélection d'un fournisseur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbx_ListeFournisseurs_SelectedValueChanged(object sender, System.EventArgs e)
        {
            if (Owner is ConnectionForm)
            {
                DataTable table = null;

                if ((cbx_ListeFournisseurs.SelectedIndex > 0) &&
                    (Owner as ConnectionForm).RechercherFournisseur(ref table, cbx_ListeFournisseurs.SelectedItem.ToString()))
                {
                }

                (Owner as ConnectionForm).RechercherListeCommandes(lv_Commandes.Items, table);
                gbx_Commandes.Visible = true;
            }
        }
    }
}
