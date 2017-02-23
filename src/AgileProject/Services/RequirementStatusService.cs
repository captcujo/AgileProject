using AgileProject.Interfaces;
using AgileProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgileProject.Services
{
    public class RequirementStatusService: IRequirementStatusService
    {
        private IGenericRespository _repo;

        public RequirementStatusService(IGenericRespository repo)
        {
            this._repo = repo;
        }


        public List<RequirementStatus> ListRequirementStatuses()
        {
            List<RequirementStatus> statusList = (from s in _repo.Query <RequirementStatus>()
                                                  select new RequirementStatus
                                                  {
                                                      Id = s.Id,
                                                      Condition = s.Condition,
                                                      Description = s.Description
                                                  }).ToList();
            return statusList;
        }


        public RequirementStatus GetRequirementStatus(int id)
        {
            RequirementStatus status = (from s in _repo.Query<RequirementStatus>()
                                        where s.Id == id
                                        select s).FirstOrDefault();
            return status;
        }


        public void AddRequirementStatus(RequirementStatus status)
        {
            _repo.Add(status);
        }
        public void UpdateRequirementStatus(RequirementStatus status)
        {
            _repo.Update(status);
        }

        public void DeleteRequirementStatus(int id)
        {
            RequirementStatus statusToBeDeleted = (from s in _repo.Query<RequirementStatus>()
                                                   where s.Id == id
                                                   select s).FirstOrDefault();
            _repo.Delete(statusToBeDeleted);

        }
    }
}
