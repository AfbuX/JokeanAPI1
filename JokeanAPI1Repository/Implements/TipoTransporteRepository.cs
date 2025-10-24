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
    public class TipoTransporteRepository : ITipoTransporteRepository
    {
        private readonly IDbConnection _db;
        public TipoTransporteRepository(IDbConnection db)
        {

            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public async Task<TipoTransporte> Add(TipoTransporte tipotransporte)
        {
            try
            {
                tipotransporte.id = await _db.InsertAsync(tipotransporte);
                return tipotransporte;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
