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
        private bool editarArticulo;
        public frmArticulo()
        {
            InitializeComponent();
        }

        public frmArticulo(Articulo articulo, bool editar = false)
        {
            InitializeComponent();
            editarArticulo = editar;
            this.articulo = articulo;
        }

        private void frmArticulo_Load(object sender, EventArgs e)
        {
            MarcaDatos marcaDatos = new MarcaDatos();
            CategoriaDatos categoriaDatos = new CategoriaDatos();
            //txtPrecio.Text = "0";
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

                if (editarArticulo)
                {
                    if (MessageBox.Show("Esta seguro de editar la siguiente instancia?", "Registro actualizado", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        nuevo.Id = articulo.Id; 
                        //llamamos al actualizar con los datos nuevos + ID original para el where del update
                        articulosDatos.modificar(nuevo);                          
                    }
                }
                else
                { 
                    //llamamos al agregar con los datos nuevos
                    articulosDatos.agregar(nuevo);
                    MessageBox.Show("Agregado correctamente");
                }                
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

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 59) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //Formato 2 decimales para txtbox            
                txtPrecio.Text = String.Format("{0:N2}", decimal.Parse(String.IsNullOrEmpty(txtPrecio.Text)==false ? txtPrecio.Text : "0"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

    }
}
