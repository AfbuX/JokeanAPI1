using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JokeanAPI1Models
{
    [Table("dbo.UbicacionActual")]
    public class UbicacionActual
    {
        [Key]
        public int id { get; set; }
        public int uduarioid { get; set; } 
        public decimal latitud {  get; set; }
        public decimal longitud { get; set; }

    }
}
