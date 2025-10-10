using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JokeanAPI1Models
{
    [Table("dbo.")]
    public class MetodoPago
    {
        [Key]
        public int id { get; set; }
        public string descripcion { get; set; } = string.Empty;
    }
}
