using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPackExpress.Models
{
    public class oResponse
    {
        public int status { get; set; }
        public string message { get; set; }
        public Object data { get; set; }
    }
}
