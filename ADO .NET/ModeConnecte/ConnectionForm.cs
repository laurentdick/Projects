using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Globalization;
using System.Collections.Generic;
using System.Windows.Forms;

using ClassMetierLibrary;


namespace ModeConnecte
{
    public partial class ConnectionForm : Form
    {
        private DbProviderFactory dbProviderFactory;
        private DbConnection dbConnection;
        private DbCommand dbCommande;
        private DbDataReader dbDataReader;

        private string factory;
        private string connectionString;

        /// <summary>
        /// Constructeur
        /// </summary>
        public ConnectionForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Affiche une messagebox
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        /// <param name="buttons"></param>
        /// <param name="icon"></param>
        public DialogResult ShowMessageBox(string message, string title = "Exception SQL",
            MessageBoxButtons buttons = MessageBoxButtons.OK,
            MessageBoxIcon icon = MessageBoxIcon.Error)
        {
            return MessageBox.Show(message, title, buttons, icon);
        }

        /// <summary>
        /// Vérification de la connection à la base de données
        /// </summary>
        /// <returns></returns>
        public bool CheckConnectionBase()
        {
            bool result = (dbConnection != null) && (dbConnection.State != ConnectionState.Closed);

            if (!result)
            {
                ShowMessageBox("Veuillez d'abord vous connecter à la base de données !", "Erreur");
            }

            return result;
        }

        /// <summary>
        /// Récupère la valeur d'un champ
        /// </summary>
        /// <param name="values"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public string GetValue(IDataRecord values, string name)
        {
            string result = "null";

            if (!values.IsDBNull(values.GetOrdinal(name)))
            {
                result = values[name].ToString();
            }

            return result;
        }

        /// <summary>
        /// Conversion d'un string null au format sql
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private string IsNull(string text)
        {
            return (text.Length > 0 ? text : "null");
        }

        /// <summary>
        /// Initialisation avant affichage formulaire
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConnectionForm_Shown(object sender, EventArgs e)
        {
            ts_MenuFournisseur.Tag = typeof(FournisseurForm);
            ts_MenuListeDesCommandes.Tag = typeof(CommandesForm);

            cbx_DriverSelect.SelectedIndex = 0;
            cbx_DriverSelect.Focus();
        }

        /// <summary>
        /// Fermeture du formulaire
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConnectionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((dbConnection != null) && (dbConnection.State != ConnectionState.Closed))
            {
                btn_Disconnect_Click(sender, null);
            }
        }

        /// <summary>
        /// Changement de pilote de base de données
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            string driver = (cbx_DriverSelect.SelectedIndex == 0) ? "dbPapyrusSqlServer" : "dbPapyrusOdbcMySql";
            factory = ConfigurationManager.AppSettings[
                        (cbx_DriverSelect.SelectedIndex == 0) ? "factorySqlServer" : "factoryMySql"];
            dbProviderFactory = DbProviderFactories.GetFactory(factory);

            ConnectionStringSettings oConfig = ConfigurationManager.ConnectionStrings[driver];
            DbConnectionStringBuilder oBuilder = new DbConnectionStringBuilder();

            connectionString = oConfig.ConnectionString;
            tbx_TablePrefix.Text = "";

