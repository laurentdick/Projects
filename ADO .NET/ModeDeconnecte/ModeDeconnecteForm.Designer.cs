namespace ModeDeconnecte
{
    partial class ModeDeconnecteForm
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
            this.btn_Quit = new System.Windows.Forms.Button();
            this.tbx_CODART = new System.Windows.Forms.TextBox();
            this.tbx_LIBART = new System.Windows.Forms.TextBox();
            this.tbx_STKALE = new System.Windows.Forms.TextBox();
            this.tbx_STKPHY = new System.Windows.Forms.TextBox();
            this.tbx_QTEANN = new System.Windows.Forms.TextBox();
            this.tbx_UNIMES = new System.Windows.Forms.TextBox();
            this.lbl_Code = new System.Windows.Forms.Label();
            this.lbl_Libelle = new System.Windows.Forms.Label();
            this.lbl_StockAlerte = new System.Windows.Forms.Label();
            this.lbl_StockPhysique = new System.Windows.Forms.Label();
            this.lbl_QuantiteAnnuelle = new System.Windows.Forms.Label();
            this.lbl_UniteMesure = new System.Windows.Forms.Label();
            this.lbl_ListeProduits = new System.Windows.Forms.Label();
            this.lbx_ListeProduits = new System.Windows.Forms.ListBox();
            this.papyrusDataSet1 = new ModeDeconnecte.PapyrusDataSet();
            this.produitTableAdapter1 = new ModeDeconnecte.PapyrusDataSetTableAdapters.PRODUITTableAdapter();
            this.btn_MAJ = new System.Windows.Forms.Button();
            this.pnl_Values = new System.Windows.Forms.Panel();
            this.btn_Annuler = new System.Windows.Forms.Button();
            this.btn_Valider = new System.Windows.Forms.Button();
            this.btn_Refill = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.papyrusDataSet1)).BeginInit();
            this.pnl_Values.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Quit
            // 
            this.btn_Quit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Quit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Quit.Location = new System.Drawing.Point(544, 348);
            this.btn_Quit.Name = "btn_Quit";
            this.btn_Quit.Size = new System.Drawing.Size(75, 23);
            this.btn_Quit.TabIndex = 4;
            this.btn_Quit.Text = "Quitter";
            this.btn_Quit.UseVisualStyleBackColor = true;
            this.btn_Quit.Click += new System.EventHandler(this.btn_Quit_Click);
            // 
            // tbx_CODART
            // 
            this.tbx_CODART.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbx_CODART.Location = new System.Drawing.Point(129, 15);
            this.tbx_CODART.MaxLength = 4;
            this.tbx_CODART.Name = "tbx_CODART";
            this.tbx_CODART.Size = new System.Drawing.Size(147, 20);
            this.tbx_CODART.TabIndex = 0;
            this.tbx_CODART.Tag = "CODART";
            this.tbx_CODART.TextChanged += new System.EventHandler(this.tbx_TextChanged);
            // 
            // tbx_LIBART
            // 
            this.tbx_LIBART.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbx_LIBART.Location = new System.Drawing.Point(129, 53);
            this.tbx_LIBART.MaxLength = 30;
            this.tbx_LIBART.Name = "tbx_LIBART";
            this.tbx_LIBART.Size = new System.Drawing.Size(147, 20);
            this.tbx_LIBART.TabIndex = 1;
            this.tbx_LIBART.Tag = "LIBART";
            this.tbx_LIBART.TextChanged += new System.EventHandler(this.tbx_TextChanged);
            // 
            // tbx_STKALE
            // 
            this.tbx_STKALE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbx_STKALE.Location = new System.Drawing.Point(129, 91);
            this.tbx_STKALE.Name = "tbx_STKALE";
            this.tbx_STKALE.Size = new System.Drawing.Size(147, 20);
            this.tbx_STKALE.TabIndex = 2;
            this.tbx_STKALE.Tag = "STKALE";
            this.tbx_STKALE.TextChanged += new System.EventHandler(this.tbx_TextChanged);
            // 
            // tbx_STKPHY
            // 
            this.tbx_STKPHY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbx_STKPHY.Location = new System.Drawing.Point(129, 129);
            this.tbx_STKPHY.Name = "tbx_STKPHY";
            this.tbx_STKPHY.Size = new System.Drawing.Size(147, 20);
            this.tbx_STKPHY.TabIndex = 3;
            this.tbx_STKPHY.Tag = "STKPHY";
            this.tbx_STKPHY.TextChanged += new System.EventHandler(this.tbx_TextChanged);
            // 
            // tbx_QTEANN
            // 
            this.tbx_QTEANN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbx_QTEANN.Location = new System.Drawing.Point(129, 167);
            this.tbx_QTEANN.Name = "tbx_QTEANN";
            this.tbx_QTEANN.Size = new System.Drawing.Size(147, 20);
            this.tbx_QTEANN.TabIndex = 4;
            this.tbx_QTEANN.Tag = "QTEANN";
            this.tbx_QTEANN.TextChanged += new System.EventHandler(this.tbx_TextChanged);
            // 
            // tbx_UNIMES
            // 
            this.tbx_UNIMES.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbx_UNIMES.Location = new System.Drawing.Point(129, 205);
            this.tbx_UNIMES.MaxLength = 5;
            this.tbx_UNIMES.Name = "tbx_UNIMES";
            this.tbx_UNIMES.Size = new System.Drawing.Size(147, 20);
            this.tbx_UNIMES.TabIndex = 5;
            this.tbx_UNIMES.Tag = "UNIMES";
            this.tbx_UNIMES.TextChanged += new System.EventHandler(this.tbx_TextChanged);
            // 
            // lbl_Code
            // 
            this.lbl_Code.AutoSize = true;
            this.lbl_Code.ForeColor = System.Drawing.Color.Blue;
            this.lbl_Code.Location = new System.Drawing.Point(12, 18);
            this.lbl_Code.Name = "lbl_Code";
            this.lbl_Code.Size = new System.Drawing.Size(32, 13);
            this.lbl_Code.TabIndex = 8;
            this.lbl_Code.Text = "Code";
            // 
            // lbl_Libelle
            // 
            this.lbl_Libelle.AutoSize = true;
            this.lbl_Libelle.ForeColor = System.Drawing.Color.Blue;
            this.lbl_Libelle.Location = new System.Drawing.Point(12, 56);
            this.lbl_Libelle.Name = "lbl_Libelle";
            this.lbl_Libelle.Size = new System.Drawing.Size(37, 13);
            this.lbl_Libelle.TabIndex = 9;
            this.lbl_Libelle.Text = "Libellé";
            // 
            // lbl_StockAlerte
            // 
            this.lbl_StockAlerte.AutoSize = true;
            this.lbl_StockAlerte.ForeColor = System.Drawing.Color.Blue;
            this.lbl_StockAlerte.Location = new System.Drawing.Point(12, 94);
            this.lbl_StockAlerte.Name = "lbl_StockAlerte";
            this.lbl_StockAlerte.Size = new System.Drawing.Size(72, 13);
            this.lbl_StockAlerte.TabIndex = 10;
            this.lbl_StockAlerte.Text = "Stock d\'alerte";
            // 
            // lbl_StockPhysique
            // 
            this.lbl_StockPhysique.AutoSize = true;
            this.lbl_StockPhysique.ForeColor = System.Drawing.Color.Blue;
            this.lbl_StockPhysique.Location = new System.Drawing.Point(12, 132);
            this.lbl_StockPhysique.Name = "lbl_StockPhysique";
            this.lbl_StockPhysique.Size = new System.Drawing.Size(80, 13);
            this.lbl_StockPhysique.TabIndex = 11;
            this.lbl_StockPhysique.Text = "Stock physique";
            // 
            // lbl_QuantiteAnnuelle
            // 
            this.lbl_QuantiteAnnuelle.AutoSize = true;
            this.lbl_QuantiteAnnuelle.ForeColor = System.Drawing.Color.Blue;
            this.lbl_QuantiteAnnuelle.Location = new System.Drawing.Point(12, 170);
            this.lbl_QuantiteAnnuelle.Name = "lbl_QuantiteAnnuelle";
            this.lbl_QuantiteAnnuelle.Size = new System.Drawing.Size(90, 13);
            this.lbl_QuantiteAnnuelle.TabIndex = 12;
            this.lbl_QuantiteAnnuelle.Text = "Quantité annuelle";
            // 
            // lbl_UniteMesure
            // 
            this.lbl_UniteMesure.AutoSize = true;
            this.lbl_UniteMesure.ForeColor = System.Drawing.Color.Blue;
            this.lbl_UniteMesure.Location = new System.Drawing.Point(12, 208);
            this.lbl_UniteMesure.Name = "lbl_UniteMesure";
            this.lbl_UniteMesure.Size = new System.Drawing.Size(84, 13);
            this.lbl_UniteMesure.TabIndex = 13;
            this.lbl_UniteMesure.Text = "Unité de mesure";
            // 
            // lbl_ListeProduits
            // 
            this.lbl_ListeProduits.AutoSize = true;
            this.lbl_ListeProduits.ForeColor = System.Drawing.Color.Blue;
            this.lbl_ListeProduits.Location = new System.Drawing.Point(34, 27);
            this.lbl_ListeProduits.Name = "lbl_ListeProduits";
            this.lbl_ListeProduits.Size = new System.Drawing.Size(89, 13);
            this.lbl_ListeProduits.TabIndex = 5;
            this.lbl_ListeProduits.Text = "Liste des produits";
            // 
            // lbx_ListeProduits
            // 
            this.lbx_ListeProduits.FormattingEnabled = true;
            this.lbx_ListeProduits.Location = new System.Drawing.Point(37, 57);
            this.lbx_ListeProduits.Name = "lbx_ListeProduits";
            this.lbx_ListeProduits.Size = new System.Drawing.Size(252, 121);
            this.lbx_ListeProduits.TabIndex = 0;
            this.lbx_ListeProduits.SelectedIndexChanged += new System.EventHandler(this.lbx_ListeProduits_SelectedIndexChanged);
            // 
            // papyrusDataSet1
            // 
            this.papyrusDataSet1.DataSetName = "PapyrusDataSet";
            this.papyrusDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // produitTableAdapter1
            // 
            this.produitTableAdapter1.ClearBeforeFill = true;
            // 
            // btn_MAJ
            // 
            this.btn_MAJ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_MAJ.Location = new System.Drawing.Point(447, 348);
            this.btn_MAJ.Name = "btn_MAJ";
            this.btn_MAJ.Size = new System.Drawing.Size(75, 23);
            this.btn_MAJ.TabIndex = 3;
            this.btn_MAJ.Text = "MAJ Base";
            this.btn_MAJ.UseVisualStyleBackColor = true;
            this.btn_MAJ.Click += new System.EventHandler(this.LoadListeProduits);
            // 
            // pnl_Values
            // 
            this.pnl_Values.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnl_Values.Controls.Add(this.btn_Annuler);
            this.pnl_Values.Controls.Add(this.btn_Valider);
            this.pnl_Values.Controls.Add(this.lbl_Code);
            this.pnl_Values.Controls.Add(this.tbx_CODART);
            this.pnl_Values.Controls.Add(this.tbx_LIBART);
            this.pnl_Values.Controls.Add(this.tbx_STKALE);
            this.pnl_Values.Controls.Add(this.lbl_UniteMesure);
            this.pnl_Values.Controls.Add(this.tbx_STKPHY);
            this.pnl_Values.Controls.Add(this.lbl_QuantiteAnnuelle);
            this.pnl_Values.Controls.Add(this.tbx_QTEANN);
            this.pnl_Values.Controls.Add(this.lbl_StockPhysique);
            this.pnl_Values.Controls.Add(this.tbx_UNIMES);
            this.pnl_Values.Controls.Add(this.lbl_StockAlerte);
            this.pnl_Values.Controls.Add(this.lbl_Libelle);
            this.pnl_Values.Location = new System.Drawing.Point(307, 27);
            this.pnl_Values.Name = "pnl_Values";
            this.pnl_Values.Size = new System.Drawing.Size(300, 294);
            this.pnl_Values.TabIndex = 1;
            // 
            // btn_Annuler
            // 
            this.btn_Annuler.Location = new System.Drawing.Point(107, 252);
            this.btn_Annuler.Name = "btn_Annuler";
            this.btn_Annuler.Size = new System.Drawing.Size(75, 23);
            this.btn_Annuler.TabIndex = 6;
            this.btn_Annuler.Text = "Annuler";
            this.btn_Annuler.UseVisualStyleBackColor = true;
            this.btn_Annuler.Click += new System.EventHandler(this.btn_Annuler_Click);
            // 
            // btn_Valider
            // 
            this.btn_Valider.Location = new System.Drawing.Point(203, 252);
            this.btn_Valider.Name = "btn_Valider";
            this.btn_Valider.Size = new System.Drawing.Size(75, 23);
            this.btn_Valider.TabIndex = 7;
            this.btn_Valider.Text = "Valider";
            this.btn_Valider.UseVisualStyleBackColor = true;
            this.btn_Valider.Click += new System.EventHandler(this.btn_Valider_Click);
            // 
            // btn_Refill
            // 
            this.btn_Refill.Location = new System.Drawing.Point(350, 348);
            this.btn_Refill.Name = "btn_Refill";
            this.btn_Refill.Size = new System.Drawing.Size(75, 23);
            this.btn_Refill.TabIndex = 2;
            this.btn_Refill.Text = "Recharger";
            this.btn_Refill.UseVisualStyleBackColor = true;
            this.btn_Refill.Click += new System.EventHandler(this.LoadListeProduits);
            // 
            // ModeDeconnecteForm
            // 
            this.AcceptButton = this.btn_Refill;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Quit;
            this.ClientSize = new System.Drawing.Size(638, 388);
            this.Controls.Add(this.btn_Refill);
            this.Controls.Add(this.pnl_Values);
            this.Controls.Add(this.btn_MAJ);
            this.Controls.Add(this.lbx_ListeProduits);
            this.Controls.Add(this.lbl_ListeProduits);
            this.Controls.Add(this.btn_Quit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ModeDeconnecteForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Affichage des Produits";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ModeDeconnecteForm_FormClosing);
            this.Shown += new System.EventHandler(this.ModeDeconnecteForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.papyrusDataSet1)).EndInit();
            this.pnl_Values.ResumeLayout(false);
            this.pnl_Values.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Quit;
        private System.Windows.Forms.TextBox tbx_CODART;
        private System.Windows.Forms.TextBox tbx_LIBART;
        private System.Windows.Forms.TextBox tbx_STKALE;
        private System.Windows.Forms.TextBox tbx_STKPHY;
        private System.Windows.Forms.TextBox tbx_QTEANN;
        private System.Windows.Forms.TextBox tbx_UNIMES;
        private System.Windows.Forms.Label lbl_Code;
        private System.Windows.Forms.Label lbl_Libelle;
        private System.Windows.Forms.Label lbl_StockAlerte;
        private System.Windows.Forms.Label lbl_StockPhysique;
        private System.Windows.Forms.Label lbl_QuantiteAnnuelle;
        private System.Windows.Forms.Label lbl_UniteMesure;
        private System.Windows.Forms.Label lbl_ListeProduits;
        private System.Windows.Forms.ListBox lbx_ListeProduits;
        private PapyrusDataSet papyrusDataSet1;
        private PapyrusDataSetTableAdapters.PRODUITTableAdapter produitTableAdapter1;
        private System.Windows.Forms.Button btn_MAJ;
        private System.Windows.Forms.Panel pnl_Values;
        private System.Windows.Forms.Button btn_Annuler;
        private System.Windows.Forms.Button btn_Valider;
        private System.Windows.Forms.Button btn_Refill;
    }
}

