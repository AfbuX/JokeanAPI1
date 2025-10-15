using JokeanAPI1Models;
using JokeanAPI1Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JokeanAPI1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalificacionController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly ICalificacionRepository _calificacionRepository;
        private readonly ICalificacionQueries _calificacionQueries;

        public CalificacionController(ILogger logger, ICalificacionRepository calificacionRepository, ICalificacionQueries calificacionQueries)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger)) ;
            _calificacionRepository = calificacionRepository ?? throw new ArgumentNullException(nameof(calificacionRepository)) ;
            _calificacionQueries = calificacionQueries ?? throw new ArgumentNullException(nameof(calificacionQueries));
        }

        [HttpGet]
        public async Task<IActionResult> listar()
        {
            try
            {
                _logger.LogInformation("Consultando Calificaciones...");
                var rs = await _calificacionQueries.GetAll();
                return Ok(rs);

            }
            catch (Exception ex) {

                _logger.LogError(ex,"algo salio mal");
                return StatusCode(StatusCodes.Status500InternalServerError);
            
            }
        }
        [HttpPost]
        public async Task<IActionResult> Crear(Calificacion calificacion)
        {
            try
            {
                _logger.LogInformation("creando calificacion");
                var rs = await _calificacionRepository.Add(calificacion);
                return Ok(rs);
            }
            catch (Exception ex) {
                _logger.LogError(ex, "algo salio mal");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
