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
    public class RequirementsController : Controller
    {
        private IRequirementService _req;

        public RequirementsController(IRequirementService req)
        {
            this._req = req;
        }

        [HttpGet]
        public List<Requirement> Get()
        {
            return _req.GetRequirementList();
        }

        [HttpGet("{id}")]
        public Requirement Get(int id)
        {
            return _req.GetRequirement(id);
        }

        [HttpGet("product/{id}")]
        public List<Requirement> GetStoriesByProduct(int id)
        {
            return _req.GetRequirementListByProduct(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Requirement req)
        {
            if (req == null)
            {
                return BadRequest();
            }
            else if (req.Id == 0)
            {
                _req.AddRequirement(req);

                return Ok();
            }
            else
            {
                _req.UpdateRequirement(req);

                return Ok();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _req.DeleteRequirement(id);

            return Ok();
        }
    }
}
