using WinFormsApp1.Drawings;

namespace WinFormsApp1.CollectionGenericObjects;

/// <summary>
/// Реализация компании - Пристань (вариант 25)
/// Направление: влево, вниз (справа налево, сверху вниз)
/// </summary>
public class Pier : AbstractCompany
{
    private readonly int _colsCount;
    private readonly int _rowsCount;

    public Pier(int pictureWidth, int pictureHeight, ICollectionGenericObjects<DrawingShip> collection)
        : base(pictureWidth, pictureHeight, 150, 80, collection)
    {
        _colsCount = (int)Math.Truncate((double)pictureWidth / _placeSizeWidth);
        _rowsCount = (int)Math.Truncate((double)pictureHeight / _placeSizeHeight);
    }

    protected override void DrawBackground(Graphics g)
    {
        g.Clear(Color.White);

        using Pen pen = new(Color.Black, 1);

        for (int i = 0; i <= _colsCount; i++)
        {
            g.DrawLine(pen, i * _placeSizeWidth, 0, i * _placeSizeWidth, _pictureHeight);
        }

        for (int i = 0; i <= _rowsCount; i++)
        {
            g.DrawLine(pen, 0, i * _placeSizeHeight, _pictureWidth, i * _placeSizeHeight);
        }
    }

    protected override void DrawObjects(Graphics g)
    {
        int maxItems = _colsCount * _rowsCount;

        for (int i = 0; i < maxItems; i++)
        {
            DrawingShip? ship = _collection.GetObject(i);
            if (ship is null)
                continue;

            int col = i % _colsCount;
            int row = i / _colsCount;

            // направление "влево" — инвертируем колонку
            int invertedCol = _colsCount - 1 - col;

            int x = invertedCol * _placeSizeWidth;
            int y = row * _placeSizeHeight;

            ship.SetPosition(x, y);
            ship.DrawTransport(g);
        }
    }

    /// <summary>
    /// Получение объекта из коллекции по позиции
    /// </summary>
    public DrawingShip? GetObjectAtPosition(int position)
    {
        return _collection.GetObject(position);
    }

    /// <summary>
    /// Добавление объекта в коллекцию (через перегруженный оператор)
    /// </summary>
    public bool AddShip(DrawingShip ship)
    {
        return this + ship;
    }

    /// <summary>
    /// Удаление объекта из коллекции (через перегруженный оператор)
    /// </summary>
    public bool RemoveShip(int position)
    {
        return this - position;
    }
}