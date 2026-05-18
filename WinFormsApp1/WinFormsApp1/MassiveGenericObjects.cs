namespace WinFormsApp1.CollectionGenericObjects;

/// <summary>
/// Параметризованный набор объектов
/// </summary>
/// <typeparam name="T">Параметр: ограничение - ссылочный тип</typeparam>
public class MassiveGenericObjects<T> : ICollectionGenericObjects<T>
    where T : class
{
    private T?[] _collection = [];

    public int CountObjects
    {
        get
        {
            int count = 0;
            for (int i = 0; i < _collection.Length; i++)
            {
                if (_collection[i] is not null)
                    count++;
            }
            return count;
        }
    }

    public int MaxCount
    {
        set
        {
            if (value > 0)
                Array.Resize(ref _collection, value);
        }
    }

    public T? GetObject(int position)
    {
        // проверка, что позиция не выходит за границы массива
        if (position < 0 || position >= _collection.Length)
            return null;
        return _collection[position];
    }

    public bool InsertObject(T obj)
    {
        // вставка в начало коллекции
        return InsertObject(obj, 0);
    }

    public bool InsertObject(T obj, int position)
    {
        if (obj is null)
            return false;

        // проверка, что позиция не выходит за границы массива
        if (position < 0 || position >= _collection.Length)
            return false;

        // если место пустое, вставляем туда
        if (_collection[position] is null)
        {
            _collection[position] = obj;
            return true;
        }

        // ищем свободное место СПРАВА от позиции
        for (int i = position + 1; i < _collection.Length; i++)
        {
            if (_collection[i] is null)
            {
                _collection[i] = obj;
                return true;
            }
        }

        // ищем свободное место СЛЕВА от позиции
        for (int i = position - 1; i >= 0; i--)
        {
            if (_collection[i] is null)
            {
                _collection[i] = obj;
                return true;
            }
        }

        // нет свободных мест
        return false;
    }

    public bool RemoveObject(int position)
    {
        // проверка, что позиция не выходит за границы массива
        if (position < 0 || position >= _collection.Length)
            return false;

        // удаление объекта из массива, присвоив элементу значение null
        if (_collection[position] is not null)
        {
            _collection[position] = null;
            return true;
        }

        return false;
    }
}