using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Rest_Cine.Models
{
    public class LogingLog
    {
        public int LoginLogId { get; set; }
        public DateTime DateLoging { get; set; }
        public int EmployeeId { get; set; }
        public string Token { get; set; }
    }
}
