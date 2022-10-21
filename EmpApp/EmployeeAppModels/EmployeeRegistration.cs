using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Xml.Linq;

namespace EmployeeAppModels
{
    public class EmployeeRegistration
    {
        [Key]
        [DisplayName("User Name")]
        [Required(ErrorMessage = "User Name is required")]
        [StringLength(100, MinimumLength = 3)]
        public string UserName { get; set; } = null!;

        [Required(ErrorMessage = "Please Enter Password")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string? Title { get; set; }

        [DisplayName("First Name")]
        [Required(ErrorMessage = "First Name is required")]
        [StringLength(100, MinimumLength = 3)]
        public string FirstName { get; set; } = null!;

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "First Name is required")]
        [StringLength(100, MinimumLength = 3)]
        public string? LastName { get; set; }


        public string? Gender { get; set; }


        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address")]
        [MaxLength(50)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter correct email")]
        public string? EmailId { get; set; }


        [Display(Name = "Mobile")]
        //    [StringLength(10, ErrorMessage = "The Mobile must contains 10 characters", MinimumLength = 10)]
        //[RegularExpression("^[0-9]{10}&")]
        public int? MobileNumber { get; set; }


        [Required(ErrorMessage = "Employee Address is required")]
        [StringLength(300)]
        public string? Address { get; set; }

        [Display(Name = "Country")]
        public string? Country { get; set; }

        [Display(Name = "Salary")]
        public int Salary { get; set; }

        [Display(Name = "Designation")]
        public string Designation { get; set; }

        public string Image { get; set; }

    }

}