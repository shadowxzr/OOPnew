using WinFormsApp1.Entities;

namespace WinFormsApp1.Drawings;

/// <summary>
/// Класс прорисовки линкора (продвинутый объект)
/// </summary>
public class DrawingBattleship : DrawingShip
{
	/// <summary>
	/// Конструктор линкора (оба признака всегда true)
	/// </summary>
	public DrawingBattleship(int speed, double weight, Color bodyColor, int deckCount, Color additionalColor)
		: base(130, 65)  // Линкор чуть больше (ширина 130, высота 65)
	{
		_entityShip = new EntityBattleship(speed, weight, bodyColor, deckCount, additionalColor);
	}

	/// <summary>
	/// Переопределенный метод прорисовки
	/// </summary>
	public override void DrawTransport(Graphics g)
	{
		if (_entityShip is null || _entityShip is not EntityBattleship battleship ||
			!_startPosX.HasValue || !_startPosY.HasValue)
		{
			return;
		}

		int x = _startPosX.Value;
		int y = _startPosY.Value;

		using (Pen blackPen = new Pen(Color.Black, 1.5f))
		{
			// ========== ОПЦИОНАЛЬНЫЕ ЭЛЕМЕНТЫ (РИСУЕМ ПОД ОСНОВНОЙ КОРПУС) ==========

			// 1. Ракетный отсек (ВСЕГДА ЕСТЬ) - рисуется слева от корпуса
			using (SolidBrush rocketBrush = new SolidBrush(battleship.AdditionalColor))
			{
				// Ракетная установка
				Rectangle rocketPod = new Rectangle(x - 15, y + 30, 15, 25);
				g.FillRectangle(rocketBrush, rocketPod);
				g.DrawRectangle(blackPen, rocketPod);

				// Ракеты
				for (int i = 0; i < 3; i++)
				{
					Rectangle rocket = new Rectangle(x - 12, y + 33 + i * 7, 9, 4);
					g.FillRectangle(rocketBrush, rocket);
					g.DrawRectangle(blackPen, rocket);
				}
			}

			// 2. Орудийная башня (ВСЕГДА ЕСТЬ) - рисуется справа от корпуса
			using (SolidBrush gunBrush = new SolidBrush(battleship.AdditionalColor))
			{
				// Дополнительная башня
				Rectangle extraTurret = new Rectangle(x + 110, y + 25, 20, 15);
				g.FillEllipse(gunBrush, extraTurret);
				g.DrawEllipse(blackPen, extraTurret);

				// Длинное орудие
				using (Pen gunPen = new Pen(Color.Black, 2.5f))
				{
					g.DrawLine(gunPen, x + 130, y + 32, x + 150, y + 32);
				}

				// Звезда на башне
				using (SolidBrush starBrush = new SolidBrush(Color.Yellow))
				{
					Point[] starPoints = new Point[]
					{
						new Point(x + 118, y + 32),
						new Point(x + 120, y + 29),
						new Point(x + 122, y + 32),
						new Point(x + 125, y + 32),
						new Point(x + 123, y + 35),
						new Point(x + 122, y + 32)
					};
					g.FillPolygon(starBrush, starPoints);
				}
			}

			// ========== СМЕЩАЕМ КООРДИНАТЫ ДЛЯ БАЗОВОЙ ЧАСТИ ==========
			int originalX = _startPosX.Value;
			int originalY = _startPosY.Value;
			_startPosX = originalX + 15;
			_startPosY = originalY - 5;

			try
			{
				// Вызываем базовую прорисовку (с палубами!)
				base.DrawTransport(g);
			}
			finally
			{
				// Возвращаем координаты
				_startPosX = originalX;
				_startPosY = originalY;
			}

			// ========== ДОПОЛНИТЕЛЬНЫЕ ЭЛЕМЕНТЫ ПОВЕРХ ==========

			// Соединительная линия между ракетным отсеком и башней
			using (Pen connectPen = new Pen(battleship.AdditionalColor, 2f))
			{
				g.DrawLine(connectPen, x - 5, y + 42, x + 110, y + 32);
			}
		}
	}
}