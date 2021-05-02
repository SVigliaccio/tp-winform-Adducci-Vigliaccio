using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Marca
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public Marca()
        {
      
        }

        public Marca(string nombre)
        {
            Descripcion = nombre;
        }

        public Marca(int id, string nombre)
        {
            Id = id;
            Descripcion = nombre;
        }
        public override string ToString()
        {
            return Descripcion;
        }
    }
}
