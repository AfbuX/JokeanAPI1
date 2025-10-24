using JokeanAPI1Models;
using JokeanAPI1Repository.ModelsVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JokeanAPI1Repository.Interfaces
{
    public interface ISolicitudServicioQueries
    {
        Task<IEnumerable<SolicitudServicio>> GetAll();

        Task<IEnumerable<SolicitudServicioVM>> GetCompleteById(int id);

        Task DeleteById(int id);
    }
}
