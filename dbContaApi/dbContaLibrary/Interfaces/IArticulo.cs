using dbContaLibrary.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbContaLibrary.Interfaces
{
    public interface IArticulo
    {
        public IEnumerable<MdlArticulo> Get(int IdArt, string Nombre);
        public void InsertarArticulo(MdlArticuloCrear item);
        public void ActualizarArticulo(MdlArticuloActualizar item);
        public void Eliminar(int pIdArt, int pIdTpArt);


    }
}
