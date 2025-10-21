using Dapper.Contrib.Extensions;
using JokeanAPI1Models;
using JokeanAPI1Repository.Interfaces;
using System.Data;

namespace JokeanAPI1Repository.Implements
{
    public class UbicacionActualRepository : IUbicacionActualRepository
    {
        private readonly IDbConnection _db;

        public UbicacionActualRepository(IDbConnection db)
        {
            _db = db ?? throw new ArgumentException(nameof(db));
        }

        public async Task<UbicacionActual> Add(UbicacionActual ubicacionActual)
        {
            try
            {
                ubicacionActual.id = await _db.InsertAsync(ubicacionActual);
                return ubicacionActual;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Update(UbicacionActual ubicacionActual)
        {
            try
            {
                return await _db.UpdateAsync(ubicacionActual);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
