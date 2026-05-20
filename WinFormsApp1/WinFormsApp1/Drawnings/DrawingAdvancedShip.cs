using WinFormsApp1.Entities;

namespace WinFormsApp1.Drawings;

/// <summary>
/// Класс прорисовки линкора (продвинутый объект)
/// </summary>
public class DrawingBattleship : DrawingShip
{
	private EntityBattleship? _battleship;

	/// <summary>
	/// Конструктор линкора (оба признака всегда true)
	/// </summary>
	public DrawingBattleship(int speed, double weight, Color bodyColor, int deckCount, Color additionalColor)
		: base(110, 50)  
	{
		_entityShip = new EntityBattleship(speed, weight, bodyColor, deckCount, additionalColor);
		_battleship = _entityShip as EntityBattleship;
	}

	/// <summary>
	/// Переопределенный метод прорисовки
	/// </summary>
	public override void DrawTransport(Graphics g)
	{
		base.DrawTransport(g);

		if (_battleship is null || !_startPosX.HasValue || !_startPosY.HasValue)
		{
			return;
		}

		int x = _startPosX.Value;
		int y = _startPosY.Value;
		int deckCount = _battleship.DeckCount;

		using (Pen blackPen = new Pen(Color.Black, 1.5f))
		{
			// ===== 3. БАССЕЙН 
			Rectangle pool = new Rectangle(x + 5, y + 38, 22, 12);
			using (SolidBrush poolBrush = new SolidBrush(Color.LightBlue))
			{
				g.FillRectangle(poolBrush, pool);
				g.DrawRectangle(blackPen, pool);
			}

			// ===== 7. ДЫМОХОД (с использованием AdditionalColor) =====
			Rectangle chimney = new Rectangle(x + 75, y + 5, 14, 18);
			using (SolidBrush chimneyBrush = new SolidBrush(_battleship.AdditionalColor))
			{
				g.FillRectangle(chimneyBrush, chimney);
				g.DrawRectangle(blackPen, chimney);
			}
		}
	}
}