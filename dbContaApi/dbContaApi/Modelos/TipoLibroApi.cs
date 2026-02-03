namespace dbContaApi.Modelos
{
    public class TipoLibroApi
    {
        public int id_tipo_libro { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }

        public string usuario_creacion { get; set; }

        public DateTime fecha_creacion { get; set; }

    }
}
