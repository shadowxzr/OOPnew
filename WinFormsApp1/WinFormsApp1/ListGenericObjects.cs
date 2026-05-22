namespace WinFormsApp1.CollectionGenericObjects;

/// <summary>
/// Параметризованный набор объектов на основе List<T>
/// </summary>
/// <typeparam name="T">Параметр: ограничение - ссылочный тип</typeparam>
public class ListGenericObjects<T> : ICollectionGenericObjects<T>
    where T : class
{
    private readonly List<T> _collection;
    private int _maxCount;

    public int CountObjects => _collection.Count;

    public int MaxCount
    {
        set
        {
            if (value > 0)
            {
                _maxCount = value;
            }
        }
    }

    public ListGenericObjects()
    {
        _collection = [];
    }

    public T? GetObject(int position)
    {
        if (position < 0 || position >= _collection.Count)
            return null;
        return _collection[position];
    }

    public bool InsertObject(T obj)
    {
        if (_collection.Count >= _maxCount)
            return false;
        _collection.Add(obj);
        return true;
    }

    public bool InsertObject(T obj, int position)
    {
        if (_collection.Count >= _maxCount)
            return false;
        if (position < 0 || position > _collection.Count)
            return false;
        _collection.Insert(position, obj);
        return true;
    }

    public bool RemoveObject(int position)
    {
        if (position < 0 || position >= _collection.Count)
            return false;
        _collection.RemoveAt(position);
        return true;
    }
}