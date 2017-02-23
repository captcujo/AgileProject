using AgileProject.Interfaces;
using AgileProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgileProject.Services
{
    public class StatusService: IStatusService
    {
        private IGenericRespository _repo;

        public StatusService(IGenericRespository repo)
        {
            this._repo = repo;
        }


        public List<Status> GetStatuses()
        {
            List<Status> statusList = (from s in _repo.Query<Status>()
                                       select new Status
                                       {
                                           Id = s.Id,
                                           Condition = s.Condition,
                                           Description = s.Description
                                       }).ToList();
            return statusList;
        }


        public Status GetStatus(int id)
        {
            Status status = (from s in _repo.Query<Status>()
                             where s.Id == id
                             select new Status
                             {
                                 Id = s.Id,
                                 Condition = s.Condition,
                                 Description = s.Description
                             }).FirstOrDefault();
            return status;
        }


        public void AddStatus(Status status)
        {
            _repo.Add(status);
        }

        public void UpdateStatus(Status status)
        { 
            _repo.Update(status);
        }

        public void DeleteStatus(int id)
        {
            Status statusToBeDeleted = (from s in _repo.Query<Status>()
                                        where s.Id == id
                                        select s).FirstOrDefault();
            _repo.Delete(statusToBeDeleted);
        }
    }
}
