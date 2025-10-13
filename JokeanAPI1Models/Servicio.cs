using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JokeanAPI1Models

{
   
    [Table("dbo.Servicio")]
    public class Servicio
    {
        [Key]   
        public int id { get; set; }
        public int transportistaid { get; set; }
        public int solicitudservicioid { get; set; }
        public  DateTime fechaServicio {  get; set; }
        public EstadoServicio estado { get; set; }
        public int valor {  get; set; }
    }
}
