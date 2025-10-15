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
    public class ServicioRepository : IServicioRepository
    {
        private readonly IDbConnection _db;
        public ServicioRepository(IDbConnection db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));

        }

        public async Task<Servicio> Add(Servicio servicio)
        {
            try
            {
               servicio.id = await _db.InsertAsync(servicio);
                return servicio;

            }
            catch (Exception)
            {
                throw;

            }
        }
        
    }
}
