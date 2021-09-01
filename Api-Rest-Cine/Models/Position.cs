using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPackExpress.Models
{
    public class Position
    {
        public int PositionId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public int EmployeeCreated { get; set; }
        public int EmployeeModified { get; set; }
        public int DepartmentId { get; set; }
    }
}
