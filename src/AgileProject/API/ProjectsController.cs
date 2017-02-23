using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AgileProject.Data;
using AgileProject.Models;
using AgileProject.ViewModels;
using AgileProject.Interfaces;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AgileProject.API
{
    [Route("api/[controller]")]
    public class ProjectsController : Controller
    {
        private IProjectService _proj;

        public ProjectsController(IProjectService proj)
        {
            this._proj = proj;
        }

        [HttpGet]
        public List<Project> Get()
        {
            return _proj.GetProjectList();
        }

        [HttpGet("{id}")]
        public ProjectWithSprints Get(int id)
        {
            return _proj.GetProjectWithSprints(id);
        }

        [HttpGet("product/{id}")]
        public ProductSprintStories GetProductSprintStories(int id)
        {
            return _proj.GetProductSprintStories(id);
        }


        [HttpPost]
        public IActionResult Post([FromBody] Project project)
        {
            if(project == null)         // bad (empty) project
            {
                return BadRequest();
            }
            else if (project.Id == 0)   // new project
            {
                _proj.AddProject(project);

                return Ok();
            }
            else                        // update existing
            {
                _proj.UpdateProject(project);

                return Ok();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _proj.DeleteProject(id);

            return Ok();
        }
    }
}
