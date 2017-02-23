using AgileProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgileProject.ViewModels
{
    public class ProjectWithSprints
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public List<Sprint> Sprints { get; set; }
    }
}
