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
    public partial class frmMarca : Form
    {
        private bool editarMarca;
        private Articulo articulo;
        private Validaciones validaciones;
        public frmMarca()
        {
            InitializeComponent();
        }

        public frmMarca(Articulo articulo, bool editar = false)
        {
            InitializeComponent();
            editarMarca = editar;
            this.articulo = articulo;
        }

        private void btnMarcaNueva_Click(object sender, EventArgs e)
        {
            Marca nueva = new Marca();
            MarcaDatos marcaDatos = new MarcaDatos();
            try
            {   
                nueva.Descripcion = txtMarcaNueva.Text;
                //validar 
                validaciones = new Validaciones();
                /*
                if (validaciones.ValidarTextbox(txtMarcaNueva, "El nombre es requerido"))
                {
                    return;
                }
                */
                if (validaciones.ValidarTextbox(txtMarcaNueva))
                {
                    MessageBox.Show("El nombre es requerido");
                    return;
                }

                if (editarMarca)
                {
                    if (MessageBox.Show("Esta seguro de editar la siguiente instancia?", "Registro actualizado", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (marcaDatos.referenciada(articulo.IdMarca) && MessageBox.Show("La siguiente Marca se encuentra referenciada, desea editarla de todas maneras?", null, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            nueva.Id = articulo.IdMarca.Id;
                            if (validaciones.Existe(nueva))
                            {
                                MessageBox.Show("Ya existe una Marca con ese nombre.");
                                return;
                            }
                            //llamamos al actualizar con los datos nuevos + ID original para el where del update
                            marcaDatos.modificar(nueva);
                        }
                    }
                }
                else
                {  
                    if (validaciones.Existe(nueva))
                    {
                        MessageBox.Show("Ya existe una Marca con ese nombre.");
                        return;
                    }
                    //llamamos al agregar con los datos nuevos
                    marcaDatos.agregar(nueva);
                    MessageBox.Show("Agregado correctamente");
                }
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void frmMarca_Load(object sender, EventArgs e)
        {         
            try
            {
                if (articulo != null)
                {  //le seteamos al control la marca del articulo
                   //la cual se desea actualizar
                    txtMarcaNueva.Text = articulo.IdMarca.Descripcion;                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
