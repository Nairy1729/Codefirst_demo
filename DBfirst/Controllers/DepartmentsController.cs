using DBfirst.Models;
using Microsoft.AspNetCore.Mvc;

namespace DBfirst.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly MyContext _context;
        public DepartmentsController(MyContext context)
        {
            _context = context;
        }



        public IActionResult Index()
        {
            var departments = _context.Departments.ToList();
            return View(departments);
        }

        public IActionResult Details(int id) {
            var department = _context.Departments.FirstOrDefault(x => x.DepartmentId == id);
            return View(department);
        }

        public IActionResult Edit(int id)
        {
            var department = _context.Departments.FirstOrDefault(x => x.DepartmentId == id);
            return View(department);
        }
        [HttpPost]
        public IActionResult Edit(Department department)
        {
            if (department != null)
            {

                _context.Entry(department).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                _context.Departments.Add(department);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }
        public IActionResult Delete(int id)
        {
            var department = _context.Departments.FirstOrDefault(x => x.DepartmentId == id);
            return View(department);
        }
        [HttpPost("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var department = _context.Departments.FirstOrDefault(x => x.DepartmentId == id);
            if (department != null)
            {
                _context.Departments.Remove(department);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }


    }
}
