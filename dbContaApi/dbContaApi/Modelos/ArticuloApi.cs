namespace dbContaApi.Modelos
{
    public class ArticuloApi
    {
        public int idArticulo { get; set; }
        public int idTipoArticulo { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public DateTime fechaCreacion { get; set; }
        public string usuarioCreacion { get; set; }
    }
}
