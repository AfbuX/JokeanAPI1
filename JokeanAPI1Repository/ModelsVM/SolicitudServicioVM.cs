using JokeanAPI1Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JokeanAPI1Repository.ModelsVM
{
    public class SolicitudServicioVM : SolicitudServicio
    {
        public Usuario usuario { get; set; }

        public Transporte transporte { get; set; }

        public MetodoPago metodoPago { get; set; }
    }
}
