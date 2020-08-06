using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Context;
using TestTask.Entities;

namespace TestTask.Services
{
    public class EmployeeService : IDisposable
    {
        protected TestTaskContext _db;
        public EmployeeService(TestTaskContext db)
        {
            this._db = db;
        }

        public async Task<bool> AddEmployer(Employer employer)
        {
            try
            {
                await _db.Set<Employer>().AddAsync(employer);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> DeleteEmployer(int id)
        {
            var employer = await _db.Set<Employer>().FindAsync(id);

            try
            {
                _db.Set<Employer>().Remove(employer);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public async Task<Employer> GetEmployer(int id)
        {
            Employer employer;
            try
            {
                employer = await _db.Set<Employer>().FindAsync(id);
            }
            catch (Exception e)
            {
                throw new Exception("Couldn't find this employer!");
            }
            return employer;
        }

        public async Task<IEnumerable<Employer>> GetEmployers()
        {
            List<Employer> employee;
            try
            {
                employee = await _db.Set<Employer>().ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Couldn't return list of employers");
            }
            return employee;
        }


        public void Dispose()
        {
            this._db.Dispose();
        }
    }
}
