using WinFormsApp1.Drawings;

namespace WinFormsApp1.CollectionGenericObjects;

/// <summary>
/// Абстракция компании, хранящий коллекцию кораблей
/// </summary>
public abstract class AbstractCompany
{
    /// <summary>
    /// Размер места (ширина)
    /// </summary>
    protected readonly int _placeSizeWidth;

    /// <summary>
    /// Размер места (высота)
    /// </summary>
    protected readonly int _placeSizeHeight;

    /// <summary>
    /// Ширина окна
    /// </summary>
    protected readonly int _pictureWidth;

    /// <summary>
    /// Высота окна
    /// </summary>
    protected readonly int _pictureHeight;

    /// <summary>
    /// Коллекция
    /// </summary>
    protected ICollectionGenericObjects<DrawingShip> _collection;

    /// <summary>
    /// Конструктор
    /// </summary>
    public AbstractCompany(int pictureWidth, int pictureHeight, int placeSizeWidth, int placeSizeHeight, ICollectionGenericObjects<DrawingShip> collection)
    {
        _pictureWidth = pictureWidth;
        _pictureHeight = pictureHeight;
        _placeSizeWidth = placeSizeWidth;
        _placeSizeHeight = placeSizeHeight;
        _collection = collection;
        _collection.MaxCount = CalcMaxCount();
    }

    /// <summary>
    /// Перегрузка оператора сложения для класса
    /// </summary>
    public static bool operator +(AbstractCompany company, DrawingShip ship) => company._collection.InsertObject(ship);

    /// <summary>
    /// Перегрузка оператора удаления для класса
    /// </summary>
    public static bool operator -(AbstractCompany company, int position) => company._collection.RemoveObject(position);

    /// <summary>
    /// Получение случайного объекта из коллекции
    /// </summary>
    public DrawingShip? GetRandomObject()
    {
        Random random = new();
        int maxCount = CalcMaxCount();
        DrawingShip? drawingShip = null;
        int counter = 10;
        while (drawingShip is null)
        {
            drawingShip = _collection.GetObject(random.Next(0, maxCount));
            counter--;
            if (counter == 0)
                break;
        }
        return drawingShip;
    }

    /// <summary>
    /// Вывод всей коллекции
    /// </summary>
    public Bitmap? Show()
    {
        Bitmap bitmap = new(_pictureWidth, _pictureHeight);
        Graphics graphics = Graphics.FromImage(bitmap);
        DrawBackground(graphics);
        DrawObjects(graphics);
        return bitmap;
    }

    /// <summary>
    /// Вывод заднего фона
    /// </summary>
    protected abstract void DrawBackground(Graphics g);

    /// <summary>
    /// Расстановка и прорисовка объектов
    /// </summary>
    protected abstract void DrawObjects(Graphics g);

    /// <summary>
    /// Вычисление максимального количества элементов, который можно разместить в окне
    /// </summary>
    private int CalcMaxCount() => (int)(Math.Truncate((double)_pictureWidth / _placeSizeWidth) * Math.Truncate((double)_pictureHeight / _placeSizeHeight));
}