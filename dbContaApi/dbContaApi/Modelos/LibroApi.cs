namespace dbContaApi.Modelos
{
    public class LibroApi
    {
        public int idlibro { get; set; }
        public DateTime fecha { get; set; }
        public int folio { get; set; }
        public int monto { get; set; }
        public int idempresa { get; set; }
        public int idtipolibro { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime fechacreacion { get; set; }
    }
}
