using System;

namespace DailyOperationsDashboard.States
{
    // Simple demo showing State Pattern in action
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== State Pattern Demo ===\n");

            // Demo 1: Basic Project Lifecycle
            Console.WriteLine("Project Lifecycle:");
            Project project = new Project("New Website");
            Console.WriteLine($"State: {project.GetCurrentState()}\n");
            
            project.Submit();    // Draft → Submitted
            project.Approve();   // Submitted → Approved  
            project.Kickoff();   // Approved → Active
            project.Complete();  // Active → Completed
            project.Archive();   // Completed → Archived
            
            Console.WriteLine($"\nFinal: {project.GetCurrentState()}\n");

            // Demo 2: Task Lifecycle
            Console.WriteLine("Task Lifecycle:");
            Task task = new Task("Build Feature");
            Console.WriteLine($"State: {task.GetCurrentState()}\n");
            
            task.Assign("Alice");   // Pending → Assigned
            task.StartWork();       // Assigned → InProgress
            task.Complete();        // InProgress → Completed
            task.Verify();          // Completed → Verified
            
            Console.WriteLine($"\nFinal: {task.GetCurrentState()}");
        }
    }
}

