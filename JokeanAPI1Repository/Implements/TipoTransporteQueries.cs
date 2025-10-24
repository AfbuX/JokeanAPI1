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
    public class TipoTransporteQueries : ITipoTransporteQueries
    {

        private readonly IDbConnection _db;
        public TipoTransporteQueries(IDbConnection db)
        {

            _db = db ?? throw new ArgumentException(nameof(db));

        }
        public async Task<IEnumerable<TipoTransporte>> GetAll()
        {
            try
            {
                string sql = "SELECT * FROM TipoTransporte";
                var rs = await _db.QueryAsync<TipoTransporte>(sql);
                return rs;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
