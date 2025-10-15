using JokeanAPI1Models;

namespace JokeanAPI1Repository.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario> Add(Usuario usuario);
    }
}
