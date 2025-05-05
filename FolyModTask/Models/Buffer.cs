using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolyModTask.Models
{
    public class Buffer
    {
        public int Capacity { get; }
        private Queue<Job> queue = new();

        public Buffer(int capacity)
        {
            Capacity = capacity;
        }

        public bool IsFull => queue.Count >= Capacity;
        public bool IsEmpty => queue.Count == 0;

        public bool TryEnqueue(Job job)
        {
            if (IsFull) return false;
            queue.Enqueue(job);
            return true;
        }

        public Job Dequeue()
        {
            return IsEmpty ? null : queue.Dequeue();
        }

        public Job Peek()
        {
            return IsEmpty ? null : queue.Peek();
        }
    }
}
