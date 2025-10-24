using JokeanAPI1Models;
using JokeanAPI1Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JokeanAPI1.Controllers
{
    /// <summary>
    /// Controlador para gestionar los pagos de los servicios.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]

    public class PagoController : ControllerBase
    {
        private readonly IPagoQueries _PagoQueries;
        private readonly IPagoRepository _PagoRepository;
        private readonly ILogger<PagoController> _logger;

        /// <summary>
        /// Constructor del controlador de mpagos.
        /// </summary>
        public PagoController(
            ILogger<PagoController> logger,
            IPagoRepository PagoRepository,
            IPagoQueries PagoQueries)
        {
            _PagoQueries = PagoQueries ?? throw new ArgumentNullException(nameof(PagoQueries));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _PagoRepository = PagoRepository ?? throw new ArgumentNullException(nameof(PagoRepository));
        }

        /// <summary>
        /// Obtiene todas los pagos registradss.
        /// </summary>
        /// <returns>Lista de pagos existentes en el sistema.</returns>
        /// <response code="200">Retorna la lista de metodos de pagos.</response>
        /// <response code="500">Error interno del servidor.</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Pago>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Listar()
        {
            try
            {
                _logger.LogInformation("Consultando Metodos de Pago");
                var rs = await _PagoQueries.GetAll();
                _logger.LogTrace(rs.ToString());
                return Ok(rs);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al consultar los Metodos de Pago");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Crea un nuevo metodo de pago en el sistema.
        /// </summary>
        /// <param name="Pago">Datos de los pagos a crear.</param>
        /// <returns>pago creado con su ID asignado.</returns>
        /// <response code="200">Retorna el pago creada exitosamente.</response>
        /// <response code="400">Si los datos del pago son inválidos.</response>
        /// <response code="500">Error interno del servidor.</response>
        [HttpPost]
        [ProducesResponseType(typeof(Pago), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Crear([FromBody] Pago Pago)
        {
            try
            {
                _logger.LogInformation("Creando nueva Metodo de Pago");
                var rs = await _PagoRepository.Add(Pago);
                return Ok(rs);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear el metodo de pago");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
