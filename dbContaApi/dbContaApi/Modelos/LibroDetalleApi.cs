namespace dbContaApi.Modelos
{
    public class LibroDetalleApi
    {
        public int idlibrodetalle { get; set; }
        public int idlibro { get; set; }
        public DateTime fecha { get; set; }
        public string numero { get; set; }
        public int serie { get; set; }
        public int tipoDocumento { get; set; }
        public string usuarioCreacion { get; set; }
    }
}
