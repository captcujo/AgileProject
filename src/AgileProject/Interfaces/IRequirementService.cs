using System.Collections.Generic;
using AgileProject.Models;

namespace AgileProject.Interfaces
{
    public interface IRequirementService
    {
        void AddRequirement(Requirement req);
        void DeleteRequirement(int id);
        Requirement GetRequirement(int id);
        List<Requirement> GetRequirementList();
        List<Requirement> GetRequirementListByProduct(int id);
        void UpdateRequirement(Requirement req);
    }
}