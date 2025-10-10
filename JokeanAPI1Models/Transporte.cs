using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JokeanAPI1Models
{
    [Table("dbo.Transporte")]

    public class Transporte
    {
        [Key]
        public int id {  get; set; }
        public int transpoprteit { get; set; }
        public int usuarioid { get; set; }
        public string matricula { get; set; } = string.Empty;
        public int capacidad { get; set; }
        public string tipomotor { get; set; } = string.Empty;
        public string? cilindraje { get; set; }
        public string? placa { get; set; }
        public string? marca { get; set; }
        public string? modelo { get; set; }

    }
}
