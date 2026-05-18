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
                    _drawningShip.MoveLeft();
                else if (currentX > 0)
                    _drawningShip.SetPosition(0, currentY);
                else
                    return false;
                return true;

            case DirectionType.Up:
                if (currentY - step >= 0)
                    _drawningShip.MoveUp();
                else if (currentY > 0)
                    _drawningShip.SetPosition(currentX, 0);
                else
                    return false;
                return true;

            case DirectionType.Right:
                int maxRight = _canvasWidth.Value - shipWidth;
                if (currentX + step <= maxRight)
                    _drawningShip.MoveRight();
                else if (currentX < maxRight)
                    _drawningShip.SetPosition(maxRight, currentY);
                else
                    return false;
                return true;

            case DirectionType.Down:
                int maxDown = _canvasHeight.Value - shipHeight;
                if (currentY + step <= maxDown)
                    _drawningShip.MoveDown();
                else if (currentY < maxDown)
                    _drawningShip.SetPosition(currentX, maxDown);
                else
                    return false;
                return true;
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