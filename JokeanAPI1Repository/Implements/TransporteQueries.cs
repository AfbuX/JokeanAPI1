using JokeanAPI1Models;
using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using JokeanAPI1Repository.Interfaces;

namespace JokeanAPI1Repository.Implements
{
    public class TransporteQueries : ITransporteQueries
    {
        private readonly IDbConnection _db;

        public TransporteQueries(IDbConnection db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public Task<IEnumerable<Transporte>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<SumaryVM>> TestVM()
        {
            try
            {
                string sql = "select * from TipoTransporte INNER JOIN Transporte ON T.tipotransporteid = tt.Id";
                var rs = await _db.QueryAsync<TransporteVm, Transporte, TransporteVm>(Transporte, TipoTransporte) =>
                (
                 reTipoTransporte.Transporte = Transporte;
                return TipoTransporte;
            }, splitOn: "Id");
                
            return rs;
            }
            catch
            {
                throw;
            }
        }

    }

        
        
