using dbContaApi.Modelos;
using dbContaLibrary.Interfaces;
using dbContaLibrary.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace dbContaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresa _empresaService;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public EmpresaController(IEmpresa empresaService) 
        {
            _empresaService = empresaService;
           
        }

        [HttpGet]
        [Route("Obtener")]
        public IActionResult Get(string? pCriterioBusqueda = null) 
        {
            var resp = new ApiRespuestaListado<EmpresaApi>();
            var lstEmpresa = new List<EmpresaApi>();
            
            try
            {                
                var lstEmpresaTp = _empresaService.Get(pCriterioBusqueda);
                lstEmpresaTp.ToList().ForEach(
                    emp =>
                    {
                        lstEmpresa.Add(
                        new EmpresaApi
                        {
                           idempresa = emp.IdEmpresa,
                           nombre  = emp.Nombre,
                           usuario = emp.UsuarioCreacion,
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
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
               
            }
        }


        [HttpPost]
        [Route("Insertar")]
        public IActionResult Insertar([FromBody] DtoEmpresaInsertar pRequest) 
        {
            var empresa = new MdlEmpresaInsertar();
            try
            {
                
                empresa.Nombre = pRequest.nombre;
                empresa.UsuarioCreacion = "Admin";
                empresa.Nit = pRequest.nit;
                _empresaService.Insertar(empresa);
                var resp = new MdlMensajeRep();
                resp.mensaje_exitoso = "Se a registrado el registro exitosamente";
                return Ok(resp);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error al Insertar los datos de la empresa");
                return BadRequest("Error al Insertar los datos de la empresa");
            }
        }


        [HttpPost]
        [Route("Actualizar")]
        public IActionResult Actualizar([FromBody] DtoEmpresaActualizar pRequest)
        {
            var ActEmpresa = new MdlActualizarEmpresa();
            try
            {
                ActEmpresa.IdEmpresa = pRequest.idempresa;
                ActEmpresa.Nombre = pRequest.nombre;
                ActEmpresa.Usuario = "Admin";
                ActEmpresa.Nit = pRequest.nit;
                _empresaService.Actualizar(ActEmpresa);
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
                logger.Error(ex, "Error al eliminar el id ");
                return BadRequest("Error al eliminar el id");

            }
             
        }
    } 
}
