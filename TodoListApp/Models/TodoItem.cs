
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using TodoListApp.Data;

namespace TodoListApp.Models;

public class TodoItem
{
    public int Id { get; set; }

    [Required]
    public required string Title { get; set; }

    public bool IsCompleted { get; set; } = false;

    [Required]
    public required string UserId { get; set; } // Foreign key to the user
    
    // Navigation property
    public virtual required ApplicationUser User { get; set; }
}
