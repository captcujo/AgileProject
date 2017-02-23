    using AgileProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgileProject.ViewModels
{
    public class SprintWithRequirements
    {
        public int Id { get; set; }
        public string SprintName { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
        public Project Project { get; set; }
        public List<Requirement> Requirements { get; set; }
    }
}
