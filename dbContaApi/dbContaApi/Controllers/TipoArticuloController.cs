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
        public IActionResult Get(string? pBusqueda = null) 
        {
            int idtpArt = 0;
            string Nombre = "";
            var resp = new ApiRespuestaListado<TipoArticuloApi>();
            var lstTipoArticulo = new List<TipoArticuloApi>();

            try
            {
                if (!int.TryParse(pBusqueda, out  idtpArt))
                {
                    Nombre = pBusqueda;
                }


                var lstTpArticuloGet = _tipoarticuloservice.GetList(idtpArt,Nombre);
                lstTpArticuloGet.ForEach(
                    art =>
                    {
                        lstTipoArticulo.Add
                        (
                            new TipoArticuloApi
                            {
                                    idtipoArticulo  = art.IdTipoArticulo,
                                    nombre = art.Nombre,
                                    descripcion = art.Descripcion,
                                    fechaCreacion = art.FechaCreacion,
                                    usuarioCreacion = art.UsuarioCreacion
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
            }
        
        }

        [HttpPost]
        [Route("Insertar")]

        public IActionResult InsertarTpArticulo([FromBody] DtoTipoArticuloInsertar pRequest) 
        {
            var TpArticuloInsert = new MdlTipoArticuloCrear();
            try
            {
                TpArticuloInsert.Nombre = pRequest.nombre;
                TpArticuloInsert.Descripcion = pRequest.descripcion;
                TpArticuloInsert.UsuarioCreacion = "";
                _tipoarticuloservice.InsertarTpArticulo(TpArticuloInsert);
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


        [HttpPost]
        [Route("Actualizar")]
        public IActionResult Actualizar([FromBody] DtoTipoArticuloActualizar pRequest)
        {
            var TpArtActualizaicon = new MdlTipoArticuloAct();

            try
            {
                TpArtActualizaicon.IdTipoArticulo = pRequest.idtipoArticulo;
                TpArtActualizaicon.Nombre = pRequest.nombre;
                TpArtActualizaicon.Descripcion = pRequest.descripcion;
                TpArtActualizaicon.UsuarioCreacion = "Admin";
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
        [Route("Eliminar/{pIdTpArt}")]
        public IActionResult Eliminar(int pIdTpArt)
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
