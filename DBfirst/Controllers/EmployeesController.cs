using DBfirst.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DBfirst.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly MyContext _context;

        public EmployeesController(MyContext context)
        {
            _context = context;
        }
       

        public IActionResult Index()
        {
            var employees = _context.Employees.Include(e => e.Department).ToList();
            return View(employees);
        }


        public IActionResult Details(int id)
        {
            var employee = _context.Employees
                                   .Include(e => e.Department)
                                   .FirstOrDefault(x => x.EmpId == id);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        public IActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(_context.Departments, "DepartmentId", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentId = new SelectList(_context.Departments, "DepartmentId", "Name");
            return View(employee);
        }


        public IActionResult Edit(int id)
        {
            var employee = _context.Employees
                                   .Include(e => e.Department)
                                   .FirstOrDefault(x => x.EmpId == id);
            if (employee == null)
            {
                return NotFound();
            }

            var departments = _context.Departments.ToList();
            if (departments == null || !departments.Any())
            {
                ModelState.AddModelError("", "No departments available. Please add a department first.");
                return View(employee);
            }

            ViewBag.DepartmentId = new SelectList(departments, "DepartmentId", "Name", employee.DepartmentId);

            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Attach(employee);
                    _context.Entry(employee).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError("", "Unable to save changes. Please try again.");
                }
            }

            ViewBag.DepartmentId = new SelectList(_context.Departments, "DepartmentId", "Name", employee.DepartmentId);
            return View(employee);
        }

        public IActionResult Delete(int id)
        {
            var employee = _context.Employees.FirstOrDefault(x => x.EmpId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var employee = _context.Employees.FirstOrDefault(x => x.EmpId == id);
            if (employee != null)
            {
                _context.Employees.Remove(employee); 
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Delete", employee);
        }











    }
}
