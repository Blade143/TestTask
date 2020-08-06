using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Context;
using TestTask.Entities;

namespace TestTask.Services
{
    public class ProjectService : IDisposable
    {
        protected TestTaskContext _db;
        public ProjectService(TestTaskContext db)
        {
            this._db = db;
        }

        public async Task<bool> UpdateProject(Project project)
        {
            try
            {
                _db.Set<Project>().Update(project);
                _db.SaveChanges();
            }
            catch (Exception e) 
            {
                return false;
            }
            return true;
        }

        public async Task<bool> AddProject(Project project)
        {
            try
            {
                await _db.Set<Project>().AddAsync(project); 
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> DeleteProject(int id)
        {
            var project = await _db.Set<Project>().FindAsync(id);

            try
            {
                _db.Set<Project>().Remove(project);
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public async Task<Project> GetProject(int id)
        {
            Project project;
            try
            {
                project = await _db.Set<Project>().FindAsync(id);
            }
            catch (Exception e)
            {
                throw new Exception("Couldn't find this project!");
            }
            return project;
        }

        public async Task<IEnumerable<Project>> GetProjects()
        {
            List<Project> projects;
            try
            {
                projects = await _db.Set<Project>().ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Couldn't return list of projects");
            }
            return projects;
        }


        public void Dispose()
        {
            this._db.Dispose();
        }
    }
}
