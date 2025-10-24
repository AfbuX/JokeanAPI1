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
    public class ServicioController : ControllerBase
    {
        private readonly IServicioRepository _servicioRepository;
        private readonly IServicioQueries _servicioQueries;
        private readonly ILogger<ServicioController> _logger;
        public ServicioController(ILogger<ServicioController> logger, IServicioQueries servicioQueries, IServicioRepository servicioRepository)
        {

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
        /// Lista todos los servicios que existen en base de datos.
        /// </summary>
        /// <returns>Retorna una lista de servicios</returns>
        /// <response code="200">la lista se pudo enviar de forma correcta.</response>
        /// <response code="500">la lista tuvo un problema en obtenerse</response>
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
                _logger.LogError(ex, "algo salo mal en la consulta");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        /// <summary>
        /// Crea un nuevo servicio en base de datos
        /// </summary>
        /// <param name="CrearServicio"></param>
        /// <returns>Retorna un codigo de estado que indica si el servicio fue creado</returns>
        /// <response code = "200">se creo de forma correcta</response>
        /// <response code = "500">no se pudo crear el servicio</response>
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
            catch (Exception ex) {

                _logger.LogError(ex, "error al crear un nuevo servicio");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        /// <summary>
        /// Elimina un nuevo servicio en base de datos
        /// </summary>
        /// <param name="DeleteServicio"></param>
        /// <returns>Retorna un codigo de estado que indica si el servicio fue creado</returns>
        /// <response code = "200">se elimino de forma correcta</response>
        /// <response code = "500">no se pudo eliminar el servicio</response>
        [HttpDelete("{id}")]
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
