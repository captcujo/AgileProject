using System.Collections.Generic;
using AgileProject.Models;

namespace AgileProject.Interfaces
{
    public interface IStatusService
    {
        void AddStatus(Status status);
        void DeleteStatus(int id);
        Status GetStatus(int id);
        List<Status> GetStatuses();
        void UpdateStatus(Status status);
    }
}