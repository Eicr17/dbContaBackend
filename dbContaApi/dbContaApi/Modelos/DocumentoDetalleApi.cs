namespace dbContaApi.Modelos
{
    public class DocumentoDetalleApi
    {
        public int idDocumentoDetalle { get; set; }
        public string numero { get; set; }
        public string serie { get; set; }
        public int tipodocumento { get; set; }
        public int idArticulo { get; set; }
        public int cantidad { get; set; }
        public int precio { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime fechacreacion { get; set; } 
    }

    public class DtoDocumentoDetInsertar
    {
        public string numero { get; set; }
        public string serie { get; set; }
        public int tipodocumento { get; set; }
        public int idArticulo { get; set; }
        public int cantidad { get; set; }
        public int precio { get; set; }
    }



    public class DtoDocumentoDetActualizar
    {
        public int idDocumentoDetalle { get; set; }
        public string numero { get; set; }
        public string serie { get; set; }
        public int tipodocumento { get; set; }
        public int idArticulo { get; set; }
        public int cantidad { get; set; }
        public int precio { get; set; }
    }
}
