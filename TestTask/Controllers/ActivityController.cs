using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Threading.Tasks;
using TestTask.Context;
using TestTask.Entities;
using TestTask.requestModels;
using TestTask.Services;

namespace TestTask.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    public class ActivityController : Controller
    {
        protected EmployeeService _eservice;
        protected ActivityTypeService _atservice;
        protected ActivityService _aservice;
        protected ProjectService _pservice;
        protected RoleService _rservice;

        public ActivityController(TestTaskContext db)
        {
            _eservice = new EmployeeService(db);
            _atservice = new ActivityTypeService(db);
            _aservice = new ActivityService(db);
            _pservice = new ProjectService(db);
            _rservice = new RoleService(db);
        }

        //POST: api/Activity/post
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> GetActionsByNameAndId([FromBody]PersonIdAndDateModel model) 
        {
            var activities = await _aservice.GetActivities();
            var employers = await _eservice.GetEmployers();
            var projects = await _pservice.GetProjects();
            var types = await _atservice.GetActivityTypes(); 
            var roles = await _rservice.GetRoles();

            var result = from activ in activities
                         join employer in employers on activ.EmployerId equals employer.Id
                         join project in projects on activ.ProjectId equals project.Id
                         join type in types on activ.ActivityTypeId equals type.Id
                         join role in roles on activ.RoleId equals role.Id
                         where (activ.TimeStart.Date == model.Date.Date && activ.EmployerId == model.PersonId)
                         select new
                         {
                             SatrtDate = activ.TimeStart.ToString("dd/mm/yyyy"),
                             PersonName = employer.Name,
                             HoursOfWork = (activ.TimeEnd - activ.TimeStart).Hours,
                             ActovityType = type.Name,
                             Role = role.RoleName,
                             Project = project.Name
                         };
            return Ok(result);
        }

        //POST: api/post
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> GetActionsByIdInWeeks([FromBody]PersonIdAndWeekNumberModel model)
        {
            DateTime jan1 = new DateTime(DateTime.Now.Year, 1, 1);

            int daysOffset = (int)CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek - (int)jan1.DayOfWeek;

            DateTime firstMonday = jan1.AddDays(daysOffset);

            int firstWeek = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(jan1, CultureInfo.CurrentCulture.DateTimeFormat.CalendarWeekRule, CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek);

            if (firstWeek <= 1)
            {
                model.WeekNumber -= 1;
            }

            var startofscope = firstMonday.AddDays(model.WeekNumber * 7);
            var endofscope = firstMonday.AddDays((model.WeekNumber+1) * 7);


            var activities = await _aservice.GetActivities();
            var employers = await _eservice.GetEmployers();
            var projects = await _pservice.GetProjects();
            var types = await _atservice.GetActivityTypes();
            var roles = await _rservice.GetRoles();

            var result = from activ in  activities
                         join employer in  employers on activ.EmployerId equals employer.Id
                         join project in  projects on activ.ProjectId equals project.Id
                         join type in  types on activ.ActivityTypeId equals type.Id
                         join role in  roles on activ.RoleId equals role.Id
                         where (activ.TimeStart.Date >= startofscope.Date && activ.TimeStart.Date < startofscope.Date && activ.EmployerId == model.PersonId)
                         select new
                         {
                             SatrtDate = activ.TimeStart.ToString("dd/mm/yyyy"),
                             PersonName = employer.Name,
                             HoursOfWork = activ.TimeEnd - activ.TimeStart,
                             ActovityType = type.Name,
                             Role = role.RoleName,
                             Project = project.Name
                         };
            return Ok(result);
        }
    }
}
