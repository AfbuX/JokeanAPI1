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
    public class MetododePagoQueries : IMetododePagoQueries
    {
        private readonly IDbConnection _db;
        public MetododePagoQueries(IDbConnection db)
        {

            _db = db ?? throw new ArgumentNullException(nameof(db));

        }

        public async Task<IEnumerable<MetodoPago>> GetAll()
        {
            try
            {
                string sql = "SELECT * FROM MetodoPago;";
                var rs = await _db.QueryAsync<MetodoPago>(sql);
                return rs;
            }
            catch (Exception) { throw; }
        }
    }
}
