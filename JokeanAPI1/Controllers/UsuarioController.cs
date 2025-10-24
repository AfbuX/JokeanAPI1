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
        /// <summary>
        /// Lista todos usuarios en base de datos.
        /// </summary>
        /// <returns>Me retorna una lista de Usuarios.</returns>}
        /// <response code = "200">La peticion fue exitosa</response>
        /// <response code = "500">La peticion fallo</response>
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
        /// <summary>
        /// Crea un Usuario nuevo en base de datos.
        /// </summary>
        /// <param name="CrearUsuario"></param>
        /// <returns>Retorna un codigo de estado que indica si el resultado fue exitoso o fallo</returns>
        /// <response code = "200">Se creo de forma correcta</response>
        [HttpPost]
        public async Task<ActionResult> Crear([FromBody] Usuario us)
        {
            try
            {
                _logger.LogInformation("Creando Usuario nuevo");
                var rs = await _usuarioRepository.Add(us);
                return Ok(rs);

            }
            catch (Exception ex) {
                _logger.LogError(ex, "usuario no se pudo crear correctamente");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }
        /// <summary>
        /// Elimina un usuario en base de datos
        /// </summary>
        /// <param name=""></param>
        /// <returns>Retorna un codigo de estado que indica si el resultado fue exitoso o fallo</returns>
        /// <response code = "200"> El usuario se elimino con exito</response>
        /// <response code = "500">El usuario no se pudo iliminar</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> BorrarServicio(int id)
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
        /// <summary>
        /// Actualiza el Usuario en base de datos
        /// </summary>
        /// <param name=""></param>
        /// <returns>Retorna un codigo de estado que indica si el resultado fue exitoso o fallo</returns>
        [HttpPut]
        public async Task<IActionResult> ActualizarUsuario(Usuario usuario)
        {
            try
            {
                _logger.LogInformation("Se esta actualizando el usuario");
                var rs = await _usuarioRepository.Update(usuario);
                return Ok(rs);

            }
            catch(Exception ex)
            {
                _logger.LogError($"no se pudo actualizar el usuario {usuario.nombre}");
                return StatusCode(StatusCodes.Status500InternalServerError, ex);

            }
        }
        /// <summary>
        /// Lista un usuario segun su id.
        /// </summary>
        /// <param name="id">id del usuario que se quiere listar</param>
        /// <returns>Retorna un codigo de estado que indica si el resultado fue exitoso o fallo</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                _logger.LogInformation($"Buscando usuario con id = {id}");
                var rs = await _usuarioQueries.Get(id);
                return Ok(rs);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Algo salio mal por favor intente más tarder");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }

    }

