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
                String Qry = @"SELECT  Codigo, 
                                       Nombre, 
	                                   Descripcion, 
	                                   ImagenUrl, 
	                                   Precio,
                                       IdMarca,
                                       IdCategoria
                                 FROM  ARTICULOS";

                datos.setearConsulta(Qry);
                datos.ejecutarLectura();

                List<Marca> listaMarcas = new List<Marca>();
                List<Categoria> listaCategorias = new List<Categoria>();

                MarcaDatos marcas = new MarcaDatos();
                listaMarcas = marcas.listar();

                CategoriaDatos categorias = new CategoriaDatos();
                listaCategorias = categorias.listar();  

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
                    //Seteamos la marca
                    for(int i = 0; i<marcas.cantRegistros; i++)
                    {
                        if (aux.IdMarca.Id == listaMarcas[i].Id)
                        {
                            aux.IdMarca.Descripcion = (string)listaMarcas[i].Descripcion;
                            break;
                        }
                    }
                    //seteamos la categoria
                    for (int i = 0; i < categorias.cantRegistros; i++)
                    {
                        if (aux.IdCategoria.Id == listaCategorias[i].Id)
                        {
                            aux.IdCategoria.Descripcion = (string)listaCategorias[i].Descripcion;
                            break;
                        }
                    }                    
                    //agregamnos el objeto
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

        public void eliminar(Articulo articulo)
        {
            datos = new AccesoDatos();
            try
            {
                datos.setearConsulta(String.Format("Delete From ARTICULOS Where Codigo = '{0}'", articulo.Codigo));
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

        public bool validarUrl(string url)
        {  
            Uri myUri;
            //se utiliza el metdo de URI para ver si es valida la url
            if (Uri.TryCreate(url, UriKind.RelativeOrAbsolute, out myUri))
            {   
                //corroboramos que halla una imagen en la url validada
                byte[] imagen = ObtenerImgAsByte(url);
                return imagen  != null ? true : false;
            }
            return false;           
        }

        private byte[] ObtenerImgAsByte(string url)
        {
            try
            {
                System.Net.WebClient _WebClient = new System.Net.WebClient();
                byte[] _image = _WebClient.DownloadData(url);
                if (_image.Length > 0)
                    return _image;
                else
                    return null;
            }
            catch (Exception)
            {
                return null;
            }
        }       
    }
}
