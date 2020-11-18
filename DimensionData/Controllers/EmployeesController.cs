using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DimensionData.Models;

namespace DimensionData.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly DimensionDataContext _context;

        public EmployeesController(DimensionDataContext context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            var dimensionDataContext = _context.Employee.Include(e => e.Department).Include(e => e.Education).Include(e => e.Job).Include(e => e.JobRole);
            return View(await dimensionDataContext.ToListAsync());
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .Include(e => e.Department)
                .Include(e => e.Education)
                .Include(e => e.Job)
                .Include(e => e.JobRole)
                .FirstOrDefaultAsync(m => m.EmployeeNumber == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList(_context.Department, "DepartmentId", "DepartmentName");
            ViewData["EducationId"] = new SelectList(_context.Education, "EducatoinId", "EducationField");
            ViewData["JobId"] = new SelectList(_context.Job, "JobId", "JobId");
            ViewData["JobRoleId"] = new SelectList(_context.JobRole, "JobRoleId", "JobRole1");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeNumber,DepartmentId,EducationId,JobId,JobRoleId,Age,Attrition,DistanceFromHome,EmployeeCount,EnvironmentSatisfaction,Gender,MaritalStatus,Over18,OverTime,PerformanceRating,RelationshipSatisfaction,StandardHours,StockOptionLevel,WorkLifeBalance,BusinessTravel")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList(_context.Department, "DepartmentId", "DepartmentName", employee.DepartmentId);
            ViewData["EducationId"] = new SelectList(_context.Education, "EducatoinId", "EducationField", employee.EducationId);
            ViewData["JobId"] = new SelectList(_context.Job, "JobId", "JobId", employee.JobId);
            ViewData["JobRoleId"] = new SelectList(_context.JobRole, "JobRoleId", "JobRole1", employee.JobRoleId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["DepartmentId"] = new SelectList(_context.Department, "DepartmentId", "DepartmentName", employee.DepartmentId);
            ViewData["EducationId"] = new SelectList(_context.Education, "EducatoinId", "EducationField", employee.EducationId);
            ViewData["JobId"] = new SelectList(_context.Job, "JobId", "JobId", employee.JobId);
            ViewData["JobRoleId"] = new SelectList(_context.JobRole, "JobRoleId", "JobRole1", employee.JobRoleId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeNumber,DepartmentId,EducationId,JobId,JobRoleId,Age,Attrition,DistanceFromHome,EmployeeCount,EnvironmentSatisfaction,Gender,MaritalStatus,Over18,OverTime,PerformanceRating,RelationshipSatisfaction,StandardHours,StockOptionLevel,WorkLifeBalance,BusinessTravel")] Employee employee)
        {
            if (id != employee.EmployeeNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.EmployeeNumber))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList(_context.Department, "DepartmentId", "DepartmentName", employee.DepartmentId);
            ViewData["EducationId"] = new SelectList(_context.Education, "EducatoinId", "EducationField", employee.EducationId);
            ViewData["JobId"] = new SelectList(_context.Job, "JobId", "JobId", employee.JobId);
            ViewData["JobRoleId"] = new SelectList(_context.JobRole, "JobRoleId", "JobRole1", employee.JobRoleId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .Include(e => e.Department)
                .Include(e => e.Education)
                .Include(e => e.Job)
                .Include(e => e.JobRole)
                .FirstOrDefaultAsync(m => m.EmployeeNumber == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employee.FindAsync(id);
            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.EmployeeNumber == id);
        }
    }
}
