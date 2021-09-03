using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPackExpress.Models
{
    public class LoginLog
    {
        public LoginLog()
        {
            this.DateLogin = DateTime.Now;
            this.Ip = "localhost";
        }
        public int IdLoginLog { get; set; }
        public DateTime DateLogin { get; set; }
        public int IdEmployee { get; set; }
        public string Token { get; set; }
        public string Ip { get; set; }
    }
}
