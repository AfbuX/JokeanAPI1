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
using JokeanAPI1Repository.ModelsVM;

namespace JokeanAPI1Repository.Implements
{
    public class TransporteQueries : ITransporteQueries
    {
        private readonly IDbConnection _db;

        public TransporteQueries(IDbConnection db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public async Task<IEnumerable<Transporte>> GetAll()
        {
            try
            {
                string sql = "SELECT * FROM Transporte";
                var rs = await _db.QueryAsync<Transporte>(sql);
                return rs;
            }
            catch (Exception) { throw; }
        }

        public async Task<IEnumerable<TransporteVM>> byVM(int id)
        {
            try
            {
                string sql = "select * from TipoTransporte tt INNER JOIN Transporte ON T.tipotransporteid = tt.Id INNER JOIN Usuario ON tt.usuarioid";
                var rs = await _db.QueryAsync<TransporteVM, Usuario, Transporte, TransporteVM>(sql, (tipotransporte, Usuario, Transporte) =>
                {
                    tipotransporte.usuario = Usuario;
                    tipotransporte.transporte = Transporte;
                    return tipotransporte;
                }, new { Id = id }, splitOn: "id,id");


                return rs;
            }
            catch
            {
                throw;
            }
        }

    }

}        


