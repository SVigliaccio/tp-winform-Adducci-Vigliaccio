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
    public partial class frmEliminar : Form
    {
        private ArticulosDatos articulosDatos ;
        private MarcaDatos marcaDatos;
        private CategoriaDatos categoriaDatos;

        public frmEliminar()
        {
            InitializeComponent();
        }

        private void frmEliminar_Load(object sender, EventArgs e)
        {
           
        }

        private void cmbArticulo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {//Agregar los tres combos y verificar! 
            try
            {
                if (MessageBox.Show("Estás seguro de eliminar el registro seleccionado?", "Registro eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //Si quiere eliminar una categoria ...
                    if (chkActivarCategorias.Checked)
                    {
                        categoriaDatos = new CategoriaDatos();
                        //instanciamos la categoria selecccionada en el combo
                        Categoria categoriaSeleccionada = (Categoria)cmbCategoria.SelectedItem;
                        //llamamos al metodo de eliminar la categoria seleccionada
                        categoriaDatos.eliminar(categoriaSeleccionada.Id);
                        //recargamos el combo con la diferencia
                        cmbCategoria.DataSource = categoriaDatos.listar();
                    }//Si quiere eliminar una marca ...
                    else 
                        if (chkActivarmarcas.Checked)
                        {
                            marcaDatos = new MarcaDatos();
                            //instanciamos la marca selecccionada en el combo
                             Marca marcaSeleccionada = (Marca)cmbMarca.SelectedItem;
                            //llamamos al metodo de eliminar la marca seleccionada
                             marcaDatos.eliminar(marcaSeleccionada.Id);
                            //recargamos el combo con la diferencia
                            cmbMarca.DataSource = marcaDatos.listar();
                        }
                        else if (chkActivarArticulos.Checked)
                        {
                            articulosDatos = new ArticulosDatos();
                            //instanciamos el articulo selecccionado en el combo
                            Articulo articuloSeleccionado = (Articulo)cmbArticulo.SelectedItem;
                            //llamamos al metodo de eliminar el articulo seleccionado
                             articulosDatos.eliminar(articuloSeleccionado.Id);
                            //recargamos el combo con la diferencia
                             cmbArticulo.DataSource = articulosDatos.listar();
                        }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void chkActivarmarcas_CheckedChanged(object sender, EventArgs e)
        {
            marcaDatos = new MarcaDatos();
            try
            {   //Al chequearlo oculto los demas checks
                if (chkActivarmarcas.Checked)
                {
                    cmbMarca.DataSource = marcaDatos.listar();
                    chkActivarArticulos.Hide();
                    chkActivarCategorias.Hide();
                }
                else // Al deschequearlo muestro los demas checks
                {
                    cmbMarca.DataSource = null;
                    chkActivarArticulos.Show();
                    chkActivarCategorias.Show();
                }
                    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void chkActivarCategorias_CheckedChanged(object sender, EventArgs e)
        {
            categoriaDatos = new CategoriaDatos();
            try
            {   //Al chequearlo oculto los demas checks
                if (chkActivarCategorias.Checked)
                {
                    cmbCategoria.DataSource = categoriaDatos.listar();
                    chkActivarArticulos.Hide();
                    chkActivarmarcas.Hide();
                }
                else// Al deschequearlo muestro los demas checks
                {
                    cmbCategoria.DataSource = null;
                    chkActivarArticulos.Show();
                    chkActivarmarcas.Show();
                }                    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void chkActivarArticulos_CheckedChanged(object sender, EventArgs e)
        {
            articulosDatos = new ArticulosDatos();
            try
            {  //Al chequearlo oculto los demas checks
                if (chkActivarArticulos.Checked)
                {
                    chkActivarCategorias.Hide();
                    chkActivarmarcas.Hide();
                    cmbArticulo.DataSource = articulosDatos.listarCombo();
                }
                else // Al deschequearlo muestro los demas checks
                {
                    cmbArticulo.DataSource = null;
                    chkActivarCategorias.Show();
                    chkActivarmarcas.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool validarReferencia(object obj)
        {
            if (obj.GetType() == Type.GetType("Categoria") ? )
            {
                //
                return false;
            }
            else
                if (obj.GetType() == Type.GetType("Marca"))
                {
                //
                return false;
            }
               
            return false;
        }
    }
}
