using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;
using Dominio;

namespace Presentacion
{
    public partial class frmArticulo : Form
    {
        public frmArticulo()
        {
            InitializeComponent();
        }

        private void frmArticulo_Load(object sender, EventArgs e)
        {
            MarcaDatos marcaDatos = new MarcaDatos();
            CategoriaDatos categoriaDatos = new CategoriaDatos();

            try
            {
                cboMarca.DataSource = marcaDatos.listar();
                cboCategoria.DataSource = categoriaDatos.listar();
            }
            catch (Exception ex)
            {

                MessageBox.Show( ex.ToString() );
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Articulo nuevo = new Articulo();
            ArticulosDatos articulosDatos = new ArticulosDatos();

            try
            {
                nuevo.Codigo = txtCodigo.Text;
                nuevo.Nombre = txtNombre.Text;
                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.IdMarca = (Marca)cboMarca.SelectedItem;
                nuevo.IdCategoria = (Categoria)cboCategoria.SelectedItem;
                nuevo.Precio = Convert.ToDecimal(txtPrecio.Text);
                nuevo.ImagenUrl = txtUrl.Text;

                articulosDatos.agregar(nuevo);
                MessageBox.Show("Agregado correctamente");
                Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show( ex.ToString() );
            }
        }
    }
}
