using Dapper;
using JokeanAPI1Models;
using JokeanAPI1Repository.Interfaces;
using System.Data;

namespace JokeanAPI1Repository.Implements
{
    public class ServicioQueries : IServicioQueries
    {
        private readonly IDbConnection _db;

        public ServicioQueries(IDbConnection db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public async Task<IEnumerable<Servicio>> GetAll()
        {
            try
            {
                const string sql = "SELECT * FROM Servicio";
                return await _db.QueryAsync<Servicio>(sql);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Servicio?> Get(int id)
        {
            try
            {
                const string sql = "SELECT * FROM Servicio WHERE id = @Id";
                return await _db.QueryFirstOrDefaultAsync<Servicio>(sql, new { Id = id });
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                const string sql = "DELETE FROM Servicio WHERE id = @Id";
                await _db.ExecuteAsync(sql, new { Id = id });
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
