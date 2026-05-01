using dbContaApi.Modelos;
using dbContaLibrary.Interfaces;
using dbContaLibrary.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dbContaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolUsuarioController : ControllerBase
    {
        private readonly IRolUsuario _rolservices;
        public RolUsuarioController(IRolUsuario rolservices)
        {

            _rolservices = rolservices;
        }

        [HttpGet]
        [Route("Obtener")]
        public IActionResult Get()
        {
            var resp = new ApiRespuestaListado<RolUsuarioApi>();
            var lstRolUsuario = new List<RolUsuarioApi>();

            try
            {
                var lstGetRolUsuario = _rolservices.Get();
                lstGetRolUsuario.ToList().ForEach(
                usrRol =>
                {
                    lstRolUsuario.Add(
                        new RolUsuarioApi
                        {
                            idrolusuario = usrRol.IdRolUsuario,
                            idrol = usrRol.IdRol,
                            idusuario = usrRol.IdUsuario,
                            fechacreacion = usrRol.FechaCreacion,
                            usuariocreacion = usrRol.UsuarioCreacion
                          
                        }
                        );
                }
                );
                resp.total_registros = lstRolUsuario.Count;
                resp.mensaje = string.Empty;
                resp.datos = lstRolUsuario;
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
        public IActionResult Insertar([FromBody] DtoRolUsuarioInsertar pRequest)
        {
            var RolUsuario = new MdlRolUsuarioInsertar();
            try
            {
                RolUsuario.IdRol = pRequest.idrol;
                RolUsuario.IdUsuario = pRequest.idusuario;
                RolUsuario.UsuarioCreacion = "Admin";
                _rolservices.Insertar(RolUsuario);
                var resp = new MdlMensajeRep();
                resp.mensaje_exitoso = "Se a registrado el registro exitosamente";
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);

            }
        }



        [HttpPost]
        [Route("Actualizar")]
        public IActionResult Actualizar([FromBody] DtoRolUsuarioActualizar pRequest)
        {
            var ActRolUsuario = new MdlRolUsuarioActualizar();
            try
            {
                ActRolUsuario.IdRolUsuario = pRequest.idrolusuario;
                ActRolUsuario.IdRol = pRequest.idrol;
                ActRolUsuario.IdUsuario = pRequest.idusuario;
                ActRolUsuario.UsuarioCreacion = "Admin";
                _rolservices.Actualizar(ActRolUsuario);
                var resp = new MdlMensajeRep();
                resp.mensaje_exitoso = "Se a actualizado exitosamente";
                return Ok(resp);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }




        [HttpDelete]
        [Route("Eliminar/{pId}")]
        public IActionResult Eliminar(int pId)
        {
            try
            {
                _rolservices.Eliminar(pId);
                var resp = new MdlMensajeRep();
                resp.mensaje_exitoso = "se a eliminado el registro";
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }

        }

    }
}

