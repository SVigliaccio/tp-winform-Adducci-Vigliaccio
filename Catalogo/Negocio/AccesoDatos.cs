using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Negocio
{
    class AccesoDatos
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        public AccesoDatos()
        {            
            //Conexion Soph
            conexion = new SqlConnection("data source=.\\SQLEXPRESS; initial catalog=CATALOGO_DB; integrated security=sspi");
            /*if (conexion.State == 0 )                 
            {//Conexion Recofsky
                string connectionString = "Data Source=LXC-NB-RADDUCCI;Initial Catalog=CATALOGO_DB;Integrated Security=True";
                conexion = new SqlConnection(connectionString);
            }*/
            comando = new SqlCommand();
        }

        public void setearConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }

        public void ejecutarLectura()
        {
            comando.Connection = conexion;
            conexion.Open();
            lector = comando.ExecuteReader();
        }

        public void cerrarConexion()
        {
            if (lector != null)
                lector.Close();
            conexion.Close();
        }

        public SqlDataReader Lector
        {
            get { return lector; }
        }

        internal void ejectutarAccion()
        {
            comando.Connection = conexion;
            conexion.Open();
            comando.ExecuteNonQuery();
        }

        internal void ejecutarAccion()
        {
            comando.Connection = conexion;
            conexion.Open();
            comando.ExecuteNonQuery();
        }
    }
}
