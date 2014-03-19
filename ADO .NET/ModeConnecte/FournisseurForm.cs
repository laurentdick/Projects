using System;
using System.Data;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using ClassMetierLibrary;


namespace ModeConnecte
{
    /// <summary>
    /// Formulaire de recherche, ajout, suppression ou modification d'un enregistrement Fournisseur
    /// </summary>
    public partial class FournisseurForm : Form
    {
        /// <summary>
        /// Enumérateur représentant le sens de l'échange de données
        /// </summary>
        private enum ExchangeDirection { SET = 1, GET };

        /// <summary>
        /// Enumérateur d'état du Formulaire
        /// </summary>
        private enum ViewMode { DISPLAY = 1, CREATE, MODIFY };

        /// <summary>
        /// ErrorProvider pour le champ 'NumFou'
        /// </summary>
        private ErrorProvider codeFournisseurError;

        /// <summary>
        /// Instance d'un fournisseur sélectionné
        /// </summary>
        private Fournisseur fournisseur;
        private DataTable dataTable;

        /// <summary>
        /// Etat du formulaire
        /// </summary>
        private ViewMode viewMode;

        /// <summary>
        ///  Constructeur
        /// </summary>
        public FournisseurForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Evènement d'Affichage du formulaire
        /// Initialisation des contrôles
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AffichageFournisseurForm_Shown(object sender, EventArgs e)
        {
            codeFournisseurError = new ErrorProvider();

            codeFournisseurError.SetIconAlignment(tbx_NUMFOU, ErrorIconAlignment.MiddleRight);
            codeFournisseurError.SetIconPadding(tbx_NUMFOU, 5);
            codeFournisseurError.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            
            InitViewMode(ViewMode.DISPLAY);
            viewMode = ViewMode.DISPLAY;
        }

