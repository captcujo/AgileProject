using AgileProject.Interfaces;
using AgileProject.Models;
using AgileProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgileProject.Services
{
    public class ProjectService: IProjectService
    {
        private IGenericRespository _repo;

        public ProjectService(IGenericRespository repo)
        {
            this._repo = repo;
        }

        public List<Project> GetProjectList()
        {
            List<Project> projects = (from p in _repo.Query<Project>()
                                      select p).ToList();

            return projects;
        }

        public ProjectWithSprints GetProjectWithSprints(int id)
        {
            ProjectWithSprints projectSprints = (from p in _repo.Query<Project>()
                                                 where p.Id == id
                                                 select new ProjectWithSprints
                                                 {
                                                     Id = p.Id,
                                                     ProjectName = p.ProjectName,
                                                     Description = p.Description,
                                                     Sprints = (from s in _repo.Query<Sprint>()
                                                                where s.Project.Id == p.Id
                                                                select new Sprint
                                                                {
                                                                    Id = s.Id,
                                                                    SprintName = s.SprintName,
                                                                    Description = s.Description,
                                                                    Duration = s.Duration,
                                                                    Status = (from st in _repo.Query<Status>()
                                                                              where st.Id == s.Status.Id
                                                                              select st).FirstOrDefault(),
                                                                    Requirements = s.Requirements
                                                                }).ToList()
                                                 }).FirstOrDefault();
            return projectSprints;
        }

        public ProductSprintStories GetProductSprintStories(int id)
        {
            return (from p in _repo.Query<Project>()
                    where p.Id == id
                    select new ProductSprintStories
                    {
                        ProductId = p.Id,
                        ProductName = p.ProjectName,
                        Requirements = (from r in _repo.Query<Requirement>()
                                        where r.Sprint.Project.Id == p.Id
                                        select new Requirement
                                        {
                                            Id = r.Id,
                                            RequirementName = r.RequirementName,
                                            Sprint = (from s in _repo.Query<Sprint>()
                                                      select s).FirstOrDefault()
                                        }).ToList()
                    }).FirstOrDefault();
        }

        public void AddProject(Project project)
        {
            _repo.Add(project);
        }

        public void UpdateProject(Project project)
        { 
            _repo.Update(project);
        }

        public void DeleteProject(int id)
        {
            // Get the project:

            Project pro = (from p in _repo.Query<Project>()
                           where p.Id == id
                           select p).FirstOrDefault();

            // Get the project's sprints:

            List<Sprint> sprintsToBeDeleted = (from s in _repo.Query<Sprint>()
                                               where s.Project.Id == id
                                               select s).ToList();

            // Delete each sprint's requirements:

            foreach (Sprint sprint in sprintsToBeDeleted)
            {
                // Get a list of all the requirements (stories):
                List<Requirement> requirementsToBeDeleted = (from r in _repo.Query<Requirement>()
                                                             where r.Sprint.Id == sprint.Id
                                                             select r).ToList();
                
                // Delete each requirement's (story's) tasks and then the story:

                foreach (Requirement requirement in requirementsToBeDeleted)
                {
                    // Get a list of all the tasks:
                    List<Thask> tasksToBeDeleted = (from t in _repo.Query<Thask>()
                                                    where t.Story.Id == requirement.Id
                                                    select t).ToList();
                    
                    // loop through the tasks and delete them:
                    foreach (Thask task in tasksToBeDeleted)
                    {
                        _repo.Delete(task);
                    }
                    
                    // and then delete the requirement (story):

                    _repo.Delete(requirement);
                }
            }

            // Now delete the project's sprints:

            foreach(Sprint sprint in sprintsToBeDeleted)
            {
                _repo.Delete(sprint);
            }

            // And finally delete the project:

            _repo.Delete(pro);
        }
    }
}
