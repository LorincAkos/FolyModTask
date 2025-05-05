using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolyModTask.Models
{
    public class Resource
    {
        public int ResourceId { get; set; }
        public int AvailableTime { get; set; } = 0;
        public Buffer InputBuffer { get; set; }
        public List<(int Start, int End)> Shifts { get; set; }

        public Resource(int id, int bufferCapacity = 2)
        {
            ResourceId = id;
            InputBuffer = new Buffer(bufferCapacity);
            Shifts = new List<(int, int)>();
        }

        public bool IsAvailableAt(int time)
        {
            return Shifts.Any(shift => shift.Start <= time && time < shift.End);
        }
    }
}
