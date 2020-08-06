using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Context;
using TestTask.Entities;

namespace TestTask.Services
{
    public class RoleService : IDisposable
    {
        protected TestTaskContext _db;
        public RoleService(TestTaskContext db)
        {
            this._db = db;
        }

        public async Task<bool> AddRole(Role role)
        {
            try
            {
                await _db.Set<Role>().AddAsync(role);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> DeleteRole(int id)
        {
            var role = await _db.Set<Role>().FindAsync(id);

            try
            {
                _db.Set<Role>().Remove(role);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public async Task<Role> GetRole(int id)
        {
            Role role;
            try
            {
                role = await _db.Set<Role>().FindAsync(id);
            }
            catch (Exception e)
            {
                throw new Exception("Couldn't find this Role!");
            }
            return role;
        }

        public async Task<IEnumerable<Role>> GetRoles()
        {
            List<Role> roles;
            try
            {
                roles = await _db.Set<Role>().ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Couldn't return list of purs");
            }
            return roles;
        }


        public void Dispose()
        {
            this._db.Dispose();
        }
    }
}
