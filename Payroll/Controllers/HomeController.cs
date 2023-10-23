using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Payroll.Data;
using Payroll.Models;
using System.Diagnostics;

namespace Payroll.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            int employeesTotal = await this._context.Employees.CountAsync();
            double baseSalaryTotal = await this._context.Employees.SumAsync(employee => employee.BaseSalary);
            double bonusTotal = await this._context.Employees.SumAsync(employee => employee.Bonus);

            ViewBag.EmployeesTotal = employeesTotal;
            ViewBag.SalaryTotal = baseSalaryTotal;
            ViewBag.BonusTotal = bonusTotal;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}