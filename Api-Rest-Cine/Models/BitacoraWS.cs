using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPackExpress.Models
{
    public class BitacoraWS
    {
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
