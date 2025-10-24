using JokeanAPI1Models;
using JokeanAPI1Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JokeanAPI1.Controllers
{
    /// <summary>
    /// Controlador para gestionar las calificaciones de los servicios.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]

    public class CalificacionController : ControllerBase
    {
        private readonly ICalificacionQueries _calificacionQueries;
        private readonly ICalificacionRepository _calificacionRepository;
        private readonly ILogger<CalificacionController> _logger;

        /// <summary>
        /// Constructor del controlador de calificaciones.
        /// </summary>
        public CalificacionController(
            ILogger<CalificacionController> logger,
            ICalificacionRepository calificacionRepository,
            ICalificacionQueries calificacionQueries)
        {
            _calificacionQueries = calificacionQueries ?? throw new ArgumentNullException(nameof(calificacionQueries));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _calificacionRepository = calificacionRepository ?? throw new ArgumentNullException(nameof(calificacionRepository));
        }

        /// <summary>
        /// Obtiene todas las calificaciones registradas.
        /// </summary>
        /// <returns>Lista de calificaciones existentes en el sistema.</returns>
        /// <response code="200">Retorna la lista de calificaciones.</response>
        /// <response code="500">Error interno del servidor.</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Calificacion>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Listar()
        {
            try
            {
                _logger.LogInformation("Consultando calificaciones");
                var rs = await _calificacionQueries.GetAll();
                _logger.LogTrace(rs.ToString());
                return Ok(rs);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al consultar calificaciones");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Crea una nueva calificación en el sistema.
        /// </summary>
        /// <param name="calificacion">Datos de la calificación a crear.</param>
        /// <returns>La calificación creada con su ID asignado.</returns>
        /// <response code="200">Retorna la calificación creada exitosamente.</response>
        /// <response code="400">Si los datos de la calificación son inválidos.</response>
        /// <response code="500">Error interno del servidor.</response>
        [HttpPost]
        [ProducesResponseType(typeof(Calificacion), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Crear([FromBody] Calificacion calificacion)
        {
            try
            {
                _logger.LogInformation("Creando nueva calificación");
                var rs = await _calificacionRepository.Add(calificacion);
                return Ok(rs);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear calificación");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
