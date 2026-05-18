using WinFormsApp1.Entities;

namespace WinFormsApp1.Drawings;

/// <summary>
/// Класс прорисовки Лайнера (продвинутый объект для варианта 25)
/// </summary>
public class DrawingLiner : DrawingShip
{
    private EntityLiner? _liner;

    public DrawingLiner(int speed, double weight, Color bodyColor, int deckCount, Color additionalColor)
        : base(110, 50)  // Те же размеры, что у обычного корабля
    {
        _entityShip = new EntityLiner(speed, weight, bodyColor, deckCount, additionalColor);
        _liner = _entityShip as EntityLiner;
    }

    public override void DrawTransport(Graphics g)
    {
        if (_liner is null || !_startPosX.HasValue || !_startPosY.HasValue)
            return;

        int x = _startPosX.Value;
        int y = _startPosY.Value;
        int deckCount = _liner.DeckCount;

        using Pen blackPen = new(Color.Black, 1.5f);

        // ===== 1. КОРПУС =====
        Point[] hullPoints = new Point[]
        {
            new Point(x + 20, y + 50),
            new Point(x + 0, y + 35),
            new Point(x + 105, y + 35),
            new Point(x + 85, y + 50)
        };

        using (SolidBrush hullBrush = new SolidBrush(_liner.BodyColor))
        {
            g.FillPolygon(hullBrush, hullPoints);
            g.DrawPolygon(blackPen, hullPoints);
        }

        // ===== 2. ПАЛУБЫ =====
        using Pen deckPen = new(Color.SandyBrown, 1.5f);
        g.DrawLine(deckPen, x + 3, y + 47, x + 103, y + 47);

        if (deckCount >= 2)
        {
            g.DrawLine(deckPen, x + 18, y + 42, x + 92, y + 42);
        }

        if (deckCount >= 3)
        {
            g.DrawLine(deckPen, x + 28, y + 37, x + 80, y + 37);
        }

        // ===== 3. БАССЕЙН =====
        Rectangle pool = new(x + 5, y + 38, 22, 12);
        using (SolidBrush poolBrush = new SolidBrush(_liner.AdditionalColor))
        {
            g.FillRectangle(poolBrush, pool);
            g.DrawRectangle(blackPen, pool);
        }

        // ===== 4. КАЮТЫ (двухэтажные) =====
        Rectangle cabinsLower = new(x + 30, y + 28, 45, 10);
        Rectangle cabinsUpper = new(x + 38, y + 22, 30, 8);

        using (SolidBrush cabinsBrush = new SolidBrush(Color.White))
        {
            g.FillRectangle(cabinsBrush, cabinsLower);
            g.DrawRectangle(blackPen, cabinsLower);
            g.FillRectangle(cabinsBrush, cabinsUpper);
            g.DrawRectangle(blackPen, cabinsUpper);
        }

        // Окна в каютах
        using SolidBrush windowBrush = new(Color.LightGray);
        for (int i = 0; i < 4; i++)
        {
            Rectangle cabinWindow = new(x + 35 + (i * 10), y + 31, 4, 4);
            g.FillRectangle(windowBrush, cabinWindow);
            g.DrawRectangle(blackPen, cabinWindow);
        }
        for (int i = 0; i < 3; i++)
        {
            Rectangle cabinWindow = new(x + 43 + (i * 9), y + 24, 3, 4);
            g.FillRectangle(windowBrush, cabinWindow);
            g.DrawRectangle(blackPen, cabinWindow);
        }

        // ===== 5. ДВЕ МАЧТЫ И ДВА ФЛАГА =====
        using Pen mastPen = new(Color.Brown, 2f);
        g.DrawLine(mastPen, x + 40, y + 22, x + 40, y + 0);

        Point[] flagPoints1 = new Point[]
        {
            new Point(x + 40, y + 2),
            new Point(x + 60, y + 5),
            new Point(x + 40, y + 8)
        };
        using (SolidBrush flagBrush1 = new SolidBrush(Color.Red))
        {
            g.FillPolygon(flagBrush1, flagPoints1);
        }

        // ===== 6. ИЛЛЮМИНАТОРЫ (6 штук) =====
        using SolidBrush illuminatorBrush = new(Color.Yellow);
        int[] xPositions = { 28, 45, 62, 79, 96 };
        foreach (int xOffset in xPositions)
        {
            Rectangle window = new(x + xOffset, y + 43, 3, 3);
            g.FillEllipse(illuminatorBrush, window);
            g.DrawEllipse(blackPen, window);
        }

        // ===== 7. ТРУБА =====
        Rectangle chimney = new(x + 60, y + 5, 12, 17);
        using (SolidBrush chimneyBrush = new SolidBrush(Color.DarkGray))
        {
            g.FillRectangle(chimneyBrush, chimney);
            g.DrawRectangle(blackPen, chimney);
        }
    }
}