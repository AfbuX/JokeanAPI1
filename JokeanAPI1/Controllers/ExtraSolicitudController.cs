using JokeanAPI1Models;
using JokeanAPI1Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JokeanAPI1.Controllers
{
    /// <summary>
    /// Controlador para gestionar las solicitudes extras del servicio.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ExtraSolicitudController : ControllerBase
    {
        private readonly ILogger<ExtraSolicitudController> _logger;
        private readonly IExtraSolicitudQueries _extraSolicitudQueries;
        private readonly IExtraSolicitudRepository _extraSolicitudRepository;

        /// <summary>
        /// Constructor del controlador de solicitudes extras.
        /// </summary>
        public ExtraSolicitudController(
            ILogger<ExtraSolicitudController> logger, 
            IExtraSolicitudQueries extraSolicitudQueries, 
            IExtraSolicitudRepository extraSolicitudRepository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _extraSolicitudQueries = extraSolicitudQueries ?? throw new ArgumentNullException(nameof(extraSolicitudQueries));
            _extraSolicitudRepository = extraSolicitudRepository ?? throw new ArgumentNullException(nameof(extraSolicitudRepository));
        }

        /// <summary>
        /// Obtiene todas las solicitudes extras registradas.
        /// </summary>
        /// <returns>Lista de solicitudes extras.</returns>
        /// <response code="200">Retorna la lista de solicitudes extras.</response>
        /// <response code="500">Error interno del servidor.</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ExtraSolicitud>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Listar()
        {
            try
            {
                _logger.LogInformation("Consultando solicitudes extras");
                var rs = await _extraSolicitudQueries.GetAll();
                return Ok(rs);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al consultar solicitudes extras");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Crea una nueva solicitud extra.
        /// </summary>
        /// <param name="extraSolicitud">Datos de la solicitud extra a crear.</param>
        /// <returns>La solicitud extra creada.</returns>
        /// <response code="200">Retorna la solicitud extra creada.</response>
        /// <response code="400">Si los datos de la solicitud son inválidos.</response>
        /// <response code="500">Error interno del servidor.</response>
        [HttpPost]
        [ProducesResponseType(typeof(ExtraSolicitud), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Crear([FromBody] ExtraSolicitud extraSolicitud)
        {
            try
            {
                _logger.LogInformation("Creando nueva solicitud extra");
                var rs = await _extraSolicitudRepository.Add(extraSolicitud);
                return Ok(rs);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear solicitud extra");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
