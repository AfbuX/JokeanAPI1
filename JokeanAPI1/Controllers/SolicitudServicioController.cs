using JokeanAPI1Models;
using JokeanAPI1Repository.Implements;
using JokeanAPI1Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JokeanAPI1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitudServicioController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly ISolicitudServicioQueries _solicitudServicioQueries;
        private readonly ISolicitudServicioRepository _solicitudServicioRepository;

        public SolicitudServicioController(ILogger logger, ISolicitudServicioQueries solicitudServicioQueries, ISolicitudServicioRepository solicitudServicioRepository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _solicitudServicioQueries = solicitudServicioQueries ?? throw new ArgumentNullException(nameof(solicitudServicioQueries));
            _solicitudServicioRepository = solicitudServicioRepository ?? throw new ArgumentNullException(nameof(solicitudServicioRepository));
        }

        [HttpGet]
        public async Task<IActionResult> listarSolicitudes()
        {
            try
            {
                _logger.LogInformation("consultando solicitudes de servicio");
                var rs = await _solicitudServicioQueries.GetAll();
                return Ok(rs);
            }
            catch (Exception ex) {
                _logger.LogError(ex, "algo salio mal");
                return StatusCode(StatusCodes.Status500InternalServerError);

            }
        }
        [HttpPost]
        public async Task<IActionResult> CrearSolicitud(SolicitudServicio solicitudServicio)
        {
            try
            {
                _logger.LogInformation("creando solicitud");
                var rs = await _solicitudServicioRepository.Add(solicitudServicio);
                return Ok(rs);
            }
            catch (Exception ex) {
                _logger.LogError(ex, "algo salio mal");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        }
    }
    

