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

namespace Presentacion
{
    public partial class frmAgregar : Form
    {
        private Articulo articulo;

        public frmAgregar()
        {
            InitializeComponent();
        }

        public frmAgregar(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
        }

        private void btnArticulo_Click(object sender, EventArgs e)
        {
            frmArticulo agregar = new frmArticulo();
            if (articulo == null)
                agregar.ShowDialog();
            else {
                    //usamos el mismo frm d agregar para modificar                    
                    frmArticulo modificar = new frmArticulo(articulo,true);
                    modificar.Text = "Modificar Artículo";
                    modificar.ShowDialog();
                 }                
        }

        private void btnMarca_Click(object sender, EventArgs e)
        {
            frmMarca agregar = new frmMarca();
            if (articulo == null)
                agregar.ShowDialog();
            else 
            {
                //usamos el mismo frm d agregar para modificar                    
                frmMarca modificar = new frmMarca(articulo, true);
                modificar.Text = "Modificar Marca";
                modificar.ShowDialog();
            }
        }

        private void btnCategoria_Click(object sender, EventArgs e)
        {
            frmCategoria agregar = new frmCategoria();
            if (articulo == null)
                agregar.ShowDialog();
            else
                {
                    frmCategoria modificar = new frmCategoria(articulo, true);
                    modificar.Text = "Modificar Categoría";
                    modificar.ShowDialog();
                }
        }
    }
}
