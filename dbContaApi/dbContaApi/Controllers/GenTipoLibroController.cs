using dbContaApi.Modelos;
using dbContaLibrary.Interfaces;
using dbContaLibrary.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dbContaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenTipoLibroController : ControllerBase
    {
        private readonly IGenTipoLibro _gentipolibroservices;

        public GenTipoLibroController(IGenTipoLibro  gentipolibroservices) 
        {
            _gentipolibroservices = gentipolibroservices;
        }
        [HttpPost]
        [Route("Insertar")]
        public IActionResult Insertar([FromBody] GenTipoLibroApi pRequest) 
        {
            var GenTpLibro = new MdlGenTipoLibro();
            try
            {
                GenTpLibro.Folio = pRequest.folio;
                GenTpLibro.Empresa = pRequest.empresa;
                GenTpLibro.TipoLibro = pRequest.tipolibro;
                GenTpLibro.Usuario = pRequest.usuario;
                GenTpLibro.AnioLibro = pRequest.aniolibro;
                GenTpLibro.MesLibro = pRequest.meslibro;
                GenTpLibro.IdLibro = pRequest.idlibro;
                _gentipolibroservices.Insertar(GenTpLibro);
                var resp = new MdlMensajeRep();
                resp.mensaje_exitoso = "Se a insertado el libro exitosamente";
                return Ok(resp);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        
        }
    }
}
