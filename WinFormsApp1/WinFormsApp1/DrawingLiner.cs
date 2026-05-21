using WinFormsApp1.Entities;

namespace WinFormsApp1.Drawings;

public class DrawingLiner : DrawingShip
{
    private EntityLiner? _liner;

    public DrawingLiner(int speed, double weight, Color bodyColor, int deckCount, Color additionalColor)
        : base(110, 50)
    {
        _entityShip = new EntityLiner(speed, weight, bodyColor, deckCount, additionalColor);
        _liner = _entityShip as EntityLiner;
    }

    public override void DrawTransport(Graphics g)
    {
        base.DrawTransport(g);

        if (_liner is null || !_startPosX.HasValue || !_startPosY.HasValue)
        {
            return;
        }

        int x = _startPosX.Value;
        int y = _startPosY.Value;
        int deckCount = _liner.DeckCount;

        using (Pen blackPen = new Pen(Color.Black, 1.5f))
        {
            Rectangle pool = new Rectangle(x + 5, y + 38, 22, 12);
            using (SolidBrush poolBrush = new SolidBrush(Color.LightBlue))
            {
                g.FillRectangle(poolBrush, pool);
                g.DrawRectangle(blackPen, pool);
            }

            Rectangle chimney = new Rectangle(x + 75, y + 5, 14, 18);
            using (SolidBrush chimneyBrush = new SolidBrush(_liner.AdditionalColor))
            {
                g.FillRectangle(chimneyBrush, chimney);
                g.DrawRectangle(blackPen, chimney);
            }
        }
    }
}