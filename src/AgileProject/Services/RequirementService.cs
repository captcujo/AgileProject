using AgileProject.Interfaces;
using AgileProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgileProject.Services
{
    public class RequirementService: IRequirementService
    {
        private IGenericRespository _repo;

        public RequirementService(IGenericRespository repo)
        {
            this._repo = repo;
        }

        public List<Requirement> GetRequirementList()
        {
            List<Requirement> requirements = (from r in _repo.Query<Requirement>()
                                              select new Requirement
                                              {
                                                  Id = r.Id,
                                                  RequirementName = r.RequirementName,
                                                  Description = r.Description,
                                                  AcceptanceCriteria = r.AcceptanceCriteria,
                                                  Status = r.Status,
                                                  Sprint = r.Sprint
                                              }).ToList();
            return requirements;
        }

        public List<Requirement> GetRequirementListByProduct(int id)
        {
            List<Requirement> requirements = (from p in _repo.Query<Project>()
                                              join s in _repo.Query<Sprint>() on p.Id equals s.Project.Id 
                                              join r in _repo.Query<Requirement>() on s.Id equals r.Sprint.Id
                                              where p.Id == id
                                              select new Requirement
                                              {
                                                  Id = r.Id,
                                                  RequirementName = r.RequirementName,
                                                  Description = r.Description,
                                                  AcceptanceCriteria = r.AcceptanceCriteria,
                                                  Status = r.Status,
                                                  Sprint = r.Sprint
                                              }).ToList();
            return requirements;
        }

        public Requirement GetRequirement(int id)
        {
            Requirement requirement = (from r in _repo.Query<Requirement>()
                                       where r.Id == id
                                       select new Requirement
                                       {
                                           Id = r.Id,
                                           RequirementName = r.RequirementName,
                                           Description = r.Description,
                                           AcceptanceCriteria = r.AcceptanceCriteria,
                                           Status = (from s in _repo.Query<RequirementStatus>()
                                                     where s.Id == r.Status.Id
                                                     select s).FirstOrDefault(),
                                           Sprint = r.Sprint
                                       }).FirstOrDefault();
            return requirement;
        }

        public void AddRequirement(Requirement req)
        {

            Sprint sprint = (from s in _repo.Query<Sprint>()
                             where s.Id == req.Sprint.Id
                             select s).FirstOrDefault();
            req.Sprint = sprint;

            RequirementStatus reqStatus = (from rs in _repo.Query<RequirementStatus>()
                                           where rs.Id == req.Status.Id
                                           select rs).FirstOrDefault();
            req.Status = reqStatus;

            _repo.Add(req);
        }

        public void UpdateRequirement(Requirement req)
        {
            Sprint sprint = (from s in _repo.Query<Sprint>()
                                where s.Id == req.Sprint.Id
                                select s).FirstOrDefault();
            req.Sprint = sprint;

            RequirementStatus reqStatus = (from rs in _repo.Query<RequirementStatus>()
                                            where rs.Id == req.Status.Id
                                            select rs).FirstOrDefault();

            req.Status = reqStatus;

            _repo.Update(req);
        }

        public void DeleteRequirement(int id)
        {
            Requirement requirementToBeDeleted = (from r in _repo.Query<Requirement>()
                                                  where r.Id == id
                                                  select r).FirstOrDefault();

            List<Thask> tasksToBeDeleted = (from t in _repo.Query<Thask>()
                                      where t.Story.Id == id
                                      select t).ToList();

            foreach (Thask task in tasksToBeDeleted)
            {
                _repo.Delete(task);
            }

            _repo.Delete(requirementToBeDeleted);
        }
    }
}
