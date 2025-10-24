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
    public class PagoRepository : IPagoRepository
    {
        private readonly IDbConnection _db;

        public PagoRepository(IDbConnection db)
        {

            _db = db ?? throw new ArgumentNullException(nameof(db));

        }

        public async Task<Pago> Add(Pago Pago)
        {
            try
            {
                Pago.id = await _db.InsertAsync(Pago);
                return Pago;
            }
            catch (Exception)
            {

                throw;

            }
        }
    }
}
