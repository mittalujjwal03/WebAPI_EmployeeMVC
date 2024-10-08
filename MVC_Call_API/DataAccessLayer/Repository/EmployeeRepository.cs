using DataAccessLayer.IRepository;
using EmployeeCRUD.DataAccessLayer;
using EmployeeCRUD.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace EmployeeCRUD.Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Employee> GetAll() => _context.Employees.Include(e => e.Department).ToList();

        public Employee? GetById(int id) => _context.Employees.Include(e => e.Department).FirstOrDefault(e => e.EmployeeId == id);

        public void Add(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public void Update(Employee employee)
        {
            _context.Employees.Update(employee);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var employee = GetById(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
        }
    }
}
