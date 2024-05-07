using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UserManagement.Data.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "Please fill in this field!")]
        [StringLength(20,ErrorMessage = "Please enter no more than 20 characters!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please fill in this field!")]
        [StringLength(20, ErrorMessage = "Please enter no more than 20 characters!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please fill in this field!")]
        [StringLength(20, ErrorMessage = "Please enter no more than 20 characters!")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Please fill in this field!")]
        [StringLength(50, ErrorMessage = "Please enter no more than 50 characters!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please fill in this field!")]
        [StringLength(20, ErrorMessage = "Please enter no more than 20 characters!")]
        public string Password { get; set; }

        public List<Address> Addresses { get; set; }
    }
}
