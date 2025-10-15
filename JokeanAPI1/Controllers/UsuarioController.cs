using JokeanAPI1Models;
using JokeanAPI1Repository.Implements;
using JokeanAPI1Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JokeanAPI1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioQueries _usuarioQueries;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ILogger<UsuarioController> _logger;

        public UsuarioController(IUsuarioQueries usuarioQueries, ILogger<UsuarioController> logger, IUsuarioRepository usuarioRepository)
        {
            _usuarioQueries = usuarioQueries ?? throw new ArgumentNullException(nameof(usuarioQueries));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _usuarioRepository = usuarioRepository ?? throw new ArgumentNullException(nameof(usuarioRepository));

        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            try
            {
                _logger.LogInformation("Consultado todos los usuarios");
                var rs = await _usuarioQueries.GetAll();
                _logger.LogTrace(rs.ToString());
                return Ok(rs);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Algo salio mal");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPost]
        public async Task<ActionResult> Crear([FromBody]Usuario us)
        {
            try
            {
                _logger.LogInformation("Creando Usuario nuevo");
                var rs = await _usuarioRepository.Add(us);
                return Ok(rs);

            }
            catch (Exception ex) {
                _logger.LogError(ex,"usuario no se pudo crear correctamente");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }
        [HttpDelete]
        public async Task<IActionResult> BorrarServicio([FromBody] int id)
        {
            try
            {
                _logger.LogInformation("Borrando Usuario");
                await _usuarioQueries.Delete(id);
                return Ok("Usuario elimando");
            }
            catch (Exception ex)
            {
                _logger.LogError($"no se pudo eliminar {id}");
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }

    }

