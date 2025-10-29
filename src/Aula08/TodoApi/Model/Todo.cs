using System.ComponentModel.DataAnnotations;

namespace TodoApi.Model;

public class Todo
{
    public int Id { get; set; }

    [Required]
    [MinLength(10)]
    public string? Name { get; set; }
    public bool IsComplete { get; set; }
    public string? Secret { get; set; }
}