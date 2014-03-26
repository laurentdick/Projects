namespace ModeConnecte
{
    partial class ConnectionForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_Connect = new System.Windows.Forms.Button();
            this.lv_TableView = new System.Windows.Forms.ListView();
            this.NUMFOU = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NOMFOU = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RUEFOU = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.POSFOU = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.VILFOU = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CONFOU = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SATISF = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.tslbl_Status = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbl_Serveur = new System.Windows.Forms.Label();
            this.tbx_Serveur = new System.Windows.Forms.TextBox();
            this.lbl_BaseDonnees = new System.Windows.Forms.Label();
            this.tbx_BaseDonnees = new System.Windows.Forms.TextBox();
            this.btn_Disconnect = new System.Windows.Forms.Button();
            this.btn_Quitter = new System.Windows.Forms.Button();
            this.lbl_Security = new System.Windows.Forms.Label();
            this.cbx_Security = new System.Windows.Forms.ComboBox();
            this.lbl_TablePrefix = new System.Windows.Forms.Label();
            this.tbx_Schema = new System.Windows.Forms.TextBox();
            this.btn_Lire = new System.Windows.Forms.Button();
            this.menuBar = new System.Windows.Forms.MenuStrip();
            this.rechercheToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_MenuFournisseur = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_MenuListeDesCommandes = new System.Windows.Forms.ToolStripMenuItem();
            this.cbx_DriverSelect = new System.Windows.Forms.ComboBox();
            this.lbl_Driver = new System.Windows.Forms.Label();
            this.statusBar.SuspendLayout();
            this.menuBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Connect
            // 
            this.btn_Connect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Connect.Location = new System.Drawing.Point(793, 111);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(98, 32);
            this.btn_Connect.TabIndex = 5;
            this.btn_Connect.Text = "Connection";
            this.btn_Connect.UseVisualStyleBackColor = true;
            this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click);
            // 
            // lv_TableView
            // 
            this.lv_TableView.AllowColumnReorder = true;
            this.lv_TableView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lv_TableView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lv_TableView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NUMFOU,
            this.NOMFOU,
            this.RUEFOU,
            this.POSFOU,
            this.VILFOU,
            this.CONFOU,
            this.SATISF});
            this.lv_TableView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.lv_TableView.FullRowSelect = true;
            this.lv_TableView.GridLines = true;
            this.lv_TableView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lv_TableView.Location = new System.Drawing.Point(23, 137);
            this.lv_TableView.MultiSelect = false;
            this.lv_TableView.Name = "lv_TableView";
            this.lv_TableView.Size = new System.Drawing.Size(717, 318);
            this.lv_TableView.TabIndex = 6;
            this.lv_TableView.UseCompatibleStateImageBehavior = false;
            this.lv_TableView.View = System.Windows.Forms.View.Details;
            // 
            // NUMFOU
            // 
            this.NUMFOU.Text = "NUMFOU";
            // 
            // NOMFOU
            // 
            this.NOMFOU.Text = "NOMFOU";
            this.NOMFOU.Width = 150;
            // 
            // RUEFOU
            // 
            this.RUEFOU.Text = "RUEFOU";
            this.RUEFOU.Width = 150;
            // 
            // POSFOU
            // 
            this.POSFOU.Text = "POSFOU";
            this.POSFOU.Width = 80;
            // 
            // VILFOU
            // 
            this.VILFOU.Text = "VILFOU";
            this.VILFOU.Width = 120;
            // 
            // CONFOU
            // 
            this.CONFOU.Text = "CONFOU";
            this.CONFOU.Width = 98;
            // 
            // SATISF
            // 
            this.SATISF.Text = "SATISF";
            this.SATISF.Width = 55;
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslbl_Status});
            this.statusBar.Location = new System.Drawing.Point(0, 474);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(903, 22);
            this.statusBar.SizingGrip = false;
            this.statusBar.TabIndex = 16;
            // 
            // tslbl_Status
            // 
            this.tslbl_Status.Name = "tslbl_Status";
            this.tslbl_Status.Size = new System.Drawing.Size(0, 17);
            // 
            // lbl_Serveur
            // 
            this.lbl_Serveur.AutoSize = true;
            this.lbl_Serveur.ForeColor = System.Drawing.Color.Blue;
            this.lbl_Serveur.Location = new System.Drawing.Point(20, 70);
            this.lbl_Serveur.Name = "lbl_Serveur";
            this.lbl_Serveur.Size = new System.Drawing.Size(47, 13);
            this.lbl_Serveur.TabIndex = 12;
            this.lbl_Serveur.Text = "Serveur:";
            // 
            // tbx_Serveur
            // 
            this.tbx_Serveur.Location = new System.Drawing.Point(172, 67);
            this.tbx_Serveur.Name = "tbx_Serveur";
            this.tbx_Serveur.Size = new System.Drawing.Size(203, 20);
            this.tbx_Serveur.TabIndex = 1;
            // 
            // lbl_BaseDonnees
            // 
            this.lbl_BaseDonnees.AutoSize = true;
            this.lbl_BaseDonnees.ForeColor = System.Drawing.Color.Blue;
            this.lbl_BaseDonnees.Location = new System.Drawing.Point(402, 69);
            this.lbl_BaseDonnees.Name = "lbl_BaseDonnees";
            this.lbl_BaseDonnees.Size = new System.Drawing.Size(95, 13);
            this.lbl_BaseDonnees.TabIndex = 13;
            this.lbl_BaseDonnees.Text = "Base de Données:";
            // 
            // tbx_BaseDonnees
            // 
            this.tbx_BaseDonnees.Location = new System.Drawing.Point(537, 67);
            this.tbx_BaseDonnees.Name = "tbx_BaseDonnees";
            this.tbx_BaseDonnees.Size = new System.Drawing.Size(179, 20);
            this.tbx_BaseDonnees.TabIndex = 2;
            // 
            // btn_Disconnect
            // 
            this.btn_Disconnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Disconnect.Enabled = false;
            this.btn_Disconnect.Location = new System.Drawing.Point(793, 158);
            this.btn_Disconnect.Name = "btn_Disconnect";
            this.btn_Disconnect.Size = new System.Drawing.Size(98, 32);
            this.btn_Disconnect.TabIndex = 7;
            this.btn_Disconnect.Text = "Déconnection";
            this.btn_Disconnect.UseVisualStyleBackColor = true;
            this.btn_Disconnect.Click += new System.EventHandler(this.btn_Disconnect_Click);
            // 
            // btn_Quitter
            // 
            this.btn_Quitter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Quitter.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Quitter.Location = new System.Drawing.Point(793, 252);
            this.btn_Quitter.Name = "btn_Quitter";
            this.btn_Quitter.Size = new System.Drawing.Size(98, 32);
            this.btn_Quitter.TabIndex = 9;
            this.btn_Quitter.Text = "Quitter";
            this.btn_Quitter.UseVisualStyleBackColor = true;
            this.btn_Quitter.Click += new System.EventHandler(this.btn_Quitter_Click);
            // 
            // lbl_Security
            // 
            this.lbl_Security.AutoSize = true;
            this.lbl_Security.ForeColor = System.Drawing.Color.Blue;
            this.lbl_Security.Location = new System.Drawing.Point(448, 96);
            this.lbl_Security.Name = "lbl_Security";
            this.lbl_Security.Size = new System.Drawing.Size(49, 13);
            this.lbl_Security.TabIndex = 15;
            this.lbl_Security.Text = "Sécurité:";
            // 
            // cbx_Security
            // 
            this.cbx_Security.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_Security.FormattingEnabled = true;
            this.cbx_Security.Items.AddRange(new object[] {
            "Aucune",
            "Intégrée"});
            this.cbx_Security.Location = new System.Drawing.Point(537, 93);
            this.cbx_Security.Name = "cbx_Security";
            this.cbx_Security.Size = new System.Drawing.Size(179, 21);
            this.cbx_Security.TabIndex = 4;
            // 
            // lbl_TablePrefix
            // 
            this.lbl_TablePrefix.AutoSize = true;
            this.lbl_TablePrefix.ForeColor = System.Drawing.Color.Blue;
            this.lbl_TablePrefix.Location = new System.Drawing.Point(20, 96);
            this.lbl_TablePrefix.Name = "lbl_TablePrefix";
            this.lbl_TablePrefix.Size = new System.Drawing.Size(49, 13);
            this.lbl_TablePrefix.TabIndex = 14;
            this.lbl_TablePrefix.Text = "Schéma:";
            // 
            // tbx_Schema
            // 
            this.tbx_Schema.Location = new System.Drawing.Point(172, 93);
            this.tbx_Schema.Name = "tbx_Schema";
            this.tbx_Schema.Size = new System.Drawing.Size(203, 20);
            this.tbx_Schema.TabIndex = 3;
            // 
            // btn_Lire
            // 
            this.btn_Lire.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Lire.Enabled = false;
            this.btn_Lire.Location = new System.Drawing.Point(793, 205);
            this.btn_Lire.Name = "btn_Lire";
            this.btn_Lire.Size = new System.Drawing.Size(98, 32);
            this.btn_Lire.TabIndex = 8;
            this.btn_Lire.Text = "Lire";
            this.btn_Lire.UseVisualStyleBackColor = true;
            this.btn_Lire.Click += new System.EventHandler(this.btn_Lire_Click);
            // 
            // menuBar
            // 
            this.menuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rechercheToolStripMenuItem});
            this.menuBar.Location = new System.Drawing.Point(0, 0);
            this.menuBar.Name = "menuBar";
            this.menuBar.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuBar.Size = new System.Drawing.Size(903, 24);
            this.menuBar.TabIndex = 10;
            this.menuBar.Text = "menuStrip1";
            // 
            // rechercheToolStripMenuItem
            // 
            this.rechercheToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_MenuFournisseur,
            this.ts_MenuListeDesCommandes});
            this.rechercheToolStripMenuItem.Name = "rechercheToolStripMenuItem";
            this.rechercheToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.rechercheToolStripMenuItem.Text = "Fichier";
            // 
            // ts_MenuFournisseur
            // 
            this.ts_MenuFournisseur.Name = "ts_MenuFournisseur";
            this.ts_MenuFournisseur.Size = new System.Drawing.Size(188, 22);
            this.ts_MenuFournisseur.Text = "Fournisseur";
            this.ts_MenuFournisseur.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // ts_MenuListeDesCommandes
            // 
            this.ts_MenuListeDesCommandes.Name = "ts_MenuListeDesCommandes";
            this.ts_MenuListeDesCommandes.Size = new System.Drawing.Size(188, 22);
            this.ts_MenuListeDesCommandes.Text = "Liste des commandes";
            this.ts_MenuListeDesCommandes.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // cbx_DriverSelect
            // 
            this.cbx_DriverSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_DriverSelect.FormattingEnabled = true;
            this.cbx_DriverSelect.Items.AddRange(new object[] {
            "SQL Server",
            "MySql 5"});
            this.cbx_DriverSelect.Location = new System.Drawing.Point(172, 38);
            this.cbx_DriverSelect.Name = "cbx_DriverSelect";
            this.cbx_DriverSelect.Size = new System.Drawing.Size(203, 21);
            this.cbx_DriverSelect.TabIndex = 0;
            this.cbx_DriverSelect.SelectedIndexChanged += new System.EventHandler(this.cbx_SelectedIndexChanged);
            // 
            // lbl_Driver
            // 
            this.lbl_Driver.AutoSize = true;
            this.lbl_Driver.ForeColor = System.Drawing.Color.Blue;
            this.lbl_Driver.Location = new System.Drawing.Point(20, 41);
            this.lbl_Driver.Name = "lbl_Driver";
            this.lbl_Driver.Size = new System.Drawing.Size(134, 13);
            this.lbl_Driver.TabIndex = 11;
            this.lbl_Driver.Text = "Pilote de Base de données";
            // 
            // ConnectionForm
            // 
            this.AcceptButton = this.btn_Connect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Quitter;
            this.ClientSize = new System.Drawing.Size(903, 496);
            this.Controls.Add(this.cbx_DriverSelect);
            this.Controls.Add(this.btn_Lire);
            this.Controls.Add(this.cbx_Security);
            this.Controls.Add(this.btn_Quitter);
            this.Controls.Add(this.btn_Disconnect);
            this.Controls.Add(this.tbx_Schema);
            this.Controls.Add(this.tbx_BaseDonnees);
            this.Controls.Add(this.tbx_Serveur);
            this.Controls.Add(this.lbl_Security);
            this.Controls.Add(this.lbl_TablePrefix);
            this.Controls.Add(this.lbl_Driver);
            this.Controls.Add(this.lbl_BaseDonnees);
            this.Controls.Add(this.lbl_Serveur);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.menuBar);
            this.Controls.Add(this.lv_TableView);
            this.Controls.Add(this.btn_Connect);
            this.MainMenuStrip = this.menuBar;
            this.Name = "ConnectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mode Connecté";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConnectionForm_FormClosing);
            this.Shown += new System.EventHandler(this.ConnectionForm_Shown);
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.menuBar.ResumeLayout(false);
            this.menuBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Connect;
        private System.Windows.Forms.ListView lv_TableView;
        private System.Windows.Forms.ColumnHeader NUMFOU;
        private System.Windows.Forms.ColumnHeader NOMFOU;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel tslbl_Status;
        private System.Windows.Forms.Label lbl_Serveur;
        private System.Windows.Forms.TextBox tbx_Serveur;
        private System.Windows.Forms.Label lbl_BaseDonnees;
        private System.Windows.Forms.TextBox tbx_BaseDonnees;
        private System.Windows.Forms.Button btn_Disconnect;
        private System.Windows.Forms.Button btn_Quitter;
        private System.Windows.Forms.ColumnHeader RUEFOU;
        private System.Windows.Forms.ColumnHeader POSFOU;
        private System.Windows.Forms.ColumnHeader VILFOU;
        private System.Windows.Forms.Label lbl_Security;
        private System.Windows.Forms.ComboBox cbx_Security;
        private System.Windows.Forms.Label lbl_TablePrefix;
        private System.Windows.Forms.TextBox tbx_Schema;
        private System.Windows.Forms.Button btn_Lire;
        private System.Windows.Forms.MenuStrip menuBar;
        private System.Windows.Forms.ToolStripMenuItem rechercheToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ts_MenuFournisseur;
        private System.Windows.Forms.ToolStripMenuItem ts_MenuListeDesCommandes;
        private System.Windows.Forms.ColumnHeader CONFOU;
        private System.Windows.Forms.ColumnHeader SATISF;
        private System.Windows.Forms.ComboBox cbx_DriverSelect;
        private System.Windows.Forms.Label lbl_Driver;
    }
}

