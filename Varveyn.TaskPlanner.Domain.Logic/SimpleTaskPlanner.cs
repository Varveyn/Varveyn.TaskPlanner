using Varveyn.TaskPlanner.Domain.Models;

namespace Varveyn.TaskPlanner.Domain.Logic;

public class SimpleTaskPlanner
{
    public WorkItem[] CreatePlan(WorkItem[] items)
    {
        var listOfItems = items.ToList();

        listOfItems.Sort(CompareWorkItems);

        return listOfItems.ToArray();
    }

    private static int CompareWorkItems(WorkItem firstItem, WorkItem secondItem)
    {
        int comparisonResult;
        
        comparisonResult = secondItem.Priority
            .CompareTo(firstItem.Priority);

        if (comparisonResult != 0)
        {
            return comparisonResult;
        }

        comparisonResult = firstItem.DueDate
            .CompareTo(secondItem.DueDate);

        if (comparisonResult != 0)
        {
            return comparisonResult;
        }

        return firstItem.Title
            .CompareTo(secondItem.Title);
    }
}
