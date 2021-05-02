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
        public frmCategoria()
        {
            InitializeComponent();
        }

        private void btnCategoriaNueva_Click(object sender, EventArgs e)
        {
            Categoria nueva = new Categoria();
            CategoriaDatos categoriaDatos = new CategoriaDatos();

            try
            {

                nueva.Descripcion = txtCategoriaNueva.Text;

                categoriaDatos.agregar(nueva);
                MessageBox.Show("Agregada correctamente");
                Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
    }
}
