using ConsoleApp.Factories;
using ConsoleApp.Interfaces;
using ConsoleApp.Models;

namespace ConsoleApp.Data;

public abstract class BaseRepository<T> : IBaseRepository<T>
{
    private readonly List<T> _items = [];


    public virtual ResponseResult<T> Create(T entity)
    {
        _items.Add(entity);
        return ResponseFactory<T>.Success(entity);
    }

    public virtual ResponseResult<IEnumerable<T>> GetAll()
    {
        return ResponseFactory<IEnumerable<T>>.Success(_items);
    }

    public virtual ResponseResult<T> GetOne(Func<T, bool> predicate)
    {
        var entity = _items.FirstOrDefault(predicate);

        if (entity != null)
        {
            return ResponseFactory<T>.Success(entity);
        }

        return ResponseFactory<T>.NotFound(entity!);

    }
    public virtual ResponseResult<T> UpdateOne(Func<T, bool> predicate, T updatedEntity)
    {
        var existingEntityIndex = _items.FindIndex(new Predicate<T>(predicate));

        if (existingEntityIndex == -1)
        {
            return ResponseFactory<T>.NotFound(default!);
        }

        _items[existingEntityIndex] = updatedEntity;
        return ResponseFactory<T>.Success(updatedEntity);
    }

    public virtual ResponseResult<T> DeleteOne(Func<T, bool> predicate)
    {
        var entity = _items.FirstOrDefault(predicate);

        if (entity != null)
        {
            _items.Remove(entity);
            return ResponseFactory<T>.Success(entity);
        }

        return ResponseFactory<T>.NotFound(entity!);
    }
}
