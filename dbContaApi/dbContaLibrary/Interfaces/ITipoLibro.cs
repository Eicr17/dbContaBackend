using dbContaLibrary.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbContaLibrary.Interfaces
{
    public interface ITipoLibro
    {
        public List<MdlTipoLibro> GetList();
        public void InsertTipoLibro(MdlTipoLibroCrear item);
        public void ActualizarTipoLibro(MdlTipoLibroActualizar item);
        public void Eliminar(int pId);

    }
}
