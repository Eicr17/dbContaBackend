using dbContaApi.Modelos;
using dbContaLibrary.Interfaces;
using dbContaLibrary.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace dbContaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuario _usuarioservices;
        public UsuarioController(IUsuario usuarioservices, IConfiguration configuration) 
        {

            _usuarioservices = usuarioservices;
        }

        [Authorize]
        [HttpGet]
        [Route("Obtener")]
        public IActionResult Get(string? idUsuario = null) 
        {
            var resp = new ApiRespuestaListado<UsuarioApi>();
            var lstUsuario = new List<UsuarioApi>();
            try
            {
                var lstGetUsuario = _usuarioservices.GetUsuario(idUsuario);
                lstGetUsuario.ToList().ForEach(
                usr =>
                {
                    lstUsuario.Add(
                        new UsuarioApi 
                        {
                            idusuario = usr.IdUsuario,
                            nombreusuario = usr.NombreUsuario,
                            email = usr.Email,
                            fechacreacion = usr.FechaCreacion,
                            usuariocreacion = usr.UsuarioCreacion
                        }
                        );
                }
                );
                resp.total_registros = lstUsuario.Count;
                resp.mensaje = string.Empty;
                resp.datos = lstUsuario;
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        
        }



        [HttpPost]
        [Route("Insertar")]
        public IActionResult Insertar([FromBody] DtoUsuarioInsertar pRequest)
        {
            var TpUsuario = new MdlUsuarioInsertar();
            try
            {
                TpUsuario.IdUsuario = pRequest.idusuario;
                TpUsuario.NombreUsuario = pRequest.nombreusuario;
                TpUsuario.Password = pRequest.password;
                TpUsuario.Email = pRequest.email;
                TpUsuario.UsuarioCreacion = "Admin";
                _usuarioservices.Insertar(TpUsuario);
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
        public IActionResult Actualizar([FromBody] DtoUsuarioActualizar pRequest)
        {
            var ActUsuario = new MdlUsuarioActualizar();
            try
            {
                ActUsuario.IdUsuario = pRequest.idusuario;
                ActUsuario.NombreUsuario = pRequest.nombreusuario;
                ActUsuario.Password = pRequest.password;
                ActUsuario.Email = pRequest.email;
                ActUsuario.UsuarioCreacion = "Admin";
                _usuarioservices.Actualizar(ActUsuario);
                var resp = new MdlMensajeRep();
                resp.mensaje_exitoso = "Se a  actualizado exitosamente";
                return Ok(resp);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }




        [HttpDelete]
        [Route("Eliminar/{pId}")]
        public IActionResult Eliminar(string pId)
        {
            try
            {
                _usuarioservices.Eliminar(pId);
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
