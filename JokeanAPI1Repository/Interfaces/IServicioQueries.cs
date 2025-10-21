using JokeanAPI1Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JokeanAPI1Repository.Interfaces
{
    public interface IServicioQueries
    {
        Task<IEnumerable<Servicio>> GetAll();
        Task<Servicio?> Get(int id);
        Task<bool> Update(Servicio servicio);
        Task Delete(int id);
    }
}
