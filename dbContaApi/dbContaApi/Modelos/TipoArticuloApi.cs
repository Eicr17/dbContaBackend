namespace dbContaApi.Modelos
{
    public class TipoArticuloApi
    {
        public int idtipoArticulo { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public DateTime fechaCreacion { get; set; }
        public string usuarioCreacion { get; set;}
    }
}
