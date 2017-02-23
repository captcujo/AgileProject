using System.Collections.Generic;
using AgileProject.Models;

namespace AgileProject.Interfaces
{
    public interface ISprintService
    {
        void AddSprint(Sprint sprint);
        void DeleteSprint(int id);
        Sprint GetSprint(int id);
        List<Sprint> GetSprintList();
        void UpdateSprint(Sprint sprint);
    }
}