using dbContaApi.Modelos;
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
        [HttpGet]
        [Route("Get")]
        public IActionResult Get()
        {
            var respuesta = new ApiRespuestaListado<TipoLibroApi>();
            var lstTpLibro = new List<MdlTipoLibro>();
            var lstLibroTipo = new List<TipoLibroApi>();

            try
            {
                lstTpLibro = SrvTipoLibro.GetList();
                lstTpLibro.ForEach(
                    lib =>
                    {
                        lstLibroTipo.Add(
                          new TipoLibroApi
                          {
                              idtipolibro = lib.Id_Tipo_Libro,
                              nombre = lib.Nombre,
                              descripcion = lib.Descripcion,
                              usuariocreacion = lib.Usuario_Creacion,
                              fechacreacion = lib.Fecha_Creacion,
                          }
                          );

                    });

                respuesta.datos = lstLibroTipo;
                respuesta.mensaje = string.Empty;
                respuesta.total_registros = lstTpLibro.Count;

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
            var TpLibroInsercion = new SrvTipoLibro();
            var InsercionTpLibro = new MdlTipoLibroCrear();
            try
            {
                InsercionTpLibro.IdTipoLibro = pRequest.idtipolibro;
                InsercionTpLibro.Nombre = pRequest.nombre;
                InsercionTpLibro.Descripcion = pRequest.descripcion;
                InsercionTpLibro.UsuarioCreacion = pRequest.usuariocreacion;
                TpLibroInsercion.InsertTipoLibro(InsercionTpLibro);
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
            var TpLibroActualizaicon = new SrvTipoLibro();
            var ActualizacionTpLibro = new MdlTipoLibroActualizar();

            try
            {
                ActualizacionTpLibro.IdTipoLibro = pRequest.idtipolibro;
                ActualizacionTpLibro.Nombre = pRequest.nombre;
                ActualizacionTpLibro.Descripcion = pRequest.descripcion;
                ActualizacionTpLibro.Usuario_Creacion = pRequest.usuariocreacion;
                TpLibroActualizaicon.ActualizarTipoLibro(ActualizacionTpLibro);
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
            var srvTipoLibro = new SrvTipoLibro();
            var resp = new ApiRespuesta();

            try
            {
                srvTipoLibro.Eliminar(pId);
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
