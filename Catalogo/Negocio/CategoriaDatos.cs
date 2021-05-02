﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class CategoriaDatos
    {
<<<<<<< Updated upstream
        private AccesoDatos datos;
=======
        public int cantRegistros { get; set; }

>>>>>>> Stashed changes
        public List<Categoria> listar()
        {
            cantRegistros = 0;
            List<Categoria> lista = new List<Categoria>();
            datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select Id, Descripcion from CATEGORIAS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    lista.Add(new Categoria((int)datos.Lector["Id"], (string)datos.Lector["Descripcion"]));
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

<<<<<<< Updated upstream
        public void eliminar(int id)
        {
            datos = new AccesoDatos();
            try
            {
                datos.setearConsulta(String.Format("Delete From CATEGORIAS Where Id = {0}", id));
                datos.ejectutarAccion();
            }
            catch (Exception ex)
            {
=======
        public void agregar(Categoria nueva)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string valores = "values('" + nueva.Descripcion + "')";
                datos.setearConsulta("insert into Categorias (Descripcion)" + valores);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

>>>>>>> Stashed changes
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
<<<<<<< Updated upstream
                datos = null;
            }
=======
            }

>>>>>>> Stashed changes
        }
    }
}
