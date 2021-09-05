using ApiPackExpress.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPackExpress.Models
{
    public class PasswordLog
    {
        public PasswordLog()
        {
            this.Password = HelpersFunctions.generatePw();
            this.DateCreated = DateTime.Now;
            this.ExpirationDate = DateTime.Now.AddMonths(1);
            this.Ip = "localhost";
            this.Status = 1;
        }
        public int IdPasswordLog { get; set; }
        public string Password { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime ExpirationDate{ get; set; }
        public string Ip { get; set; }
        public int Status { get; set; }
        public int IdEmployee { get; set; }
    }
}
