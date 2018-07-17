using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Employees.Models;
using Microsoft.EntityFrameworkCore;

namespace Employees.Controllers
{
    public class HomeController : Controller
    {
        private Context db;
        public HomeController(Context context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            var result = db.Employees.Include(a => a.EmployeeJobs).ThenInclude(i => i.Job);
            
            return View(result);
        }

       public IActionResult Create()
        {
            ViewBag.Jobs = db.Jobs;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employee, int[] jobs)
        {
            foreach (var item in jobs)
            {
                //var job = db.Jobs.Find(item);
                //db.EmployeeJobs.Add(new EmployeeJob() { Employee = employee, Job = job });

                db.EmployeeJobs.Add(new EmployeeJob() { Employee = employee, JobId = item });
            }
            employee.CreationDate = DateTime.Now;

            db.Add(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await db.Employees
                .SingleOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await db.Employees.SingleOrDefaultAsync(m => m.Id == id);
            db.Employees.Remove(employee);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
