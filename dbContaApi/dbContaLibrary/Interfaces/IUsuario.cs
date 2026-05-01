using dbContaLibrary.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbContaLibrary.Interfaces
{
    public interface IUsuario
    {
        public IEnumerable<MdlUsuario> GetUsuario(string IdUsuario);
        public void Insertar(MdlUsuarioInsertar item);
        public void Actualizar(MdlUsuarioActualizar item);
        public void Eliminar(string pId);

    }
}
