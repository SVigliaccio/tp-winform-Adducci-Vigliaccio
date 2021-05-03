using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Dominio;

namespace Negocio
{
    public class Validaciones
    {
        private ErrorProvider error;
        public bool ValidarTextbox(TextBox txtBox, string msj)
        {
            error = new ErrorProvider();

             if (string.IsNullOrEmpty(txtBox.Text))
            {                
                txtBox.Focus();
                error.SetError(txtBox,msj);
                return true;
            }
            //wandanara, sigue mostrando el icono ... 
            error.SetError(txtBox, String.Empty);
            error.Clear();            
            error.Dispose();
            return false;
        }

        public bool ValidarTextbox(TextBox txtBox)
        {
            if (string.IsNullOrEmpty(txtBox.Text))
            {
                return true;
            }
            return false;
        }

        public bool ValidarCombo(ComboBox cmbBox, string msj)
        {
            error = new ErrorProvider();
            if (cmbBox.SelectedItem == null)
            {                
                cmbBox.Focus();
                error.SetError(cmbBox, msj);
                return true;
            }
            error.SetError(cmbBox, String.Empty);
            error.Clear();
            return false;   
        }

        public bool ValidarCombo(ComboBox cmbBox)
        {
            if (cmbBox.SelectedItem == null)
            {
                return true;
            }
            return false;
        }

        public void QuitarFocus()
        {  //limpiar error provider
            error = new ErrorProvider();
            error.Clear();
            error.Dispose();
        }

        public void ClearAllControls(ref List<Control> Controls)
        {  //tampoco funciono 
            error = new ErrorProvider();
            foreach (Control cr in Controls)
            {
                error.SetError(cr, "");
            }
        }

        public bool Existe(object entidad)
        { //verifica que no exista en la bdd una marca o categoria con el mismo nombre
            AccesoDatos datos = new AccesoDatos();
            String qry = String.Empty;
            String Nombre = String.Empty;
            try
            {                
                switch (entidad.GetType().Name)
                {
                    case "Categoria":
                                    qry = @"SELECT CAT.Id 
                                              FROM CATEGORIAS CAT
                                             WHERE CAT.Descripcion = '{0}'";
                                    Categoria cat = (Categoria)entidad;
                                    Nombre = cat.Descripcion;
                                    break;
                    case "Marca":
                                    qry = @"SELECT MAR.Id 
                                              FROM MARCAS MAR
                                             WHERE MAR.Descripcion = '{0}'";
                                    Marca mar = (Marca)entidad;
                                    Nombre = mar.Descripcion;
                                    break;
                } 
                datos.setearConsulta(String.Format(qry, Nombre ));
                datos.ejecutarLectura();                
                return datos.Lector.Read() ? true : false;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
