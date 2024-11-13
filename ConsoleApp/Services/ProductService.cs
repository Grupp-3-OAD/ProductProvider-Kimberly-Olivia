using ConsoleApp.Factories;
using ConsoleApp.Interfaces;
using ConsoleApp.Models;

namespace ConsoleApp.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository<Product> _productRepository;

    public ProductService(IProductRepository<Product> productRepository)
    {
        _productRepository = productRepository;
    }
    public ResponseResult<Product> Create(ProductRequest productRequest)
    {
        try
        {
            var product = ProductFactory.Create(productRequest);
            var result = _productRepository.Create(product);

            if (result.Success)
            {
                return ResponseFactory<Product>.Success(result.Data!);
            }

            return ResponseFactory<Product>.NotFound(result.Data!);
        }
        catch
        {
            return ResponseFactory<Product>.NotFound(null!);
        }
       
    }

    public ResponseResult<IEnumerable<Product>> GetAll()
    {
        try
        {
            var result = _productRepository.GetAll();

            if (result.Success && result.Data != null && result.Data.Any())
            {
                return ResponseFactory<IEnumerable<Product>>.Success(result.Data);
            }

            return ResponseFactory<IEnumerable<Product>>.NotFound(null!);
        }
        catch
        {
            return ResponseFactory<IEnumerable<Product>>.Failed(null!);
        }
           
    }

    public ResponseResult<Product> GetOne(string productId)
    {
        try
        {
            var result = _productRepository.GetOne(x => x.Id == productId);

            if (result.Success && result.Data != null)
            {
                return ResponseFactory<Product>.Success(result.Data);
            }
            return ResponseFactory<Product>.NotFound(null!);
        }
        catch
        {
            return ResponseFactory<Product>.Failed(null!);
        }
    }

    public ResponseResult<Product> UpdateOne(string productId, Product updatedProduct)
    {
        try
        {
            var result = _productRepository.UpdateOne(x => x.Id == productId, updatedProduct);

            if (result.Success)
            {
                return ResponseFactory<Product>.Success(result.Data!);
            }

            return ResponseFactory<Product>.NotFound(null!);
        }
        catch 
        {
            return ResponseFactory<Product>.Failed(null!);
        }
    }

    public ResponseResult DeleteOne(string productId)
    {
        throw new NotImplementedException();
    }

}
