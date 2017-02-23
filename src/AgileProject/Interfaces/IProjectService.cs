using System.Collections.Generic;
using AgileProject.Models;
using AgileProject.ViewModels;

namespace AgileProject.Interfaces
{
    public interface IProjectService
    {
        void AddProject(Project project);
        void DeleteProject(int id);
        List<Project> GetProjectList();
        ProjectWithSprints GetProjectWithSprints(int id);
        ProductSprintStories GetProductSprintStories(int id);
        void UpdateProject(Project project);
    }
}