using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolyModTask.Models
{
    public class Job
    {
        public int JobId { get; set; }
        public List<Operation> Operations { get; set; }
        public int CurrentOpIndex { get; set; } = 0;
        public int CompletionTime { get; set; }

        public Job(int jobId, List<Operation> operations)
        {
            JobId = jobId;
            Operations = operations;
        }

        public bool IsCompleted => CurrentOpIndex >= Operations.Count;

        public Operation GetCurrentOperation()
        {
            return !IsCompleted ? Operations[CurrentOpIndex] : null;
        }

        public void Advance()
        {
            CurrentOpIndex++;
        }
    }
}
