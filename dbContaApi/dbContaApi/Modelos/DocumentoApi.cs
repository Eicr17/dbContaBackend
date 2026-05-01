namespace dbContaApi.Modelos
{
    public class DocumentoApi
    {
        public string numero { get; set; }
        public string serie { get; set; }
        public int tipodocumento { get; set; }
        public int idempresa { get; set; }
        public string fecha { get; set; }
        public int monto { get; set; }
        public string usuariocreacion { get; set; }
        public string fechaexpiracion { get; set; }
        public string fechacreacion { get; set; }
    }

    public class DtoDocumentoInsertar
    {
      
        public int idempresa { get; set; }
        public int monto { get; set; }
        public DateTime fechaexpiracion { get; set; }
    }

    public class DtoDocumentoActualizar
    {
        public string numero { get; set; }
        public string serie { get; set; }
        public int tipodocumento { get; set; }
        public int idempresa { get; set; }
        public int monto { get; set; }
        public DateTime fechaexpiracion { get; set; }
    }
}
