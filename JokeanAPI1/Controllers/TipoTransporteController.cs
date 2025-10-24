using JokeanAPI1Models;
using JokeanAPI1Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JokeanAPI1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoTransporteController : ControllerBase
    {

        private readonly ILogger _logger;
        private readonly ITransporteQueries _tipotransporteQueries;
        private readonly ITransporteRepository _tipotransporteRepository;


        public TipoTransporteController(ILogger logger, ITipoTransporteRepository tipotransporteRepository, ITipoTransporteQueries tipotransporteQueries)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _tipotransporteRepository = tipotransporteRepository ?? throw new ArgumentNullException(nameof(_tipotransporteRepository));
            _tipotransporteQueries = tipotransporteQueries ?? throw new ArgumentNullException(nameof(tipotransporteQueries));
        
        }

        [HttpGet("vm")]


        public async Task<IActionResult> listar()
        {
            try
            {
                _logger.LogInformation("En consulta de tipo de Transporte . . .");
                var rs = await _tipotransporteQueries.GetAll();
                return Ok(rs);

            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "Algo salio mal...");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]

        public async Task<IActionResult> Crear(TipoTransporte tipotransporte)
        {
            try
            {
                _logger.LogInformation("Creando un tipo de Transporte . . . ");
                var rs = await _tipotransporteRepository.Add(transporte);
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
