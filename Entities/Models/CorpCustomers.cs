using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public partial class CorpCustomers
    {   
        
        public CorpCustomers()
        {
            WeightControl = new HashSet<WeightControl>();
        }

        [Key]
        [Column("IdCustomers")]
        public int IdCustomers { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(45, MinimumLength = 5, ErrorMessage = "The name must have a minimum length of {2} characters and a maximum length of {1}")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is required")]
        [StringLength(45, MinimumLength = 5, ErrorMessage = "The LastName must have a minimum length of {2} characters and a maximum length of {1}")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Email is not correct")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Ingrese fecha de nacimiento")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "The Password must have a minimum length of {2} characters and a maximum length of {1}")]
        public string Password { get; set; }

        public int Status { get; set; }

        public string UserModify { get; set; }

        public DateTime DateModify { get; set; }

        public int PasswordAttempts { get; set; }
      
        public virtual ICollection<WeightControl> WeightControl { get; set; }
    }
}
