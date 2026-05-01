using Microsoft.AspNetCore.Identity;

namespace dbContaApi.Modelos
{
    public class RolesApi
    {
        public int idrol { get; set; }
        public string nombrerol { get; set; }
        public string usuariocreacion { get; set; }
    }

    public class DtoRolesInsertar
    {
        public string nombrerol { get; set; }
    }

    public class DtoRolesActualizar
    {
        public int idrol { get; set; }
        public string nombrerol { get; set; }
    }
}
