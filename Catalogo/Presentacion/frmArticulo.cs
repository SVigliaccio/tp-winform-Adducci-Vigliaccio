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
        private Articulo articulo;
        public frmArticulo()
        {
            InitializeComponent();
        }

        public frmArticulo(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
        }

        private void frmArticulo_Load(object sender, EventArgs e)
        {
            MarcaDatos marcaDatos = new MarcaDatos();
            CategoriaDatos categoriaDatos = new CategoriaDatos();

            try
            {
                cboMarca.DataSource = marcaDatos.listar();
                cboCategoria.DataSource = categoriaDatos.listar();

                if (articulo != null)
                {
                    
                    txtCodigo.Text = articulo.Codigo;
                    txtNombre.Text = articulo.Nombre;
                    txtDescripcion.Text = articulo.Descripcion;
                    cboMarca.Text = articulo.IdMarca.Descripcion;
                    //cboMarca.ValueMember = Convert.ToString(articulo.IdMarca.Id);
                    //cboMarca.DisplayMember = articulo.IdMarca.Descripcion;
                    //detalle.cboMarca.SelectedIndex = 2;
                    cboCategoria.Text = articulo.IdCategoria.ToString();
                    txtPrecio.Text = Convert.ToString(articulo.Precio);
                    txtUrl.Text = articulo.ImagenUrl;
                }
                
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
