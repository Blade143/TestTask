using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestTask.Entities
{
    public class Activity
    {
        public int Id { get; set; }
        public int ActivityTypeId { get; set; }
        public int RoleId { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public int ProjectId { get; set; }
        public int EmployerId { get; set; }
    }
}
