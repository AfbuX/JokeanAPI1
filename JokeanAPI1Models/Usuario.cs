using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JokeanAPI1Models
{
    [Table("dbo.Usuario")]
    public class Usuario
    {

        [Key]
        public int id { get; set; }
        public string  nombre { get; set; } = string.Empty;
        public string documento { get; set; } = string.Empty;
        public string telefono { get; set; } = string.Empty;
        public string? correo { get; set; }
        public string direccion { get; set; } = string.Empty;
        public Rol rol {  get; set; }
    }

    
}
