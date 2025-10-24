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
    public class MetododePagoRepository : IMetododePagoRepository
    {
        private readonly IDbConnection _db;

        public MetododePagoRepository(IDbConnection db)
        {

            _db = db ?? throw new ArgumentNullException(nameof(db));

        }

        public async Task<MetodoPago> Add(MetodoPago metodoPago)
        {
            try
            {
                metodoPago.id = await _db.InsertAsync(metodoPago);
                return metodoPago;
            }
            catch (Exception)
            {

                throw;

            }
        }
    }
}

