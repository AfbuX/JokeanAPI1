using Dapper;
using JokeanAPI1Models;
using JokeanAPI1Repository.Interfaces;
using System.Data;

namespace JokeanAPI1Repository.Implements
{
    public class UsuarioQueries : IUsuarioQueries
    {
        private readonly IDbConnection _db;
        public UsuarioQueries(IDbConnection db) {
        
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public async Task<IEnumerable<Usuario>> GetAll()
        {
            try
            {
                string sql = "SELECT * FROM Usuario";
                var rs = await _db.QueryAsync<Usuario>(sql);
                return rs;

            }
            catch (Exception) {
                throw;
            }
        }
        public async Task Delete(int id)
        {
            try
            {
                string sql = $"DELETE FROM Usuario WHERE id = {id};";
                await _db.ExecuteAsync(sql);

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
