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
		: base(140, 70)  // Линкор чуть больше (ширина 140, высота 70)
	{
		_entityShip = new EntityBattleship(speed, weight, bodyColor, deckCount, additionalColor);
		_battleship = _entityShip as EntityBattleship;
	}

	/// <summary>
	/// Переопределенный метод прорисовки
	/// </summary>
	public override void DrawTransport(Graphics g)
	{
		if (_battleship is null || !_startPosX.HasValue || !_startPosY.HasValue)
		{
			return;
		}

		int x = _startPosX.Value;
		int y = _startPosY.Value;
		int deckCount = _battleship.DeckCount;

		using (Pen blackPen = new Pen(Color.Black, 1.5f))
		{
			// ===== 1. КОРПУС ЛАЙНЕРА =====
			Point[] hullPoints = new Point[]
			{
				new Point(x + 25, y + 55),
				new Point(x + 0, y + 38),
				new Point(x + 120, y + 38),
				new Point(x + 100, y + 55)
			};

			using (SolidBrush hullBrush = new SolidBrush(_battleship.BodyColor))
			{
				g.FillPolygon(hullBrush, hullPoints);
				g.DrawPolygon(blackPen, hullPoints);
			}

			// ===== 2. ПАЛУБЫ =====
			using (Pen deckPen = new Pen(Color.SandyBrown, 1.5f))
			{
				g.DrawLine(deckPen, x + 5, y + 52, x + 118, y + 52);

				if (deckCount >= 2)
				{
					g.DrawLine(deckPen, x + 20, y + 46, x + 105, y + 46);
				}

				if (deckCount >= 3)
				{
					g.DrawLine(deckPen, x + 30, y + 40, x + 90, y + 40);
				}
			}

			// ===== 3. БАССЕЙН (с использованием AdditionalColor для воды) =====
			Rectangle pool = new Rectangle(x + 8, y + 41, 24, 12);
			using (SolidBrush poolBrush = new SolidBrush(_battleship.AdditionalColor))
			{
				g.FillRectangle(poolBrush, pool);
				g.DrawRectangle(blackPen, pool);
			}

			// ===== 4. КАЮТЫ (надстройка) =====
			Rectangle cabins = new Rectangle(x + 35, y + 22, 50, 18);
			using (SolidBrush cabinsBrush = new SolidBrush(Color.White))
			{
				g.FillRectangle(cabinsBrush, cabins);
				g.DrawRectangle(blackPen, cabins);
			}

			// Окна в каютах
			using (SolidBrush windowBrush = new SolidBrush(Color.LightGray))
			{
				for (int i = 0; i < 5; i++)
				{
					Rectangle cabinWindow = new Rectangle(x + 42 + (i * 9), y + 27, 5, 5);
					g.FillRectangle(windowBrush, cabinWindow);
					g.DrawRectangle(blackPen, cabinWindow);
				}
			}

			// ===== 5. МАЧТА И ФЛАГ =====
			using (Pen mastPen = new Pen(Color.Brown, 2f))
			{
				g.DrawLine(mastPen, x + 58, y + 22, x + 58, y + 0);
			}

			// Флаг (используем AdditionalColor для флага)
			Point[] flagPoints = new Point[]
			{
				new Point(x + 58, y + 2),
				new Point(x + 78, y + 5),
				new Point(x + 58, y + 8)
			};
			using (SolidBrush flagBrush = new SolidBrush(_battleship.AdditionalColor))
			{
				g.FillPolygon(flagBrush, flagPoints);
			}

			// ===== 6. ИЛЛЮМИНАТОРЫ =====
			using (SolidBrush illuminatorBrush = new SolidBrush(Color.Yellow))
			{
				int[] xPositions = { 30, 48, 66, 84, 102 };
				foreach (int xOffset in xPositions)
				{
					Rectangle window = new Rectangle(x + xOffset, y + 48, 4, 4);
					g.FillEllipse(illuminatorBrush, window);
					g.DrawEllipse(blackPen, window);
				}
			}

			// ===== 7. ДЫМОХОД (с использованием AdditionalColor) =====
			Rectangle chimney = new Rectangle(x + 75, y + 5, 14, 18);
			using (SolidBrush chimneyBrush = new SolidBrush(_battleship.AdditionalColor))
			{
				g.FillRectangle(chimneyBrush, chimney);
				g.DrawRectangle(blackPen, chimney);
			}

			// ===== 8. ДЕКОРАТИВНАЯ ПОЛОСА (бонус от AdditionalColor) =====
			using (Pen decorPen = new Pen(_battleship.AdditionalColor, 2f))
			{
				g.DrawLine(decorPen, x + 10, y + 58, x + 115, y + 58);
			}
		}
	}
}