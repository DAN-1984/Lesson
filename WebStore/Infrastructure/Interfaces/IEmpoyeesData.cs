using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Models;

namespace WebStore.Infrastructure.Interfaces
{
    public interface IEmpoyeesData
    {
        IEnumerable<Employee> GetAll(); // Получение всех сотрудников

        Employee GetById(int id); // Получение идентефикатора сотрудника

        void Add(Employee Employee); // Добавление сотрудника

        void Edit(int id, Employee Employee); // Редактирование сотрудника по идентефикатору

        bool Delete(int id); // Удаление сотрудника по идентефикатору

        void SaveChanges(); // Сохранение в случае когда есть база данных
    }
}
