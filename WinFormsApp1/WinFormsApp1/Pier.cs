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
        // белый фон
        g.Clear(Color.White);

        // черная сетка
        using Pen pen = new(Color.Black, 1);

        // вертикальные линии
        for (int i = 0; i <= _colsCount; i++)
        {
            g.DrawLine(pen, i * _placeSizeWidth, 0, i * _placeSizeWidth, _pictureHeight);
        }

        // горизонтальные линии
        for (int i = 0; i <= _rowsCount; i++)
        {
            g.DrawLine(pen, 0, i * _placeSizeHeight, _pictureWidth, i * _placeSizeHeight);
        }
    }

    protected override void DrawObjects(Graphics g)
    {
        // проходим по всем возможным позициям в сетке
        int maxItems = _colsCount * _rowsCount;

        for (int i = 0; i < maxItems; i++)
        {
            // получаем объект по индексу i (индекс в коллекции соответствует позиции в сетке)
            DrawingShip? ship = _collection.GetObject(i);
            if (ship is null)
                continue;

            // расчет позиции в сетке с направлением "влево, вниз"
            int col = i % _colsCount;
            int row = i / _colsCount;

            // влево: колонка инвертируется (справа налево)
            int invertedCol = _colsCount - 1 - col;

            int x = invertedCol * _placeSizeWidth;
            int y = row * _placeSizeHeight;

            // установка позиции и прорисовка корабля
            ship.SetPosition(x, y);
            ship.DrawTransport(g);
        }
    }
}