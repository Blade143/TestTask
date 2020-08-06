using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Context;
using TestTask.Entities;

namespace TestTask.Services
{
    public class ProjectUserRoleService : IDisposable
    {
        protected TestTaskContext _db;
        public ProjectUserRoleService(TestTaskContext db)
        {
            this._db = db;
        }

        public async Task<bool> AddProjectUserRole(ProjectUserRole pur)
        {
            try
            {
                await _db.Set<ProjectUserRole>().AddAsync(pur);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> DeleteProjectUserRole(int id)
        {
            var pur = await _db.Set<ProjectUserRole>().FindAsync(id);

            try
            {
                _db.Set<ProjectUserRole>().Remove(pur);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public async Task<ProjectUserRole> GetProjectUserRole(int id)
        {
            ProjectUserRole pur;
            try
            {
                pur = await _db.Set<ProjectUserRole>().FindAsync(id);
            }
            catch (Exception e)
            {
                throw new Exception("Couldn't find this project!");
            }
            return pur;
        }

        public async Task<IEnumerable<ProjectUserRole>> GetProjectUserRoles()
        {
            List<ProjectUserRole> purs;
            try
            {
                purs = await _db.Set<ProjectUserRole>().ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Couldn't return list of purs");
            }
            return purs;
        }


        public void Dispose()
        {
            this._db.Dispose();
        }
    }
}
