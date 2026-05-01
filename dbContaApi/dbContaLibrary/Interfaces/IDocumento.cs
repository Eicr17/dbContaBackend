using dbContaLibrary.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbContaLibrary.Interfaces
{
    public  interface IDocumento
    {
        public IEnumerable<MdlDocumento> GetDoc(string pCriterio);
        public void Insertar(MdlDocCrear item);
        public void Actualizar(MdlDocActualizar item);
        public void Eliminar(int pId);



    }
}
