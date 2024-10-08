using BusinessLogicLayer.IServices;
using DataAccessLayer.IRepository;
using EmployeeCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _repository;

        public DepartmentService(IDepartmentRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Department> GetAll() => _repository.GetAll();
        public Department? GetById(int id) => _repository.GetById(id);
        public void Add(Department department) => _repository.Add(department);
        public void Update(Department department) => _repository.Update(department);
        public void Delete(int id) => _repository.Delete(id);
    }
}
