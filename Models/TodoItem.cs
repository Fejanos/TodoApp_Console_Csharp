namespace TodoApp.Models;

public class TodoItem
{
    // Tasks' id
    public int Id { get; set; }

    // Title or Description
    public string Title { get; set; } = string.Empty;

    // Marks: completed or not
    public bool IsCompleted { get; set; }
    
}