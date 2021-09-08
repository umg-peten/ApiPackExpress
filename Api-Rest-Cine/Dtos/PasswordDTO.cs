using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPackExpress.Dtos
{
    public class PasswordDTO
    {
        [Required]
        //[RegularExpression(@"/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])([A-Za-z\d$@$!%*?&]|[^ ]){8,15}$/;")]
        public string Password { get; set; }
        [Required]
        //[RegularExpression(@"/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])([A-Za-z\d$@$!%*?&]|[^ ]){8,15}$/;")]
        public string  ConfirmPassword { get; set; }

    }
}
