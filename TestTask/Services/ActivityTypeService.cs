using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Context;
using TestTask.Entities;

namespace TestTask.Services
{
    public class ActivityTypeService : IDisposable
    {
        protected TestTaskContext _db;
        public ActivityTypeService(TestTaskContext db)
        {
            this._db = db;
        }

        public async Task<bool> AddActivityType(ActivityType activitytype)
        {
            try
            {
                await _db.Set<ActivityType>().AddAsync(activitytype);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> DeleteActivityType(int id)
        {
            var actv = await _db.Set<ActivityType>().FindAsync(id);

            try
            {
                _db.Set<ActivityType>().Remove(actv);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public async Task<ActivityType> GetActivityType(int id)
        {
            ActivityType actv;
            try
            {
                actv = await _db.Set<ActivityType>().FindAsync(id);
            }
            catch (Exception e)
            {
                throw new Exception("Couldn't find this activity type!");
            }
            return actv;
        }

        public async Task<IEnumerable<ActivityType>> GetActivityTypes()
        {
            List<ActivityType> actvs;
            try
            {
                actvs = await _db.Set<ActivityType>().ToListAsync();
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
