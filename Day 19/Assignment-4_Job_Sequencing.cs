using System;
using System.Linq;

class Job_Sequencing
{
    public class Job
    {
        public string Id { get; set; }  
        public int Profit { get; set; }
        public int Deadline { get; set; }
    }

    static void Main()
    {
        string[] jobIds = { "j1", "j2", "j3", "j4", "j5", "j6", "j7" };
        int[] profits = { 20, 25, 15, 40, 4, 10, 9 };
        int[] deadlines = { 2, 2, 1, 4, 3, 3, 4 };

        var jobs = jobIds.Select((id, index) => new Job
        {
            Id = id,
            Profit = profits[index],
            Deadline = deadlines[index]
        }).ToList();

        jobs = jobs.OrderByDescending(job => job.Profit).ToList();
        int maxDeadline = jobs.Max(job => job.Deadline);
        bool[] slots = new bool[maxDeadline]; 
        var result = new Job[maxDeadline];

        int jobCount = 0;
        int totalProfit = 0;
        foreach (var job in jobs)
        {
            for (int slot = Math.Min(maxDeadline, job.Deadline) - 1; slot >= 0; slot--)
            {
                if (!slots[slot])
                {
                    slots[slot] = true;
                    result[slot] = job;
                    totalProfit += job.Profit;

                    jobCount++;
                    break;
                }
            }
        }

        Console.WriteLine($"Number of jobs scheduled: {jobCount}");
        Console.WriteLine($"Maximum profit: {totalProfit}");

        Console.WriteLine("Scheduled jobs:");
        foreach (var job in result)
        {
            if (job != null)
            {
                Console.WriteLine($"Job {job.Id}: Profit = {job.Profit}, Deadline = {job.Deadline}");
                Console.WriteLine($"{job.Id}");

            }
        }
    }
}
