namespace ModeConnecte
{
    partial class CommandesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_Fournisseur = new System.Windows.Forms.Label();
            this.cbx_ListeFournisseurs = new System.Windows.Forms.ComboBox();
            this.gbx_Commandes = new System.Windows.Forms.GroupBox();
            this.lv_Commandes = new System.Windows.Forms.ListView();
            this.columnIndex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnNumCde = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnDateCde = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnObs = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_Fermer = new System.Windows.Forms.Button();
            this.gbx_Commandes.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_Fournisseur
            // 
            this.lbl_Fournisseur.AutoSize = true;
            this.lbl_Fournisseur.ForeColor = System.Drawing.Color.Blue;
            this.lbl_Fournisseur.Location = new System.Drawing.Point(84, 37);
            this.lbl_Fournisseur.Name = "lbl_Fournisseur";
            this.lbl_Fournisseur.Size = new System.Drawing.Size(90, 13);
            this.lbl_Fournisseur.TabIndex = 3;
            this.lbl_Fournisseur.Text = "Choix Fournisseur";
            // 
            // cbx_ListeFournisseurs
            // 
            this.cbx_ListeFournisseurs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_ListeFournisseurs.FormattingEnabled = true;
            this.cbx_ListeFournisseurs.Items.AddRange(new object[] {
            "Tous"});
            this.cbx_ListeFournisseurs.Location = new System.Drawing.Point(209, 34);
            this.cbx_ListeFournisseurs.Name = "cbx_ListeFournisseurs";
            this.cbx_ListeFournisseurs.Size = new System.Drawing.Size(205, 21);
            this.cbx_ListeFournisseurs.TabIndex = 0;
            this.cbx_ListeFournisseurs.SelectedValueChanged += new System.EventHandler(this.cbx_ListeFournisseurs_SelectedValueChanged);
            // 
            // gbx_Commandes
            // 
            this.gbx_Commandes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbx_Commandes.Controls.Add(this.lv_Commandes);
            this.gbx_Commandes.ForeColor = System.Drawing.Color.Blue;
            this.gbx_Commandes.Location = new System.Drawing.Point(15, 73);
            this.gbx_Commandes.Name = "gbx_Commandes";
            this.gbx_Commandes.Padding = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.gbx_Commandes.Size = new System.Drawing.Size(485, 281);
            this.gbx_Commandes.TabIndex = 1;
            this.gbx_Commandes.TabStop = false;
            this.gbx_Commandes.Text = "Liste des Commandes";
            this.gbx_Commandes.Visible = false;
            // 
            // lv_Commandes
            // 
            this.lv_Commandes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lv_Commandes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lv_Commandes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnIndex,
            this.columnNumCde,
            this.columnDateCde,
            this.columnObs});
            this.lv_Commandes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lv_Commandes.FullRowSelect = true;
            this.lv_Commandes.GridLines = true;
            this.lv_Commandes.Location = new System.Drawing.Point(8, 23);
            this.lv_Commandes.Name = "lv_Commandes";
            this.lv_Commandes.Size = new System.Drawing.Size(469, 248);
            this.lv_Commandes.TabIndex = 0;
            this.lv_Commandes.UseCompatibleStateImageBehavior = false;
            this.lv_Commandes.View = System.Windows.Forms.View.Details;
            // 
            // columnIndex
            // 
            this.columnIndex.Text = "";
            this.columnIndex.Width = 40;
            // 
            // columnNumCde
            // 
            this.columnNumCde.Text = "N° Commande";
            this.columnNumCde.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnNumCde.Width = 91;
            // 
            // columnDateCde
            // 
            this.columnDateCde.Text = "Date Commande";
            this.columnDateCde.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnDateCde.Width = 100;
            // 
            // columnObs
            // 
            this.columnObs.Text = "Observations";
            this.columnObs.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnObs.Width = 234;
            // 
            // btn_Fermer
            // 
            this.btn_Fermer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Fermer.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_Fermer.Location = new System.Drawing.Point(417, 375);
            this.btn_Fermer.Name = "btn_Fermer";
            this.btn_Fermer.Size = new System.Drawing.Size(75, 23);
            this.btn_Fermer.TabIndex = 2;
            this.btn_Fermer.Text = "Fermer";
            this.btn_Fermer.UseVisualStyleBackColor = true;
            // 
            // ListeCommandesForm
            // 
            this.AcceptButton = this.btn_Fermer;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Fermer;
            this.ClientSize = new System.Drawing.Size(519, 421);
            this.Controls.Add(this.btn_Fermer);
            this.Controls.Add(this.gbx_Commandes);
            this.Controls.Add(this.cbx_ListeFournisseurs);
            this.Controls.Add(this.lbl_Fournisseur);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ListeCommandesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Liste des Commandes";
            this.Shown += new System.EventHandler(this.ListeCommandesForm_Shown);
            this.gbx_Commandes.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Fournisseur;
        private System.Windows.Forms.ComboBox cbx_ListeFournisseurs;
        private System.Windows.Forms.GroupBox gbx_Commandes;
        private System.Windows.Forms.Button btn_Fermer;
        private System.Windows.Forms.ListView lv_Commandes;
        private System.Windows.Forms.ColumnHeader columnIndex;
        private System.Windows.Forms.ColumnHeader columnNumCde;
        private System.Windows.Forms.ColumnHeader columnDateCde;
        private System.Windows.Forms.ColumnHeader columnObs;
    }
}