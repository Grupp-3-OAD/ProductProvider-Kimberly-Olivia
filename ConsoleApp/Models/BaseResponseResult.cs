namespace ConsoleApp.Models;

public class BaseResponseResult
{
    public bool Success { get; set; }
    public int StatusCode { get; set; }
    public string? Message { get; set; }
}


