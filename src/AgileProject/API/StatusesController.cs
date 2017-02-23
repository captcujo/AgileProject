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
    public class StatusesController : Controller
    {
        private IStatusService _stat;

        public StatusesController(IStatusService stat)
        {
            this._stat = stat;
        }

        [HttpGet]
        public List<Status> Get()
        {
            return _stat.GetStatuses();
        }

        [HttpGet("{id}")]
        public Status Get(int id)
        {
            return _stat.GetStatus(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Status status)
        {
            if(status == null)
            {
                return BadRequest();
            }
            else if(status.Id == 0)
            {
                _stat.AddStatus(status);

                return Ok();
            }
            else
            {
                _stat.UpdateStatus(status);

                return Ok();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _stat.DeleteStatus(id);

            return Ok();
        }
    }
}
