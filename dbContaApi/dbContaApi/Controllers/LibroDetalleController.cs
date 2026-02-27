using dbContaApi.Modelos;
using dbContaLibrary.Interfaces;
using dbContaLibrary.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dbContaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroDetalleController : ControllerBase
    {
        private readonly ILibroDetalle _librodetalleServices;

        public LibroDetalleController(ILibroDetalle detallelibroServices) 
        {
            _librodetalleServices = detallelibroServices;
        }

        [HttpGet]
        [Route("Obtener")]
        public IActionResult GetLibroDetalle() 
        {
            var lstLbDet = new List<LibroDetalleApi>();
            var resp = new ApiRespuestaListado<LibroDetalleApi>();
            try
            {
                var lbdetGet = _librodetalleServices.Obtener();
                lbdetGet.ToList().ForEach(
                      libdt =>
                      {
                          lstLbDet.Add(
                          new LibroDetalleApi
                          {
                              idlibrodetalle = libdt.IdLibroDetalle,
                              idlibro = libdt.IdLibro,
                              fecha = libdt.Fecha,
                              numero = libdt.Numero,
                              serie = libdt.Serie,
                              tipoDocumento = libdt.TipoDocumento,
                              usuarioCreacion = libdt.UsuarioCreacion
                          }
                          );
                      }
                    );
                resp.total_registros = lstLbDet.Count;
                resp.mensaje = string.Empty;
                resp.datos = lstLbDet;
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                
            }
        
        
        
        }

    }
}
