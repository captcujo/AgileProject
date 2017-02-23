using AgileProject.Interfaces;
using AgileProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgileProject.Services
{
    public class TaskService: ITaskService
    {
        private IGenericRespository _repo;

        public TaskService(IGenericRespository repo)
        {
            this._repo = repo;
        }

        public List<Thask> GetTaskList(int id)
        {
            List<Thask> taskList = (from r in _repo.Query<Requirement>()
                                    join t in _repo.Query<Thask>() on r.Id equals t.Story.Id
                                    where r.Id == id
                                    select new Thask
                                    {
                                        id = t.id,
                                        TaskName = t.TaskName,
                                        PointValue = t.PointValue,
                                        Description = t.Description,
                                        Story = t.Story
                                    }).ToList();

            return taskList;
        }

        public Thask GetTask(int id)
        {
            Thask task = (from t in _repo.Query<Thask>()
                          where t.id == id
                          select new Thask
                          {
                              id = t.id,
                              TaskName = t.TaskName,
                              Description = t.Description,
                              Story = 
                              (from r in _repo.Query<Requirement>()
                               where r.Id == t.Story.Id
                               select new Requirement
                               {
                                   Id = r.Id,
                                   RequirementName = r.RequirementName
                               }).FirstOrDefault()
                          }).FirstOrDefault();

            return task;
        }

        public void DeleteTask(int id)
        {
            Thask taskToBeDeleted = (from t in _repo.Query<Thask>()
                                     where t.id == id
                                     select t).FirstOrDefault();

            _repo.Delete(taskToBeDeleted);
        }

        public void AddTask(Thask task)
        {
            Requirement requirement = (from r in _repo.Query<Requirement>()
                                       where r.Id == task.Story.Id
                                       select r).FirstOrDefault();
            task.Story = requirement;

            _repo.Add(task);
        }

        public void UpdateTask(Thask task)
        {
            Requirement requirement = (from r in _repo.Query<Requirement>()
                                       where r.Id == task.Story.Id
                                       select r).FirstOrDefault();
            task.Story = requirement;

            _repo.Update(task);
        }
    }
}
