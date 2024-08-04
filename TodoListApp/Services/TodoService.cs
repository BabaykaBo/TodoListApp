using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TodoListApp.Data;
using TodoListApp.Models;

namespace TodoListApp.Services;

public class TodoService
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public TodoService(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public async Task<List<TodoItem>> GetUserTodoItemsAsync(string userId)
    {
        return await _context.TodoItems
            .Where(t => t.UserId == userId)
            .ToListAsync();
    }

    public async Task AddTodoItemAsync(TodoItem todoItem, string userId)
    {
        todoItem.UserId = userId; // Set the userId
        _context.TodoItems.Add(todoItem);
        await _context.SaveChangesAsync();
    }
}
