using ConsoleApp.Factories;
using ConsoleApp.Models;

namespace ProductProvider.Tests.Factories;

public class ProductFactory_Tests
{
    private readonly ProductRequest _requestWithData = new ProductRequest
    {
        Title = "Test product",
        Description = "Test description",
        Price = 250
    };

    //Tagit hjälp av ChatGPT 4o
    [Fact]
    public void Create_ShouldReturnProduct_FromProductRequest()
    {
        var result = ProductFactory.Create(_requestWithData);

        Assert.IsType<Product>(result);
    }

    //Tagit hjälp av ChatGPT 4o
    [Fact]
    public void Create_ShouldMapProperties_FromProductRequestToProduct()
    {
        var result = ProductFactory.Create(_requestWithData);

        Assert.Equal(_requestWithData.Title, result.Title);
        Assert.Equal(_requestWithData.Description, result.Description);
        Assert.Equal(_requestWithData.Price, result.Price);
    }

    //Tagit hjälp av ChatGPT 4o
    [Fact]
    public void Create_ShouldReturnNull_WhenProductRequestIsInvalid()
    {
        ProductRequest nullRequest = null!;

        var result = ProductFactory.Create(nullRequest);

        Assert.Null(result);
    }
}
