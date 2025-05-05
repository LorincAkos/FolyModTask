using FolyModTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolyModTask.Scheduler
{
    public class SimulationEngine
    {
        private List<Job> Jobs;
        private Dictionary<int, Resource> Resources;
        private int Time = 0;

        public SimulationEngine(List<Job> jobs, List<Resource> resources)
        {
            Jobs = jobs;
            Resources = resources.ToDictionary(r => r.ResourceId);
        }

        public void Run()
        {
            Console.WriteLine("Szimuláció elindult...\n");

            while (Jobs.Any(j => !j.IsCompleted))
            {
                // Buffer feltöltés
                foreach (Job job in Jobs)
                {
                    if (job.IsCompleted) continue;

                    Operation op = job.GetCurrentOperation();
                    Resource res = Resources[op.ResourceId];
                    if (!res.InputBuffer.IsFull && res.InputBuffer.Peek() != job)
                    {
                        res.InputBuffer.TryEnqueue(job);
                    }
                }

                // Művelet indítása a bufferből
                foreach (Resource res in Resources.Values)
                {
                    Job job = res.InputBuffer.Peek();
                    if (job == null || job.IsCompleted) continue;

                    Operation op = job.GetCurrentOperation();
                    if (Time >= res.AvailableTime && res.IsAvailableAt(Time))
                    {
                        Console.WriteLine($"Idő {Time}: Job#{job.JobId} - '{op.Name}' elindult a Resource#{res.ResourceId} erőforráson.");
                        res.AvailableTime = Time + op.Duration;
                        job.CompletionTime = res.AvailableTime;
                        job.Advance();
                        res.InputBuffer.Dequeue();
                    }
                }

                Time++;
            }


            Console.WriteLine("\nSzimuláció befejeződött!");
            foreach (Job job in Jobs)
            {
                Console.WriteLine($"Job#{job.JobId} befejeződött: {job.CompletionTime} időegységnél.");
            }
        }
    }
}
