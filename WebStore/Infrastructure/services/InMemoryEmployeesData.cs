using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Data;
using WebStore.Infrastructure.Interfaces;
using WebStore.Models;

namespace WebStore.Infrastructure.services
{
    public class InMemoryEmployeesData : IEmpoyeesData      
    {
        private readonly List<Employee> _Employees = TestData.Employees;

        public IEnumerable<Employee> GetAll() => _Employees;
        public Employee GetById(int id) => _Employees.FirstOrDefault(e => e.Id == id);
        public void Add(Employee Employee) 
        {
            if (Employee is null)
                throw new ArgumentNullException(nameof(Employee)); // Если передана пустая ссылка то ругается
            if (_Employees.Contains(Employee)) return; // Если у нас список содержит сотрудника ничего не делаем
            Employee.Id = _Employees.Count == 0 ? 1 : _Employees.Max(e => e.Id) + 1;
            _Employees.Add(Employee);
        }
        public void Edit(int id, Employee Employee) 
        {
            if (Employee is null)
                throw new ArgumentNullException(nameof(Employee));
            if (_Employees.Contains(Employee)) return;
            var db_employee = GetById(id);
            if (db_employee is null)
                return;

            db_employee.SurName = Employee.SurName;
            db_employee.FirstName = Employee.FirstName;
            db_employee.Patronymic = Employee.Patronymic;
            db_employee.Age = Employee.Age;
            SaveChanges();
        }
        public bool Delete(int id) 
        {
            var db_employee = GetById(id);
            if (db_employee is null)
                return false;
            return _Employees.Remove(db_employee);
        }
        public void SaveChanges() { throw new NotImplementedException(); }
    }
}
