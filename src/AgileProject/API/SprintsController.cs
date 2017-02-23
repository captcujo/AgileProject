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
    public class SprintsController : Controller
    {
        private ISprintService _sprnt;

        public SprintsController (ISprintService sprnt)
        {
            this._sprnt = sprnt;
        }

        [HttpGet]
        public List<Sprint> Get()
        {
            return _sprnt.GetSprintList();
        }

        [HttpGet("{id}")]
        public Sprint Get(int id)
        {
            return _sprnt.GetSprint(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Sprint sprint)
        {
            if(sprint == null)              // bad (empty) sprint object
            {
                return BadRequest();
            }
            else if (sprint.Id == 0)        // new sprint
            {
                _sprnt.AddSprint(sprint);

                return Ok();
            }
            else                            // update existing
            {
                _sprnt.UpdateSprint(sprint);

                return Ok();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _sprnt.DeleteSprint(id);

            return Ok();
        }
    }
}


//[HttpGet("{id}")]
//public SprintWithRequirements Get(int id)
//{
//    SprintWithRequirements sprintRequirements = (from s in _db.Sprints
//                                                 where s.Id == id
//                                                 select new SprintWithRequirements
//                                                 {
//                                                     Id = s.Id,
//                                                     SprintName = s.SprintName,
//                                                     Description = s.Description,
//                                                     Status = s.Status,
//                                                     Project = s.Project,
//                                                     Requirements =
//                                                     (from r in _db.Requirements
//                                                      where r.Sprint.Id == s.Id
//                                                      select new Requirement
//                                                      {
//                                                          Id = r.Id,
//                                                          RequirementName = r.RequirementName,
//                                                          Description = r.Description,
//                                                          Status = r.Status
//                                                                  //Sprint = r.Sprint
//                                                              }).ToList()
//                                                 }).FirstOrDefault();
//    return sprintRequirements;
//}
