using JokeanAPI1Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JokeanAPI1Repository.Interfaces
{
    public interface IUbicacionActualQueries
    {
        Task<IEnumerable<UbicacionActual>> GetAll();
        Task<UbicacionActual?> Get(int id);
        Task<bool> Update(UbicacionActual ubicacion);
    }
}
