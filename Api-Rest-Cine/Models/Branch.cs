using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPackExpress.Models
{
    public class Branch
    {
        public int BranchId { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public string Address { get; set; }
        public DateTime DateCreated { get; set; }
        public string CoorX { get; set; }
        public string CoorY { get; set; } 
        public Municipality Municipality { get; set; }
    }
}
