using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.Data;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class EmployeesController : Controller
    {
        

        public IActionResult Index() => View(TestData.Employees);

        public IActionResult Details(int Id)
        {
            var employee = TestData.Employees.FirstOrDefault(e => e.Id == Id);
            if (employee is null)
                return NotFound();
            return View(employee);
        }
     
        public IActionResult Edit1(int Id)
        {
            var employee = TestData.Employees.FirstOrDefault(e => e.Id == Id);
            if (employee is null)
                return NotFound();
            return View(employee);
        }
        [HttpPost]
        public IActionResult Edit2(int Id, string FirstName, string SurName, string Patronymic, int Age)
        {
            var employee = TestData.Employees.FirstOrDefault(e => e.Id == Id);
            if (FirstName != null)
            {
                employee.FirstName = FirstName;
            }
            if (SurName != null)
            {
                employee.SurName = SurName;
            }
            if (Patronymic != null)
            {
                employee.Patronymic = Patronymic;
            }
            if (Age != 0)
            {
                employee.Age = Age;
            }
            return View(employee);
        }
    }
}
