using dbContaLibrary.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbContaLibrary.Interfaces
{
    public interface ITipoArticulo
    {
        public List<MdlTipoArticulo> GetList();
        public void InsertarTpArticulo(MdlTipoArticuloCrear item);
        public void ActualizarTpDoc(MdlTipoArticuloAct item);
        public void Eliminar(int pIdTpArt);



    }
}
