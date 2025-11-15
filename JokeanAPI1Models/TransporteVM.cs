using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JokeanAPI1Models
{
    public class TransporteVM
    {
        // Transporte
        public int TransporteId { get; set; }
        public string? Placa { get; set; }
        public string? Marca { get; set; }
        public string? Modelo { get; set; }
        public int Capacidad { get; set; }

        // TipoTransporte
        public string? TipoNombre { get; set; }
        public string? TipoDescripcion { get; set; }
    }
}