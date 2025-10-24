using Dapper;
using JokeanAPI1Models;
using JokeanAPI1Repository.Interfaces;
using JokeanAPI1Repository.ModelsVM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JokeanAPI1Repository.Implements
{
    public class PagoQueries : IPagoQueries
    {
        private readonly IDbConnection _db;
        public PagoQueries(IDbConnection db)
        {

            _db = db ?? throw new ArgumentNullException(nameof(db));

        }

        public async Task<IEnumerable<Pago>> GetAll()
        {
            try
            {
                string sql = "SELECT * FROM Pago;";
                var rs = await _db.QueryAsync<Pago>(sql);
                return rs;
            }
            catch (Exception) { throw; }
        }

        public async Task<IEnumerable<PagoVM>> byVM(int id)
        {
            try
            {
                string sql = "select * from Pago p INNER JOIN metodopago m ON p.metodopago = p.Id";
                var rs = await _db.QueryAsync<PagoVM, MetodoPago, PagoVM>(sql, (pago, MetodoPago) =>
                {
                    pago.metodopago = MetodoPago;
                    return pago;
                }, new { Id = id }, splitOn: "id");


                return rs;
            }
            catch
            {
                throw;
            }
        }
    }
}