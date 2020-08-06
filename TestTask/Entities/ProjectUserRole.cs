using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestTask.Entities
{
    public class ProjectUserRole
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public int ProjectId { get; set; }
    }
}
