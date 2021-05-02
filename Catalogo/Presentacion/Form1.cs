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

                dgvArticulos.Columns["ImagenUrl"].Visible = false;
                dgvArticulos.Columns["IdCategoria"].Visible = false;
                dgvArticulos.Columns["IdMarca"].Visible = false;

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
                picImagen.Load(img);
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
            frmEliminar eliminar = new frmEliminar();
            eliminar.ShowDialog();
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
        }        
    }
}
