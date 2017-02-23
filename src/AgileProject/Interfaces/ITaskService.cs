using System.Collections.Generic;
using AgileProject.Models;

namespace AgileProject.Services
{
    public interface ITaskService
    {
        void AddTask(Thask task);
        void DeleteTask(int id);
        Thask GetTask(int id);
        List<Thask> GetTaskList(int id);
        void UpdateTask(Thask task);
    }
}