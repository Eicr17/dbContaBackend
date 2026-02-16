namespace dbContaApi.Modelos
{
    public class TipoDocumentoApi
    {
        public int idtipodocumento { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime fechacreacion { get; set; }
        public int idcategoriadocumento { get; set; } 
    }
}
