using dbContaApi.Modelos;
using dbContaLibrary.Interfaces;
using dbContaLibrary.Modelos;
using dbContaLibrary.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace dbContaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoLibroController : ControllerBase
    {
        private readonly ITipoLibro _tipoLibroService;
        public TipoLibroController(ITipoLibro tipoLibroService)
        {
            _tipoLibroService = tipoLibroService;
        }

        [HttpGet]
        [Route("Get")]
        public IActionResult Get()
        {
            var respuesta = new ApiRespuestaListado<TipoLibroApi>();
            var lstLibroTipo = new List<TipoLibroApi>();

            try
            {
                var lstTpLibroTask = _tipoLibroService.GetList();
                lstTpLibroTask.ForEach(
                    lib =>
                    {
                        lstLibroTipo.Add(
                          new TipoLibroApi
                          {
                              idtipolibro = lib.IdTipoLibro,
                              nombre = lib.Nombre,
                              descripcion = lib.Descripcion,
                              usuariocreacion = lib.UsuarioCreacion,
                              fechacreacion = lib.FechaCreacion,
                          }
                          );

                    });

                respuesta.datos = lstLibroTipo;
                respuesta.mensaje = string.Empty;
                respuesta.total_registros = lstLibroTipo.Count;

                return Ok(respuesta);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Crear")]
        public IActionResult Crear([FromBody] TipoLibroApi pRequest)
        {
            var lstTpLibroInsert = new MdlTipoLibroCrear();
            try
            {
                lstTpLibroInsert.IdTipoLibro = pRequest.idtipolibro;
                lstTpLibroInsert.Nombre = pRequest.nombre;
                lstTpLibroInsert.Descripcion = pRequest.descripcion;
                lstTpLibroInsert.UsuarioCreacion = pRequest.usuariocreacion;
                _tipoLibroService.InsertTipoLibro(lstTpLibroInsert);
                var resp = new MdlMensajeRep();
                resp.mensaje_exitoso = "La insercion a sido exitosa";
                return Ok(resp);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpPut]
        [Route("Actualizar")]
        public IActionResult Actualizar([FromBody] TipoLibroApi pRequest)
        {
            var TpLibroActualizaicon = new MdlTipoLibroActualizar();

            try
            {
                TpLibroActualizaicon.IdTipoLibro = pRequest.idtipolibro;
                TpLibroActualizaicon.Nombre = pRequest.nombre;
                TpLibroActualizaicon.Descripcion = pRequest.descripcion;
                TpLibroActualizaicon.Usuario_Creacion = pRequest.usuariocreacion;
                _tipoLibroService.ActualizarTipoLibro(TpLibroActualizaicon);
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
                    _tipoLibroService.Eliminar(pId);
                    resp.exitosa = true;
                    resp.mensaje = "El Registro a sido eliminado";
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
