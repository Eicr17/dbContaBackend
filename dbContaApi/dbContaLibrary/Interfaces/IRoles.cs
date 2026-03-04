using dbContaLibrary.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbContaLibrary.Interfaces
{
    public interface IRoles
    {
        public IEnumerable<MdlRoles> GetRoles();
        public void Insertar(MdlRolesInsertar item);
        public void Actualizar(MdlRolesActualizar item);
        public void Eliminar(int pIdRol);


    }
}
