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
        [Route("Obtener")]
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
                              id_tipo_libro = lib.Id_Tipo_Libro,
                              nombre = lib.Nombre,
                              descripcion = lib.Descripcion,
                              usuario_creacion = lib.Usuario_Creacion,
                              fecha_creacion = lib.Fecha_Creacion,
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

    }
       
}
