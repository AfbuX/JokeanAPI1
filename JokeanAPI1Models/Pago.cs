using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JokeanAPI1Models
{
    [Table("dbo.Pago")]
    public class Pago
    {
        [Key]   
        public int id { get; set; }
        public decimal valor { get; set; }
        public int metodopagoid { get; set; }
        public string? descripcion {  get; set; }
        public int servicioid { get; set; }

    }
}
