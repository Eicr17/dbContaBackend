namespace dbContaApi.Modelos
{
    public class CatDocumentoApi
    {
        public int idcategoriadocumento { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime fechaCreacion { get; set; }
    }



    public class DtoCatDocumentoInsertar
    {
        public int idcategoriadocumento { get; set; }
    }

    public class DtoCatDocumentoActualizar
    {
        public int idcategoriadocumento { get; set; }
    }

}
