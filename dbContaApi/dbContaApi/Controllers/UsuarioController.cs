using dbContaApi.Modelos;
using dbContaLibrary.Interfaces;
using dbContaLibrary.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dbContaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuario _usuarioservices;
        public UsuarioController(IUsuario usuarioservices) 
        {

            _usuarioservices = usuarioservices;
        }

        [HttpGet]
        [Route("Obtener")]
        public IActionResult Get() 
        {
            var resp = new ApiRespuestaListado<UsuarioApi>();
            var lstUsuario = new List<UsuarioApi>();

            try
            {
                var lstGetUsuario = _usuarioservices.GetUsuario();
                lstGetUsuario.ToList().ForEach(
                usr =>
                {
                    lstUsuario.Add(
                        new UsuarioApi 
                        {
                            idusuario = usr.IdUsuario,
                            nombreusuario = usr.NombreUsuario,
                            password = usr.Password,
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
                throw;
            }
        
        }



        [HttpPost]
        [Route("Insertar")]
        public IActionResult Insertar([FromBody] UsuarioApi pRequest)
        {
            var lstTpUsuario = new MdlUsuarioInsertar();
            try
            {

                lstTpUsuario.IdUsuario = pRequest.idusuario;
                lstTpUsuario.NombreUsuario = pRequest.nombreusuario;
                lstTpUsuario.Password = pRequest.password;
                lstTpUsuario.Email = pRequest.email;
                lstTpUsuario.UsuarioCreacion = pRequest.usuariocreacion;
                _usuarioservices.Insertar(lstTpUsuario);
                var resp = new MdlMensajeRep();
                resp.mensaje_exitoso = "Se a registrado el registro exitosamente";
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);

            }
        }



        [HttpPut]
        [Route("Actualizar")]
        public IActionResult Actualizar([FromBody] UsuarioApi pRequest)
        {
            var lsActUsuario = new MdlUsuarioActualizar();
            try
            {
                lsActUsuario.IdUsuario = pRequest.idusuario;
                lsActUsuario.NombreUsuario = pRequest.nombreusuario;
                lsActUsuario.Password = pRequest.password;
                lsActUsuario.Email = pRequest.email;
                lsActUsuario.UsuarioCreacion = pRequest.usuariocreacion;
                _usuarioservices.Actualizar(lsActUsuario);
                var resp = new MdlMensajeRep();
                resp.mensaje_exitoso = "Se a  actualizado exitosamente";
                return Ok(resp);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }




        [HttpPut]
        [Route("Eliminar/{pId}")]
        public IActionResult Eliminar(int pId)
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
