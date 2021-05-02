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
                        //Verificamos que no existajn referencias en la base de datos
                        if (validarReferencia((Categoria)cmbCategoria.SelectedItem)) // --> existe referencia
                            return;
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
                            //Verificamos que no existajn referencias en la base de datos
                            if (validarReferencia((Marca)cmbMarca.SelectedItem)) // --> existe referencia
                                return;
                            marcaDatos = new MarcaDatos();
                            //instanciamos la marca selecccionada en el combo
                             Marca marcaSeleccionada = (Marca)cmbMarca.SelectedItem;
                            //llamamos al metodo de eliminar la marca seleccionada
                             marcaDatos.eliminar(marcaSeleccionada.Id);
                            //recargamos el combo con la diferencia
                            cmbMarca.DataSource = marcaDatos.listar();
                        }                        
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                    chkActivarmarcas.Hide();
                }
                else// Al deschequearlo muestro los demas checks
                {
                    cmbCategoria.DataSource = null;
                    chkActivarmarcas.Show();
                }                    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
                    chkActivarCategorias.Hide();
                }
                else// Al deschequearlo muestro los demas checks
                {
                    cmbMarca.DataSource = null;
                    chkActivarCategorias.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private bool validarReferencia(object obj )
        {//Verifica si existe referencia   
            if (obj.GetType().Name == "Categoria")
            {
                categoriaDatos = new CategoriaDatos();
                if (categoriaDatos.referenciada((Categoria)obj))
                {
                    MessageBox.Show("No puede eliminarse un registro que esta siendo referenciado");
                    return true;
                }
                return false;
            }
            else
                if (obj.GetType().Name == "Marca" )
                {
                    marcaDatos = new MarcaDatos();
                    if (marcaDatos.referenciada((Marca)obj))
                    {
                        MessageBox.Show("No puede eliminarse un registro que esta siendo referenciado");
                        return true;
                    }
                    return false;
                }            
            return false;
        }        
    }
}
