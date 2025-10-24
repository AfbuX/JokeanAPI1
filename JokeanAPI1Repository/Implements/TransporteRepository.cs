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
    public class TransporteRepository : ITransporteRepository
    {
        private readonly IDbConnection _db;
        public TransporteRepository(IDbConnection db)
        {

            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public async Task<Transporte> Add(Transporte transporte)
        {
            try
            {
                transporte.id = await _db.InsertAsync(transporte);
                return transporte;
            }
            catch (Exception) { throw; }
        }

        public Task Add(TipoTransporte tipotransporte)
        {
            throw new NotImplementedException();
        }
    }
}
