using TodoApp.Models;

namespace TodoApp.Services;

public class TodoServices
{
    // List will hold all tasks in memory
    private List<TodoItem> todos = new List<TodoItem>();

    // Used to assign unique IDs to tasks
    private int nextId = 1;

    // Load existing tasks into memory
    public void Load(List<TodoItem> ts)
    {
        todos = ts;

        // If there are already tasks make sure next ID is set correctly
        if (todos.Count > 0)
        {
            int maxId = 0;
            foreach (var t in todos)
            {
                if (t.Id > maxId)
                {
                    maxId = t.Id;
                }
            }
            nextId = maxId + 1;
        }
    }

    // Get all tasks
    public List<TodoItem> GetAllTasks()
    {
        return todos;
    }

    // Add a new task
    public void Add(string title)
    {
        TodoItem newTask = new TodoItem()
        {
            Id = nextId,
            Title = title,
            IsCompleted = false
        };

        todos.Add(newTask);
        nextId++;

    }

    // Delete a task by id
    public bool Delete(int id)
    {
        TodoItem? delete = null;

        foreach (var t in todos)
        {
            if (t.Id == id)
            {
                delete = t;
                break;
            }
        }

        if (delete != null)
        {
            todos.Remove(delete);
            return true;
        }

        return false;
    }

    // Toggle completion status of a task
    public bool ToggleComplete(int id)
    {
        foreach (var t in todos)
        {
            if (t.Id == id)
            {
                t.IsCompleted = !t.IsCompleted;
                return true;
            }
        }
        
        return false;
    }
}