        /// <summary>
        /// Fermeture du Formulaire seulement si on est en mode DISPLAY
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AffichageFournisseurForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (viewMode != ViewMode.DISPLAY)
            {
                viewMode = ViewMode.DISPLAY;
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Initialise l'interface du Formulaire dans le mode spécifié
        /// </summary>
        /// <param name="mode"></param>
        private void InitViewMode(ViewMode mode)
        {
            switch (mode)
            {
                // Mode d'affichage d'un fournisseur
                case ViewMode.DISPLAY:
                    Clear();
                    tbx_NUMFOU.Focus();

                    if (dataTable != null)
                    {
                        DoExchangeDatas(ref dataTable, ExchangeDirection.GET);
                    }

                    tbx_NUMFOU.Enabled = btn_Search.Visible = true;
                    tbx_NOMFOU.Enabled = tbx_RUEFOU.Enabled = tbx_POSFOU.Enabled =
                        tbx_VILFOU.Enabled = tbx_CONFOU.Enabled = tbx_SATISF.Enabled = false;
                    btn_Nouveau.Visible = btn_Modifier.Visible = btn_Supprimer.Visible = btn_Fermer.Visible = true;
                    btn_Creer.Visible = btn_Valider.Visible = btn_Annuler.Visible = false;

                    AcceptButton = btn_Search;
                    CancelButton = btn_Fermer;
                    tbx_NUMFOU.SelectAll();
                    break;

                // Mode Création d'un nouveau fournisseur
                case ViewMode.CREATE:
                    Clear();
                    tbx_NUMFOU.Focus();

                    btn_Search.Visible = false;
                    tbx_NOMFOU.Enabled = tbx_RUEFOU.Enabled = tbx_POSFOU.Enabled =
                        tbx_VILFOU.Enabled = tbx_CONFOU.Enabled = tbx_SATISF.Enabled = true;
                    btn_Nouveau.Visible = btn_Modifier.Visible = btn_Supprimer.Visible = btn_Fermer.Visible = false;
                    btn_Creer.Visible = btn_Annuler.Visible = true;
                    btn_Creer.Enabled = false;

                    AcceptButton = btn_Creer;
                    CancelButton = btn_Annuler;
                    viewMode = ViewMode.CREATE;
                    break;

                // Mode modification d'un fournisseur
                case ViewMode.MODIFY:
                    tbx_NOMFOU.Focus();

                    tbx_NUMFOU.Enabled = btn_Search.Visible = false;
                    tbx_NOMFOU.Enabled = tbx_RUEFOU.Enabled = tbx_POSFOU.Enabled =
                        tbx_VILFOU.Enabled = tbx_CONFOU.Enabled = tbx_SATISF.Enabled = true;
                    btn_Nouveau.Visible = btn_Modifier.Visible = btn_Supprimer.Visible = btn_Fermer.Visible = false;
                    btn_Valider.Visible = btn_Annuler.Visible = true;

                    AcceptButton = btn_Valider;
                    CancelButton = btn_Annuler;
                    tbx_NOMFOU.SelectAll();
                    viewMode = ViewMode.MODIFY;
                    break;
            }
        }

        /// <summary>
        /// Efface toutes les informations Fournisseur des TextBoxs
        /// </summary>
        private void Clear()
        {
            foreach (Control control in gbx_InfoFournisseur.Controls)
            {
                if (control is TextBox)
                {
                    (control as TextBox).Clear();
                }
            }
        }

        /// <summary>
        /// Echange des données entre les TextBoxs et un objet Fournisseur
        /// </summary>
        /// <param name="unFournisseur"></param>
        /// <param name="direction"></param>
        private void DoExchangeDatas(ref DataTable table, ExchangeDirection direction)
        {
            foreach (DataColumn column in table.Columns)
            {
                switch (direction)
                {
                    // Fournisseur => TextBoxs
                    case ExchangeDirection.GET:
                        gbx_InfoFournisseur.Controls["tbx_" + column].Text = table.Rows[0][column].ToString();
                        break;

                    // TextBoxs => Fournisseur
                    case ExchangeDirection.SET:
                        table.Rows[0][column] = gbx_InfoFournisseur.Controls["tbx_" + column].Text;
                        break;
                }
            }
        }

        private void DoExchangeDatas(ref Fournisseur unFournisseur, ExchangeDirection datasDirection)
        {
            switch (datasDirection)
            {
                // Fournisseur => TextBoxs
                case ExchangeDirection.GET:
                    tbx_NUMFOU.Text = unFournisseur.NumFou;
                    tbx_NOMFOU.Text = unFournisseur.NomFou;
                    tbx_RUEFOU.Text = unFournisseur.RueFou;
                    tbx_POSFOU.Text = unFournisseur.PosFou;
                    tbx_VILFOU.Text = unFournisseur.VilFou;
                    tbx_CONFOU.Text = unFournisseur.ConFou;
                    tbx_SATISF.Text = unFournisseur.Satisf;
                    break;

                // TextBoxs => Fournisseur
                case ExchangeDirection.SET:
                    unFournisseur.NumFou = tbx_NUMFOU.Text;
                    unFournisseur.NomFou = tbx_NOMFOU.Text;
                    unFournisseur.RueFou = tbx_RUEFOU.Text;
                    unFournisseur.PosFou = tbx_POSFOU.Text;
                    unFournisseur.VilFou = tbx_VILFOU.Text;
                    unFournisseur.ConFou = tbx_CONFOU.Text;
                    unFournisseur.Satisf = tbx_SATISF.Text;
                    break;
            }
        }

        /// <summary>
        /// Contrôle de saisie du code fournisseur
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbx_Code_TextChanged(object sender, EventArgs e)
        {
            string numfou = tbx_NUMFOU.Text.Trim();
            bool result = (numfou.Length > 0);

            btn_Creer.Enabled = Regex.IsMatch(numfou, "^[0-9]+$");
            codeFournisseurError.SetError(tbx_NUMFOU,
                (result && !btn_Creer.Enabled) ?
                    "caractères numériques attendus" :
                    null);

            btn_Search.Enabled = result;
        }

        /// <summary>
        /// Recherche par Numéro de Fournisseur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Search_Click(object sender, EventArgs e)
        {
            if ((Owner is ConnectionForm))
            {
                if ((Owner as ConnectionForm).RechercherFournisseur(ref dataTable, Convert.ToInt16(tbx_NUMFOU.Text)))
                {
                    InitViewMode(ViewMode.DISPLAY);
                    btn_Modifier.Enabled = btn_Supprimer.Enabled = true;
                    viewMode = ViewMode.DISPLAY;
                }
                else
                {
                    Clear();
                }
            }
        }

        /// <summary>
        /// Saisie d'un nouveau Fournisseur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Nouveau_Click(object sender, EventArgs e)
        {
            switch (viewMode)
            {
                // Initialisation du Formulaire en mode Création
                case ViewMode.DISPLAY:
                    InitViewMode(ViewMode.CREATE);
                    break;

                // Ajout de l'enregistrement Fournisseur dans la base de données
                case ViewMode.CREATE:
                    {
                        Fournisseur unFournisseur = new Fournisseur();
                        DoExchangeDatas(ref unFournisseur, ExchangeDirection.SET);

                        if ((Owner is ConnectionForm) && (Owner as ConnectionForm).AjouterFournisseur(unFournisseur))
                        {
                            fournisseur = unFournisseur;
                            InitViewMode(ViewMode.DISPLAY);
                            viewMode = ViewMode.DISPLAY;
                            btn_Modifier.Enabled = btn_Supprimer.Enabled = true;
                        }
                    }
                    break;

                // On ne doit pas arriver ici
                default:
                    throw new InvalidOperationException();
            }
        }

        /// <summary>
        /// Suppression du Fournisseur courant
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Supprimer_Click(object sender, EventArgs e)
        {
            if ((Owner is ConnectionForm) &&
                (Owner as ConnectionForm).ShowMessageBox("Voulez-vous supprimer ce fournisseur ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Fournisseur unFournisseur = new Fournisseur();
                DoExchangeDatas(ref unFournisseur, ExchangeDirection.SET);

                if ((Owner as ConnectionForm).SupprimerFournisseur(unFournisseur))
                {
                    fournisseur = null;
                }
            }

            InitViewMode(ViewMode.DISPLAY);
            viewMode = ViewMode.DISPLAY;
        }

        /// <summary>
        /// Edition Fournisseur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Modifier_Click(object sender, EventArgs e)
        {
            switch (viewMode)
            {
                // Initialisation du Formulaire en mode Modification
                case ViewMode.DISPLAY:
                    InitViewMode(ViewMode.MODIFY);
                    break;

                // Validation des modifications
                case ViewMode.MODIFY:
                    {
                        DoExchangeDatas(ref fournisseur, ExchangeDirection.SET);

                        if ((Owner is ConnectionForm) && (Owner as ConnectionForm).ModifierFournisseur(fournisseur))
                        {
                            InitViewMode(ViewMode.DISPLAY);
                            btn_Modifier.Enabled = btn_Supprimer.Enabled = true;
                            viewMode = ViewMode.DISPLAY;
                        }
                    }
                    break;

                // On ne doit pas arriver ici
                default:
                    break;
            }
        }

        /// <summary>
        /// Annulation de l'opération en cours
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Annuler_Click(object sender, EventArgs e)
        {
            InitViewMode(ViewMode.DISPLAY);

            if ((Owner is ConnectionForm) &&
                ((Owner as ConnectionForm).ShowMessageBox("Opération annulée\nNombre de ligne(s) affectée(s) : 0", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK))
            {
            }
        }
    }
}
