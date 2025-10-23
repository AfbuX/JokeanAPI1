using JokeanAPI1Models;
using JokeanAPI1Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JokeanAPI1.Controllers
{
    /// <summary>
    /// Controlador para la gestión de servicios de transporte.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ServicioController : ControllerBase // Cambiado de Controller a ControllerBase
    {
        private readonly IServicioRepository _servicioRepository;
        private readonly IServicioQueries _servicioQueries;
        private readonly ILogger<ServicioController> _logger; // Tipado el logger

        /// <summary>
        /// Constructor del controlador de servicios.
        /// </summary>
        public ServicioController(
            ILogger<ServicioController> logger,
            IServicioQueries servicioQueries,
            IServicioRepository servicioRepository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _servicioQueries = servicioQueries ?? throw new ArgumentNullException(nameof(servicioQueries));
            _servicioRepository = servicioRepository ?? throw new ArgumentNullException(nameof(servicioRepository));
        }

        /// <summary>
        /// Obtiene todos los servicios registrados en el sistema.
        /// </summary>
        /// <returns>Lista de servicios.</returns>
        /// <response code="200">Retorna la lista de servicios.</response>
        /// <response code="500">Error interno del servidor.</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Servicio>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ListarServicio()
        {
            try
            {
                _logger.LogInformation("Consultando todos los servicios");
                var rs = await _servicioQueries.GetAll();
                return Ok(rs);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al consultar servicios");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Crea un nuevo servicio en el sistema.
        /// </summary>
        /// <param name="servicio">Datos del servicio a crear.</param>
        /// <returns>Servicio creado con su ID asignado.</returns>
        /// <response code="200">Servicio creado exitosamente.</response>
        /// <response code="400">Datos del servicio inválidos.</response>
        /// <response code="500">Error interno del servidor.</response>
        [HttpPost]
        [ProducesResponseType(typeof(Servicio), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CrearServicio([FromBody] Servicio servicio)
        {
            try
            {
                _logger.LogInformation("Creando nuevo servicio");
                var rs = await _servicioRepository.Add(servicio);
                return Ok(rs);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear servicio");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Elimina un servicio del sistema.
        /// </summary>
        /// <param name="id">ID del servicio a eliminar.</param>
        /// <returns>Confirmación de la eliminación.</returns>
        /// <response code="200">Servicio eliminado exitosamente.</response>
        /// <response code="404">Servicio no encontrado.</response>
        /// <response code="500">Error interno del servidor.</response>
        [HttpDelete("{id}")] // Corregido para usar parámetro de ruta en lugar de body
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> BorrarServicio(int id)
        {
            try
            {
                _logger.LogInformation($"Eliminando servicio con ID: {id}");
                await _servicioQueries.Delete(id);
                return Ok("Servicio eliminado exitosamente");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al eliminar servicio con ID: {id}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Obtiene un servicio por su ID.
        /// </summary>
        /// <param name="id">ID del servicio a buscar.</param>
        /// <returns>Datos del servicio.</returns>
        /// <response code="200">Retorna el servicio solicitado.</response>
        /// <response code="404">Servicio no encontrado.</response>
        /// <response code="500">Error interno del servidor.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Servicio), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObtenerServicio(int id)
        {
            try
            {
                _logger.LogInformation($"Buscando servicio con ID: {id}");
                var servicio = await _servicioQueries.Get(id);
                if (servicio == null)
                {
                    return NotFound($"Servicio con ID {id} no encontrado");
                }
                return Ok(servicio);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al buscar servicio con ID: {id}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Actualiza un servicio existente.
        /// </summary>
        /// <param name="servicio">Datos actualizados del servicio.</param>
        /// <returns>Servicio actualizado.</returns>
        /// <response code="200">Servicio actualizado exitosamente.</response>
        /// <response code="400">Datos del servicio inválidos.</response>
        /// <response code="404">Servicio no encontrado.</response>
        /// <response code="500">Error interno del servidor.</response>
        [HttpPut]
        [ProducesResponseType(typeof(Servicio), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ActualizarServicio([FromBody] Servicio servicio)
        {
            try
            {
                _logger.LogInformation($"Actualizando servicio ID: {servicio.id}");
                var actualizado = await _servicioRepository.Update(servicio);
                if (!actualizado)
                {
                    return NotFound($"Servicio con ID {servicio.id} no encontrado");
                }
                return Ok(servicio);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al actualizar servicio ID: {servicio.id}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
