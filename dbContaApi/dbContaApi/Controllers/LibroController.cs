using dbContaApi.Modelos;
using dbContaLibrary.Interfaces;
using dbContaLibrary.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dbContaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly ILibro _libroServices;

        public LibroController(ILibro libroservices) 
        {
            _libroServices = libroservices;
        }

        [HttpGet]
        [Route("Obtener")]
        public IActionResult Get()
        {
            var resp = new ApiRespuestaListado<LibroApi>();
            var lstLibro = new List<LibroApi>();

            try
            {
                var lstLibroGet = _libroServices.Get();
                lstLibroGet.ToList().ForEach(
                    lib =>
                    {
                        lstLibro.Add(
                         new LibroApi
                         {
                             idlibro = lib.IdLibro,
                             fecha = lib.Fecha,
                             folio = lib.Folio,
                             monto = lib.Monto,
                             idempresa = lib.IdEmpresa,
                             idtipolibro = lib.IdTipoLibro,
                             usuariocreacion = lib.UsuarioCreacion,
                             fechacreacion = lib.FechaCreacion,
                            
                         }
                       );
                    }

                    );

                resp.total_registros = lstLibro.Count;
                resp.mensaje = string.Empty;
                resp.datos = lstLibro;
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
               
            }
           

        }
    }
}
