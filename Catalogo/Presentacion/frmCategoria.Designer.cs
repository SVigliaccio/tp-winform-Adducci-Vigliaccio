
namespace Presentacion
{
    partial class frmCategoria
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
            this.lblCategoriaNueva = new System.Windows.Forms.Label();
            this.txtCategoriaNueva = new System.Windows.Forms.TextBox();
            this.btnCategoriaNueva = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblCategoriaNueva
            // 
            this.lblCategoriaNueva.AutoSize = true;
            this.lblCategoriaNueva.Location = new System.Drawing.Point(86, 92);
            this.lblCategoriaNueva.Name = "lblCategoriaNueva";
            this.lblCategoriaNueva.Size = new System.Drawing.Size(54, 15);
            this.lblCategoriaNueva.TabIndex = 0;
            this.lblCategoriaNueva.Text = "Nombre:";
            // 
            // txtCategoriaNueva
            // 
            this.txtCategoriaNueva.Location = new System.Drawing.Point(141, 88);
            this.txtCategoriaNueva.Name = "txtCategoriaNueva";
            this.txtCategoriaNueva.Size = new System.Drawing.Size(113, 23);
            this.txtCategoriaNueva.TabIndex = 1;
            // 
            // btnCategoriaNueva
            // 
            this.btnCategoriaNueva.Location = new System.Drawing.Point(260, 88);
            this.btnCategoriaNueva.Name = "btnCategoriaNueva";
            this.btnCategoriaNueva.Size = new System.Drawing.Size(75, 23);
            this.btnCategoriaNueva.TabIndex = 2;
            this.btnCategoriaNueva.Text = "Aceptar";
            this.btnCategoriaNueva.UseVisualStyleBackColor = true;
            this.btnCategoriaNueva.Click += new System.EventHandler(this.btnCategoriaNueva_Click);
            // 
            // frmCategoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 227);
            this.Controls.Add(this.btnCategoriaNueva);
            this.Controls.Add(this.txtCategoriaNueva);
            this.Controls.Add(this.lblCategoriaNueva);
            this.Name = "frmCategoria";
            this.Text = "Nueva categoria";
            this.Load += new System.EventHandler(this.frmCategoria_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCategoriaNueva;
        private System.Windows.Forms.TextBox txtCategoriaNueva;
        private System.Windows.Forms.Button btnCategoriaNueva;
    }
}