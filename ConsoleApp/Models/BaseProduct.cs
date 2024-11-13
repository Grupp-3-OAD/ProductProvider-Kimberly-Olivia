namespace ConsoleApp.Models;

public abstract class BaseProduct 
{
    public string? ArticleNumber { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public decimal Price { get; set; }
}