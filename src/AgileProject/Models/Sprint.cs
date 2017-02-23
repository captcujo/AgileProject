using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgileProject.Models
{
    public class Sprint
    {
        public int Id { get; set; }
        public string SprintName { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }
        public Status Status { get; set; }
        public Project Project { get; set; }
        public ICollection<Requirement> Requirements { get; set; }

    }
}
