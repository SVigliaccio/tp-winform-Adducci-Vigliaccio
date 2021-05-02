using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmAgregar : Form
    {
        public frmAgregar()
        {
            InitializeComponent();
        }

        private void btnArticulo_Click(object sender, EventArgs e)
        {
            frmArticulo agregar = new frmArticulo();
            agregar.ShowDialog();
        }

        private void btnMarca_Click(object sender, EventArgs e)
        {
            frmMarca agregar = new frmMarca();
            agregar.ShowDialog();
        }

        private void btnCategoria_Click(object sender, EventArgs e)
        {
            frmCategoria agregar = new frmCategoria();
            agregar.ShowDialog();
        }
    }
}
