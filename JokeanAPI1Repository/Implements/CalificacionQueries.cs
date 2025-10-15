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
    public class CalificacionQueries : ICalificacionQueries
    {
        private readonly IDbConnection _db;
        public CalificacionQueries(IDbConnection db) { 
        
        _db = db ?? throw new ArgumentException(nameof(db));
        
        }
        public async Task<IEnumerable<Calificacion>> GetAll()
        {
            try
            {
                string sql = "SELECT * FROM Calificacion";
                var rs = await _db.QueryAsync<Calificacion>(sql);
                return rs;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
