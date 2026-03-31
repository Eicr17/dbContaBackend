using dbContaApi.Modelos;
using dbContaLibrary.Interfaces;
using dbContaLibrary.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dbContaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoArticuloController : ControllerBase
    {
        private readonly ITipoArticulo _tipoarticuloservice;
        public  TipoArticuloController(ITipoArticulo tipodocumentoservice) 
        {
            _tipoarticuloservice = tipodocumentoservice;
        
        }

        [HttpGet]
        [Route("Get")]
        public IActionResult Get() 
        {
            var resp = new ApiRespuestaListado<TipoArticuloApi>();
            var lstTipoArticulo = new List<TipoArticuloApi>();

            try
            {
                var lstTpArticuloGet = _tipoarticuloservice.GetList();
                lstTpArticuloGet.ForEach(
                    art =>
                    {
                        lstTipoArticulo.Add
                        (
                            new TipoArticuloApi
                            {
                                    idtipoArticulo  = art.IdTipoArticulo,
                                    nombre = art.Nombre,
                                    //descripcion = art.Descripcion,
                                    //fechaCreacion = art.FechaCreacion,
                                    //usuarioCreacion = art.UsuarioCreacion
                            }
                        );
                    }


                );
                resp.datos = lstTipoArticulo;
                resp.mensaje = string.Empty;
                resp.total_registros = lstTipoArticulo.Count;
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

        public IActionResult InsertarTpArticulo([FromBody] TipoArticuloApi pRequest) 
        {
            var lstTpArticuloInsert = new MdlTipoArticuloCrear();
            try
            {
                lstTpArticuloInsert.IdTipoArticulo = pRequest.idtipoArticulo;
                lstTpArticuloInsert.Nombre = pRequest.nombre;
                lstTpArticuloInsert.Descripcion = pRequest.descripcion;
                lstTpArticuloInsert.UsuarioCreacion = pRequest.usuarioCreacion;
                _tipoarticuloservice.InsertarTpArticulo(lstTpArticuloInsert);
                var resp = new MdlMensajeRep();
                resp.mensaje_exitoso = "La insesrsion ha sido exitosa";
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
        public IActionResult Actualizar([FromBody] TipoArticuloApi pRequest)
        {
            var TpArtActualizaicon = new MdlTipoArticuloAct();

            try
            {
                TpArtActualizaicon.IdTipoArticulo = pRequest.idtipoArticulo;
                TpArtActualizaicon.Nombre = pRequest.nombre;
                TpArtActualizaicon.Descripcion = pRequest.descripcion;
                TpArtActualizaicon.UsuarioCreacion = pRequest.usuarioCreacion;
                _tipoarticuloservice.ActualizarTpDoc(TpArtActualizaicon);
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
        [HttpDelete]
        [Route("Eliminar/{pIdArt}")]
        public IActionResult Eliminar(int pIdArt, int pIdTpArt)
        {

            var resp = new ApiRespuesta();

            try
            {
                _tipoarticuloservice.Eliminar(pIdTpArt);
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
