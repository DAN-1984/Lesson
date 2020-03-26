using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebStore.Data;
using WebStore.Domain.Entities.Identity;
using WebStore.Infrastructure.Interfaces;
using WebStore.Infrastructure.Mapping;
using WebStore.Models;
using WebStore.ViewModels;

namespace WebStore.Controllers
{
    [Authorize]
    public class EmployeesController : Controller
    {
        private readonly IEmpoyeesData _EmployeesData;
        public EmployeesController(IEmpoyeesData EmployeesData) => _EmployeesData = EmployeesData;
        
        public IActionResult Index() => View(_EmployeesData.GetAll().Select(e => e.ToView()));

        public IActionResult Details(int Id)
        {
            var employee = _EmployeesData.GetById(Id);
            if (employee is null)
                return NotFound();
            return View(employee.ToView());
        }
        [Authorize(Roles = Role.Administrator)]
        public IActionResult Create()
        {
            return View(new EmployeeViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Role.Administrator)]
        public IActionResult Create(EmployeeViewModel Employee)
        {
            if (Employee is null)
                throw new ArgumentNullException(nameof(Employee));
            if (!ModelState.IsValid)
                return View(Employee);
            _EmployeesData.Add(Employee.FromView());
            _EmployeesData.SaveChanges();

            return RedirectToAction("Index");
        }

        [Authorize(Roles = Role.Administrator)]
        public IActionResult Edit(int? Id)
        {
            if (Id is null) return View(new EmployeeViewModel());

            if (Id < 0)
                return BadRequest();
            var employee = _EmployeesData.GetById((int)Id);

            if (employee is null)
                return NotFound();
            return View(employee.ToView());
        }
        [HttpPost]
        [Authorize(Roles = Role.Administrator)]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EmployeeViewModel Employee)
        {
            if (Employee is null)
                throw new ArgumentNullException();
            if (!ModelState.IsValid)
                return View(Employee);

            var id = Employee.Id;
            if (id == 0)
                _EmployeesData.Add(Employee.FromView());
            else
                _EmployeesData.Edit(id, new Employee()
                {
                    SurName = Employee.SecondName,
                    FirstName = Employee.Name,
                    Patronymic = Employee.Patronymic,
                    Age = Employee.Age
                });

            _EmployeesData.SaveChanges();

            return RedirectToAction("Index");
        }
        [Authorize(Roles = Role.Administrator)]
        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest();

            var employee = _EmployeesData.GetById(id);
            
            if (employee is null)
                return NotFound();
            
            return View(employee.ToView());
        }
        [Authorize(Roles = Role.Administrator)]
        public IActionResult DeleteConfirmed(int id)
        {
            _EmployeesData.Delete(id);
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
