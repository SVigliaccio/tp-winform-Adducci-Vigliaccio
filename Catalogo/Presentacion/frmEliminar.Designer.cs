
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
            this.cmbArticulo = new System.Windows.Forms.ComboBox();
            this.cmbMarca = new System.Windows.Forms.ComboBox();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.chkActivarmarcas = new System.Windows.Forms.CheckBox();
            this.chkActivarCategorias = new System.Windows.Forms.CheckBox();
            this.chkActivarArticulos = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnBorrar
            // 
            this.btnBorrar.Location = new System.Drawing.Point(155, 113);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(75, 23);
            this.btnBorrar.TabIndex = 5;
            this.btnBorrar.Text = "Borrar";
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(280, 113);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 6;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // cmbArticulo
            // 
            this.cmbArticulo.FormattingEnabled = true;
            this.cmbArticulo.Location = new System.Drawing.Point(12, 30);
            this.cmbArticulo.Name = "cmbArticulo";
            this.cmbArticulo.Size = new System.Drawing.Size(155, 23);
            this.cmbArticulo.TabIndex = 7;
            this.cmbArticulo.SelectedIndexChanged += new System.EventHandler(this.cmbArticulo_SelectedIndexChanged);
            // 
            // cmbMarca
            // 
            this.cmbMarca.FormattingEnabled = true;
            this.cmbMarca.Location = new System.Drawing.Point(173, 30);
            this.cmbMarca.Name = "cmbMarca";
            this.cmbMarca.Size = new System.Drawing.Size(155, 23);
            this.cmbMarca.TabIndex = 9;
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new System.Drawing.Point(334, 30);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(155, 23);
            this.cmbCategoria.TabIndex = 12;
            // 
            // chkActivarmarcas
            // 
            this.chkActivarmarcas.AutoSize = true;
            this.chkActivarmarcas.Location = new System.Drawing.Point(173, 9);
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
            this.chkActivarCategorias.Location = new System.Drawing.Point(334, 9);
            this.chkActivarCategorias.Name = "chkActivarCategorias";
            this.chkActivarCategorias.Size = new System.Drawing.Size(130, 19);
            this.chkActivarCategorias.TabIndex = 14;
            this.chkActivarCategorias.Text = "Habilitar Categorías";
            this.chkActivarCategorias.UseVisualStyleBackColor = true;
            this.chkActivarCategorias.CheckedChanged += new System.EventHandler(this.chkActivarCategorias_CheckedChanged);
            // 
            // chkActivarArticulos
            // 
            this.chkActivarArticulos.AutoSize = true;
            this.chkActivarArticulos.Location = new System.Drawing.Point(12, 9);
            this.chkActivarArticulos.Name = "chkActivarArticulos";
            this.chkActivarArticulos.Size = new System.Drawing.Size(121, 19);
            this.chkActivarArticulos.TabIndex = 15;
            this.chkActivarArticulos.Text = "Habilitar Artículos";
            this.chkActivarArticulos.UseVisualStyleBackColor = true;
            this.chkActivarArticulos.CheckedChanged += new System.EventHandler(this.chkActivarArticulos_CheckedChanged);
            // 
            // frmEliminar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 155);
            this.Controls.Add(this.chkActivarArticulos);
            this.Controls.Add(this.chkActivarCategorias);
            this.Controls.Add(this.chkActivarmarcas);
            this.Controls.Add(this.cmbCategoria);
            this.Controls.Add(this.cmbMarca);
            this.Controls.Add(this.cmbArticulo);
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
        private System.Windows.Forms.ComboBox cmbArticulo;
        private System.Windows.Forms.ComboBox cmbMarca;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.CheckBox chkActivarmarcas;
        private System.Windows.Forms.CheckBox chkActivarCategorias;
        private System.Windows.Forms.CheckBox chkActivarArticulos;
    }
}