using Dapper;
using JokeanAPI1Models;
using JokeanAPI1Repository.Interfaces;
using JokeanAPI1Repository.ModelsVM;
using System.Data;

namespace JokeanAPI1Repository.Implements
{
    public class SolicitudServicioQueries : ISolicitudServicioQueries
    {
        private readonly IDbConnection _db;
        public SolicitudServicioQueries(IDbConnection db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));

        }

        public async Task<IEnumerable<SolicitudServicio>> GetAll()
        {
            try
            {
                string sql = "SELECT * FROM SolicitudServicio";
                var rs = await _db.QueryAsync <SolicitudServicio>(sql);
                return rs;
            }
            catch (Exception) { throw; }

        }

        public async Task DeleteById(int id)
        {
            try
            {
                string sql = "DELETE FROM SolicitudServicio WHERE id = @Id";
                await _db.ExecuteAsync(sql, new { Id = id });

            }
            catch (Exception) { throw; }
        }

        public async Task<IEnumerable<SolicitudServicioVM>> GetCompleteById(int id)
        {
            try
            {
                string sql = "SELECT * FROM SolicitudServicio s INNER JOIN Usuario u ON s.usuarioid = u.id INNER JOIN Transporte t ON s.tipotransporteid = t.id INNER JOIN MetodoPago m ON s.metodopagoid = m.id WHERE s.id = @Id";
                var rs = await _db.QueryAsync<SolicitudServicioVM, Usuario, Transporte, MetodoPago, SolicitudServicioVM>(sql, (solicitud,Usuario, Transporte, MetodoPago) =>
                {
                    solicitud.usuario = Usuario;
                    solicitud.metodoPago = MetodoPago;
                    solicitud.transporte = Transporte;
                    return solicitud;
                },new { Id = id }, splitOn: "id,id,id");
                return rs;

            }catch (Exception) { throw; }
        }
    }
}
