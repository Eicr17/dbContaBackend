using dbContaLibrary.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbContaLibrary.Interfaces
{
    public interface IEmpresa
    {
        public IEnumerable<MdlEmpresa> Get();
        public void Insertar(MdlEmpresaInsertar item);
        public void Actualizar(MdlActualizarEmpresa item);
        public void Eliminar(int pId);



    }
}
