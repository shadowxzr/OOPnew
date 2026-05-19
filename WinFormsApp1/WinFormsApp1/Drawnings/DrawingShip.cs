using WinFormsApp1.Entities;

namespace WinFormsApp1.Drawings;

public class DrawingShip
{
    protected EntityShip? _entityShip;
    protected int? _startPosX;
    protected int? _startPosY;
    protected int _drawningShipWidth = 110;
    protected int _drawningShipHeight = 50;

    public int? PosX => _startPosX;
    public int? PosY => _startPosY;
    public double? ShipStep => _entityShip?.Step;
    public int DrawingShipWidth => _drawningShipWidth;
    public int DrawingShipHeight => _drawningShipHeight;

    private DrawingShip()
    {
        _startPosX = null;
        _startPosY = null;
    }

    public DrawingShip(int speed, double weight, Color bodyColor, int deckCount) : this()
    {
        _entityShip = new EntityShip(speed, weight, bodyColor, deckCount);
    }

    protected DrawingShip(int width, int height) : this()
    {
        _drawningShipWidth = width;
        _drawningShipHeight = height;
    }

    public void SetPosition(int x, int y)
    {
        _startPosX = x;
        _startPosY = y;
    }

    public void MoveLeft()
    {
        if (_entityShip is null || !_startPosX.HasValue) return;
        _startPosX -= (int)_entityShip.Step;
    }

    public void MoveRight()
    {
        if (_entityShip is null || !_startPosX.HasValue) return;
        _startPosX += (int)_entityShip.Step;
    }

    public void MoveUp()
    {
        if (_entityShip is null || !_startPosY.HasValue) return;
        _startPosY -= (int)_entityShip.Step;
    }

    public void MoveDown()
    {
        if (_entityShip is null || !_startPosY.HasValue) return;
        _startPosY += (int)_entityShip.Step;
    }

    public virtual void DrawTransport(Graphics g)
    {
        if (_entityShip is null || !_startPosX.HasValue || !_startPosY.HasValue)
            return;

        int x = _startPosX.Value;
        int y = _startPosY.Value;
        int deckCount = _entityShip.DeckCount;

        using (Pen blackPen = new Pen(Color.Black, 1.5f))
        {
            Point[] hullPoints = new Point[]
            {
                new Point(x + 20, y + 50),
                new Point(x + 0, y + 35),
                new Point(x + 105, y + 35),
                new Point(x + 85, y + 50)
            };

            using (SolidBrush hullBrush = new SolidBrush(_entityShip.BodyColor))
            {
                g.FillPolygon(hullBrush, hullPoints);
                g.DrawPolygon(blackPen, hullPoints);
            }

            using (Pen deckPen = new Pen(Color.SandyBrown, 1.5f))
            {
                g.DrawLine(deckPen, x + 3, y + 47, x + 103, y + 47);

                if (deckCount >= 2)
                {
                    g.DrawLine(deckPen, x + 18, y + 42, x + 92, y + 42);
                }

                if (deckCount >= 3)
                {
                    g.DrawLine(deckPen, x + 28, y + 37, x + 80, y + 37);
                }
            }

            Rectangle pool = new Rectangle(x + 5, y + 38, 22, 12);
            using (SolidBrush poolBrush = new SolidBrush(Color.LightBlue))
            {
                g.FillRectangle(poolBrush, pool);
                g.DrawRectangle(blackPen, pool);
            }

            Rectangle cabins = new Rectangle(x + 30, y + 22, 45, 16);
            using (SolidBrush cabinsBrush = new SolidBrush(Color.White))
            {
                g.FillRectangle(cabinsBrush, cabins);
                g.DrawRectangle(blackPen, cabins);
            }

            using (SolidBrush windowBrush = new SolidBrush(Color.LightGray))
            {
                for (int i = 0; i < 4; i++)
                {
                    Rectangle cabinWindow = new Rectangle(x + 35 + (i * 10), y + 26, 5, 5);
                    g.FillRectangle(windowBrush, cabinWindow);
                    g.DrawRectangle(blackPen, cabinWindow);
                }
            }

            using (Pen mastPen = new Pen(Color.Brown, 2f))
            {
                g.DrawLine(mastPen, x + 50, y + 22, x + 50, y + 0);
            }

            Point[] flagPoints = new Point[]
            {
                new Point(x + 50, y + 2),
                new Point(x + 65, y + 5),
                new Point(x + 50, y + 8)
            };
            using (SolidBrush flagBrush = new SolidBrush(Color.Red))
            {
                g.FillPolygon(flagBrush, flagPoints);
            }

            using (SolidBrush illuminatorBrush = new SolidBrush(Color.Yellow))
            {
                int[] xPositions = { 28, 45, 62, 79 };
                foreach (int xOffset in xPositions)
                {
                    Rectangle window = new Rectangle(x + xOffset, y + 43, 4, 4);
                    g.FillEllipse(illuminatorBrush, window);
                    g.DrawEllipse(blackPen, window);
                }
            }
        }
    }
}