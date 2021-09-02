using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPackExpress.Dtos
{
    public class BranchDTO
    {
        public int IdBranch { get; set; }
        public string Branch { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
    }
}
