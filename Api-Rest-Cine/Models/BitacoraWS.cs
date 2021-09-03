using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPackExpress.Models
{
    public class BitacoraWS
    {
        public BitacoraWS(string messageError, string section, string username)
        {
            this.DateBegin = DateTime.Now;
            this.Pc = Environment.MachineName;
            this.Ip = "localhost";
            this.MessageError = messageError;
            this.Section = section;
            this.Username = username;

        }
        public int IdDetalle { get; set; }
        public string MessageError  { get; set; }
        public string Section { get; set; }
        public DateTime  DateBegin { get; set; }
        public DateTime DateEnd{ get; set; }
        public string Username { get; set; }
        public string  Pc { get; set; }
        public string Ip { get; set; }

    }
}
