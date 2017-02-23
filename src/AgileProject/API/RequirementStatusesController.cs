using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AgileProject.Data;
using AgileProject.Models;
using AgileProject.Interfaces;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AgileProject.API
{
    [Route("api/[controller]")]
    public class RequirementStatusesController : Controller
    {
        private IRequirementStatusService _reqStat;

        public RequirementStatusesController(IRequirementStatusService reqStat)
        {
            this._reqStat = reqStat;
        }

        [HttpGet]
        public List<RequirementStatus> Get()
        {
            return _reqStat.ListRequirementStatuses();
        }

        [HttpGet("{id}")]
        public RequirementStatus Get(int id)
        {
            return _reqStat.GetRequirementStatus(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody] RequirementStatus status)
        {
            if(status == null)
            {
                return BadRequest();
            }
            else if (status.Id == 0)
            {
                _reqStat.AddRequirementStatus(status);

                return Ok();
            }
            else
            {
                _reqStat.UpdateRequirementStatus(status);

                return Ok();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _reqStat.DeleteRequirementStatus(id);

            return Ok();
        }
    }
}
