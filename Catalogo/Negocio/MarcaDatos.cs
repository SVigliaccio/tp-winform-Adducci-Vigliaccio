using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class MarcaDatos
    {

        private AccesoDatos datos;

        public int cantRegistros { get; set; }


        public List<Marca> listar()
        {
            cantRegistros = 0;
            List<Marca> lista = new List<Marca>();
            datos = new AccesoDatos();

            try
            {               
                datos.setearConsulta("select Id, Descripcion from MARCAS");                

                datos.ejecutarLectura();
                while ( datos.Lector.Read() )
                {
                    lista.Add(new Marca((int)datos.Lector["Id"], (string)datos.Lector["Descripcion"]));
                    cantRegistros++;
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public bool referenciada(Marca marca)
        {
            String qry = @"SELECT ART.Codigo 
                             FROM articulos ART
                            WHERE ART.IdMarca = {0}";

            datos = new AccesoDatos();
            datos.setearConsulta(String.Format(qry, Convert.ToString(marca.Id)));
            datos.ejecutarLectura();
            return datos.Lector.Read() ? true : false; 
        }

        public void modificar(Marca marca)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string qry = @"UPDATE  MARCAS set
	                                   Descripcion = '{0}' 
                                WHERE  Id = {1}";

                datos.setearConsulta(String.Format(qry, marca.Descripcion,
                                                        Convert.ToString(marca.Id)
                                                   ));
                datos.ejectutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }


        public void eliminar(int id)
        {
            datos = new AccesoDatos();
            try
            {
                datos.setearConsulta(String.Format("Delete From MARCAS Where Id = {0}", id));
                datos.ejectutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void agregar(Marca nueva)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string valores = "values('" + nueva.Descripcion + "')";
                datos.setearConsulta("insert into Marcas (Descripcion)" + valores);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
                datos = null;
            }
        }

    }  
    
}
