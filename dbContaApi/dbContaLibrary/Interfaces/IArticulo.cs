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
        public IEnumerable<MdlArticulo> Get();
        public void InsertarArticulo(MdlArticuloCrear item);
        public void ActualizarArticulo(MdlArticuloActualizar item);
        public void Eliminar(int pId);


    }
}
