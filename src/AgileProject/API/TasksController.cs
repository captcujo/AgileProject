using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AgileProject.Data;
using AgileProject.Models;
using AgileProject.Services;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AgileProject.API
{
    [Route("api/[controller]")]
    public class TasksController : Controller
    {
        private ITaskService _tsk;

        public TasksController(ITaskService tsk)
        {
            this._tsk = tsk;
        }

        [HttpGet("tsks/{id}")]
        public List<Thask> GetTasks(int id)
        {
            return _tsk.GetTaskList(id);
        }

        [HttpGet("{id}")]
        public Thask Get(int id)
        {
            return _tsk.GetTask(id);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _tsk.DeleteTask(id);

            return Ok();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Thask task)
        {
            if(task == null)
            {
                return BadRequest();
            }
            else if(task.id == 0)
            {
                _tsk.AddTask(task);

                return Ok();
            }
            else
            {
                _tsk.UpdateTask(task);

                return Ok();
            }
        }
    }
}