            if (oConfig != null)
            {
                oBuilder.ConnectionString = oConfig.ConnectionString;

                switch (cbx_DriverSelect.SelectedIndex)
                {
                    case 0:
                        tbx_Serveur.Text = oBuilder["Data Source"].ToString();
                        tbx_BaseDonnees.Text = oBuilder["Initial Catalog"].ToString();
                        cbx_Security.SelectedIndex = (oBuilder["Integrated Security"].ToString() == "False" ? 0 : 1);
                        cbx_Security.SelectedIndex = 1;
                        cbx_Security.Enabled = true;
                        break;
                    case 1:
                        tbx_Serveur.Text = oBuilder["server"].ToString();
                        tbx_BaseDonnees.Text = oBuilder["database"].ToString();
                        cbx_Security.SelectedIndex = -1;
                        cbx_Security.Enabled = false;
                        break;
                }
            }
        }

        /// <summary>
        /// Indication de l'état de la connection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void sqlConnect_StateChange(object sender, StateChangeEventArgs e)
        {
            btn_Lire.Enabled = btn_Disconnect.Enabled =
                !(btn_Connect.Enabled = (e.CurrentState == ConnectionState.Closed));

            cbx_DriverSelect.Enabled =
            tbx_Serveur.Enabled = tbx_BaseDonnees.Enabled = cbx_Security.Enabled = btn_Connect.Enabled;

            switch (e.CurrentState)
            {
                case ConnectionState.Connecting:
                    tslbl_Status.Text = "Connection en cours à: " + dbConnection.ConnectionString; break;

                case ConnectionState.Open:
                    tslbl_Status.Text = "Connecté: " + dbConnection.ConnectionString; AcceptButton = btn_Disconnect; lv_TableView.Focus(); break;

                case ConnectionState.Closed:
                    tslbl_Status.Text = "Déconnecté"; AcceptButton = btn_Connect; cbx_DriverSelect.Focus(); break;

                default:
                    tslbl_Status.Text = "Etat inconnu"; break;
            }
        }

        /// <summary>
        /// Connection à la base de données
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Connect_Click(object sender, EventArgs e)
        {
            try
            {
                dbConnection = dbProviderFactory.CreateConnection();
                dbConnection.StateChange += sqlConnect_StateChange;

                // configuration connexion
                dbConnection.ConnectionString = connectionString;

                // ouverture connexion
                dbConnection.Open();
                btn_Lire_Click(sender, e);
            }
            catch (DbException ex)
            {
                ShowMessageBox("Erreur de connection:" + ex.Message);
                tslbl_Status.Text = "Echec de connection à : " + dbConnection.ConnectionString;
            }
        }

        /// <summary>
        /// Déconnection de la base de données
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Disconnect_Click(object sender, EventArgs e)
        {
            if (CheckConnectionBase())
            {
                lv_TableView.Items.Clear();
                dbConnection.Close();
            }
        }

        /// <summary>
        /// Fermeture de l'application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Quitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void btn_Lire_Click(object sender, EventArgs e)
        {
            if (CheckConnectionBase())
            {
                lv_TableView.Items.Clear();

                dbCommande = dbProviderFactory.CreateCommand();
                dbCommande.CommandText = "SELECT * FROM " + tbx_TablePrefix.Text + ".FOURNIS";
                dbCommande.Connection = dbConnection;

                try
                {
                    dbDataReader = dbCommande.ExecuteReader();

                    while (dbDataReader.Read())
                    {
                        lv_TableView.Items.Add(
                            new ListViewItem(
                                new string[] {
                                    GetValue(dbDataReader, "NUMFOU"),
                                    GetValue(dbDataReader, "NOMFOU"),
                                    GetValue(dbDataReader, "RUEFOU"),
                                    GetValue(dbDataReader, "POSFOU"),
                                    GetValue(dbDataReader, "VILFOU"),
                                    GetValue(dbDataReader, "CONFOU"),
                                    GetValue(dbDataReader, "SATISF"),
                        }));
                    }

                    dbDataReader.Close();
                    lv_TableView.Focus();
                }
                catch (DbException ex)
                {
                    ShowMessageBox("Requête SQL: " + ex.Message);
                }
            }
        }

        /// <summary>
        /// Création des Formulaires correspondants aux Menus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CheckConnectionBase() && (sender is ToolStripMenuItem))
            {
                Form theForm;

                try
                {
                    theForm = Activator.CreateInstance((sender as ToolStripMenuItem).Tag as Type) as Form;

                    theForm.ShowDialog(this);
                    theForm.Dispose();
                }
                catch (Exception ex)
                {
                    ShowMessageBox("Exception : " + ex.Message, "Exception");
                }
            }
        }

        /// <summary>
        /// Execute une requête en mode reader de base de données
        /// Renvoi les résultats de lecture par un DataTable
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        private DataTable ExecuteReader(string command)
        {
            DataTable table = null;

            if (CheckConnectionBase())
            {
                dbCommande = dbProviderFactory.CreateCommand();
                dbCommande.CommandText = command;
                dbCommande.Connection = dbConnection;

                try
                {
                    dbDataReader = dbCommande.ExecuteReader();

                    while (dbDataReader.Read())
                    {
                        if (table == null)
                        {
                            table = new DataTable();

                            for (int i = 0; i < dbDataReader.FieldCount; i++)
                            {
                                table.Columns.Add(dbDataReader.GetName(i), dbDataReader.GetFieldType(i));
                            }
                        }

                        DataRow row = table.NewRow();
                        table.Rows.Add(row);

                        for (int i = 0; i < dbDataReader.FieldCount; i++)
                        {
                            row[dbDataReader.GetName(i)] = dbDataReader.GetValue(i);
                        }
                    }
                }
                catch (DbException ex)
                {
                    ShowMessageBox("Requête SQL: " + ex.Message);
                }
                finally
                {
                    dbDataReader.Close();
                }
            }

            return table;
        }

        /// <summary>
        /// Recherche d'un fournisseur par son numéro
        /// </summary>
        /// <param name="numfou"></param>
        /// <returns></returns>
        public bool RechercherFournisseur(ref DataTable table, int numfou)
        {
            table = ExecuteReader("SELECT * FROM " + tbx_TablePrefix.Text + ".FOURNIS WHERE NUMFOU=" + numfou);

            if (table == null)
            {
                ShowMessageBox("Numéro de Fournisseur inexistant", "Erreur");
            }

            return (table != null);
        }

        /// <summary>
        /// Recherche d'un fournisseur par son nom
        /// </summary>
        /// <param name="unFournisseur"></param>
        /// <param name="nomfou"></param>
        /// <returns></returns>
        public bool RechercherFournisseur(ref Fournisseur unFournisseur, string nomfou)
        {
            if (CheckConnectionBase())
            {
                //dbCommande = dbProviderFactory.CreateCommand();
                //dbCommande.CommandText = "SELECT * FROM " + tbx_TablePrefix.Text + ".FOURNIS WHERE NOMFOU='" + nomfou + "'";
                //dbCommande.Connection = dbConnection;

                //try
                //{
                //    dbDataReader = dbCommande.ExecuteReader();

                //    if (dbDataReader.Read())
                //    {
                //        Dictionary<string, object> values = new Dictionary<string, object>();
                //        for (int i = 0; i < dbDataReader.FieldCount; i++)
                //        {
                //            values.Add(dbDataReader.GetName(i), dbDataReader.GetValue(i));
                //        }

                //        unFournisseur = new Fournisseur(values);
                //    }
                //    else
                //    {
                //        ShowMessageBox("Nom Fournisseur inexistant", "Erreur");
                //    }

                //    dbDataReader.Close();
                //}
                //catch (DbException ex)
                //{
                //    ShowMessageBox("Requête SQL: " + ex.Message);
                //}
                DataTable table = ExecuteReader("SELECT * FROM " + tbx_TablePrefix.Text + ".FOURNIS WHERE NOMFOU='" + nomfou + "'");
                GenericFournisseur f = new GenericFournisseur(table);
            }

            return (unFournisseur != null);
        }

        /// <summary>
        /// Remplit une liste de nom de Fournisseurs
        /// </summary>
        /// <param name="listeFournisseurs"></param>
        /// <returns></returns>
        public bool RechercherListeFournisseurs(ref DataTable table)
        {
            table = ExecuteReader("SELECT NOMFOU FROM " + tbx_TablePrefix.Text + ".FOURNIS");

            return (table != null);
        }

        /// <summary>
        /// Construit une liste de commande d'un fournisseur
        /// </summary>
        /// <param name="listeCommandes"></param>
        /// <param name="unFournisseur"></param>
        /// <returns></returns>
        public bool RechercherListeCommandes(ListView.ListViewItemCollection listeCommandes, Fournisseur unFournisseur)
        {
            if (CheckConnectionBase())
            {
                dbCommande = dbProviderFactory.CreateCommand();
                dbCommande.CommandText = "GetEntCom";
                dbCommande.CommandType = CommandType.StoredProcedure;
                dbCommande.Connection = dbConnection;

                dbCommande.CommandType = CommandType.StoredProcedure;

                // Spécification des parametres
                DbParameter numfouParam = dbCommande.CreateParameter();
                numfouParam.Direction = ParameterDirection.Input;
                numfouParam.DbType = DbType.Int16;
                numfouParam.Value = (unFournisseur != null) ? unFournisseur.NumFou : (-1).ToString();
                numfouParam.ParameterName = "n";
                dbCommande.Parameters.Add(numfouParam);

                listeCommandes.Clear();

                // Exécution de la commande
                try
                {
                    dbDataReader = dbCommande.ExecuteReader();

                    int i = 1;
                    while (dbDataReader.Read())
                    {
                        listeCommandes.Add(
                            new ListViewItem(
                                new string[]
                                {
                                    (i++).ToString(),
                                    dbDataReader["NUMCOM"].ToString(),
                                    DateTime.ParseExact(dbDataReader["DATECOM"].ToString(), "dd/MM/yyyy hh:mm:ss",  CultureInfo.InvariantCulture).ToString("d"),
                                    dbDataReader["OBSCOM"].ToString()
                                }
                            )
                        );
                    }

                    dbDataReader.Close();
                }
                catch (DbException ex)
                {
                    ShowMessageBox("Erreur SQL : " + ex.Message);
                }
            }

            return true;
        }

        /// <summary>
        /// Ajout d'un enregistrement de fiche fournisseur
        /// </summary>
        /// <param name="codefou"></param>
        /// <returns></returns>
        public bool AjouterFournisseur(Fournisseur unFournisseur)
        {
            int result = -1;

            if (CheckConnectionBase())
            {
                dbCommande = dbProviderFactory.CreateCommand();
                dbCommande.CommandText = "INSERT INTO " + tbx_TablePrefix.Text + ".FOURNIS VALUES (" +
                    unFournisseur.NumFou + "," +
                    "'" + IsNull(unFournisseur.NomFou) + "'," +
                    "'" + IsNull(unFournisseur.RueFou) + "'," +
                    "'" + IsNull(unFournisseur.PosFou) + "'," +
                    "'" + IsNull(unFournisseur.VilFou) + "'," +
                    "'" + IsNull(unFournisseur.ConFou) + "'," +
                    IsNull(unFournisseur.Satisf) + ")";

                dbCommande.Connection = dbConnection;

                try
                {
                    result = dbCommande.ExecuteNonQuery();

                    if (result >= 1)
                    {
                        btn_Lire_Click(this, null);
                        ShowMessageBox("Modification effectuée\nNombre de ligne(s) affectée(s) :" + result, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (DbException ex)
                {
                    ShowMessageBox("Requête SQL: " + ex.Message);
                }
            }

            return (result >= 1);
        }

        /// <summary>
        /// Mise à jour d'un enregistrement de fiche fournisseur
        /// </summary>
        /// <param name="codefou"></param>
        /// <returns></returns>
        public bool ModifierFournisseur(Fournisseur unFournisseur)
        {
            int result = -1;

            if (CheckConnectionBase())
            {
                dbCommande = dbProviderFactory.CreateCommand();
                dbCommande.CommandText = "UPDATE " + tbx_TablePrefix.Text + ".FOURNIS SET " +
                    "NOMFOU='" + IsNull(unFournisseur.NomFou) + "'," +
                    "RUEFOU='" + IsNull(unFournisseur.RueFou) + "'," +
                    "POSFOU='" + IsNull(unFournisseur.PosFou) + "'," +
                    "VILFOU='" + IsNull(unFournisseur.VilFou) + "'," +
                    "CONFOU='" + IsNull(unFournisseur.ConFou) + "'," +
                    "SATISF=" + IsNull(unFournisseur.Satisf) +
                    " WHERE NUMFOU=" + unFournisseur.NumFou;

                dbCommande.Connection = dbConnection;

                try
                {
                    result = dbCommande.ExecuteNonQuery();

                    if (result >= 1)
                    {
                        btn_Lire_Click(this, null);
                        ShowMessageBox("Modification effectuée\nNombre de ligne(s) affectée(s) :" + result, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (DbException ex)
                {
                    ShowMessageBox("Requête SQL: " + ex.Message);
                }
            }

            return (result >= 1);
        }

        /// <summary>
        /// Suppression d'un fournisseur par son code
        /// </summary>
        /// <param name="codefou"></param>
        /// <returns></returns>
        public bool SupprimerFournisseur(Fournisseur unFournisseur)
        {
            int result = -1;

            if (CheckConnectionBase())
            {
                dbCommande = dbProviderFactory.CreateCommand();
                dbCommande.CommandText = "DELETE FROM " + tbx_TablePrefix.Text + ".FOURNIS WHERE NUMFOU=" + unFournisseur.NumFou;
                dbCommande.Connection = dbConnection;

                try
                {
                    result = dbCommande.ExecuteNonQuery();

                    if (result >= 1)
                    {
                        btn_Lire_Click(this, null);
                        ShowMessageBox("Suppression effectuée\nNombre de ligne(s) affectée(s) :" + result, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (DbException ex)
                {
                    ShowMessageBox("Requête SQL: " + ex.Message);
                }
            }

            return (result >= 1);
        }
    }
}
