using dbContaApi.Modelos;
using dbContaLibrary.Interfaces;
using dbContaLibrary.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dbContaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresa _empresaService;

        public EmpresaController(IEmpresa empresaService) 
        {
            _empresaService = empresaService;
        }

        [HttpGet]
        [Route("Obtener")]
        public IActionResult Get() 
        {
            var resp = new ApiRespuestaListado<EmpresaApi>();
            var lstEmpresa = new List<EmpresaApi>();

            try
            {
                var lstEmpresaTp = _empresaService.Get();
                lstEmpresaTp.ToList().ForEach(
                    emp =>
                    {
                        lstEmpresa.Add(
                        new EmpresaApi
                        {
                           idempresa = emp.IdEmpresa,
                           nombre  = emp.Nombre,
                           usuariocreacion = emp.UsuarioCreacion,
                           fechacreacion = emp.FechaCreacion,
                           nit = emp.Nit,
                        }
                       );
                    }
                    );
                resp.datos = lstEmpresa;
                resp.mensaje = "Se muestra la cantidad de consultas";
                resp.total_registros = lstEmpresa.Count;
                return Ok(resp);
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpPost]
        [Route("Insertar")]
        public IActionResult Insertar([FromBody] EmpresaApi pRequest) 
        {
            var lstTpEmpresa = new MdlEmpresaInsertar();
            try
            {

                lstTpEmpresa.IdEmpresa = pRequest.idempresa;
                lstTpEmpresa.Nombre = pRequest.nombre;
                lstTpEmpresa.UsuarioCreacion = pRequest.usuariocreacion;
                lstTpEmpresa.Nit = pRequest.nit;
                _empresaService.Insertar(lstTpEmpresa);
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
        public IActionResult Actualizar([FromBody] EmpresaApi pRequest)
        {
            var lsActEmpresa = new MdlActualizarEmpresa();
            try
            {
                lsActEmpresa.IdEmpresa = pRequest.idempresa;
                lsActEmpresa.Nombre = pRequest.nombre;
                lsActEmpresa.UsuarioCreacion = pRequest.usuariocreacion;
                lsActEmpresa.Nit = pRequest.nit;
                _empresaService.Actualizar(lsActEmpresa);
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
                _empresaService.Eliminar(pId);
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
