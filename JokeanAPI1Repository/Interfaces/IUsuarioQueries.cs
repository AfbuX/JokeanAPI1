using JokeanAPI1Models;

namespace JokeanAPI1Repository.Interfaces
{
    public interface IUsuarioQueries
    {
        Task<IEnumerable<Usuario>> GetAll();
        Task Delete(int id);

        Task<IEnumerable<Usuario>> Get(int id);
    }
}
