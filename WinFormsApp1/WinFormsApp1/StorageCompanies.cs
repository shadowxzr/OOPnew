using WinFormsApp1.Drawings;

namespace WinFormsApp1.CollectionGenericObjects;

/// <summary>
/// Класс-хранилище компаний (Пристаней)
/// </summary>
public class StorageCompanies
{
    /// <summary>
    /// Словарь (хранилище) с компаниями
    /// </summary>
    private readonly Dictionary<string, AbstractCompany> _companies;

    /// <summary>
    /// Коллекция удалённых объектов (LinkedList для усложнённой части, вариант 25)
    /// </summary>
    private readonly LinkedList<object> _deletedObjects;

    /// <summary>
    /// Возвращение списка названий компаний
    /// </summary>
    public List<string> StorageKeys => [.. _companies.Keys];

    /// <summary>
    /// Количество удалённых объектов
    /// </summary>
    public int DeletedObjectsCount => _deletedObjects.Count;

    /// <summary>
    /// Получение коллекции удалённых объектов (только для чтения)
    /// </summary>
    public IEnumerable<object> DeletedObjects => _deletedObjects;

    /// <summary>
    /// Конструктор
    /// </summary>
    public StorageCompanies()
    {
        _companies = [];
        _deletedObjects = [];
    }

    /// <summary>
    /// Добавление компании в хранилище
    /// </summary>
    /// <param name="name">Название компании</param>
    /// <param name="collectionType">тип коллекции</param>
    /// <param name="pictureWidth">Ширина окна</param>
    /// <param name="pictureHeight">Высота окна</param>
    public void AddCompany(string name, CollectionType collectionType, int pictureWidth, int pictureHeight)
    {
        // проверяем, что в словаре нет записи с таким ключом
        if (_companies.ContainsKey(name))
        {
            MessageBox.Show($"Компания с именем \"{name}\" уже существует", "Предупреждение",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        // на основе типа коллекции создаём коллекцию нужного типа
        ICollectionGenericObjects<DrawingShip>? collection = null;

        switch (collectionType)
        {
            case CollectionType.Massive:
                collection = new MassiveGenericObjects<DrawingShip>();
                break;
            case CollectionType.List:
                collection = new ListGenericObjects<DrawingShip>();
                break;
            case CollectionType.LinkedList:
                collection = new LinkedListGenericObjects<DrawingShip>();
                break;
            default:
                return;
        }

        // устанавливаем максимальное количество элементов в коллекции
        // для Пристани: (ширина / 150) * (высота / 80)
        int maxCount = (int)(Math.Truncate((double)pictureWidth / 150) * Math.Truncate((double)pictureHeight / 80));
        collection.MaxCount = maxCount;

        // создаём компанию (Пристань) с выбранной коллекцией
        AbstractCompany company = new Pier(pictureWidth, pictureHeight, collection);

        // добавляем в словарь
        _companies.Add(name, company);
    }

    /// <summary>
    /// Удаление компании
    /// </summary>
    /// <param name="name">Название компании</param>
    public void DelCompany(string name)
    {
        if (string.IsNullOrEmpty(name)) return;
        if (_companies.ContainsKey(name))
            _companies.Remove(name);
    }

    /// <summary>
    /// Индексатор с 1 параметром (базовая часть)
    /// Доступ к компании по имени
    /// </summary>
    public AbstractCompany? this[string name]
    {
        get
        {
            if (string.IsNullOrEmpty(name)) return null;
            return _companies.GetValueOrDefault(name);
        }
    }

    /// <summary>
    /// Индексатор с 2 параметрами (усложнённая часть, вариант 25)
    /// Первый параметр - имя компании, второй - позиция объекта в коллекции
    /// </summary>
    public object? this[string companyName, int objectPosition]
    {
        get
        {
            var company = this[companyName];
            if (company is null) return null;

            if (company is Pier pier)
            {
                return pier.GetObjectAtPosition(objectPosition);
            }

            return null;
        }
    }

    /// <summary>
    /// Добавление удалённого объекта в коллекцию LinkedList (усложнённая часть)
    /// </summary>
    public void AddDeletedObject(object obj)
    {
        _deletedObjects.AddLast(obj);
    }

    /// <summary>
    /// Получение удалённого объекта по индексу
    /// </summary>
    public object? GetDeletedObject(int index)
    {
        if (index < 0 || index >= _deletedObjects.Count)
            return null;

        var current = _deletedObjects.First;
        for (int i = 0; i < index; i++)
            current = current?.Next;

        return current?.Value;
    }
}