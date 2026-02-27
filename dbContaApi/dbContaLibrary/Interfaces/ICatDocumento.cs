using dbContaLibrary.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbContaLibrary.Interfaces
{
    public interface ICatDocumento
    {
        public IEnumerable<MdlCatDocumento> GetList();
        public void Insertar(MdlCatDocCrear item);
        public void Actualizar(MdlCatDocActualizar item);
        public void Eliminar(int pId);



    }
}
