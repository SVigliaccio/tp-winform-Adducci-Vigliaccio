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
    public partial class frmCategoria : Form
    {
        private Articulo articulo;
        private bool editarCategoria;
        private Validaciones validaciones;
        public frmCategoria()
        {
            InitializeComponent();
        }

        public frmCategoria(Articulo articulo, bool editar = false)
        {
            InitializeComponent();
            editarCategoria = editar;
            this.articulo = articulo;
        }

        private void btnCategoriaNueva_Click(object sender, EventArgs e)
        {
            Categoria nueva = new Categoria();
            CategoriaDatos categoriaDatos = new CategoriaDatos();            

            try
            {
                nueva.Descripcion = txtCategoriaNueva.Text;
                
                //validar 
                validaciones = new Validaciones();
                /*
                if (validaciones.ValidarTextbox(txtCategoriaNueva, "El nombre es requerido"))
                {
                    return;
                }
                */
                if (validaciones.ValidarTextbox(txtCategoriaNueva))
                {
                    MessageBox.Show("El nombre es requerido");
                    return;
                }

                if (editarCategoria)
                {                    
                    if ( MessageBox.Show("Esta seguro de editar la siguiente instancia?", null, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                       if (categoriaDatos.referenciada(articulo.IdCategoria) && MessageBox.Show("La siguiente Categpría se encuentra referenciada, desea editarla de todas maneras?", null, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            nueva.Id = articulo.IdCategoria.Id;
                            //Si existe en la bdd, no se guarda
                            if (validaciones.Existe(nueva))
                            {
                                MessageBox.Show("Ya existe una categoria con ese nombre.");
                                return;
                            }
                            //llamamos al actualizar con los datos nuevos + ID original para el where del update
                            categoriaDatos.modificar(nueva);
                        }
                    }
                }
                else
                {
                    //VERIFICA QUE NO EXISTA EN LA BDD
                    if (validaciones.Existe(nueva))
                    {
                        MessageBox.Show("Ya existe una categoria con ese nombre.");
                        return;
                    } 
                    categoriaDatos.agregar(nueva);
                    MessageBox.Show("Agregada correctamente");
                }
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void frmCategoria_Load(object sender, EventArgs e)
        {
            try
            {
                if (articulo != null)
                {  //le seteamos al control la marca del articulo
                   //la cual se desea actualizar
                    txtCategoriaNueva.Text = articulo.IdCategoria.Descripcion;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
