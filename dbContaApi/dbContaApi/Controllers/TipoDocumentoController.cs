using dbContaApi.Modelos;
using dbContaLibrary.Interfaces;
using dbContaLibrary.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dbContaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoDocumentoController : ControllerBase
    {
        private readonly ITipoDocumento _tipoDocumentoService;
        public TipoDocumentoController(ITipoDocumento tipodocumentoservice)
        {
            _tipoDocumentoService = tipodocumentoservice;
        }


        [HttpGet]
        [Route("Get")]
        public IActionResult Get()
        {

            var resp = new ApiRespuestaListado<TipoDocumentoApi>();
            var lstTipoDocumento = new List<TipoDocumentoApi>();

            try
            {
                var lstTpLibroGet = _tipoDocumentoService.GetList();
                lstTpLibroGet.ForEach(
                     lib =>
                     {
                         lstTipoDocumento.Add(
                            new TipoDocumentoApi
                            {

                                idtipodocumento = lib.IdTipoDocumento,
                                nombre = lib.Nombre,
                                descripcion = lib.Descripcion,
                                usuariocreacion = lib.UsuarioCreacion,
                                fechacreacion = lib.FechaCreacion,
                               idcategoriadocumento = lib.IdCategoriaDocumento

                            }

                          );
                     });
                resp.datos = lstTipoDocumento;
                resp.mensaje = string.Empty;
                resp.total_registros = lstTipoDocumento.Count;
                return Ok(resp);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }

        }


        [HttpPost]
        [Route("Insertar")]
        public IActionResult Insertar([FromBody] TipoDocumentoApi pRequest) 
        {
            var TpDocumentoActuzlicar = new MdlTipoDocCrear();

            try
            {
                TpDocumentoActuzlicar.IdTipoDocumento = pRequest.idtipodocumento;
                TpDocumentoActuzlicar.Nombre = pRequest.nombre;
                TpDocumentoActuzlicar.Descripcion = pRequest.descripcion;
                TpDocumentoActuzlicar.UsuarioCreacion = pRequest.usuariocreacion;
                TpDocumentoActuzlicar.IdCategoriaDocumento = pRequest.idcategoriadocumento;
                _tipoDocumentoService.InsertarTipoDoc(TpDocumentoActuzlicar);
                var resp = new MdlMensajeRep();
                resp.mensaje_exitoso = "Tipo Documento Insertar Exitosamente";
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
        public IActionResult Actualizar([FromBody] MdlTpDocActualizar item) 
        {
            var TpLibroActualizacion = new MdlTpDocActualizar();
            try
            {
                TpLibroActualizacion.IdTipoDocumento = item.IdTipoDocumento;
                TpLibroActualizacion.Nombre = item.Nombre;
                TpLibroActualizacion.Descripcion = item.Descripcion;
                TpLibroActualizacion.UsuarioCreacion = item.UsuarioCreacion;
                _tipoDocumentoService.ActualizarTpDoc(TpLibroActualizacion);
                var resp = new MdlMensajeRep();
                resp.mensaje_exitoso = "La Actualizacion ha sido exitosa";
                return Ok(resp);
               
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        
        
        }

        [HttpPut]
        [Route("Eliminar/{pId}")]
        public IActionResult Eliminar(int pId) 
        {

            var resp = new ApiRespuesta();
            try
            {
                _tipoDocumentoService.Eliminar(pId);
                resp.exitosa = true;
                resp.mensaje = "Tipo Documento Eliminado";
                return Ok(resp);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        
        }

    }
}
