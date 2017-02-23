using AgileProject.Interfaces;
using AgileProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgileProject.Services
{
    public class SprintService: ISprintService
    {
        private IGenericRespository _repo;

        public SprintService(IGenericRespository repo)
        {
            this._repo = repo;
        }

        public List<Sprint> GetSprintList()
        {
            List<Sprint> sprints = (from s in _repo.Query <Sprint>()
                                    select new Sprint
                                    {
                                        Id = s.Id,
                                        SprintName = s.SprintName,
                                        Status = s.Status,
                                        Description = s.Description,
                                        Duration = s.Duration,
                                        Project = s.Project,
                                        Requirements = s.Requirements
                                    }).ToList();

            return sprints;
        }

        public Sprint GetSprint(int id)
        {
            Sprint sprint = (from s in _repo.Query<Sprint>()
                             where s.Id == id
                             select new Sprint
                             {
                                 Id = s.Id,
                                 SprintName = s.SprintName,
                                 Description = s.Description,
                                 Duration = s.Duration,
                                 Status = s.Status,
                                 Project = s.Project,
                                 Requirements = (from r in _repo.Query<Requirement>()
                                                 where r.Sprint.Id == s.Id
                                                 select new Requirement
                                                 {
                                                     Id = r.Id,
                                                     RequirementName = r.RequirementName,
                                                     Description = r.Description,
                                                     Status = r.Status
                                                 }).ToList()
                             }).FirstOrDefault();
            return sprint;
        }

        public void AddSprint(Sprint sprint)
        {
            Project project = (from p in _repo.Query<Project>()
                               where p.Id == sprint.Project.Id
                               select p).FirstOrDefault();
            sprint.Project = project;

            Status status = (from s in _repo.Query<Status>()
                             where s.Id == sprint.Status.Id
                             select s).FirstOrDefault();
            sprint.Status = status;

            _repo.Add(sprint);
        }

        public void UpdateSprint(Sprint sprint)
        { 
            Project project = (from p in _repo.Query<Project>()
                                where p.Id == sprint.Project.Id
                                select p).FirstOrDefault();
            sprint.Project = project;

            Status status = (from s in _repo.Query<Status>()
                                where s.Id == sprint.Status.Id
                                select s).FirstOrDefault();
            sprint.Status = status;

            _repo.Update(sprint);
        }

        public void DeleteSprint(int id)
        {
            Sprint sprintToBeDeleted = (from s in _repo.Query<Sprint>()
                                        where s.Id == id
                                        select s).FirstOrDefault();
            
            // get a list of all the sprint's requirements(stories):
            List<Requirement> requirementsToBeDeleted = (from r in _repo.Query<Requirement>()
                                                         where r.Sprint.Id == id
                                                         select r).ToList();

            // get a list of all the requirement's (storie's) tasks:
            List<Thask> tasksToBeDeleted = (from s in _repo.Query<Sprint>() 
                                            join r in _repo.Query<Requirement>() on s.Id equals r.Sprint.Id
                                            join t in _repo.Query<Thask>() on r.Id equals t.Story.Id
                                            where s.Id == id
                                            select new Thask
                                            {
                                                id = t.id,
                                                TaskName = t.TaskName,
                                                Description = t.Description,
                                                PointValue = t.PointValue
                                            }).ToList();
            
            // loop through the list of tasks and delete them:
            foreach (Thask task in tasksToBeDeleted)
            {
                _repo.Delete(task);
            }

            // loop through the list of requirements (stories) and delete them:
            foreach (Requirement requirement in requirementsToBeDeleted)
            {
                _repo.Delete(requirement);
            }

            // finally delete the sprint:
            _repo.Delete(sprintToBeDeleted);
        }
    }
}
