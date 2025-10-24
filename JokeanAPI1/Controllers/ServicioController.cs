using JokeanAPI1Models;
using JokeanAPI1Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JokeanAPI1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicioController : ControllerBase
    {

        private readonly IServicioRepository _servicioRepository;
        private readonly IServicioQueries _servicioQueries;
        private readonly ILogger<ServicioController> _logger;
        public ServicioController(ILogger<ServicioController> logger, IServicioQueries servicioQueries, IServicioRepository servicioRepository)
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
        public async Task<IActionResult> ListarServicio()
        {
            try
            {
                _logger.LogInformation("Realizando consulta de Servicios");
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
        public async Task<IActionResult> CrearSercvicio(Servicio servicio)
        {
            try
            {
                _logger.LogInformation("Creando Servicio");
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
                _logger.LogInformation("Borrando Servicio");
                await _servicioQueries.Delete(id);
                return Ok("sevicio elimando");
            }
            catch(Exception ex) 
            {
                _logger.LogError($"no se pudo eliminar {id}");
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
