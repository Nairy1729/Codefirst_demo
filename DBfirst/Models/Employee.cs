namespace DBfirst.Models
{
    public class Employee
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int EmpId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Designation { get; set; }

        public decimal Salary { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department? Department { get; set; }

    }
}
