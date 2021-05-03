using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var culture = CultureInfo.GetCultureInfo("es-AR");
            //Cultura para cualquier hilo
            CultureInfo.DefaultThreadCurrentCulture = culture;
            //Cultura para la interfaz de usuario
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
