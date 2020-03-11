using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.Data;
using WebStore.Infrastructure.Interfaces;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmpoyeesData _EmployeesData;
        public EmployeesController(IEmpoyeesData EmployeesData) => _EmployeesData = EmployeesData;
        
        public IActionResult Index() => View(_EmployeesData.GetAll());

        public IActionResult Details(int Id)
        {
            var employee = _EmployeesData.GetById(Id);
            if (employee is null)
                return NotFound();
            return View(employee);
        }

        public IActionResult Create()
        {
            return View(new Employee());
        }

        [HttpPost]
        public IActionResult Create(Employee Employee)
        {
            if (Employee is null)
                throw new ArgumentNullException(nameof(Employee));
            if (!ModelState.IsValid)
                return View(Employee);
            _EmployeesData.Add(Employee);
            _EmployeesData.SaveChanges();

            return RedirectToAction("Index");
        }


        public IActionResult Edit(int? Id)
        {
            if (Id is null) return View(new Employee());

            if (Id < 0)
                return BadRequest();
            var employee = _EmployeesData.GetById((int)Id);

            if (employee is null)
                return NotFound();
            return View(employee);
        }
        [HttpPost]
        public IActionResult Edit(Employee Employee)
        {
            if (Employee is null)
                throw new ArgumentNullException();
            if (!ModelState.IsValid)
                return View(Employee);

            var id = Employee.Id;
            if (id == 0)
                _EmployeesData.Add(Employee);
            else
                _EmployeesData.Edit(id, Employee);

            _EmployeesData.SaveChanges();

            return RedirectToAction("Index");
        }


        //public IActionResult Edit1(int Id)
        //{
        //    var employee = TestData.Employees.FirstOrDefault(e => e.Id == Id);
        //    if (employee is null)
        //        return NotFound();
        //    return View(employee);
        //}



        //[HttpPost]
        //public IActionResult Edit2(int Id, string FirstName, string SurName, string Patronymic, int Age)
        //{
        //    var employee = TestData.Employees.FirstOrDefault(e => e.Id == Id);
        //    if (FirstName != null)
        //    {
        //        employee.FirstName = FirstName;
        //    }
        //    if (SurName != null)
        //    {
        //        employee.SurName = SurName;
        //    }
        //    if (Patronymic != null)
        //    {
        //        employee.Patronymic = Patronymic;
        //    }
        //    if (Age != 0)
        //    {
        //        employee.Age = Age;
        //    }
        //    return View(employee);
        //}
    }
}
