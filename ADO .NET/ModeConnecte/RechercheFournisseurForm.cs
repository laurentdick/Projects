using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ModeConnecte
{
    public partial class RechercheFournisseurForm : Form
    {
        private ErrorProvider codeFournisseurError;

        /// <summary>
        /// Constructeur
        /// </summary>
        public RechercheFournisseurForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Affichage Formulaire
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RechercheFournisseurForm_Shown(object sender, System.EventArgs e)
        {
            codeFournisseurError = new ErrorProvider();
            codeFournisseurError.SetIconAlignment(tbx_CodeFournisseur, ErrorIconAlignment.MiddleRight);
            codeFournisseurError.SetIconPadding(tbx_CodeFournisseur, 5);
            codeFournisseurError.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        }

        /// <summary>
        /// Accesseur Code Fournisseur
        /// </summary>
        /// <returns></returns>
        public string GetCodeFournisseur()
        {
            return tbx_CodeFournisseur.Text;
        }

        /// <summary>
        /// Vérification de la saisie du code fournisseur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbx_CodeFournisseur_TextChanged(object sender, System.EventArgs e)
        {
            bool result = (tbx_CodeFournisseur.TextLength > 0) && Regex.IsMatch(tbx_CodeFournisseur.Text, "^[0-9]+$");

            if ((tbx_CodeFournisseur.TextLength > 0) && !result)
            {
                codeFournisseurError.SetError(tbx_CodeFournisseur, "caractères numériques attendus");
            }
            else
            {
                codeFournisseurError.SetError(tbx_CodeFournisseur, null);
            }

            btn_OK.Enabled = result;
        }
    }
}
