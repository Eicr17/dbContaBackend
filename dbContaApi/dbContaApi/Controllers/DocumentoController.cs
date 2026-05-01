using dbContaApi.Modelos;
using dbContaLibrary.Interfaces;
using dbContaLibrary.Modelos;
using dbContaLibrary.Servicios;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

namespace dbContaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentoController : ControllerBase
    {
        private readonly IDocumento _documentoservice;

        public DocumentoController(IDocumento documentoServices) 
        {
            _documentoservice = documentoServices;
        }

        [HttpGet]
        [Route("Obtener")]
        public IActionResult Get(string? pCriterioBusqueda = null)
        {
            var resp = new ApiRespuestaListado<DocumentoApi>();
            var lstDocumento = new List<DocumentoApi>();

            try
            {
            
                var lstTpGetDocumento = _documentoservice.GetDoc(pCriterioBusqueda);
                lstTpGetDocumento.ToList().ForEach(
                    Doc =>
                    {
                        lstDocumento.Add(
                         new DocumentoApi
                         {
                             numero = Doc.Numero,
                             serie = Doc.Serie,
                             tipodocumento = Doc.TipoDocumento,
                             idempresa = Doc.IdEmpresa,
                             fecha = Doc.Fecha,
                             monto = Doc.Monto,
                             usuariocreacion = Doc.UsuarioCreacion,
                            fechacreacion = Doc.FechaCreacion,
                            fechaexpiracion = Doc.FechaExpiracion,
                         }

                        );
                    }
                    );
                resp.datos = lstDocumento;
                resp.mensaje = string.Empty;
                resp.total_registros = lstDocumento.Count;
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                
            }
            
        
        }

        [HttpPost]
        [Route("Insertar")]
        public IActionResult Insert([FromBody] DtoDocumentoInsertar pRequest) 
        {
            var InDoc = new MdlDocCrear();
            try
            {
              
                InDoc.IdEmpresa = pRequest.idempresa;
                InDoc.Monto = pRequest.monto;
                InDoc.UsuarioCreacion = "Admin";
                InDoc.FechaExpiracion = pRequest.fechaexpiracion;
                _documentoservice.Insertar(InDoc);
                var resp = new MdlMensajeRep();
                resp.mensaje_exitoso = "Se a insertado exitosamente el Docuemnto";
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
        public IActionResult Actualizar([FromBody] DtoDocumentoActualizar pRequest) 
        {
            var AcDocumento = new MdlDocActualizar();
            try
            {
                AcDocumento.Numero = pRequest.numero;
                AcDocumento.Serie = pRequest.serie;
                AcDocumento.TipoDocumento = pRequest.tipodocumento;
                AcDocumento.IdEmpresa = pRequest.idempresa;
                AcDocumento.Monto = pRequest.monto;
                AcDocumento.FechaExpiracion = pRequest.fechaexpiracion;
                _documentoservice.Actualizar(AcDocumento);
                var resp = new MdlMensajeRep();
                resp.mensaje_exitoso = " Se a actualizado el documento exitosamente";
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
            var resp = new ApiRespuesta();
            try
            {
                _documentoservice.Eliminar(pId);
                resp.exitosa = true;
                resp.mensaje = "El Registro a sido eliminado";
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
               
            }
        
        }
    }
}
