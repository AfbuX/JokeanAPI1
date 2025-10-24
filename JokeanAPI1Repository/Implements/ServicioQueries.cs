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
                string sql = "SELECT * FROM Servicio";
                var rs = await _db.QueryAsync<Servicio>(sql);
                return rs;
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

        public async Task<bool> Update(Servicio servicio)
        {
            try
            {
                const string sql = @"UPDATE Servicio SET 
                                    transportistaid = @transportistaid, 
                                    solicitudservicioid = @solicitudservicioid, 
                                    fechaServicio = @fechaServicio, 
                                    estado = @estado, 
                                    valor = @valor 
                                    WHERE id = @id";
                var parameters = new
                {
                    servicio.id,
                    servicio.transportistaid,
                    servicio.solicitudservicioid,
                    servicio.fechaServicio,
                    servicio.estado,
                    servicio.valor
                };
                var result = await _db.ExecuteAsync(sql, parameters);
                return result > 0;

            }
            catch (Exception)
            {

                throw;
            }
            throw new NotImplementedException();
        }
    }
}
