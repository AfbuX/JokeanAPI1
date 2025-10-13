using JokeanAPI1Models;
using JokeanAPI1Repository.Implements;
using JokeanAPI1Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JokeanAPI1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExtraSolicitudController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IExtraSolicitudQueries _extraSolicitudQueries;
        private readonly IExtraSolicitudRepository _extraSolicitudRepository;

        public ExtraSolicitudController(ILogger logger, IExtraSolicitudQueries extraSolicitudQueries, IExtraSolicitudRepository extraSolicitudRepository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _extraSolicitudQueries = extraSolicitudQueries ?? throw new ArgumentNullException(nameof(extraSolicitudQueries));
            _extraSolicitudRepository = extraSolicitudRepository ?? throw new ArgumentNullException(nameof(extraSolicitudRepository));
        }

        [HttpGet]
        public async Task<IActionResult> listar()
        {
            try
            {
                _logger.LogInformation("Consultando en bsae de datos");
                var rs = await _extraSolicitudQueries.GetAll();
                return Ok(rs);
            }
            catch (Exception ex) {
                _logger.LogError(ex, "algo salio mal");
                return StatusCode(StatusCodes.Status500InternalServerError);
            
            }
        }
        [HttpPost]
        public async Task<IActionResult> Crear(ExtraSolicitud extraSolicitud)
        {
            try
            {
                _logger.LogInformation("generando solicitud extra");
                var rs = await _extraSolicitudRepository.Add(extraSolicitud);
                return Ok(rs);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "algo salio mal");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
