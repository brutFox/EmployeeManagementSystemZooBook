using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementZooBookFronEnd
{
    public class EmployeeVM
    {
        public long Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }
    }
}
