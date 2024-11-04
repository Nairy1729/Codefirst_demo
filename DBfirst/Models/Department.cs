namespace DBfirst.Models
{
    //Plain Old CLR Object
    public class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public virtual ICollection<Employee>? Employees { get; set; }

    }

}
