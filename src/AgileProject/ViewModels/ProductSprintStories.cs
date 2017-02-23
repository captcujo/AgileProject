using AgileProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgileProject.ViewModels
{
    public class ProductSprintStories
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public List<Requirement> Requirements { get; set; }
    }
}
