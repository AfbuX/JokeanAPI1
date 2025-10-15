using Dapper;
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
    public class ServicioQueries : IServicioQueries
    {
        private readonly IDbConnection _db;

        public ServicioQueries(IDbConnection db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));

        }

        public async Task<IEnumerable<Servicio>> GetAll()
        {
            try
            {
                string sql = "SELECT * FROM Servico";
                var rs = await _db.QueryAsync<Servicio>(sql);
                return rs;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task Delete(int id)
        {
            try
            {
                string sql = "DELETE FROM Servicio WHERE id = @Id;";
                await _db.ExecuteAsync(sql,new { Id = id});
              
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
