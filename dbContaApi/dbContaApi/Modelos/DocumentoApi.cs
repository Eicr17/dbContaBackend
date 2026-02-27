namespace dbContaApi.Modelos
{
    public class DocumentoApi
    {
        public string numero { get; set; }
        public string serie { get; set; }
        public int tipodocumento { get; set; }
        public int idempresa { get; set; }
        public DateTime fecha { get; set; }
        public int monto { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime fechaexpiracion { get; set; }
        public DateTime fechacreacion { get; set; }
    }
}
