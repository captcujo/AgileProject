using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgileProject.Models
{
    public class Thask
    {
        public int id { get; set; }
        public string TaskName { get; set; }
        public int PointValue { get; set; }
        public string Description { get; set; }
        public Requirement Story { get; set; }
    }
}
