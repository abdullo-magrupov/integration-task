using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synel.DAL.Entities
{
    [Table("Employees")]
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MaxLength(50)]
        [DisplayName("Payroll Number")]
        public string PayrollNumber { get; set; }
        
        [Required]
        [MaxLength(50)]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        
        [Required]
        [MaxLength(50)]
        [DisplayName("Last Name")]
        public string LastName { get; set; }


        [Required]
        [DisplayName("DOB")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [MaxLength(50)]
        [DisplayName("Phone")]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(50)]
        [DisplayName("Mobile")]
        public string MobileNumber { get; set; }

        [Required]
        [MaxLength(200)]
        [DisplayName("Primary Address")]
        public string PrimaryAddress { get; set; }

        [Required]
        [MaxLength(200)]
        [DisplayName("Secondary Address")]
        public string SecondaryAddress { get; set; }

        [Required]
        [MaxLength(50)]
        [DisplayName("Post Code")]
        public string PostCode { get; set; }

        [Required]
        [MaxLength(100)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Required]
        [DisplayName("Start Date")]
        public DateTime StartDate { get; set; }

    }
}
