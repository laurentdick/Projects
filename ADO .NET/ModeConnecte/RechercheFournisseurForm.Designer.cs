namespace ModeConnecte
{
    partial class RechercheFournisseurForm
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
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.lbl_Fournisseur = new System.Windows.Forms.Label();
            this.tbx_CodeFournisseur = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_OK
            // 
            this.btn_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_OK.Enabled = false;
            this.btn_OK.Location = new System.Drawing.Point(143, 87);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 1;
            this.btn_OK.Text = "Valider";
            this.btn_OK.UseVisualStyleBackColor = true;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Location = new System.Drawing.Point(53, 87);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 2;
            this.btn_Cancel.Text = "Annuler";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            // 
            // lbl_Fournisseur
            // 
            this.lbl_Fournisseur.AutoSize = true;
            this.lbl_Fournisseur.ForeColor = System.Drawing.Color.Blue;
            this.lbl_Fournisseur.Location = new System.Drawing.Point(14, 31);
            this.lbl_Fournisseur.Name = "lbl_Fournisseur";
            this.lbl_Fournisseur.Size = new System.Drawing.Size(95, 13);
            this.lbl_Fournisseur.TabIndex = 3;
            this.lbl_Fournisseur.Text = "Code Fournisseur :";
            // 
            // tbx_CodeFournisseur
            // 
            this.tbx_CodeFournisseur.Location = new System.Drawing.Point(143, 28);
            this.tbx_CodeFournisseur.Name = "tbx_CodeFournisseur";
            this.tbx_CodeFournisseur.Size = new System.Drawing.Size(94, 20);
            this.tbx_CodeFournisseur.TabIndex = 0;
            this.tbx_CodeFournisseur.TextChanged += new System.EventHandler(this.tbx_CodeFournisseur_TextChanged);
            // 
            // RechercheFournisseurForm
            // 
            this.AcceptButton = this.btn_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Cancel;
            this.ClientSize = new System.Drawing.Size(281, 135);
            this.Controls.Add(this.tbx_CodeFournisseur);
            this.Controls.Add(this.lbl_Fournisseur);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "RechercheFournisseurForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recherche Fournisseur";
            this.Shown += new System.EventHandler(this.RechercheFournisseurForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Label lbl_Fournisseur;
        private System.Windows.Forms.TextBox tbx_CodeFournisseur;
    }
}