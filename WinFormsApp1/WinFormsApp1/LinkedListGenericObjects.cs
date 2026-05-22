namespace WinFormsApp1.CollectionGenericObjects;

/// <summary>
/// Параметризованный набор объектов на основе LinkedList<T>
/// </summary>
/// <typeparam name="T">Параметр: ограничение - ссылочный тип</typeparam>
public class LinkedListGenericObjects<T> : ICollectionGenericObjects<T>
    where T : class
{
    private readonly LinkedList<T> _collection;
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

    public LinkedListGenericObjects()
    {
        _collection = [];
    }

    public T? GetObject(int position)
    {
        if (position < 0 || position >= _collection.Count)
            return null;

        var current = _collection.First;
        for (int i = 0; i < position; i++)
            current = current?.Next;

        return current?.Value;
    }

    public bool InsertObject(T obj)
    {
        if (_collection.Count >= _maxCount)
            return false;
        _collection.AddLast(obj);
        return true;
    }

    public bool InsertObject(T obj, int position)
    {
        if (_collection.Count >= _maxCount)
            return false;
        if (position < 0 || position > _collection.Count)
            return false;

        if (position == 0)
        {
            _collection.AddFirst(obj);
            return true;
        }

        if (position == _collection.Count)
        {
            _collection.AddLast(obj);
            return true;
        }

        var current = _collection.First;
        for (int i = 0; i < position - 1; i++)
            current = current?.Next;

        if (current != null)
            _collection.AddAfter(current, obj);

        return true;
    }

    public bool RemoveObject(int position)
    {
        if (position < 0 || position >= _collection.Count)
            return false;

        var current = _collection.First;
        for (int i = 0; i < position; i++)
            current = current?.Next;

        if (current != null)
            _collection.Remove(current);

        return true;
    }
}