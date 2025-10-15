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
    public class SolicitudServicioRepository : ISolicitudServicioRepository
    {
        private readonly IDbConnection _db;
        public SolicitudServicioRepository(IDbConnection db) { 
        _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public async Task<SolicitudServicio> Add(SolicitudServicio solicitudServicio)
        {
            try
            {
                solicitudServicio.id = await _db.InsertAsync(solicitudServicio);
                return solicitudServicio;
            }
            catch (Exception) {
            
                throw;
            }
        }

    }
}
