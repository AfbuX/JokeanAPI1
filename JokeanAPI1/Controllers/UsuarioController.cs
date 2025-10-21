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
        /// Obtiene todos los usuarios registrados en el sistema.
        /// </summary>
        /// <returns>Lista de usuarios.</returns>
        /// <response code="200">Retorna la lista de usuarios.</response>
        /// <response code="500">Error interno del servidor.</response>
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
        /// Crea un nuevo usuario en el sistema.
        /// </summary>
        /// <param name="usuario">Datos del usuario a crear.</param>
        /// <returns>Usuario creado con su ID asignado.</returns>
        /// <response code="200">Usuario creado exitosamente.</response>
        /// <response code="400">Datos del usuario inválidos.</response>
        /// <response code="500">Error interno del servidor.</response>
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
        /// Elimina un usuario del sistema.
        /// </summary>
        /// <param name="id">ID del usuario a eliminar.</param>
        /// <returns>Confirmación de la eliminación.</returns>
        /// <response code="200">Usuario eliminado exitosamente.</response>
        /// <response code="404">Usuario no encontrado.</response>
        /// <response code="500">Error interno del servidor.</response>
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
        /// Actualiza los datos de un usuario existente.
        /// </summary>
        /// <param name="usuario">Datos actualizados del usuario.</param>
        /// <returns>Usuario actualizado.</returns>
        /// <response code="200">Usuario actualizado exitosamente.</response>
        /// <response code="400">Datos del usuario inválidos.</response>
        /// <response code="404">Usuario no encontrado.</response>
        /// <response code="500">Error interno del servidor.</response>
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
        /// Obtiene un usuario por su ID.
        /// </summary>
        /// <param name="id">ID del usuario a buscar.</param>
        /// <returns>Datos del usuario.</returns>
        /// <response code="200">Retorna el usuario solicitado.</response>
        /// <response code="404">Usuario no encontrado.</response>
        /// <response code="500">Error interno del servidor.</response>
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

