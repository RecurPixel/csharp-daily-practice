// **Concepts:** Enums, Structs  
// - Define a `TaskStatus` enum → `Pending`, `InProgress`, `Completed`.  
// - Create a `Task` struct → `Id`, `Title`, `Status`.  
// - Store tasks in a `List<Task>` and print formatted output.  
// 🧩 **Bonus:** Filter tasks by `Status` using simple loops.


enum TaskStatus
{
    Pending,
    InProgress,
    Completed
}

struct Task
{
    public int Id { get; init; }
    public string Title { get; init; }
    public TaskStatus Status { get; init; }

    public Task(int id, string title, TaskStatus status)
    {
        this.Id = id;
        this.Title = title;
        this.Status = status;

    }
    
    public override string ToString()
    {
        return $"[ID: {Id}] - {Title,-30} | Status: {Status}";
    }
}

class TaskManager
{

    private readonly List<Task> Tasks;

    public TaskManager()
    {
        Tasks = new List<Task>();
    }

    public void AddTask(Task task)
    {
        Tasks.Add(task);
        Console.WriteLine($"Successfully added Task ID: {task.Id}");
    }

    public void RemoveTask(int taskId)
    {
        int removedCount = Tasks.RemoveAll(t => t.Id == taskId);
        
        if (removedCount > 0)
        {
            Console.WriteLine($"\nSuccessfully removed {removedCount} Task(s) with ID: {taskId}");
        }
        else
        {
            Console.WriteLine($"\nNo task found with ID: {taskId}.");
        }
    }

    public void ShowTasks()
    {
        Console.WriteLine("\nAvailable Tasks");

        if (Tasks.Count == 0)
        {
            Console.WriteLine("No tasks found.");
            return;
        }

        foreach (Task t in Tasks)
        {
            // Using the overridden ToString method for clean output
            Console.WriteLine(t);
        }
        Console.WriteLine("---------------------------");
    }

    public void ShowFilteredTasks(TaskStatus status)
    {
        Console.WriteLine($"\nAvailable {status} Tasks");

        List<Task> tasks = Tasks.Where(t => t.Status == status).ToList();
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks found.");
            return;
        }

        foreach (Task t in tasks)
        {
            // Using the overridden ToString method for clean output
            Console.WriteLine(t);
        }
        Console.WriteLine("---------------------------");
    }
    
    public static void Main(string[] args)
    {
        TaskManager ts = new TaskManager();
        
        ts.AddTask(new Task(1, "Fix critical server bug", TaskStatus.InProgress));
        ts.AddTask(new Task(2, "Review marketing documents", TaskStatus.Pending));
        ts.AddTask(new Task(3, "Deploy new feature branch", TaskStatus.Completed));
        ts.AddTask(new Task(4, "Write unit tests for UI", TaskStatus.InProgress));
        ts.AddTask(new Task(5, "Schedule team meeting", TaskStatus.Pending));

        ts.ShowTasks();
        ts.ShowFilteredTasks(TaskStatus.InProgress);
        ts.ShowFilteredTasks(TaskStatus.Completed);

        ts.RemoveTask(1);
        ts.ShowTasks();


        string input = "InProgress";
        TaskStatus testEnumParse = (TaskStatus)Enum.Parse(typeof(TaskStatus), input);

        Console.WriteLine("Parsed enum status = {0}", testEnumParse);

    }
}