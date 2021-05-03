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
        }

        private void CargarGrilla()
        {
            ArticulosDatos articulosDatos = new ArticulosDatos();
            try
            {
                listaArticulos = articulosDatos.listar();
                dgvArticulos.DataSource = listaArticulos;

                //formato 2 decimales --> recorre las columnas y las formatea
                //for (int i = 0; i < this.dgvArticulos.Columns.Count; i++)
                //    this.dgvArticulos.Columns[i].DefaultCellStyle.Format = "0.00";

                dgvArticulos.Columns["Descripcion"].Visible = false;
                dgvArticulos.Columns["ImagenUrl"].Visible = false;             

                //dgvArticulos.Columns["IdCategoria"].Visible = false;
                //dgvArticulos.Columns["IdMarca"].Visible = false;

                DataGridViewCellStyle dgvEstilo;
                DataGridViewCellStyle dgvEstiloColumPrecio;
                dgvEstiloColumPrecio = new DataGridViewCellStyle();
                dgvEstilo = new DataGridViewCellStyle();

                //ESTILO PARA LA COLUMNA PRECIO
                dgvEstiloColumPrecio.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvEstiloColumPrecio.Format = "0.00";

                //ESTILOS PARA TODO EL DGV
                dgvEstilo.NullValue = "Sin asignar";
                this.dgvArticulos.Columns["Precio"].DefaultCellStyle = dgvEstiloColumPrecio;

                ocultarColumnas();

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
            try
            {
               //Verificar que no sea null el current row
               if (dgvArticulos.CurrentRow != null)
               {
                    Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                    RecargarImg(seleccionado.ImagenUrl);
               }                
            }
            catch (Exception ex)
            {

                MessageBox.Show("Selecciona un artículo"); 
            }
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAgregar agregar = new frmAgregar();
            agregar.ShowDialog();
            CargarGrilla();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
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
                        if (MessageBox.Show("Desea eliminar una categoria o marca?", null, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        frmEliminar eliminar = new frmEliminar();
                        eliminar.ShowDialog();
                        CargarGrilla();
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("No está seleccionando ningún artículo", "Atención");
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
            if ( !String.IsNullOrEmpty(txtFiltro.Text))
            {
                //expresion lambda para filtrar por Nombre o Descripcion
                listaFiltrada = listaArticulos.FindAll( x => x.Nombre.ToUpper().Contains(txtFiltro.Text.ToUpper()) ||
                                                             x.IdMarca.Descripcion.ToUpper().Contains(txtFiltro.Text.ToUpper()) ||
                                                             x.IdCategoria.Descripcion.ToUpper().Contains(txtFiltro.Text.ToUpper())
                                                             );
                //vacio la lista para recargarla
                dgvArticulos.DataSource = null;
                //recargo la lista con la usqueda filtrada
                dgvArticulos.DataSource = listaFiltrada;
                ocultarColumnas();
            }
            else
            {
                //vacio la lista para recargarla
                dgvArticulos.DataSource = null;
                //recargo la lista de manera normal
                dgvArticulos.DataSource = listaArticulos;
                CargarGrilla();
            }
            
        }

        private void ocultarColumnas()
        {
            //Oculto Columnas de la grilla AGREGAR LAS QUE RESTAN OCULTAR!
            dgvArticulos.Columns["ImagenUrl"].Visible = false;
            dgvArticulos.Columns["IdCategoria"].Visible = false;
            dgvArticulos.Columns["IdMarca"].Visible = false;
            dgvArticulos.Columns["Descripcion"].Visible = false;
            dgvArticulos.Columns["Id"].Visible = false;
        }        

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            try
            {
                Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                frmArticulo detalle = new frmArticulo(seleccionado);
                detalle.Text = "Detalle articulo";


                /* BOTONES modificando sus propiedades */
                detalle.btnAceptar.Enabled = false;
                detalle.btnAceptar.Visible = false;
                detalle.btnCancelar.Text = "Cerrar";

                /* deshabilitando edicion del frm */
                detalle.txtCodigo.ReadOnly = true;
                detalle.txtNombre.ReadOnly = true;
                detalle.txtDescripcion.ReadOnly = true;
                detalle.cboMarca.Enabled = false;
                detalle.cboCategoria.Enabled = false;
                detalle.txtPrecio.ReadOnly = true;
                detalle.txtUrl.ReadOnly = true;

                detalle.ShowDialog();
            }
            catch (Exception ex)
            {

                MessageBox.Show("No está seleccionando ningún artículo", "Atención");
            }
            
        }        

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                //usamos el mismo frm d agregar para modificar
                Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                frmAgregar modificar = new frmAgregar(seleccionado);
                modificar.Text = "Modificar";
                modificar.ShowDialog();
                CargarGrilla();
            }
            catch (Exception ex)
            {

                MessageBox.Show("No está seleccionando ningún artículo","Atención");
            }
            
        }

        private void dgvArticulos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CargarGrilla();
        }
    }
}
