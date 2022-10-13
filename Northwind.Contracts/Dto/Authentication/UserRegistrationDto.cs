using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Contracts.Dto.Authentication
{
    public class UserRegistrationDto
    {
        public string FirsName { get; set; }

        public string LastName { get; set; }

        [Required(ErrorMessage ="Membutuhkan  Email Valid")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage ="Silahkan Masukan Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Not macth Password & Confirmasi Password")]
        public string ConfirmPassword { get; set; }
    }
}
