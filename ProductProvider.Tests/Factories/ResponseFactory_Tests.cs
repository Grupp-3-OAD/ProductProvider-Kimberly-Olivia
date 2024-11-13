using ConsoleApp.Factories;
using ConsoleApp.Models;

namespace ProductProvider.Tests.Factories;

public class ResponseFactory_Tests
{
    [Fact]
    public void Success_ShouldReturnResponseWithTrueAndData()
    {
        var product = new Product();

        var result = ResponseFactory<Product>.Success(data: product);

        Assert.True(result.Success);
        Assert.IsType<Product>(result.Data);
    }


    [Fact]
    public void Failed_ShouldReturnResponseWithFalseAndStatusCode400()
    {
        var result = BaseResponseFactory.Failed();

        Assert.False(result.Success);
        Assert.Equal(400, result.StatusCode);

    }

    [Fact]
    public void NotFound_ShouldReturnResponseWithFalseAndStatusCode404()
    {
        var result = BaseResponseFactory.NotFound();

        Assert.False(result.Success);
        Assert.Equal(404, result.StatusCode);

    }
}


