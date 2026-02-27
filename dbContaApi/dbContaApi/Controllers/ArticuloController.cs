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
    public class ArticuloController : ControllerBase
    {
        private readonly IArticulo _articuloservice;

        public ArticuloController(IArticulo articuloservice) 
        {
            _articuloservice = articuloservice;
        }

      [HttpGet]
      [Route("Obtener")]
    public IActionResult GetArticulo() 
      {
            var resp = new ApiRespuestaListado<ArticuloApi>();
            var lstArticulo = new List<ArticuloApi>();
            try
            {
                var lstArticuloGet = _articuloservice.Get();
                lstArticuloGet.ForEach(
                    art =>
                    {
                        lstArticulo.Add(
                            new ArticuloApi 
                            {
                                idArticulo = art.IdArticulo,
                                idTipoArticulo = art.IdTipoArticulo,
                                nombre = art.Nombre,
                                descripcion = art.Descripcion,
                                usuarioCreacion = art.UsuarioCreacion,
                            }
                        );


                    }


              );
                resp.datos = lstArticulo;
                resp.mensaje = string.Empty;
                resp.total_registros = lstArticulo.Count;
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
        public IActionResult Insert([FromBody] ArticuloApi item) 
        {
            var TpArticulo = new MdlArticuloCrear();
            try
            {
                TpArticulo.IdArticulo = item.idArticulo;
                TpArticulo.IdTipoArticulo = item.idTipoArticulo;
                TpArticulo.Nombre = item.nombre;
                TpArticulo.Descripcion = item.descripcion;
                TpArticulo.UsuarioCreacion = item.usuarioCreacion;
                _articuloservice.InsertarArticulo(TpArticulo);
                var resp = new MdlMensajeRep();
                resp.mensaje_exitoso = "Se ha insertado exitosamente el articulo";
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
        public IActionResult Actualizar([FromBody] ArticuloApi item) 
        {
            var tpArticuloAct = new MdlArticuloActualizar();
            try
            {
                tpArticuloAct.IdTipoArticulo = item.idTipoArticulo;
                tpArticuloAct.Nombre = item.nombre;
                tpArticuloAct.Descripcion = item.descripcion;
                tpArticuloAct.UsuarioCreacion = item.usuarioCreacion;
                _articuloservice.ActualizarArticulo(tpArticuloAct);
                var resp = new MdlMensajeRep();
                resp.mensaje_exitoso = "Se ha actualizado exitosmente";
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
                _articuloservice.Eliminar(pId);
                resp.exitosa = true;
                resp.mensaje = "Se ha eliminado exitosamente el registro";
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
