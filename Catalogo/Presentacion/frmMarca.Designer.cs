
namespace Presentacion
{
    partial class frmMarca
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
            this.lblMarcaNueva = new System.Windows.Forms.Label();
            this.txtMarcaNueva = new System.Windows.Forms.TextBox();
            this.btnMarcaNueva = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblMarcaNueva
            // 
            this.lblMarcaNueva.AutoSize = true;
            this.lblMarcaNueva.Location = new System.Drawing.Point(93, 87);
            this.lblMarcaNueva.Name = "lblMarcaNueva";
            this.lblMarcaNueva.Size = new System.Drawing.Size(51, 15);
            this.lblMarcaNueva.TabIndex = 1;
            this.lblMarcaNueva.Text = "Nombre";
            // 
            // txtMarcaNueva
            // 
            this.txtMarcaNueva.Location = new System.Drawing.Point(159, 84);
            this.txtMarcaNueva.Name = "txtMarcaNueva";
            this.txtMarcaNueva.Size = new System.Drawing.Size(100, 23);
            this.txtMarcaNueva.TabIndex = 3;
            // 
            // btnMarcaNueva
            // 
            this.btnMarcaNueva.Location = new System.Drawing.Point(281, 83);
            this.btnMarcaNueva.Name = "btnMarcaNueva";
            this.btnMarcaNueva.Size = new System.Drawing.Size(75, 23);
            this.btnMarcaNueva.TabIndex = 4;
            this.btnMarcaNueva.Text = "Aceptar";
            this.btnMarcaNueva.UseVisualStyleBackColor = true;
            this.btnMarcaNueva.Click += new System.EventHandler(this.btnMarcaNueva_Click);
            // 
            // frmMarca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 213);
            this.Controls.Add(this.btnMarcaNueva);
            this.Controls.Add(this.txtMarcaNueva);
            this.Controls.Add(this.lblMarcaNueva);
            this.Name = "frmMarca";
            this.Text = "Nueva marca";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMarcaNueva;
        private System.Windows.Forms.TextBox txtMarcaNueva;
        private System.Windows.Forms.Button btnMarcaNueva;
    }
}