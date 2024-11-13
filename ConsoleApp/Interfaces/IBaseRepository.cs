using ConsoleApp.Models;

namespace ConsoleApp.Interfaces;

public interface IBaseRepository<T>
{
    ResponseResult<T> Create(T entity);
    ResponseResult<IEnumerable<T>> GetAll();
    ResponseResult<T> GetOne(Func<T, bool> predicate);
    ResponseResult<T> UpdateOne(Func<T, bool> predicate, T updatedEntity);
    ResponseResult<T> DeleteOne(Func<T, bool> predicate);
}