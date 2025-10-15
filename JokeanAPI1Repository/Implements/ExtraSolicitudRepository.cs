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
    public class ExtraSolicitudRepository : IExtraSolicitudRepository
    {
        private readonly IDbConnection _db;

        public ExtraSolicitudRepository(IDbConnection db) { 
        
        _db = db ?? throw new ArgumentNullException(nameof(db));
        
        }

        public async Task<ExtraSolicitud> Add(ExtraSolicitud extraSolicitud)
        {
            try
            {
                extraSolicitud.id = await _db.InsertAsync(extraSolicitud);
                return extraSolicitud;
            }
            catch (Exception ) { 
            
            throw;
            
            }
    }
}
