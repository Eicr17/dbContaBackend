namespace dbContaApi.Modelos
{
    public class TipoArticuloApi
    {
        public int idtipoArticulo { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string fechaCreacion { get; set; }
        public string usuarioCreacion { get; set; }
    }


    public class DtoTipoArticuloInsertar
    {
        public string nombre { get; set; }
        public string descripcion { get; set; }
    }

    public class DtoTipoArticuloActualizar
    {
        public int idtipoArticulo { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
    }
}
