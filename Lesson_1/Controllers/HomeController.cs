using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lesson_1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lesson_1.Controllers
{
    public class HomeController : Controller
    {
        private readonly List<Employee> _employees = new List<Employee>()
        {
            new Employee()
            {
                Id = 1,
                FirstName = "Иванов",
                SurName = "Иван",
                Patronymic = "Иванович",
                Age = 38
            },
            new Employee()
            {
                Id = 2,
                FirstName = "Петров",
                SurName = "Петр",
                Patronymic = "Петрович",
                Age = 35
            },
            new Employee()
            {
                Id = 3,
                FirstName = "Сидоров",
                SurName = "Коля",
                Patronymic = "Александрович",
                Age = 40
            }
        };
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SomeAction()
        {
            return View();
        }
        public IActionResult Employees()
        {
            return View(_employees);
        }
        public IActionResult Employee(int id)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
                return NotFound();
            else
            return View(employee);
        }
    }
}