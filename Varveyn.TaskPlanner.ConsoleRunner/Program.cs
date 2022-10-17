using Varveyn.TaskPlanner.Domain.Logic;
using Varveyn.TaskPlanner.Domain.Models;
using Varveyn.TaskPlanner.Domain.Models.Enums;

namespace Varveyn.TaskPlanner.ConsoleRunner;

internal static class Program
{
    public static void Main(string[] args)
    {
        var items = ReadWorkItems();

        var planner = new SimpleTaskPlanner();

        var orderedItems = planner.CreatePlan(items);

        PrintWorkPlan(orderedItems);
    }

    private static WorkItem[] ReadWorkItems()
    {
        var items = new List<WorkItem>();

        bool promptToEnterWorkItem = true;

        while (promptToEnterWorkItem)
        {
            var workItem = ReadWorkItem();

            items.Add(workItem);

            promptToEnterWorkItem = ReadPromptToEnterAnotherWorkItem();
        }

        return items.ToArray();
    }

    private static bool ReadPromptToEnterAnotherWorkItem()
    {
        Console.WriteLine("Do you want to enter another work item? Y/[N]");
        var response = Console.ReadLine();

        response = response?.ToUpper();

        return response == "Y";
    }

    private static WorkItem ReadWorkItem()
    {
        Console.WriteLine("Enter work item title:");
        string? title = Console.ReadLine();

        Console.WriteLine("Enter work item description:");
        string description = Console.ReadLine();

        Console.WriteLine("Enter work item priority:");
        string stringifiedPriority = Console.ReadLine();
        Priority priority = Enum.Parse<Priority>(stringifiedPriority, ignoreCase: true);
        
        Console.WriteLine("Enter work item complexity:");
        string stringifiedComplexity = Console.ReadLine();
        Complexity complexity = Enum.Parse<Complexity>(stringifiedComplexity, ignoreCase: true);

        Console.WriteLine("Enter work item due date:");
        string stringifiedDueDate = Console.ReadLine();
        DateTime dueDate = DateTime.Parse(stringifiedDueDate);

        return new WorkItem
        {
            Title = title,
            Description = description,
            Complexity = complexity,
            Priority = priority,
            DueDate = dueDate,
            CreationDate = DateTime.Now,
            IsCompleted = false,
        };
    }

    private static void PrintWorkPlan(WorkItem[] items)
    {
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }
}
