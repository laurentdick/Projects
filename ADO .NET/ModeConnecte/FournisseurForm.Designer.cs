namespace ModeConnecte
{
    partial class FournisseurForm
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
            this.lbl_Nom = new System.Windows.Forms.Label();
            this.lbl_Adresse = new System.Windows.Forms.Label();
            this.lbl_CPVille = new System.Windows.Forms.Label();
            this.lbl_Contact = new System.Windows.Forms.Label();
            this.lbl_Satisfaction = new System.Windows.Forms.Label();
            this.btn_Fermer = new System.Windows.Forms.Button();
            this.tbx_NOMFOU = new System.Windows.Forms.TextBox();
            this.tbx_RUEFOU = new System.Windows.Forms.TextBox();
            this.tbx_POSFOU = new System.Windows.Forms.TextBox();
            this.tbx_VILFOU = new System.Windows.Forms.TextBox();
            this.tbx_CONFOU = new System.Windows.Forms.TextBox();
            this.tbx_SATISF = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btn_Supprimer = new System.Windows.Forms.Button();
            this.lbl_CodeFournisseur = new System.Windows.Forms.Label();
            this.tbx_NUMFOU = new System.Windows.Forms.TextBox();
            this.gbx_InfoFournisseur = new System.Windows.Forms.GroupBox();
            this.btn_Search = new System.Windows.Forms.Button();
            this.btn_Modifier = new System.Windows.Forms.Button();
            this.btn_Nouveau = new System.Windows.Forms.Button();
            this.btn_Valider = new System.Windows.Forms.Button();
            this.btn_Annuler = new System.Windows.Forms.Button();
            this.btn_Creer = new System.Windows.Forms.Button();
            this.gbx_InfoFournisseur.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_Nom
            // 
            this.lbl_Nom.AutoSize = true;
            this.lbl_Nom.ForeColor = System.Drawing.Color.Blue;
            this.lbl_Nom.Location = new System.Drawing.Point(21, 80);
            this.lbl_Nom.Name = "lbl_Nom";
            this.lbl_Nom.Size = new System.Drawing.Size(29, 13);
            this.lbl_Nom.TabIndex = 9;
            this.lbl_Nom.Text = "Nom";
            // 
            // lbl_Adresse
            // 
            this.lbl_Adresse.AutoSize = true;
            this.lbl_Adresse.ForeColor = System.Drawing.Color.Blue;
            this.lbl_Adresse.Location = new System.Drawing.Point(21, 117);
            this.lbl_Adresse.Name = "lbl_Adresse";
            this.lbl_Adresse.Size = new System.Drawing.Size(45, 13);
            this.lbl_Adresse.TabIndex = 10;
            this.lbl_Adresse.Text = "Adresse";
            // 
            // lbl_CPVille
            // 
            this.lbl_CPVille.AutoSize = true;
            this.lbl_CPVille.ForeColor = System.Drawing.Color.Blue;
            this.lbl_CPVille.Location = new System.Drawing.Point(21, 154);
            this.lbl_CPVille.Name = "lbl_CPVille";
            this.lbl_CPVille.Size = new System.Drawing.Size(51, 13);
            this.lbl_CPVille.TabIndex = 11;
            this.lbl_CPVille.Text = "CP / Ville";
            // 
            // lbl_Contact
            // 
            this.lbl_Contact.AutoSize = true;
            this.lbl_Contact.ForeColor = System.Drawing.Color.Blue;
            this.lbl_Contact.Location = new System.Drawing.Point(21, 191);
            this.lbl_Contact.Name = "lbl_Contact";
            this.lbl_Contact.Size = new System.Drawing.Size(44, 13);
            this.lbl_Contact.TabIndex = 12;
            this.lbl_Contact.Text = "Contact";
            // 
            // lbl_Satisfaction
            // 
            this.lbl_Satisfaction.AutoSize = true;
            this.lbl_Satisfaction.ForeColor = System.Drawing.Color.Blue;
            this.lbl_Satisfaction.Location = new System.Drawing.Point(21, 228);
            this.lbl_Satisfaction.Name = "lbl_Satisfaction";
            this.lbl_Satisfaction.Size = new System.Drawing.Size(62, 13);
            this.lbl_Satisfaction.TabIndex = 13;
            this.lbl_Satisfaction.Text = "Satisfaction";
            // 
            // btn_Fermer
            // 
            this.btn_Fermer.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Fermer.Location = new System.Drawing.Point(319, 318);
            this.btn_Fermer.Name = "btn_Fermer";
            this.btn_Fermer.Size = new System.Drawing.Size(75, 23);
            this.btn_Fermer.TabIndex = 1;
            this.btn_Fermer.Text = "Fermer";
            this.btn_Fermer.UseVisualStyleBackColor = true;
            // 
            // tbx_NOMFOU
            // 
            this.tbx_NOMFOU.BackColor = System.Drawing.SystemColors.Window;
            this.tbx_NOMFOU.Enabled = false;
            this.tbx_NOMFOU.Location = new System.Drawing.Point(138, 77);
            this.tbx_NOMFOU.Name = "tbx_NOMFOU";
            this.tbx_NOMFOU.Size = new System.Drawing.Size(244, 20);
            this.tbx_NOMFOU.TabIndex = 1;
            // 
            // tbx_RUEFOU
            // 
            this.tbx_RUEFOU.BackColor = System.Drawing.SystemColors.Window;
            this.tbx_RUEFOU.Enabled = false;
            this.tbx_RUEFOU.Location = new System.Drawing.Point(138, 114);
            this.tbx_RUEFOU.Name = "tbx_RUEFOU";
            this.tbx_RUEFOU.Size = new System.Drawing.Size(244, 20);
            this.tbx_RUEFOU.TabIndex = 2;
            // 
            // tbx_POSFOU
            // 
            this.tbx_POSFOU.BackColor = System.Drawing.SystemColors.Window;
            this.tbx_POSFOU.Enabled = false;
            this.tbx_POSFOU.Location = new System.Drawing.Point(138, 151);
            this.tbx_POSFOU.Name = "tbx_POSFOU";
            this.tbx_POSFOU.Size = new System.Drawing.Size(87, 20);
            this.tbx_POSFOU.TabIndex = 3;
            // 
            // tbx_VILFOU
            // 
            this.tbx_VILFOU.BackColor = System.Drawing.SystemColors.Window;
            this.tbx_VILFOU.Enabled = false;
            this.tbx_VILFOU.Location = new System.Drawing.Point(231, 151);
            this.tbx_VILFOU.Name = "tbx_VILFOU";
            this.tbx_VILFOU.Size = new System.Drawing.Size(151, 20);
            this.tbx_VILFOU.TabIndex = 4;
            // 
            // tbx_CONFOU
            // 
            this.tbx_CONFOU.BackColor = System.Drawing.SystemColors.Window;
            this.tbx_CONFOU.Enabled = false;
            this.tbx_CONFOU.Location = new System.Drawing.Point(138, 188);
            this.tbx_CONFOU.Name = "tbx_CONFOU";
            this.tbx_CONFOU.Size = new System.Drawing.Size(244, 20);
            this.tbx_CONFOU.TabIndex = 5;
            // 
            // tbx_SATISF
            // 
            this.tbx_SATISF.BackColor = System.Drawing.SystemColors.Window;
            this.tbx_SATISF.Enabled = false;
            this.tbx_SATISF.Location = new System.Drawing.Point(138, 225);
            this.tbx_SATISF.Name = "tbx_SATISF";
            this.tbx_SATISF.Size = new System.Drawing.Size(87, 20);
            this.tbx_SATISF.TabIndex = 6;
            // 
            // btn_Supprimer
            // 
            this.btn_Supprimer.Enabled = false;
            this.btn_Supprimer.Location = new System.Drawing.Point(220, 318);
            this.btn_Supprimer.Name = "btn_Supprimer";
            this.btn_Supprimer.Size = new System.Drawing.Size(75, 23);
            this.btn_Supprimer.TabIndex = 2;
            this.btn_Supprimer.Text = "Supprimer";
            this.btn_Supprimer.UseVisualStyleBackColor = true;
            this.btn_Supprimer.Click += new System.EventHandler(this.btn_Supprimer_Click);
            // 
            // lbl_CodeFournisseur
            // 
            this.lbl_CodeFournisseur.AutoSize = true;
            this.lbl_CodeFournisseur.ForeColor = System.Drawing.Color.Blue;
            this.lbl_CodeFournisseur.Location = new System.Drawing.Point(21, 43);
            this.lbl_CodeFournisseur.Name = "lbl_CodeFournisseur";
            this.lbl_CodeFournisseur.Size = new System.Drawing.Size(32, 13);
            this.lbl_CodeFournisseur.TabIndex = 8;
            this.lbl_CodeFournisseur.Text = "Code";
            // 
            // tbx_NUMFOU
            // 
            this.tbx_NUMFOU.Location = new System.Drawing.Point(138, 40);
            this.tbx_NUMFOU.Name = "tbx_NUMFOU";
            this.tbx_NUMFOU.Size = new System.Drawing.Size(87, 20);
            this.tbx_NUMFOU.TabIndex = 0;
            this.tbx_NUMFOU.TextChanged += new System.EventHandler(this.tbx_Code_TextChanged);
            // 
            // gbx_InfoFournisseur
            // 
            this.gbx_InfoFournisseur.Controls.Add(this.btn_Search);
            this.gbx_InfoFournisseur.Controls.Add(this.lbl_Contact);
            this.gbx_InfoFournisseur.Controls.Add(this.tbx_VILFOU);
            this.gbx_InfoFournisseur.Controls.Add(this.lbl_Nom);
            this.gbx_InfoFournisseur.Controls.Add(this.tbx_NUMFOU);
            this.gbx_InfoFournisseur.Controls.Add(this.lbl_CodeFournisseur);
            this.gbx_InfoFournisseur.Controls.Add(this.tbx_POSFOU);
            this.gbx_InfoFournisseur.Controls.Add(this.tbx_SATISF);
            this.gbx_InfoFournisseur.Controls.Add(this.lbl_Adresse);
            this.gbx_InfoFournisseur.Controls.Add(this.tbx_CONFOU);
            this.gbx_InfoFournisseur.Controls.Add(this.lbl_CPVille);
            this.gbx_InfoFournisseur.Controls.Add(this.tbx_RUEFOU);
            this.gbx_InfoFournisseur.Controls.Add(this.lbl_Satisfaction);
            this.gbx_InfoFournisseur.Controls.Add(this.tbx_NOMFOU);
            this.gbx_InfoFournisseur.ForeColor = System.Drawing.Color.Blue;
            this.gbx_InfoFournisseur.Location = new System.Drawing.Point(12, 12);
            this.gbx_InfoFournisseur.Name = "gbx_InfoFournisseur";
            this.gbx_InfoFournisseur.Size = new System.Drawing.Size(398, 288);
            this.gbx_InfoFournisseur.TabIndex = 0;
            this.gbx_InfoFournisseur.TabStop = false;
            this.gbx_InfoFournisseur.Text = "Informations Fournisseur";
            // 
            // btn_Search
            // 
            this.btn_Search.Enabled = false;
            this.btn_Search.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_Search.Location = new System.Drawing.Point(282, 38);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(100, 23);
            this.btn_Search.TabIndex = 7;
            this.btn_Search.Text = "Rechercher";
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // btn_Modifier
            // 
            this.btn_Modifier.Enabled = false;
            this.btn_Modifier.Location = new System.Drawing.Point(139, 318);
            this.btn_Modifier.Name = "btn_Modifier";
            this.btn_Modifier.Size = new System.Drawing.Size(75, 23);
            this.btn_Modifier.TabIndex = 2;
            this.btn_Modifier.Text = "Modifier";
            this.btn_Modifier.UseVisualStyleBackColor = true;
            this.btn_Modifier.Click += new System.EventHandler(this.btn_Modifier_Click);
            // 
            // btn_Nouveau
            // 
            this.btn_Nouveau.Location = new System.Drawing.Point(58, 318);
            this.btn_Nouveau.Name = "btn_Nouveau";
            this.btn_Nouveau.Size = new System.Drawing.Size(75, 23);
            this.btn_Nouveau.TabIndex = 2;
            this.btn_Nouveau.Text = "Nouveau";
            this.btn_Nouveau.UseVisualStyleBackColor = true;
            this.btn_Nouveau.Click += new System.EventHandler(this.btn_Nouveau_Click);
            // 
            // btn_Valider
            // 
            this.btn_Valider.Location = new System.Drawing.Point(319, 318);
            this.btn_Valider.Name = "btn_Valider";
            this.btn_Valider.Size = new System.Drawing.Size(75, 23);
            this.btn_Valider.TabIndex = 14;
            this.btn_Valider.Text = "Valider";
            this.btn_Valider.UseVisualStyleBackColor = true;
            this.btn_Valider.Visible = false;
            this.btn_Valider.Click += new System.EventHandler(this.btn_Modifier_Click);
            // 
            // btn_Annuler
            // 
            this.btn_Annuler.Location = new System.Drawing.Point(221, 318);
            this.btn_Annuler.Name = "btn_Annuler";
            this.btn_Annuler.Size = new System.Drawing.Size(75, 23);
            this.btn_Annuler.TabIndex = 15;
            this.btn_Annuler.Text = "Annuler";
            this.btn_Annuler.UseVisualStyleBackColor = true;
            this.btn_Annuler.Visible = false;
            this.btn_Annuler.Click += new System.EventHandler(this.btn_Annuler_Click);
            // 
            // btn_Creer
            // 
            this.btn_Creer.Location = new System.Drawing.Point(319, 318);
            this.btn_Creer.Name = "btn_Creer";
            this.btn_Creer.Size = new System.Drawing.Size(75, 23);
            this.btn_Creer.TabIndex = 16;
            this.btn_Creer.Text = "Créer";
            this.btn_Creer.UseVisualStyleBackColor = true;
            this.btn_Creer.Click += new System.EventHandler(this.btn_Nouveau_Click);
            // 
            // FournisseurForm
            // 
            this.AcceptButton = this.btn_Search;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Fermer;
            this.ClientSize = new System.Drawing.Size(422, 353);
            this.Controls.Add(this.btn_Creer);
            this.Controls.Add(this.btn_Annuler);
            this.Controls.Add(this.btn_Valider);
            this.Controls.Add(this.gbx_InfoFournisseur);
            this.Controls.Add(this.btn_Nouveau);
            this.Controls.Add(this.btn_Modifier);
            this.Controls.Add(this.btn_Supprimer);
            this.Controls.Add(this.btn_Fermer);
            this.Name = "FournisseurForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fournisseur";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AffichageFournisseurForm_FormClosing);
            this.Shown += new System.EventHandler(this.AffichageFournisseurForm_Shown);
            this.gbx_InfoFournisseur.ResumeLayout(false);
            this.gbx_InfoFournisseur.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_Nom;
        private System.Windows.Forms.Label lbl_Adresse;
        private System.Windows.Forms.Label lbl_CPVille;
        private System.Windows.Forms.Label lbl_Contact;
        private System.Windows.Forms.Label lbl_Satisfaction;
        private System.Windows.Forms.Button btn_Fermer;
        private System.Windows.Forms.TextBox tbx_NOMFOU;
        private System.Windows.Forms.TextBox tbx_RUEFOU;
        private System.Windows.Forms.TextBox tbx_POSFOU;
        private System.Windows.Forms.TextBox tbx_VILFOU;
        private System.Windows.Forms.TextBox tbx_CONFOU;
        private System.Windows.Forms.TextBox tbx_SATISF;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btn_Supprimer;
        private System.Windows.Forms.Label lbl_CodeFournisseur;
        private System.Windows.Forms.TextBox tbx_NUMFOU;
        private System.Windows.Forms.GroupBox gbx_InfoFournisseur;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.Button btn_Modifier;
        private System.Windows.Forms.Button btn_Nouveau;
        private System.Windows.Forms.Button btn_Valider;
        private System.Windows.Forms.Button btn_Annuler;
        private System.Windows.Forms.Button btn_Creer;
    }
}