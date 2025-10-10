using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JokeanAPI1Models
{
    [Table("dbo.ExtraSolicitud")]
    public class ExtraSolicitud
    {
        [Key]
        public int id { get; set; }
        public string descripcion   { get; set; } = string.Empty;
        public int solicitudservicioid { get; set; }

    }
}
