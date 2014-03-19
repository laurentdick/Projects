using System;
using System.Data;
using System.Windows.Forms;

namespace ModeDeconnecte
{
    public partial class ModeDeconnecteForm : Form
    {
        private enum DataExchangeDir { SET = 1, GET };
        private delegate DialogResult MessageBoxProc(string msg, string title, MessageBoxButtons buttons, MessageBoxIcon icon);

        /// <summary>
        /// Constructeur
        /// </summary>
        public ModeDeconnecteForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initialisations avant Affichage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ModeDeconnecteForm_Shown(object sender, EventArgs e)
        {
            LoadListeProduits(sender, e);
        }

        /// <summary>
        /// Enregistrement si nécessaire de la base de données et fermeture application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ModeDeconnecteForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (papyrusDataSet1.HasChanges(DataRowState.Modified))
            {
                e.Cancel =
                    SyncDataBase(
                        new object[] {
                            "Enregistrer les modifications à la base de données ?",
                            "Quitter l'application",
                            MessageBoxButtons.YesNoCancel,
                            MessageBoxIcon.Question
                        }) == DialogResult.Cancel;
            }
        }

        /// <summary>
        /// Fermeture de l'application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Quit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Remplit a listbox à partir de la table produits
        /// </summary>
        private void LoadListeProduits(object sender, EventArgs e)
        {
            btn_Annuler.Enabled = btn_Valider.Enabled = false;

            if (papyrusDataSet1.HasChanges(DataRowState.Modified)
                && SyncDataBase(
                    new object[] {
                        "La base de données a été modifiée\nVoulez-vous sauvegarder les modifications ?",
                        "Enregistrer",
                        MessageBoxButtons.YesNoCancel,
                        MessageBoxIcon.Question
                    }) != DialogResult.Cancel)
            {
            }

            if (!papyrusDataSet1.HasChanges(DataRowState.Modified))
            {
                produitTableAdapter1.Fill(papyrusDataSet1.PRODUIT);
            }

            InitListeProduits();
        }

        /// <summary>
        /// Initialise la ListBox avec le DataSet en mémoire
        /// </summary>
        private void InitListeProduits()
        {
            int selectedIndex = lbx_ListeProduits.SelectedIndex;

            lbx_ListeProduits.Items.Clear();

            foreach (DataRow datasRow in papyrusDataSet1.PRODUIT.Rows)
            {
                lbx_ListeProduits.Items.Add(datasRow["LIBART"]);
            }

            foreach (DataColumn columnName in papyrusDataSet1.PRODUIT.Columns)
            {
                if (pnl_Values.Controls["tbx_" + columnName] is TextBox)
                {
                    (pnl_Values.Controls["tbx_" + columnName] as TextBox).Clear();
                }
            }

            lbx_ListeProduits.SelectedIndex = selectedIndex;
            EnableTextBoxs(selectedIndex >= 0);
            btn_MAJ.Enabled = papyrusDataSet1.HasChanges(DataRowState.Modified);
        }

        /// <summary>
        /// Active/Désactive les TextBoxs
        /// </summary>
        /// <param name="value"></param>
        private void EnableTextBoxs(bool value)
        {
            foreach (Control control in pnl_Values.Controls)
            {
                if (control is TextBox)
                {
                    control.Enabled = value;
                }
            }
        }

        /// <summary>
        /// Echange des données entre les DataRow et les TextBox
        /// </summary>
        /// <param name="dataRow"></param>
        /// <param name="direction"></param>
        private bool DoExchangeData(PapyrusDataSet.PRODUITRow dataRow, DataExchangeDir direction)
        {
            if (dataRow != null)
            {
                foreach (DataColumn columnName in papyrusDataSet1.PRODUIT.Columns)
                {
                    if ((pnl_Values.Controls["tbx_" + columnName] is TextBox)
                        && (pnl_Values.Controls["tbx_" + columnName] as TextBox).Text != dataRow[columnName].ToString()
                        )
                    {
                        switch (direction)
                        {
                            case DataExchangeDir.SET:
                                dataRow[columnName] = pnl_Values.Controls["tbx_" + columnName].Text;
                                break;

                            case DataExchangeDir.GET:
                                pnl_Values.Controls["tbx_" + columnName].Text = dataRow[columnName].ToString();
                                break;

                            default: /* WTF ? Bad Programmer Exception Detected ! */
                                break;
                        }
                    }
                }
            }

            return (dataRow != null);
        }

