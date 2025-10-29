// **Concepts:** Enums + File I/O + Collections + Exception Handling  
// - Use `TaskStatus` enum from Problem 31.  
// - Allow adding, removing, completing tasks.  
// - Save and load tasks from a `todo.txt` file.  
// 🧩 **Bonus:** Show summary grouped by task status.

using System.Text.Json;

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
    public TaskStatus Status { get; set; }

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


class ToDoList
{
    private const string SaveFile = "todo.txt";
    private List<Task> Tasks;

    private int nextTasksId = 1001;

    public ToDoList()
    {
        // Load from file else create new
        LoadFromFile();
    }

    public void AddTask(string title, TaskStatus status = TaskStatus.Pending)
    {
        Task newTask = new Task(nextTasksId, title, status);
        Tasks.Add(newTask);
        Console.WriteLine($"\nSUCCESS: Added Task ID: {nextTasksId}.");
        nextTasksId++; // Increment the counter immediately after use
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

        foreach (Task t in Tasks.OrderBy(t => t.Id))
        {
            // Using the overridden ToString method for clean output
            Console.WriteLine(t);
        }
        Console.WriteLine("---------------------------");
    }

    public void ShowTasksSummary()
    {
        Console.WriteLine("\nTasks Summary");

        if (Tasks.Count == 0)
        {
            Console.WriteLine("No tasks found.");
            return;
        }

        var summary = Tasks.GroupBy(t => t.Status)
                    .Select(g => new 
                    { 
                        Status = g.Key, 
                        Count = g.Count() 
                    })
                    .OrderByDescending(s => s.Count);

        foreach (var item in summary)
        {
            Console.WriteLine($"{item.Status,-12}: {item.Count}");
        }

        Console.WriteLine($"Total Tasks   : {Tasks.Count}");
                    
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

    public bool ChangeTaskStatus(int taskId, TaskStatus taskStatus)
    {
        int index = Tasks.FindIndex(t => t.Id == taskId);

        if (index == -1)
        {
            Console.WriteLine($"\nWARNING: Cannot change status. Task ID {taskId} not found.");
            return false;
        }

        Task oldTask = Tasks[index];

        Task updatedTask = oldTask with { Status = taskStatus };

        Tasks[index] = updatedTask;
        Console.WriteLine($"SUCCESS: Task ID {taskId} updated to {taskStatus}.");
        return true;


    }

    public void LoadFromFile()
    {
        if (!File.Exists(SaveFile))
        {
            try 
            {
                File.WriteAllText(SaveFile, "[]");
                Console.WriteLine($"\nNOTE: Created new empty to-do list file: {SaveFile}");
            }
            catch (Exception ex)
            {
                 Console.WriteLine($"\nERROR: Could not create file. {ex.Message}");
            }
            return;
        }

        try
        {
            string jsonStringFromFile = File.ReadAllText(SaveFile);


            if (string.IsNullOrWhiteSpace(jsonStringFromFile) || jsonStringFromFile.Trim() == "[]")
            {
                 Console.WriteLine($"Loaded file is empty. Starting with a blank list.");
                 Tasks = new List<Task>();
                 nextTasksId = 1001;
                 return;
            }


            List<Task>? loadedTasks = JsonSerializer.Deserialize<List<Task>>(jsonStringFromFile);

            if (loadedTasks != null)
            {
                Tasks = loadedTasks;
                nextTasksId = Tasks.Any() ? Tasks.Max(t => t.Id) + 1 : 1001;
                Console.WriteLine($"Loaded {Tasks.Count} records from {SaveFile}. Next ID: {nextTasksId}");
            }
            return;

        }
        catch (IOException ex)
        {
            Console.WriteLine($"\nERROR loading file: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nERROR loading file: {ex.Message}");
        }
        return;

    }

    public void SaveToFile()
    {
        try
        {
            string jsonTasks = JsonSerializer.Serialize(Tasks);

            // Console.WriteLine(jsonTasks);
            File.WriteAllText(SaveFile, jsonTasks);  
        }catch(Exception ex)
        {
            Console.WriteLine($"\nError: Someting Went Wrong while writing. Details: {ex.Message}");
        }
        Console.WriteLine("Write Complete");
    }
    

    public static void Main()
    {
        ToDoList toDoList = new ToDoList();

        // Use the simplified AddTask method
        toDoList.AddTask("Fix critical server bug", TaskStatus.InProgress);
        toDoList.AddTask("Review marketing documents", TaskStatus.Pending);
        toDoList.AddTask("Deploy new feature branch", TaskStatus.Completed);
        toDoList.AddTask("Write unit tests for UI", TaskStatus.InProgress);
        toDoList.AddTask("Schedule team meeting", TaskStatus.Pending);
        
        // This task will be assigned ID 1006
        toDoList.AddTask("Research new database technology"); 

        toDoList.ShowTasks();
        
        // Change Task 1001 to Completed
        toDoList.ChangeTaskStatus(1001, TaskStatus.Completed); 

        toDoList.ShowFilteredTasks(TaskStatus.InProgress);

        // Try to remove a non-existent task
        toDoList.RemoveTask(5555); 
        
        // Remove Task 1002 (Review marketing documents)
        toDoList.RemoveTask(1002);
        
        toDoList.ShowTasks();
        toDoList.ShowTasksSummary();

        // Save the current state (with the removed and updated tasks)
        toDoList.SaveToFile();
    }


}