using ConsoleApp.Models;

namespace ConsoleApp.Interfaces
{
    public interface IProductService
    {

        public ResponseResult<Product> Create(ProductRequest productRequest);
        public ResponseResult<IEnumerable<Product>> GetAll();
        public ResponseResult<Product> GetOne(string productId);
        public ResponseResult<Product> UpdateOne(string productId, Product updatedProduct);
        public ResponseResult DeleteOne(string productId);

    }
}