using dbContaApi.Modelos;
using dbContaLibrary.Modelos;
using System.Security.Claims;

namespace dbContaApi.Servicios
{
    public class ObtenerInformacionToken
    {
        private readonly IHttpContextAccessor _context;
        public ObtenerInformacionToken(IHttpContextAccessor pContext)
        {
               _context = pContext;
        }
        public UserDataApi ObtenerInformacion()
        {
            var identity = _context.HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var userClaims = identity.Claims;

                return new UserDataApi
                {
                    ueid = userClaims.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier)?.Value,
                };
            }

            return null;
        }

    }
}
