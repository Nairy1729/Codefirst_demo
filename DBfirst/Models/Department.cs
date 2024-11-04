using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DBfirst.Models
{
    public class Department
    {
        [Key] 
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Department name is required.")]
        [StringLength(100, ErrorMessage = "Department name cannot exceed 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Location is required.")]
        [StringLength(200, ErrorMessage = "Location cannot exceed 200 characters.")]
        public string Location { get; set; }

        public virtual ICollection<Employee>? Employees { get; set; }
    }
}

