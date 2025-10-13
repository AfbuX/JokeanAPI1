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
                string sql = "SELECT * FROM SolitudServicio";
                var rs = await _db.QueryAsync <SolicitudServicio>(sql);
                return rs;
            }
            catch (Exception) { throw; }

        }
    }
}