        /// <summary>
        /// Retourne le DataRow en fonction d'un libellé article
        /// Si plusieurs DataRows sont concernés, ne retourne que le premier trouvé
        /// Renvoi NULL si aucun ne correspond
        /// </summary>
        /// <param name="libelle"></param>
        /// <returns></returns>
        private PapyrusDataSet.PRODUITRow GetDataRowFromLibelle(object libelle)
        {
            PapyrusDataSet.PRODUITRow dataRowResult = null;

            var selectedRow = from row in papyrusDataSet1.PRODUIT
                              where row["LIBART"] == libelle
                              select row;

            foreach (PapyrusDataSet.PRODUITRow dataRow in selectedRow)
            {
                if (dataRowResult == null)
                {
                    dataRowResult = dataRow;
                }
            }

            return dataRowResult;
        }

        /// <summary>
        /// Sélection d'un article sélectionné dans la listbox
        /// Mise à jour des champs dans les textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbx_ListeProduits_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnableTextBoxs(lbx_ListeProduits.SelectedIndex >= 0);

            if (DoExchangeData(GetDataRowFromLibelle(lbx_ListeProduits.SelectedItem), DataExchangeDir.GET))
            {
            }
        }

        /// <summary>
        /// Valider les modifications et recharger la listbox si libellé modifié
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Valider_Click(object sender, EventArgs e)
        {
            if (DoExchangeData(GetDataRowFromLibelle(lbx_ListeProduits.SelectedItem), DataExchangeDir.SET))
            {
                btn_Annuler.Enabled = btn_Valider.Enabled = false;
            }

            InitListeProduits();
        }

        /// <summary>
        /// Annulation des modifications en cours
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Annuler_Click(object sender, EventArgs e)
        {
            lbx_ListeProduits_SelectedIndexChanged(sender, e);
            btn_Annuler.Enabled = btn_Valider.Enabled = false;
        }

        /// <summary>
        /// Synchronise la Base de données et le DataSet
        /// </summary>
        /// <param name="dlgMessageProc"></param>
        private DialogResult SyncDataBase(params object[] param)
        {
            DialogResult result = DialogResult.Cancel;

            if (papyrusDataSet1.HasChanges(DataRowState.Modified))
            {
                result = MessageBox.Show(param[0] as string, param[1] as string, (MessageBoxButtons)param[2], (MessageBoxIcon)param[3]);

                switch (result)
                {
                    case DialogResult.Yes:
                        produitTableAdapter1.Update(papyrusDataSet1.PRODUIT);
                        break;

                    case DialogResult.No:
                        papyrusDataSet1.RejectChanges();
                        break;

                    default: /* nothing to do */
                        break;
                }
            }

            return result;
        }

        /// <summary>
        /// Evènements modification des TextBoxs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbx_TextChanged(object sender, EventArgs e)
        {
            bool result = false;

            foreach (Control control in pnl_Values.Controls)
            {
                if (control is TextBox)
                {
                    TextBox tbx = control as TextBox;
                    PapyrusDataSet.PRODUITRow selectedDataRow = GetDataRowFromLibelle(lbx_ListeProduits.SelectedItem);

                    if (selectedDataRow != null)
                    {
                        result |= (tbx.Text != selectedDataRow[tbx.Tag.ToString()].ToString());
                    }
                }
            }

            btn_Annuler.Enabled = btn_Valider.Enabled = result;
            AcceptButton = (btn_Valider.Enabled ? btn_Valider : btn_Refill);
            CancelButton = (btn_Annuler.Enabled ? btn_Annuler : btn_Quit);
        }
    }
}
