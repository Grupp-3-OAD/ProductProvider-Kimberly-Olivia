
using ConsoleApp.Interfaces;

namespace ConsoleApp.Data;

public class ProductRepository<T> : BaseRepository<T>, IProductRepository<T>
{

}
