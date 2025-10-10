using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JokeanAPI1Models
{
    [Table("dbo.Calificacion")]
    public class Calificacion
    {
        [Key]
        public int id { get; set; }
        public int servicioid {  get; set; }
        public string calificacion {  get; set; } = string.Empty;
        public string? descripcion { get; set; }
    }
}
