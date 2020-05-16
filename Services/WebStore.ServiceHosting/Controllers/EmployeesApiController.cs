using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebStore.Domain;
using WebStore.Infrastructure.Interfaces;
using WebStore.Models;

namespace WebStore.ServiceHosting.Controllers
{
    [Route(WebAPI.Employees)]
    [ApiController]
    public class EmployeesApiController : ControllerBase, IEmpoyeesData
    {
        private readonly IEmpoyeesData _EmployeesData;

        public EmployeesApiController(IEmpoyeesData EmployeesData) => _EmployeesData = EmployeesData;
        [HttpPost]
        public void Add(Employee Employee) => _EmployeesData.Add(Employee);
        
        [HttpDelete("{id}")]
        public bool Delete(int id) => _EmployeesData.Delete(id);
        
        [HttpPut("{id}")]
        public void Edit(int id, Employee Employee) => _EmployeesData.Edit(id, Employee);
        
        [HttpGet]
        public IEnumerable<Employee> GetAll() => _EmployeesData.GetAll();
        
        [HttpGet("{id}")]
        public Employee GetById(int id) => _EmployeesData.GetById(id);
        
        [NonAction]
        public void SaveChanges() => _EmployeesData.SaveChanges();
        
    }
}