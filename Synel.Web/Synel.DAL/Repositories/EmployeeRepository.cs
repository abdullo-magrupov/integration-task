using Synel.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Synel.DAL.Repositories
{
    public class EmployeeRepository
    {
        private SynelDbContext db;

        public EmployeeRepository()
        {
            db = new SynelDbContext();
        }

        public IQueryable<Employee> GetAll()
        {
            return db.Employees;
        }

        public void Insert(Employee emp)
        { 
            db.Employees.Add(emp);
            Save();
        }

        public Employee GetByPayroll(string payrollNumber)
        {
            return db.Employees
                     .Where(x => x.PayrollNumber.ToLower() == payrollNumber.ToLower())
                     .FirstOrDefault();
        }

        private void Save()
        {
            db.SaveChanges();
        }
    }
}
