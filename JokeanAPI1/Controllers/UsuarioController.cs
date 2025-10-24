using JokeanAPI1Models;
using JokeanAPI1Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JokeanAPI1.Controllers
{
    /// <summary>
    /// Controlador para la gestión de usuarios en el sistema.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioQueries _usuarioQueries;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ILogger<UsuarioController> _logger;

        /// <summary>
        /// Constructor del controlador de usuarios.
        /// </summary>
        public UsuarioController(
            IUsuarioQueries usuarioQueries, 
            ILogger<UsuarioController> logger, 
            IUsuarioRepository usuarioRepository)
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
        [ProducesResponseType(typeof(IEnumerable<Usuario>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Listar()
        {
            try
            {
                _logger.LogInformation("Consultando todos los usuarios");
                var rs = await _usuarioQueries.GetAll();
                _logger.LogTrace(rs.ToString());
                return Ok(rs);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al consultar usuarios");
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
        [ProducesResponseType(typeof(Usuario), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Crear([FromBody] Usuario usuario)
        {
            try
            {
                _logger.LogInformation("Creando nuevo usuario");
                var rs = await _usuarioRepository.Add(usuario);
                return Ok(rs);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear usuario");
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> BorrarUsuario(int id)
        {
            try
            {
                _logger.LogInformation($"Eliminando usuario con ID: {id}");
                await _usuarioQueries.Delete(id);
                return Ok("Usuario eliminado exitosamente");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al eliminar usuario con ID: {id}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        /// <summary>
        /// Actualiza el Usuario en base de datos
        /// </summary>
        /// <param name=""></param>
        /// <returns>Retorna un codigo de estado que indica si el resultado fue exitoso o fallo</returns>
        [HttpPut]
        [ProducesResponseType(typeof(Usuario), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ActualizarUsuario([FromBody] Usuario usuario)
        {
            try
            {
                _logger.LogInformation($"Actualizando usuario ID: {usuario.id}");
                var rs = await _usuarioRepository.Update(usuario);
                return Ok(rs);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al actualizar usuario ID: {usuario.id}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        /// <summary>
        /// Lista un usuario segun su id.
        /// </summary>
        /// <param name="id">id del usuario que se quiere listar</param>
        /// <returns>Retorna un codigo de estado que indica si el resultado fue exitoso o fallo</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Usuario), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                _logger.LogInformation($"Buscando usuario con ID: {id}");
                var rs = await _usuarioQueries.Get(id);
                if (rs == null)
                {
                    return NotFound($"Usuario con ID {id} no encontrado");
                }
                return Ok(rs);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al buscar usuario con ID: {id}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}

