using dbContaApi.Modelos;
using dbContaLibrary.Interfaces;
using dbContaLibrary.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace dbContaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentoDetalleController : ControllerBase
    {
        private readonly IDocumentoDetalle _documentoDetalleService;

        public DocumentoDetalleController(IDocumentoDetalle docDetalleService)
        {
            _documentoDetalleService = docDetalleService;
        }


        [HttpGet]
        [Route("Obtener")]
        public IActionResult GetDocumentoeDetalle(string? pCriterioBusqueda  = null)
        {
            var resp = new ApiRespuestaListado<DocumentoDetalleApi>();
            var lstDocDetalle = new List<DocumentoDetalleApi>();

            int idDocDet = 0;
            string numero = "";

            try
            {

                if (!int.TryParse(pCriterioBusqueda, out idDocDet))
                {
                    numero = pCriterioBusqueda;
                }

                var lstDtDoc = _documentoDetalleService.Get(idDocDet,numero);
                lstDtDoc.ToList().ForEach(
                    dtDoc =>
                    {
                        lstDocDetalle.Add(
                       new DocumentoDetalleApi
                       {
                           idDocumentoDetalle = dtDoc.IdDocumentoDetalle,
                           numero = dtDoc.Numero,
                           serie = dtDoc.Serie,
                           tipodocumento = dtDoc.TipoDocumento,
                           idArticulo = dtDoc.IdArticulo,
                           cantidad = dtDoc.Cantidad,
                           precio = dtDoc.Precio,
                           usuariocreacion = dtDoc.UsuarioCreacion,
                           fechacreacion = dtDoc.FechaCreacion,
                       }
                     );
                    }
                );

                resp.datos = lstDocDetalle;
                resp.total_registros = lstDocDetalle.Count;
                return Ok(resp);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                ; }
        }

        [HttpPost]
        [Route("Insertar")]
        public IActionResult Insertar([FromBody] DtoDocumentoDetInsertar pRequest)
        {
              var InDtDocumento = new MdlDocumentoDetalleCrear();
            try
            {
                InDtDocumento.Numero = pRequest.numero;
                InDtDocumento.Serie = pRequest.serie;
                InDtDocumento.TipoDocumento = pRequest.tipodocumento;
                InDtDocumento.IdArticulo = pRequest.idArticulo;
                InDtDocumento.Cantidad = pRequest.cantidad;
                InDtDocumento.Precio = pRequest.precio;
                InDtDocumento.UsuarioCreacion = "Admin";
                _documentoDetalleService.Insertar(InDtDocumento);
                var resp = new MdlMensajeRep();
                resp.mensaje_exitoso = "Se a insertado el  registro exitosamente";
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("Actualizar")]
        public IActionResult Actualizar([FromBody] DocumentoDetalleApi pRequest) 
        {
            var AcDocDt = new MdlDtDocumentoActualizar();
            try
            {
                AcDocDt.IdDocumentoDetalle = pRequest.idDocumentoDetalle;
                AcDocDt.Numero = pRequest.numero;
                AcDocDt.Serie = pRequest.serie;
                AcDocDt.TipoDocumento = pRequest.tipodocumento;
                AcDocDt.IdArticulo = pRequest.idArticulo;
                AcDocDt.Cantidad = pRequest.cantidad;
                AcDocDt.Precio = pRequest.precio;
                AcDocDt.UsuarioCreacion = "Admin";
                _documentoDetalleService.Actualizar(AcDocDt);
                var resp = new MdlMensajeRep();
                resp.mensaje_exitoso = "Se a actualizado el documento detalle";
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
                _documentoDetalleService.Eliminar(pId);
                var resp = new MdlMensajeRep();
                resp.mensaje_exitoso = "Se a eliminado el registro exitosamente";
                return Ok(resp);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        
        
        }
    }
}
