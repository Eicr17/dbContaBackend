namespace dbContaApi.Modelos
{
    public class TipoLibroApi
    {
        public int idtipolibro { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }

        public string usuariocreacion { get; set; }

        public DateTime fechacreacion { get; set; }

    }



    public class DtoTipoLibroInsertar
    {
        public string nombre { get; set; }
        public string descripcion { get; set; }
    }

    public class DtoTipoLibroActualizar
    {
        public int idtipolibro { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }

    }
}
