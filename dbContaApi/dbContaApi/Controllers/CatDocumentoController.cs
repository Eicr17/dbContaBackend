using dbContaApi.Modelos;
using dbContaLibrary.Interfaces;
using dbContaLibrary.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dbContaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CatDocumentoController : ControllerBase
    {
        private readonly ICatDocumento _catDocumentoService;

        public CatDocumentoController(ICatDocumento catDocumentoService)
        {
            _catDocumentoService = catDocumentoService;
        }


        [HttpGet]
        [Route("Obtener")]
        public IActionResult GetCatDocumento()
        {
            var resp = new ApiRespuestaListado<CatDocumentoApi>();
            var lstCatDocumento = new List<CatDocumentoApi>();
            try
            {   
                var lstTpCatDocumento = _catDocumentoService.GetList();
                lstTpCatDocumento.ToList().ForEach(
                     art =>
                     {
                         lstCatDocumento.Add(
                            new CatDocumentoApi
                            {
                                idcategoriadocumento = art.IdCategoriaDocumento,
                                usuarioCreacion = art.UsuarioCreacion,
                                fechaCreacion = art.FechaCreacion,
                            }
                         );

                     }
                    );
                resp.datos = lstCatDocumento;
                resp.mensaje = string.Empty;
                resp.total_registros = lstCatDocumento.Count;
                return Ok(resp);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }


        }

        [HttpPost]
        [Route("Crear")]
        public IActionResult Insertar([FromBody] CatDocumentoApi item)
        {
            var lstCatDoc = new MdlCatDocCrear();
            try
            {
                lstCatDoc.IdCategoriaDocumento = item.idcategoriadocumento;
                lstCatDoc.UsuarioCreacion = item.usuarioCreacion;
                _catDocumentoService.Insertar(lstCatDoc);
                var resp = new MdlMensajeRep();
                resp.mensaje_exitoso = "Se a insertado el registro exitosamente";
                return Ok(resp);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }

        }

        [HttpPut]
        [Route("Actualizar")]
        public IActionResult Actualizar([FromBody] CatDocumentoApi item)
        {
            var lstAcCatDoc = new MdlCatDocActualizar();
            try
            {
                lstAcCatDoc.IdCategoriaDocumento = item.idcategoriadocumento;
                lstAcCatDoc.UsuarioCreacion = item.usuarioCreacion;
                _catDocumentoService.Actualizar(lstAcCatDoc);
                var resp = new MdlMensajeRep();
                resp.mensaje_exitoso = "Se a actualizado el registro exitosamente";
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Eliminar")]
        public IActionResult Eliminar(int pId) 
        {
            try
            {
                _catDocumentoService.Eliminar(pId);
                var resp = new MdlMensajeRep();
                resp.mensaje_exitoso = "Se ha eliminado exitosamente el registro";
                return Ok(resp);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }


}
