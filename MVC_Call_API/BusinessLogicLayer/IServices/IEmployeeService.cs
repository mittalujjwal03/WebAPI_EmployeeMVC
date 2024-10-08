
using EmployeeCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.IServices
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAll();
        Employee? GetById(int id);
        void Add(Employee employee);
        void Update(Employee employee);
        void Delete(int id);

    }
}
