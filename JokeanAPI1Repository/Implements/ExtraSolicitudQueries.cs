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
    public class ExtraSolicitudQueries : IExtraSolicitudQueries
    {
        private readonly IDbConnection _db;
        public ExtraSolicitudQueries(IDbConnection db) { 
        
        _db = db ?? throw new ArgumentNullException(nameof(db));
        
        }

        public async Task<IEnumerable<ExtraSolicitud>> GetAll()
        {
            try
            {
                string sql = "SELECT * FROM ExtraSolicitud;";
                var rs = await _db.QueryAsync<ExtraSolicitud>(sql);
                return rs;
            }
            catch (Exception) { throw; }
        }
    }
}
