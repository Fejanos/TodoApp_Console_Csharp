using System.Text.Json;
using TodoApp.Models;

namespace TodoApp.Data;

public class FileStorage
{
    private string filePath;

    public FileStorage(string filePath = "todos.json")
    {
        string baseDir = AppDomain.CurrentDomain.BaseDirectory; 
        this.filePath = Path.Combine(baseDir, filePath);
    }

    // Load tasks from file
    public List<TodoItem> Load()
    {
        if (!File.Exists(filePath))
        {
            //Console.WriteLine($"File not found: {filePath}");
            return new List<TodoItem>();
        }

        string json = File.ReadAllText(filePath);

        // Deserialize JSON into a list of TodoItem
        List<TodoItem>? todos = JsonSerializer.Deserialize<List<TodoItem>>(json);

        if (todos == null)
        {
            return new List<TodoItem>();
        }

        //Console.WriteLine($"Loaded {todos.Count} tasks from file.");
        return todos;
    }

    // Save tasks to file
    public void Save(List<TodoItem> todos)
    {
        string json = JsonSerializer.Serialize(todos, new JsonSerializerOptions
        {
            WriteIndented = true // makes JSON easier to read
        }
        );

        File.WriteAllText(filePath, json);
    }
}