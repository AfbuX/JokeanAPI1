using JokeanAPI1Models;
using JokeanAPI1Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JokeanAPI1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitudServicioController : ControllerBase
    {
        
        private readonly ISolicitudServicioQueries _solicitudServicioQueries;
        private readonly ISolicitudServicioRepository _solicitudServicioRepository;
        private readonly ILogger<SolicitudServicioController> _logger;

        public SolicitudServicioController(ILogger<SolicitudServicioController> logger, ISolicitudServicioQueries solicitudServicioQueries, ISolicitudServicioRepository solicitudServicioRepository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _solicitudServicioQueries = solicitudServicioQueries ?? throw new ArgumentNullException(nameof(solicitudServicioQueries));
            _solicitudServicioRepository = solicitudServicioRepository ?? throw new ArgumentNullException(nameof(solicitudServicioRepository));
        }
        /// <summary>
        /// lista todas las solicitudes de servicio en base de datos
        /// </summary>
        /// <returns>Retorna una lista con las solicitudes</returns>
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
        /// <summary>
        /// Crea una nueva solicitud de servicio
        /// </summary>
        /// <param name="solicitudServicio">Solicitud quu se quiere crear en base de datos</param>
        /// <returns>Retorna un codigo de estado que indica si el resultado fue exitoso o fallo</returns>
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
        /// <summary>
        /// Elimina una solicitud de servicio
        /// </summary>
        /// <param name="id">id de la solicitud que quiero eliminar</param>
        /// <returns>Retorna un codigo de estado que indica si el resultado fue exitoso o fallo</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> BorrarSolicitud(int id)
        {
            try
            {
                _logger.LogInformation($"borando solicitud con identificador: {id}");
                await _solicitudServicioQueries.DeleteById(id);
                return Ok();
            }
            catch (Exception ex) {

                _logger.LogInformation(ex, "algo salio mal");
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            
            }
        }
        /// <summary>
        /// lista una sola solicitud con campos completos de usuario y transporte.
        /// </summary>
        /// <param name="id">id de la solicitud que quieres listar</param>
        /// <returns>Retorna un codigo de estado que indica si el resultado fue exitoso o fallo</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> ListarSolicitudById(int id)
        {
            try
            {
                _logger.LogInformation($"Buscando solicitud con id: {id}");
                var rs = await _solicitudServicioQueries.GetCompleteById(id);
                return Ok(rs);

            }
            catch (Exception ex) {
                _logger.LogError(ex, "ups! error al traer la solicitud");
                return StatusCode(StatusCodes.Status500InternalServerError);
            
            
            }
        }
        }
    }
    

