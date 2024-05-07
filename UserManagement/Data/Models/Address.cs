using System.ComponentModel.DataAnnotations;

namespace UserManagement.Data.Models
{
    public class Address
    {
        public int AddressId { get; set; }

        [Required(ErrorMessage = "Please fill in this field!")]
        [StringLength(20, ErrorMessage = "Please enter no more than 20 characters!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please fill in this field!")]
        [StringLength(20, ErrorMessage = "Please enter no more than 20 characters!")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please fill in this field!")]
        [StringLength(20, ErrorMessage = "Please enter no more than 20 characters!")]
        public string County { get; set; }

        [Required(ErrorMessage = "Please fill in this field!")]
        [StringLength(20, ErrorMessage = "Please enter no more than 20 characters!")]
        public string Neighbourhood { get; set; }

        [Required(ErrorMessage = "Please fill in this field!")]
        [StringLength(100, ErrorMessage = "Please enter no more than 100 characters!")]
        public string LongAddress { get; set; }

        [Required(ErrorMessage = "Please fill in this field!")]
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
