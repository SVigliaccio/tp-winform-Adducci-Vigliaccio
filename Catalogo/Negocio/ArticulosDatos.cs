using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;

namespace Negocio
{
    public class ArticulosDatos
    {
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                String Qry = @"SELECT  Codigo, 
                                       Nombre, 
	                                   Descripcion, 
	                                   ImagenUrl, 
	                                   Precio 
                                 FROM  ARTICULOS";

                datos.setearConsulta(Qry);
                datos.ejecutarLectura();
               
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    aux.Precio = (decimal)datos.Lector["Precio"];

                    lista.Add(aux);
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

        public void agregar(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string valores = String.Format("values ('{0}', '{1}', '{2}', {3}, {4},'{5}',{6})",
                                                 nuevo.Codigo, nuevo.Nombre, nuevo.Descripcion, nuevo.IdMarca.Id, nuevo.IdCategoria.Id,
                                                 nuevo.ImagenUrl, Convert.ToString(nuevo.Precio).Replace(",", "."));
                datos.setearConsulta("insert into Articulos (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio)"+valores);

                datos.ejecutarAccion();
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
    }
}
