namespace ToDoAPI.Models;

public class Assignment
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public DateTime? Date { get; set; }
    public bool IsDone { get; set; }
}