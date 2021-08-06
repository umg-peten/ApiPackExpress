using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Rest_Cine.Models
{
    public class Branch
    {
        public int BranchId { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public string Address { get; set; }
        public DateTime DateCreated { get; set; }
        public float CoorX { get; set; }
        public float CoorY { get; set; }
        public Municipality municipality { get; set; }
        public Company company { get; set; }
    }
}
