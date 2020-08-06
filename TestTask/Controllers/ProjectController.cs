using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Context;
using TestTask.Entities;
using TestTask.Services;

namespace TestTask.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/Project")]
    public class ProjectController : Controller
    {
        protected ProjectService _projectService;

        public ProjectController(TestTaskContext _db)
        {
            _projectService = new ProjectService(_db);
        }

        //GET: api/projects
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try 
            {
                var result = await this._projectService.GetProjects();
                return Ok(result);
            }
            catch (Exception e) 
            {
                return BadRequest(e.Message);
            }
        }

        //GET: api/project/id
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var result = await this._projectService.GetProject(id);
                return Ok(result);
            }
            catch (Exception e) 
            {
                return BadRequest(e.Message);
            }
        }

        //POST: api/project
        [HttpPost]
        public async Task<IActionResult> Post(Project project)
        {
                bool result = await _projectService.AddProject(project);
                return Ok(result);
        }

        //PUT: api/project
        [HttpPut]
        public async Task<IActionResult> Put(Project project) 
        {
            bool result = await _projectService.UpdateProject(project);
            return Ok(result);
        }

        //DELETEL api/delete/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) 
        {
            var result = await _projectService.DeleteProject(id);
            return Ok(result);
        }
    }
}
