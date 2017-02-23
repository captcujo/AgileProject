using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgileProject.Models
{
    public class Requirement
    {
        public int Id { get; set; }
        public string RequirementName { get; set; }
        public string Description { get; set; }
        public string AcceptanceCriteria { get; set; }
        public RequirementStatus Status { get; set; }
        public Sprint Sprint { get; set; }
        public ICollection<Thask> Tasks { get; set; }
    }
}
