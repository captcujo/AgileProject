using System.Collections.Generic;
using AgileProject.Models;

namespace AgileProject.Interfaces
{
    public interface IRequirementStatusService
    {
        void AddRequirementStatus(RequirementStatus status);
        void DeleteRequirementStatus(int id);
        RequirementStatus GetRequirementStatus(int id);
        List<RequirementStatus> ListRequirementStatuses();
        void UpdateRequirementStatus(RequirementStatus status);
    }
}