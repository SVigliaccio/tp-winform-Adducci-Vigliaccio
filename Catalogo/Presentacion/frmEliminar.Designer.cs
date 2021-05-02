
namespace Presentacion
{
    partial class frmEliminar
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
            this.btnBorrar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.cmbMarca = new System.Windows.Forms.ComboBox();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.chkActivarmarcas = new System.Windows.Forms.CheckBox();
            this.chkActivarCategorias = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnBorrar
            // 
            this.btnBorrar.Location = new System.Drawing.Point(65, 101);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(75, 23);
            this.btnBorrar.TabIndex = 5;
            this.btnBorrar.Text = "Borrar";
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(190, 101);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 6;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // cmbMarca
            // 
            this.cmbMarca.FormattingEnabled = true;
            this.cmbMarca.Location = new System.Drawing.Point(13, 35);
            this.cmbMarca.Name = "cmbMarca";
            this.cmbMarca.Size = new System.Drawing.Size(155, 23);
            this.cmbMarca.TabIndex = 9;
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new System.Drawing.Point(174, 35);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(155, 23);
            this.cmbCategoria.TabIndex = 12;
            // 
            // chkActivarmarcas
            // 
            this.chkActivarmarcas.AutoSize = true;
            this.chkActivarmarcas.Location = new System.Drawing.Point(13, 14);
            this.chkActivarmarcas.Name = "chkActivarmarcas";
            this.chkActivarmarcas.Size = new System.Drawing.Size(112, 19);
            this.chkActivarmarcas.TabIndex = 13;
            this.chkActivarmarcas.Text = "Habilitar Marcas";
            this.chkActivarmarcas.UseVisualStyleBackColor = true;
            this.chkActivarmarcas.CheckedChanged += new System.EventHandler(this.chkActivarmarcas_CheckedChanged);
            // 
            // chkActivarCategorias
            // 
            this.chkActivarCategorias.AutoSize = true;
            this.chkActivarCategorias.Location = new System.Drawing.Point(174, 14);
            this.chkActivarCategorias.Name = "chkActivarCategorias";
            this.chkActivarCategorias.Size = new System.Drawing.Size(130, 19);
            this.chkActivarCategorias.TabIndex = 14;
            this.chkActivarCategorias.Text = "Habilitar Categorías";
            this.chkActivarCategorias.UseVisualStyleBackColor = true;
            this.chkActivarCategorias.CheckedChanged += new System.EventHandler(this.chkActivarCategorias_CheckedChanged);
            // 
            // frmEliminar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 155);
            this.Controls.Add(this.chkActivarCategorias);
            this.Controls.Add(this.chkActivarmarcas);
            this.Controls.Add(this.cmbCategoria);
            this.Controls.Add(this.cmbMarca);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnBorrar);
            this.Name = "frmEliminar";
            this.Text = "Eliminar";
            this.Load += new System.EventHandler(this.frmEliminar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.ComboBox cmbMarca;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.CheckBox chkActivarmarcas;
        private System.Windows.Forms.CheckBox chkActivarCategorias;
    }
}