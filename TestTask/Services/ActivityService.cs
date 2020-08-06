using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Context;
using TestTask.Entities;

namespace TestTask.Services
{
    public class ActivityService : IDisposable
    {
        protected TestTaskContext _db;
        public ActivityService(TestTaskContext db) 
        {
            this._db = db;
        }

        public async Task<bool> AddActivity(Activity activity) 
        {
            try
            {
                await _db.Set<Activity>().AddAsync(activity);
            }
            catch (Exception e) 
            {
                return false;
            }
            return true;
        }

        public async Task<bool> DeleteActivity(int id)
        {
            var actv = await _db.Set<Activity>().FindAsync(id);

            try
            {
                _db.Set<Activity>().Remove(actv);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public async Task<Activity> GetActivity(int id)
        {
            Activity actv;
            try
            {
                actv = await _db.Set<Activity>().FindAsync(id);
            }
            catch (Exception e)
            {
                throw new Exception("Couldn't find this activity!");
            }
            return actv;
        }

        public async Task<IEnumerable<Activity>> GetActivities()
        {
            List<Activity> actvs;
            try
            {
                actvs = await _db.Set<Activity>().ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Couldn't return list of activities");
            }
            return actvs;
        }


        public void Dispose()
        {
            this._db.Dispose();
        }
    }
}
