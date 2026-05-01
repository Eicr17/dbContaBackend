namespace dbContaApi.Modelos
{
    public class EmpresaApi
    {
        public int idempresa { get; set; }
        public string nombre { get; set; }
        public string fechacreacion { get; set; }
        public string usuario { get; set; }
        public string nit { get; set; }

    }

    public class DtoEmpresaInsertar
    {        
        public string nombre { get; set; }        
        public string nit { get; set; }
    }

    public class DtoEmpresaActualizar
    {
        public int idempresa { get; set; }
        public string nombre { get; set; }
        public string nit { get; set; }

    }

    //public class DtoEmpresaEliminar
    //{
    //    public int idempresa { get; set; }
    //}


}
