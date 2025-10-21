using Dapper;
using JokeanAPI1Models;
using JokeanAPI1Repository.Interfaces;
using System.Data;

namespace JokeanAPI1Repository.Implements
{
    public class UbicacionActualQueries : IUbicacionActualQueries
    {
        private readonly IDbConnection _db;

        public UbicacionActualQueries(IDbConnection db)
        {
            _db = db ?? throw new ArgumentException(nameof(db));
        }

        public async Task<IEnumerable<UbicacionActual>> GetAll()    
        {
            try
            {
                const string sql = "SELECT * FROM UbicacionActual";
                return await _db.QueryAsync<UbicacionActual>(sql);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<UbicacionActual?> Get(int id)
        {
            try
            {
                const string sql = "SELECT * FROM UbicacionActual WHERE id = @Id";
                return await _db.QueryFirstOrDefaultAsync<UbicacionActual>(sql, new { Id = id });
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Update(UbicacionActual ubicacion)
        {
            try
            {
                const string sql = @"
                    UPDATE UbicacionActual 
                    SET latitud = @Latitud, 
                        longitud = @Longitud,
                        usuarioid = @UsuarioId,
                        fecha = @Fecha
                    WHERE id = @Id";

                var parameters = new
                {
                    ubicacion.id,
                    ubicacion.latitud,
                    ubicacion.longitud,
                    ubicacion.usuarioId,
                    ubicacion.fecha
                };

                var affectedRows = await _db.ExecuteAsync(sql, parameters);
                return affectedRows > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
