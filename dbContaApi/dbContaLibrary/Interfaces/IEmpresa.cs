using dbContaLibrary.Modelos;
using dbContaLibrary.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbContaLibrary.Interfaces
{
    public interface IEmpresa
    {
        public IEnumerable<MdlEmpresa> Get(string pCriterio);
        public void Insertar(MdlEmpresaInsertar item);
        public void Actualizar(MdlActualizarEmpresa item);
        public void Eliminar(int pId);



    }
}
