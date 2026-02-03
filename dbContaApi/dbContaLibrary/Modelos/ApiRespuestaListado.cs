using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbContaLibrary.Modelos
{
    public class ApiRespuestaListado<T>
    {
        public List<T> datos { get; set; }
        public string mensaje { get; set; }

        public int total_registros { get; set; }


    }
}
