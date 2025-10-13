using Dapper.Contrib.Extensions;
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
    public class CalificacionRepository : ICalificacionRepository
    {
        private readonly IDbConnection _db;
        public CalificacionRepository(IDbConnection db) {
        
        _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public async Task<Calificacion> Add(Calificacion calificacion)
        {
            try
            {
                calificacion.id= await _db.InsertAsync(calificacion);
                return calificacion;
            }
            catch (Exception) { throw; }
        }
    }
}
