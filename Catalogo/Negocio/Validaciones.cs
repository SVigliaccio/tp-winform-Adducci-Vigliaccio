using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Negocio
{
    public class Validaciones
    {
        private ErrorProvider error;
        public bool ValidarTextbox(TextBox txtBox, string msj)
        {
            error = new ErrorProvider();
            error.Clear();
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

        public bool ValidarCombo(ComboBox cmbBox, string msj)
        {
            error = new ErrorProvider();
            if (cmbBox.SelectedItem == null)
            {                
                cmbBox.Focus();
                error.SetError(cmbBox, msj);
                return true;
            }
            error.Clear();
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
    }
}
