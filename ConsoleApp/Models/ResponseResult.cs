namespace ConsoleApp.Models;

public class ResponseResult : BaseResponseResult
{
   
}

public class ResponseResult<T> : BaseResponseResult
{
    public T? Data { get; set; }
}



