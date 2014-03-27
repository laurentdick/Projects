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
        private string IsNull(object obj)
        {
            return ((obj.ToString().Length > 0) ? obj.ToString() : "null");
        }

        /// <summary>
        /// Formatage du nom de schéma  à utiliser
        /// </summary>
        /// <returns></returns>
        private string GetSchema()
        {
            string result = "";

            if (tbx_Schema.TextLength > 0)
            {
                result = tbx_Schema.Text + '.';
            }

            return result;
        }

        /// <summary>
        /// Initialisation avant affichage formulaire
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConnectionForm_Shown(object sender, EventArgs e)
        {
            int i = 0;
            foreach (string name in new string[] { "NUMFOU", "NOMFOU", "RUEFOU", "POSFOU", "VILFOU", "CONFOU", "SATISF" })
            {
                lv_TableView.Columns[i++].Name = name;
            }

            ts_MenuFournisseur.Tag = typeof(FournisseurForm);
            ts_MenuListeDesCommandes.Tag = typeof(CommandesForm);

            tbx_Schema.Text = "";
            cbx_DriverSelect.Items.Clear();

            foreach (string dbDriverName in ConfigurationManager.AppSettings)
            {
                cbx_DriverSelect.Items.Add(dbDriverName);
            }

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
            string driver = cbx_DriverSelect.SelectedItem.ToString();

            factory = ConfigurationManager.AppSettings[driver];
            dbProviderFactory = DbProviderFactories.GetFactory(factory);

            ConnectionStringSettings oConfig = ConfigurationManager.ConnectionStrings[driver];
            DbConnectionStringBuilder oBuilder = new DbConnectionStringBuilder();

            if (oConfig != null)
            {
                connectionString = oBuilder.ConnectionString = oConfig.ConnectionString;

                try
                {
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
                        case 2:
                            tbx_Serveur.Text = oBuilder["server"].ToString();
                            tbx_BaseDonnees.Text = oBuilder["database"].ToString();
                            cbx_Security.SelectedIndex = -1;
                            cbx_Security.Enabled = false;
                            break;
                    }
                }
                catch (ArgumentException)
                {
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
                !(btn_Connect.Enabled = cbx_Security.Enabled = (e.CurrentState == ConnectionState.Closed));

            cbx_DriverSelect.Enabled =
            tbx_Serveur.Enabled = tbx_BaseDonnees.Enabled = btn_Connect.Enabled;

            switch (e.CurrentState)
            {
                case ConnectionState.Connecting:
                    tslbl_Status.Text = "Connection en cours à: " + dbConnection.ConnectionString; break;

                case ConnectionState.Open:
                    tslbl_Status.Text = "Connecté: " + dbConnection.ConnectionString; AcceptButton = btn_Disconnect; lv_TableView.Focus(); break;

                case ConnectionState.Closed:
                    cbx_SelectedIndexChanged(sender, e);
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
            DbConnectionStringBuilder oBuilder = new DbConnectionStringBuilder();
            oBuilder.ConnectionString = connectionString;
            oBuilder["Database"] = tbx_BaseDonnees.Text;

            try
            {
                dbConnection = dbProviderFactory.CreateConnection();
                dbConnection.StateChange += sqlConnect_StateChange;

                // configuration connexion
                dbConnection.ConnectionString = oBuilder.ConnectionString;

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

        /// <summary>
        /// Lit les enregistrement et les affiche dans la ListView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btn_Lire_Click(object sender, EventArgs e)
        {
            DataTable table = ExecuteReader("SELECT * FROM " + GetSchema() + "FOURNIS ORDER BY NUMFOU");

            lv_TableView.Items.Clear();

            if (table != null)
            {
                foreach (DataRow row in table.Rows)
                {
                    ListViewItem item = new ListViewItem(new string[table.Columns.Count]);

                    foreach (DataColumn column in table.Columns)
                    {
                        item.SubItems[lv_TableView.Columns.IndexOfKey(column.ColumnName)].Text = row[column.ColumnName].ToString();
                    }

                    lv_TableView.Items.Add(item);
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
        /// Exécution d'une instruction SQL
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        private int ExecuteNonQuery(string command)
        {
            int result = -1;

            if (CheckConnectionBase())
            {
                dbCommande = dbProviderFactory.CreateCommand();
                dbCommande.CommandText = command;
                dbCommande.Connection = dbConnection;

                try
                {
                    result = dbCommande.ExecuteNonQuery();

                    if (result >= 1)
                    {
                        btn_Lire_Click(this, null);
                        
                        ShowMessageBox(
                            "Opération effectuée\nNombre de ligne(s) affectée(s) :" + result,
                            "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (DbException e)
                {
                    ShowMessageBox("Requête SQL: " + e.Message);
                }
            }

            return result;
        }

        /// <summary>
        /// Execute une requête en mode reader de base de données
        /// Renvoi les résultats de lecture par un DataTable
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        private DataTable ExecuteReader(string command, CommandType type = CommandType.Text)
        {
            DataTable table = null;

            if (CheckConnectionBase())
            {
                dbCommande = dbProviderFactory.CreateCommand();
                dbCommande.CommandText = command;
                dbCommande.CommandType = type;
                dbCommande.Connection = dbConnection;

                try
                {
                    dbDataReader = dbCommande.ExecuteReader();

                    // Récupération et ajout des lignes de données
                    while (dbDataReader.Read())
                    {
                        if (table == null)
                        {
                            // Création d'une nouvelle table
                            table = new DataTable();

                            // Récupération des noms de colonnes et des types des champs
                            for (int i = 0; i < dbDataReader.FieldCount; i++)
                            {
                                table.Columns.Add(dbDataReader.GetName(i), dbDataReader.GetFieldType(i));
                            }
                        }

                        DataRow row = table.NewRow();
                        object[] obj = new object[row.ItemArray.Length];

                        dbDataReader.GetValues(obj);
                        row.ItemArray = obj;
                        table.Rows.Add(row);
                    }
                }
                catch (DbException ex)
                {
                    ShowMessageBox("Requête SQL: " + ex.Message);
                }
                finally
                {
                    if (dbDataReader != null)
                    {
                        dbDataReader.Close();
                    }
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
            table = ExecuteReader("SELECT * FROM " + GetSchema() + "FOURNIS WHERE NUMFOU='" + numfou + "'");

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
        public bool RechercherFournisseur(ref DataTable table, string nomfou)
        {
            return (
                (table = ExecuteReader("SELECT * FROM " + GetSchema() + "FOURNIS WHERE NOMFOU='" + nomfou + "'"))
                != null);
        }

        /// <summary>
        /// Remplit une liste de nom de Fournisseurs
        /// </summary>
        /// <param name="listeFournisseurs"></param>
        /// <returns></returns>
        public bool RechercherListeFournisseurs(ref DataTable table)
        {
            return (
                (table = ExecuteReader("SELECT NOMFOU FROM " + GetSchema() + "FOURNIS ORDER BY NUMFOU"))
                != null);
        }

        /// <summary>
        /// Ajout d'un enregistrement de fiche fournisseur
        /// </summary>
        /// <param name="codefou"></param>
        /// <returns></returns>
        public bool AjouterFournisseur(DataTable tableFournisseur)
        {
            return (
                ExecuteNonQuery("INSERT INTO " + GetSchema() + "FOURNIS VALUES (" +
                    "'" + tableFournisseur.Rows[0]["NUMFOU"] + "'," +
                    "'" + IsNull(tableFournisseur.Rows[0]["NOMFOU"]) + "'," +
                    "'" + IsNull(tableFournisseur.Rows[0]["RUEFOU"]) + "'," +
                    "'" + IsNull(tableFournisseur.Rows[0]["POSFOU"]) + "'," +
                    "'" + IsNull(tableFournisseur.Rows[0]["VILFOU"]) + "'," +
                    "'" + IsNull(tableFournisseur.Rows[0]["CONFOU"]) + "'," +
                    "'" + IsNull(tableFournisseur.Rows[0]["SATISF"]) + "')")
                >= 1);
        }

        /// <summary>
        /// Mise à jour d'un enregistrement de fiche fournisseur
        /// </summary>
        /// <param name="codefou"></param>
        /// <returns></returns>
        public bool ModifierFournisseur(DataTable tableFournisseur)
        {
            return (
                ExecuteNonQuery("UPDATE " + GetSchema() + "FOURNIS SET " +
                    "NOMFOU='" + IsNull(tableFournisseur.Rows[0]["NOMFOU"]) + "'," +
                    "RUEFOU='" + IsNull(tableFournisseur.Rows[0]["RUEFOU"]) + "'," +
                    "POSFOU='" + IsNull(tableFournisseur.Rows[0]["POSFOU"]) + "'," +
                    "VILFOU='" + IsNull(tableFournisseur.Rows[0]["VILFOU"]) + "'," +
                    "CONFOU='" + IsNull(tableFournisseur.Rows[0]["CONFOU"]) + "'," +
                    "SATISF='" + IsNull(tableFournisseur.Rows[0]["SATISF"]) + "'" +
                    " WHERE NUMFOU='" + tableFournisseur.Rows[0]["NUMFOU"] + "'")
                >= 1);
        }

        /// <summary>
        /// Suppression d'un fournisseur par son code
        /// </summary>
        /// <param name="tableFournisseur"></param>
        /// <returns></returns>
        public bool SupprimerFournisseur(DataTable tableFournisseur)
        {
            return (
                ExecuteNonQuery("DELETE FROM " + GetSchema() + "FOURNIS WHERE NUMFOU='" +
                    tableFournisseur.Rows[0]["NUMFOU"] + "'")
                >= 1);
        }

        /// <summary>
        /// Construit une liste de commande d'un fournisseur
        /// </summary>
        /// <param name="listeCommandes"></param>
        /// <param name="unFournisseur"></param>
        /// <returns></returns>
        public bool RechercherListeCommandes(ListView.ListViewItemCollection listeCommandes, DataTable table)
        {
            if (CheckConnectionBase())
            {
                dbCommande = dbProviderFactory.CreateCommand();
                dbCommande.CommandText = "GetEntCom";
                dbCommande.CommandType = CommandType.StoredProcedure;

                // Spécification des parametres
                DbParameter numfouParam = dbCommande.CreateParameter();
                numfouParam.Direction = ParameterDirection.Input;
                numfouParam.DbType = DbType.Int16;
                numfouParam.Value = (table != null) ? table.Rows[0]["NUMFOU"] : (-1).ToString();
                numfouParam.ParameterName = "n";
                dbCommande.Parameters.Add(numfouParam);

                dbCommande.Connection = dbConnection;

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
                                    DateTime.ParseExact(dbDataReader["DATCOM"].ToString(), "dd/MM/yyyy hh:mm:ss",  CultureInfo.InvariantCulture).ToString("d"),
                                    dbDataReader["OBSCOM"].ToString()
                                }
                            )
                        );
                    }
                }
                catch (DbException ex)
                {
                    ShowMessageBox("Erreur SQL : " + ex.Message);
                }
                finally
                {
                    if (dbDataReader != null)
                    {
                        dbDataReader.Close();
                    }
                }
            }

            return true;
        }

    }
}
