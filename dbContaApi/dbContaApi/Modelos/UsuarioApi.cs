namespace dbContaApi.Modelos
{
    public class UsuarioApi
    {
        public string idusuario { get; set; }
        public string nombreusuario { get; set; }
        public string email { get; set; }
        public string usuariocreacion { get; set; }
        public DateTime fechacreacion { get; set; }
    }

   
    public class DtoUsuarioInsertar
    {
        public string idusuario { get; set; }
        public string nombreusuario { get; set; }
        public string password { get; set; }
        public string email { get; set; }
    }


    public class DtoUsuarioActualizar
    {
         public string idusuario { get; set; }
        public string nombreusuario { get; set; }
        public string password { get; set; }
        public string email { get; set; }

    }
}
