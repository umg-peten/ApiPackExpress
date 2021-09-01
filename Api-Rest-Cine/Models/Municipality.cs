using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPackExpress.Models
{
    public class Municipality
    {
        public int MunicipalityId { get; set; }
        public string Town { get; set; }
        public string ZipCode { get; set; }
        public State state { get; set; }
    }
}
