using dbContaLibrary.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbContaLibrary.Interfaces
{
    public interface IDocumentoDetalle
    {
        public IEnumerable<MdlDocumentoDetalle> Get(int idDocDet, string numero);
        public void Insertar(MdlDocumentoDetalleCrear item);
        public void Actualizar(MdlDtDocumentoActualizar item);
        public void Eliminar(int pId);

    }
}
