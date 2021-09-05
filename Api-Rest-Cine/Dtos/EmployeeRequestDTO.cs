using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPackExpress.Dtos
{
    public class EmployeeRequestDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [StringLength(13)]
        public string Dni { get; set; }
        [Required]
        [RegularExpression(@"^\d{4}\-(0?[1-9]|1[012])\-(0?[1-9]|[12][0-9]|3[01])$")]

        public string Birthdate { get; set; }
        [Required]
        public string Nit { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int GenderId { get; set; }
        [Required]
        public int PositionId { get; set; }
        [Required]
        public int BranchId { get; set; }
    }
}
