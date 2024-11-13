using ConsoleApp.Models;

namespace ConsoleApp.Factories;

public static class ProductFactory 
{
    public static Product Create(ProductRequest productRequest)
    {
        try
        {
            var product = new Product
            {
                Title = productRequest.Title,
                Description = productRequest.Description,
                Price = productRequest.Price
            };

            return product;
        }
        catch
        {
            return null!;
        }
    }
}
