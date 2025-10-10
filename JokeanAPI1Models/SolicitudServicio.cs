using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JokeanAPI1Models
{
    [Table("dbo.SolicitudServicio")]
    public class SolicitudServicio
    {
        [Key]
        public int id { get; set; }
        public decimal latitudOrigen {  get; set; }
        public decimal longitudOrigen { get; set; }
        public decimal latitudDestino { get; set; }
        public decimal longitudDestino { get;set; }
        public int tipotransporteid { get; set; }
        public int usuarioid { get; set; }
        public int metodopagoid { get; set; }
        public DateTime fechaSolicitud { get; set; }
    }
}
