using Dapper;
using JokeanAPI1Models;
using JokeanAPI1Repository.Interfaces;
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
    }
}