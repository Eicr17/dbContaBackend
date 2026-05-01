namespace dbContaApi.Modelos
{
    public class RolUsuarioApi
    {
        public int idrolusuario { get; set; }
        public int idrol { get; set; }
        public string idusuario { get; set; }
        public DateTime fechacreacion { get; set; }
        public string usuariocreacion { get; set; }

    }


    public class DtoRolUsuarioInsertar
    {
        public int idrol { get; set; }
        public string idusuario { get; set; }
    }
    public class DtoRolUsuarioActualizar
    {
        public int idrolusuario { get; set; }
        public int idrol { get; set; }
        public string idusuario { get; set; }

    }

}
