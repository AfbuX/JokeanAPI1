using JokeanAPI1Models;
using JokeanAPI1Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JokeanAPI1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    ///             


    public class TransporteController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly ITransporteQueries _transporteQueries;
        private readonly ITransporteRepository _transporteRepository;


        public TransporteController(ILogger logger, ITransporteRepository transporteRepository, ITransporteQueries transporteQueries)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _transporteRepository = transporteRepository ?? throw new ArgumentNullException(nameof(transporteRepository));
            _transporteQueries = transporteQueries ?? throw new ArgumentNullException(nameof(transporteQueries));
        }

        [HttpGet("vm")]

    
        public async Task<IActionResult> listar()
        {
            try
            {
                _logger.LogInformation("En consulta de Transporte . . .");
                var rs = await _transporteQueries.GetAll();
                return Ok(rs);

            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "Algo salio mal...");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]

        public async Task<IActionResult> Crear(Transporte transporte)
        {
            try
            {
                _logger.LogInformation("Creando 'Transporte' ");
                var rs = await _transporteRepository.Add(transporte);
                return Ok(rs);

            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "Algo salio mal . . .");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

    }


}