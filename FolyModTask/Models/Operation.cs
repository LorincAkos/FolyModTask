using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolyModTask.Models
{
    public class Operation
    {
        public string Name { get; set; }
        public int Duration { get; set; }
        public int ResourceId { get; set; }

        public Operation(string name, int duration, int resourceId)
        {
            Name = name;
            Duration = duration;
            ResourceId = resourceId;
        }
    }
}
