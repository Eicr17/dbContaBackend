using dbContaApi.Modelos;
using dbContaLibrary.Interfaces;
using dbContaLibrary.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace dbContaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoles _rolesServices;

        public RolesController(IRoles rolesServices) 
        {

            _rolesServices = rolesServices;
        
        }


        [HttpGet]
        [Route("Obtener")]
        public IActionResult Get() 
        {
            var resp = new ApiRespuestaListado<RolesApi>();
            var lstObRoles = new List<RolesApi>();

            try
            {
                var lstGetRoles = _rolesServices.GetRoles();
                lstGetRoles.ToList().ForEach(
                    rol => {
                       {
                            lstObRoles.Add(
                            new RolesApi
                            {
                                idrol = rol.IdRol,
                                nombrerol = rol.NombreRol,
                                usuariocreacion = rol.UsuarioCreacion,
                            }
                         );

                       }
                    
                    }

                    );
                resp.datos = lstObRoles;
                resp.total_registros  = lstObRoles.Count;
                resp.mensaje = string.Empty;
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
       
        }


        [HttpPost]
        [Route("Insertar")]
        public IActionResult Insertar([FromBody]  RolesApi item) 
        {
            var rolInsertar = new MdlRolesInsertar();

            try
            {
                rolInsertar.IdRol = item.idrol;
                rolInsertar.NombreRol = item.nombrerol;
                rolInsertar.UsuarioCreacion = item.usuariocreacion;
                _rolesServices.Insertar(rolInsertar);
                var resp = new ApiRespuesta();
                resp.mensaje = "Se a insertado el registro exitosamente";
                return Ok(resp);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        
        }


        [HttpPut]
        [Route("Actualizar")]
        public IActionResult Actualizar([FromBody] RolesApi item)
        {
            var rolActualizar = new MdlRolesActualizar();
            try
            {
                rolActualizar.IdRol = item.idrol;
                rolActualizar.NombreRol = item.nombrerol;
                rolActualizar.UsuarioCreacion = item.usuariocreacion;
                _rolesServices.Actualizar(rolActualizar);
                var resp = new ApiRespuesta();
                resp.mensaje = "Se a actualizado el registro";
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Eliminar")]
        public IActionResult Eliminar(int pId)
        {
            var resp = new ApiRespuesta();
            try
            {
                _rolesServices.Eliminar(pId);
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
