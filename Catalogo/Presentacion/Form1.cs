using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace Presentacion
{
    public partial class Form1 : Form
    {
        private List<Articulo> listaArticulos;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarGrilla();
            /*
            listaArticulos = new List<Articulo>();
            Articulo art1 = new Articulo();
            art1.Codigo = "HD2";
            art1.Nombre = "Milanesa";
            art1.Descripcion = "Carne empanisada con las migas que sobraron de la cena";
            art1.ImagenUrl = "https://ugc.kn3.net/i/760x/http://www.sitiosargentina.com.ar/imagenes-2009/milanesa.jpg";
            art1.Precio = 200;

            Articulo art2 = new Articulo();
            art2.Codigo = "HD4";
            art2.Nombre = "Guiso de lenteja";
            art2.Descripcion = "lentejas hervidas con popurri de lo que sobro en la cena";
            art2.ImagenUrl = "http://guisosyguisados.com/wp-content/uploads/2016/08/2.-guiso-de-lentejas-tradicional-receta-argentina-300x225.jpg";
            art2.Precio = 100;

            listaArticulos.Add(art1);
            listaArticulos.Add(art2);
            */
           
        }

        private void CargarGrilla()
        {
            ArticulosDatos articulosDatos = new ArticulosDatos();
            try
            {
                listaArticulos = articulosDatos.listar();
                dgvArticulos.DataSource = listaArticulos;

                dgvArticulos.Columns["Descripcion"].Visible = false;
                dgvArticulos.Columns["ImagenUrl"].Visible = false;
                //dgvArticulos.Columns["IdCategoria"].Visible = false;
                //dgvArticulos.Columns["IdMarca"].Visible = false;

                RecargarImg(listaArticulos[0].ImagenUrl);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void RecargarImg(string img)
        {
            try
            {
                ArticulosDatos articulosDatos = new ArticulosDatos();
                if (articulosDatos.validarUrl(img))
                {
                    picImagen.Show();
                    picImagen.Load(img);
                }                    
                else
                {
                    picImagen.Hide();
                    return;

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al cargar la imagen: "+ ex);
            }
            
        }

        private void dgvArticulos_MouseClick(object sender, MouseEventArgs e)
        {
            Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            RecargarImg(seleccionado.ImagenUrl);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAgregar agregar = new frmAgregar();
            agregar.ShowDialog();
            CargarGrilla();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //si selecciono un articulo, quiere eliminar uno
            if ((Articulo)dgvArticulos.CurrentRow.DataBoundItem != null)
            {
                Articulo articulo = new Articulo();
                articulo = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                if (MessageBox.Show("Estás seguro de eliminar el registro seleccionado?", "Registro eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ArticulosDatos articulosDatos = new ArticulosDatos();
                    //llamamos al metodo de eliminar el articulo seleccionado
                    articulosDatos.eliminar(articulo);
                    //recargamos la grilla
                    CargarGrilla();
                }
                else 
                    if (MessageBox.Show("Desea eliminar una categorñia o marca?", null, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                            frmEliminar eliminar = new frmEliminar();
                            eliminar.ShowDialog();
                            CargarGrilla();
                }
            }
            
        }


        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            filtrar();
        }

        private void txtFiltro_KeyUp(object sender, KeyEventArgs e)
        {
            filtrar();
        }

        private void filtrar()
        {
            List<Articulo> listaFiltrada;
            if (txtFiltro.Text != "")
            {
                //expresion lambda para filtrar por Nombre o Descripcion
                listaFiltrada = listaArticulos.FindAll( x => x.Nombre.ToUpper().Contains(txtFiltro.Text.ToUpper()) ||
                                                             x.Descripcion.ToUpper().Contains(txtFiltro.Text.ToUpper()));
                //vacio la lista para recargarla
                dgvArticulos.DataSource = null;
                //recargo la lista con la usqueda filtrada
                dgvArticulos.DataSource = listaFiltrada;
            }
            else
            {
                //vacio la lista para recargarla
                dgvArticulos.DataSource = null;
                //recargo la lista de manera normal
                dgvArticulos.DataSource = listaArticulos;
            }
            ocultarColumnas();
        }

        private void ocultarColumnas()
        {
            //Oculto Columnas de la grilla AGREGAR LAS QUE RESTAN OCULTAR!
            dgvArticulos.Columns["ImagenUrl"].Visible = false;
            dgvArticulos.Columns["IdCategoria"].Visible = false;
            dgvArticulos.Columns["IdMarca"].Visible = false;
            dgvArticulos.Columns["Id"].Visible = false;
        }        

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            
            Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            frmArticulo detalle = new frmArticulo(seleccionado);
            detalle.Text = "Detalle articulo";
            /*Campos de articulos en "detalles" se le asignan los del articulo seleccionado*/
            //detalle.txtCodigo.Text = seleccionado.Codigo;
            //detalle.txtNombre.Text = seleccionado.Nombre;
            //detalle.txtDescripcion.Text = seleccionado.Descripcion;
            ////detalle.cboMarca.ValueMember = Convert.ToString(seleccionado.IdMarca.Id);
            ////detalle.cboMarca.DisplayMember = seleccionado.IdMarca.Descripcion;
            //detalle.cboMarca.SelectedIndex = 2;
            //detalle.cboCategoria.Text = seleccionado.IdCategoria.ToString();
            //detalle.txtPrecio.Text = Convert.ToString(seleccionado.Precio);
            //detalle.txtUrl.Text = seleccionado.ImagenUrl;
            //MessageBox.Show(seleccionado.IdMarca.ToString());
            //detalle.cboCategoria.Text = "hola";
            //detalle.cboMarca.Name = "3";
            /*
            
            item.Name = dt.Rows[i]["id"].ToString());
            item.Content = dt.Rows[i]["codificador"].ToString();

            comboBox.Items.Add(item);
            */


            /* BOTONES modificando sus propiedades */
            detalle.btnAceptar.Enabled = false;
            detalle.btnAceptar.Visible = false;
            detalle.btnCancelar.Text = "Cerrar";

            /* deshabilitando edicion del frm */
            detalle.txtCodigo.ReadOnly = true;
            detalle.txtNombre.ReadOnly = true;
            detalle.txtDescripcion.ReadOnly = true;
            //detalle.cboMarca.Enabled = false;
            //detalle.cboCategoria.Enabled = false;
            detalle.txtPrecio.ReadOnly = true;
            detalle.txtUrl.ReadOnly = true;

            detalle.ShowDialog();
        }        

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //usamos el mismo frm d agregar para modificar
            Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            frmAgregar modificar = new frmAgregar(seleccionado);
            modificar.Text = "Modificar";
            modificar.ShowDialog();
            CargarGrilla();
        }

        private void dgvArticulos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
