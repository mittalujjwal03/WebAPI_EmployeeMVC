using DataAccessLayer.IRepository;
using EmployeeCRUD.DataAccessLayer;
using EmployeeCRUD.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace EmployeeCRUD.Data.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;

        public DepartmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Department> GetAll() => _context.Departments.Include(d => d.Employees).ToList();

        public Department? GetById(int id) => _context.Departments.Include(d => d.Employees).FirstOrDefault(d => d.DepartmentId == id);

        public void Add(Department department)
        {
            _context.Departments.Add(department);
            _context.SaveChanges();
        }

        public void Update(Department department)
        {
            _context.Departments.Update(department);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var department = GetById(id);
            if (department != null)
            {
                _context.Departments.Remove(department);
                _context.SaveChanges();
            }
        }
    }
}
