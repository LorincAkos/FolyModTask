using FolyModTask.Models;
using FolyModTask.Scheduler;

namespace FolyModTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Resource> resources = new List<Resource>
        {
            new Resource(1, 2),
            new Resource(2, 2),
            new Resource(3, 2)
        };

            resources[0].Shifts.Add((0, 10));
            resources[0].Shifts.Add((15, 25));
            resources[1].Shifts.Add((5, 20));
            resources[2].Shifts.Add((0, 30));

            List<Job> jobs = new List<Job>
        {
            new Job(1, new List<Operation>
            {
                new Operation("Fúrás", 3, 1),
                new Operation("Csiszolás", 2, 2),
                new Operation("Festés", 1, 3)
            }),
            new Job(2, new List<Operation>
            {
                new Operation("Csiszolás", 2, 2),
                new Operation("Fúrás", 3, 1),
                new Operation("Festés", 2, 3)
            }),
             new Job(3, new List<Operation>
            {
                new Operation("Fúrás", 3, 1),
                new Operation("Csiszolás", 2, 2),
                new Operation("Festés", 2, 3)
            }),
              new Job(4, new List<Operation>
            {
                new Operation("Csiszolás", 2, 2),
                new Operation("Fúrás", 3, 1),
                new Operation("Festés", 2, 3)
            }),
               new Job(5, new List<Operation>
            {
                new Operation("Fúrás", 3, 1),
                new Operation("Csiszolás", 2, 2),
                new Operation("Festés", 2, 3)
            }),
              new Job(6, new List<Operation>
            {
                new Operation("Csiszolás", 2, 2),
                new Operation("Fúrás", 3, 1),
                new Operation("Festés", 2, 3)
            }),
        };

            SimulationEngine engine = new SimulationEngine(jobs, resources);
            engine.Run();
        }
    }
}
