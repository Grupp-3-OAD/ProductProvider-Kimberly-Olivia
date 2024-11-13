using ConsoleApp.Factories;
using ConsoleApp.Interfaces;
using ConsoleApp.Models;
using Moq;

namespace ProductProvider.Tests.Services;

public class ProductService_Tests
{
    private readonly Mock<IProductService> _mockProductService;
    private readonly IProductService _productService;
    private readonly Product _product;

    public ProductService_Tests()
    {
        _mockProductService = new Mock<IProductService>();
        _productService = _mockProductService.Object;

        _product = new Product
        {
            Id = "1",
            Title = "Test",
            Price = 100,
            Description = "Description",
            ArticleNumber = "123",
        };
    }
    [Fact]
    public void Create_ShouldReturnSuccess_WhenProductIsCreated()
    {
        var productRequest = new ProductRequest
        {
            Title = "Test Product",
            Price = 100,
            Description = "Test Description"
        };

        var product = new Product
        {
            Id = "1",
            Title = "Test Product",
            Price = 100,
            Description = "Test Description"
        };

        _mockProductService
            .Setup(service => service.Create(It.IsAny<ProductRequest>()))
            .Returns(ResponseFactory<Product>.Success(product));

        var result = _productService.Create(productRequest);

        Assert.True(result.Success);
        Assert.Equal("Test Product", result.Data?.Title);
        Assert.Equal(100, result.Data?.Price);
        Assert.Equal("Test Description", result.Data?.Description);
    }

    [Fact]
    public void GetAll_ShouldReturnSuccess_WhenProductsExists()
    {
        var products = new List<Product>
        {
            new Product
            {
                Id = "1",
                Title = "Sweater",
                Price = 100,
                Description = "Blue, Oversized",
            },
            new Product
            {
                Id = "2",
                Title = "Dress",
                Price = 250,
                Description = "Pink",
            }

        };
        var expectedResult = new ResponseResult<IEnumerable<Product>>
        {
            Success = true,
            StatusCode = 200,
            Data = products

        };
        _mockProductService.Setup(service => service.GetAll()).Returns(expectedResult);

        var result = _productService.GetAll();

        Assert.True(result.Success);
        Assert.Equal(200, result.StatusCode);
        Assert.Equal(products, result.Data);
    }

    [Fact]
    public void GetOne_ShouldReturnSuccess_WhenProductExists()
    {
        var products = new List<Product> { _product };

        var expectedResult = new ResponseResult<Product> { Success = true, StatusCode = 200, Data = _product };

        _mockProductService.Setup(x => x.GetOne(_product.Id)).Returns(expectedResult);

        var result = _productService.GetOne(_product.Id);

        Assert.True(result.Success);
        Assert.Equal(200, result.StatusCode);
        Assert.Equal(_product, result.Data);
    }
    [Fact]
    public void UpdateOne_ShouldReturnSuccess_WhenTheProductIsUpdated()
    {

        var updateProduct = new Product
        {
            Id = "001",
            Title = "Test Product",
            Price = 100,
            Description = "Test Description"
        };

        var expectedResult = new ResponseResult<Product>
        {
            Success = true,
            StatusCode = 200,
            Data = updateProduct
        };

        _mockProductService
            .Setup(x => x.UpdateOne(updateProduct.Id, updateProduct))
            .Returns(expectedResult);

        var result = _productService.UpdateOne(updateProduct.Id, updateProduct);

        Assert.True(result.Success);
        Assert.Equal(200, result.StatusCode);
        Assert.Equal(updateProduct, result.Data);
    }
}
