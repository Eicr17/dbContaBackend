using dbContaApi.Modelos;
using dbContaLibrary.Interfaces;
using dbContaLibrary.Modelos;
using dbContaLibrary.Servicios;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Get()
        {
            var resp = new ApiRespuestaListado<DocumentoApi>();
            var lstDocumento = new List<DocumentoApi>();
            try
            {
                var lstTpGetDocumento = _documentoservice.GetDoc();
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
        public IActionResult Insert([FromBody] DocumentoApi pRequest) 
        {
            var lstInDoc = new MdlDocCrear();
            try
            {
                lstInDoc.Numero = pRequest.numero;
                lstInDoc.Serie = pRequest.serie;
                lstInDoc.TipoDocumento = pRequest.tipodocumento;
                lstInDoc.IdEmpresa = pRequest.idempresa;
                lstInDoc.Fecha = pRequest.fecha;
                lstInDoc.Monto = pRequest.monto;
                lstInDoc.UsuarioCreacion = pRequest.usuariocreacion;
                lstInDoc.FechaExpiracion = pRequest.fechaexpiracion;
                _documentoservice.Insertar(lstInDoc);
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

        [HttpPut]
        [Route("Actualiar")]
        public IActionResult Actualizar([FromBody] DocumentoApi pRequest) 
        {
            var lstAcDocumento = new MdlDocActualizar();
            try
            {
                lstAcDocumento.Numero = pRequest.numero;
                lstAcDocumento.Serie = pRequest.serie;
                lstAcDocumento.TipoDocumento = pRequest.tipodocumento;
                lstAcDocumento.IdEmpresa = pRequest.idempresa;
                lstAcDocumento.Fecha = pRequest.fecha;
                lstAcDocumento.Monto = pRequest.monto;
                lstAcDocumento.UsuarioCreacion = pRequest.usuariocreacion;
                lstAcDocumento.FechaExpiracion = pRequest.fechaexpiracion;
                _documentoservice.Actualizar(lstAcDocumento);
                var resp = new MdlMensajeRep();
                resp.mensaje_exitoso = " Se a actualizado el documento exitosamente";
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
