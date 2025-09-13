using TodoApp.Models;
using TodoApp.Services;
using TodoApp.Data;
using System.Xml.Linq;

// Create storage and service objects
FileStorage storage = new FileStorage();
TodoServices service = new TodoServices();

// Load existing tasks from file
List<TodoItem> loadedTodos = storage.Load();
service.Load(loadedTodos);

while (true)
{
    Console.Clear();
    Console.WriteLine("=== TODO LIST APP ===");
    Console.WriteLine("1. Add task");
    Console.WriteLine("2. Show tasks");
    Console.WriteLine("3. Delete task");
    Console.WriteLine("4. Toggle complete");
    Console.WriteLine("5. Save and Exit");
    Console.Write("\nChoose an option: ");

    string? choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            AddTask(service);
            break;
        case "2":
            ShowTasks(service);
            break;
        case "3":
            DeleteTask(service);
            break;
        case "4":
            StatusChange(service);
            break;
        case "5":
            storage.Save(service.GetAllTasks());
            break;
        default:
            Console.WriteLine("Invalid choice.");
            Console.ReadKey();
            break;
    }
}



static void AddTask(TodoServices service)
{
    Console.Write("Enter task title: ");
    string? title = Console.ReadLine();

    if (!string.IsNullOrWhiteSpace(title))
    {
        service.Add(title);
        Console.WriteLine("Task added!");
    }
    else
    {
        Console.WriteLine("Title cannot be empty.");
    }
    Console.ReadKey();
}

static void ShowTasks(TodoServices service)
{
    List<TodoItem> todos = service.GetAllTasks();

    if (todos.Count == 0)
    {
        Console.WriteLine("No tasks yet.");
    }
    else
    {
        // Print table header
        Console.WriteLine("-------------------------------------------------");
        Console.WriteLine($"{"ID",-5} {"Status",-10} {"Title",-30}");
        Console.WriteLine("-------------------------------------------------");

        // Print each todo in formatted columns
        foreach (var todo in todos)
        {
            string status = todo.IsCompleted ? "[X]" : "[ ]";
            Console.WriteLine($"{todo.Id,-5} {status,-10} {todo.Title,-30}");
        }

        Console.WriteLine("-------------------------------------------------");
    }

    Console.ReadKey();
}

static void DeleteTask(TodoServices service)
{
    Console.Write("Enter ID to delete: ");
    string? input = Console.ReadLine();

    int id;
    if (int.TryParse(input, out id))
    {
        if (service.Delete(id))
        {
            Console.WriteLine("Task deleted.");
        }
        else
        {
            Console.WriteLine("Task not found.");
        }
    }
    else
    {
        Console.WriteLine("Invalid ID.");
    }

    Console.ReadKey();
}

static void StatusChange(TodoServices service)
{
    Console.Write("Enter ID to toggle: ");
    string? input = Console.ReadLine();

    int id;
    if (int.TryParse(input, out id))
    {
        if (service.ToggleComplete(id))
        {
            Console.WriteLine("Status changed.");
        }
        else
        {
            Console.WriteLine("Task not found.");
        }
    }
    else
    {
        Console.WriteLine("Invalid ID.");
    }

    Console.ReadKey();
}