namespace WinFormsApp1.Drawings;

/// <summary>
/// Полотно для корабля
/// </summary>
public class CanvasForShip
{
    private DrawingShip? _drawningShip;
    private int? _canvasWidth;
    private int? _canvasHeight;

    public DrawingShip? DrawingShip => _drawningShip;

    public void SetPictureSize(int width, int height)
    {
        _canvasWidth = width;
        _canvasHeight = height;
    }

    public bool InsertShip(DrawingShip ship)
    {
        if (!_canvasWidth.HasValue || !_canvasHeight.HasValue)
            return false;

        if (ship.DrawingShipWidth > _canvasWidth.Value ||
            ship.DrawingShipHeight > _canvasHeight.Value)
            return false;

        _drawningShip = ship;
        return true;
    }

    public void SetShipPosition(int x, int y)
    {
        if (!_canvasWidth.HasValue || !_canvasHeight.HasValue || _drawningShip is null)
            return;

        int newX = x;
        int newY = y;
        int shipWidth = _drawningShip.DrawingShipWidth;
        int shipHeight = _drawningShip.DrawingShipHeight;

        if (newX < 0)
            newX = 0;
        else if (newX + shipWidth > _canvasWidth.Value)
            newX = _canvasWidth.Value - shipWidth;

        if (newY < 0)
            newY = 0;
        else if (newY + shipHeight > _canvasHeight.Value)
            newY = _canvasHeight.Value - shipHeight;

        _drawningShip.SetPosition(newX, newY);
    }

    public bool MoveTransport(DirectionType direction)
    {
        if (!_canvasWidth.HasValue || !_canvasHeight.HasValue || _drawningShip is null ||
            !_drawningShip.PosX.HasValue || !_drawningShip.PosY.HasValue ||
            !_drawningShip.ShipStep.HasValue)
        {
            return false;
        }

        int currentX = _drawningShip.PosX.Value;
        int currentY = _drawningShip.PosY.Value;
        int step = (int)_drawningShip.ShipStep.Value;
        int shipWidth = _drawningShip.DrawingShipWidth;
        int shipHeight = _drawningShip.DrawingShipHeight;

        switch (direction)
        {
            case DirectionType.Left:
                if (currentX - step >= 0)
                {
                    _drawningShip.MoveLeft();
                    return true;
                }
                break;
            case DirectionType.Up:
                if (currentY - step >= 0)
                {
                    _drawningShip.MoveUp();
                    return true;
                }
                break;
            case DirectionType.Right:
                if (currentX + step + shipWidth <= _canvasWidth.Value)
                {
                    _drawningShip.MoveRight();
                    return true;
                }
                break;
            case DirectionType.Down:
                if (currentY + step + shipHeight <= _canvasHeight.Value)
                {
                    _drawningShip.MoveDown();
                    return true;
                }
                break;
        }
        return false;
    }

    public Bitmap? DrawCanvas()
    {
        if (!_canvasWidth.HasValue || !_canvasHeight.HasValue)
            return null;

        Bitmap bmp = new(_canvasWidth.Value, _canvasHeight.Value);
        using (Graphics graphics = Graphics.FromImage(bmp))
        {
            graphics.Clear(Color.White);
            _drawningShip?.DrawTransport(graphics);
        }
        return bmp;
    }
}