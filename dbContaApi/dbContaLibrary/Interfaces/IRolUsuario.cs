using dbContaLibrary.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbContaLibrary.Interfaces
{
    public interface IRolUsuario
    {
        public IEnumerable<MdlRolUsuario> Get();
        public void Insertar(MdlRolUsuarioInsertar item);
        public void Actualizar(MdlRolUsuarioActualizar item);
        public void Eliminar(int pId);




    }
}
