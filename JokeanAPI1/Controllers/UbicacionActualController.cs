using JokeanAPI1Models;
using JokeanAPI1Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JokeanAPI1.Controllers
{
    /// <summary>
    /// Controlador para gestionar las ubicaciones actuales de los usuarios.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UbicacionActualController : ControllerBase
    {
        private readonly IUbicacionActualQueries _ubicacionActualQueries;
        private readonly IUbicacionActualRepository _ubicacionActualRepository;
        private readonly ILogger<UbicacionActualController> _logger;

        /// <summary>
        /// Constructor del controlador de ubicaciones actuales.
        /// </summary>
        public UbicacionActualController(
            IUbicacionActualQueries ubicacionActualQueries,
            ILogger<UbicacionActualController> logger,
            IUbicacionActualRepository ubicacionActualRepository)
        {
            _ubicacionActualQueries = ubicacionActualQueries ?? throw new ArgumentNullException(nameof(ubicacionActualQueries));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _ubicacionActualRepository = ubicacionActualRepository ?? throw new ArgumentNullException(nameof(ubicacionActualRepository));
        }

        /// <summary>
        /// Obtiene todas las ubicaciones actuales registradas.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UbicacionActual>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Listar()
        {
            try
            {
                _logger.LogInformation("Consultando todas las ubicaciones actuales");
                var rs = await _ubicacionActualQueries.GetAll();
                _logger.LogTrace(rs.ToString());
                return Ok(rs);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al consultar ubicaciones");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Registra una nueva ubicación actual.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(UbicacionActual), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Crear([FromBody] UbicacionActual ubicacion)
        {
            try
            {
                _logger.LogInformation("Registrando nueva ubicación actual");
                var rs = await _ubicacionActualRepository.Add(ubicacion);
                return Ok(rs);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al registrar ubicación actual");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Actualiza una ubicación actual existente.
        /// </summary>
        [HttpPut]
        [ProducesResponseType(typeof(UbicacionActual), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Actualizar(UbicacionActual ubicacion)
        {
            try
            {
                _logger.LogInformation($"Actualizando ubicación actual ID: {ubicacion.id}");
                var rs = await _ubicacionActualRepository.Update(ubicacion);
                return Ok(rs);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al actualizar ubicación actual ID: {ubicacion.id}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Obtiene una ubicación actual por su ID.
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UbicacionActual), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                _logger.LogInformation($"Buscando ubicación actual con ID: {id}");
                var rs = await _ubicacionActualQueries.Get(id);
                if (rs == null)
                {
                    return NotFound($"No se encontró la ubicación con ID: {id}");
                }
                return Ok(rs);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al buscar ubicación actual ID: {id}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
