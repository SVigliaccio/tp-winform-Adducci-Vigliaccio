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
        public frmMarca()
        {
            InitializeComponent();
        }

        private void btnMarcaNueva_Click(object sender, EventArgs e)
        {
            Marca nueva = new Marca();
            MarcaDatos marcaDatos = new MarcaDatos();

            try
            {
                
                nueva.Descripcion = txtMarcaNueva.Text;

                marcaDatos.agregar(nueva);
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
