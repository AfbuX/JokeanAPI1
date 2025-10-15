using JokeanAPI1Models;
using JokeanAPI1Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace JokeanAPI1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicioController : Controller
    {

        private readonly IServicioRepository _servicioRepository;
        private readonly IServicioQueries _servicioQueries;
        private readonly ILogger _logger;
        public ServicioController(ILogger logger, IServicioQueries servicioQueries, IServicioRepository servicioRepository)
        {

            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _servicioQueries = servicioQueries ?? throw new ArgumentNullException(nameof(servicioQueries));
            _servicioRepository = servicioRepository ?? throw new ArgumentNullException(nameof(servicioRepository));
        }
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
                _logger.LogError(ex,"algo salo mal en la consulta");
                return StatusCode(StatusCodes.Status500InternalServerError);


            }

        }
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

                _logger.LogError(ex,"error al crear un nuevo servicio");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> BorrarServicio([FromBody] int id)
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
