using ConsoleApp.Models;

namespace ConsoleApp.Factories;

public abstract class BaseResponseFactory
{
    public static ResponseResult Success(int statusCode = 200, string? message = null!)
    {
        return new ResponseResult
        {
            Success = true,
            StatusCode = statusCode,
            Message = message 
        };
    }

    public static ResponseResult Failed(int statusCode = 400, string? message = null!)
    {
        return new ResponseResult
        {
            Success = false,
            StatusCode = statusCode,
            Message = message
        };
    }
    public static ResponseResult NotFound(int statusCode = 404, string? message = null!)
    {
        return new ResponseResult
        {
            Success = false,
            StatusCode = statusCode,
            Message = message
        };
    }

    public static ResponseResult AlreadyExists(int statusCode = 409, string? message = null!)
    {
        return new ResponseResult
        {
            Success = false,
            StatusCode = statusCode,
            Message = message
        };
    }
}
