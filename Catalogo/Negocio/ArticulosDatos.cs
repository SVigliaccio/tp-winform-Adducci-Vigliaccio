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
        private AccesoDatos datos;
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            datos = new AccesoDatos();
            try
            {
<<<<<<< Updated upstream
                String Qry = @"SELECT  Codigo, 
                                       Nombre, 
	                                   Descripcion, 
	                                   ImagenUrl, 
	                                   Precio 
                                 FROM  ARTICULOS";

                datos.setearConsulta(Qry);
=======
                List<Marca> listaMarcas = new List<Marca>();
                List<Categoria> listaCategorias = new List<Categoria>();

                MarcaDatos marcas = new MarcaDatos();
                listaMarcas = marcas.listar();

                CategoriaDatos categorias = new CategoriaDatos();
                listaCategorias = categorias.listar();

                datos.setearConsulta("select Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio from ARTICULOS");
>>>>>>> Stashed changes
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.IdMarca.Id = (int)datos.Lector["IdMarca"];
                    aux.IdCategoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    aux.Precio = (decimal)datos.Lector["Precio"];

                    
                    for(int i = 0; i<marcas.cantRegistros; i++)
                    {
                        if (aux.IdMarca.Id == listaMarcas[i].Id)
                        {
                            aux.IdMarca.Descripcion = (string)listaMarcas[i].Descripcion;
                            break;
                        }
                        
                    }
                    for (int i = 0; i < categorias.cantRegistros; i++)
                    {
                        if (aux.IdCategoria.Id == listaCategorias[i].Id)
                        {
                            aux.IdCategoria.Descripcion = (string)listaCategorias[i].Descripcion;
                            break;
                        }
                    }
                    

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
            datos = new AccesoDatos();
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

        public List<Articulo> listarCombo()
        {
            List<Articulo> lista = new List<Articulo>();
            datos = new AccesoDatos();
            try
            {
                String Qry = @"SELECT  Id, 
                                       Nombre
                                 FROM  ARTICULOS";

                datos.setearConsulta(Qry);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    lista.Add(new Articulo((int)datos.Lector["Id"], (string)datos.Lector["Nombre"]));
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

        public void eliminar(int id)
        {
            datos = new AccesoDatos();
            try
            {
                datos.setearConsulta(String.Format("Delete From ARTICULOS Where Id = {0}", id));
                datos.ejectutarAccion();
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
