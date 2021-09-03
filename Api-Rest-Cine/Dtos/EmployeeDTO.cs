using ApiPackExpress.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPackExpress.Dtos
{
    public class EmployeeDTO
    {
        public int IdEmployee { get; set; }
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
        public Gender Gender { get; set; }
        public PositionDTO Position { get; set; }
        public BranchDTO Branch { get; set; }
    }
}
