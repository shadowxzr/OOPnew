using WinFormsApp1.Entities;

namespace WinFormsApp1.Drawings;

/// <summary>
/// Класс, отвечающий за прорисовку и перемещение объекта-сущности
/// </summary>
public class DrawingShip
{
	/// <summary>
	/// Класс-сущность (protected для доступа из наследников)
	/// </summary>
	protected EntityShip? _entityShip;

	/// <summary>
	/// Левая координата прорисовки
	/// </summary>
	protected int? _startPosX;

	/// <summary>
	/// Верхняя координата прорисовки
	/// </summary>
	protected int? _startPosY;

	/// <summary>
	/// Ширина прорисовки корабля
	/// </summary>
	protected int _drawningShipWidth = 110;

	/// <summary>
	/// Высота прорисовки корабля
	/// </summary>
	protected int _drawningShipHeight = 50;

	/// <summary>
	/// Левая координата прорисовки
	/// </summary>
	public int? PosX => _startPosX;

	/// <summary>
	/// Верхняя координата прорисовки
	/// </summary>
	public int? PosY => _startPosY;

	/// <summary>
	/// Шаг перемещения
	/// </summary>
	public double? ShipStep => _entityShip?.Step;

	/// <summary>
	/// Ширина прорисовки
	/// </summary>
	public int DrawingShipWidth => _drawningShipWidth;

	/// <summary>
	/// Высота прорисовки
	/// </summary>
	public int DrawingShipHeight => _drawningShipHeight;

	/// <summary>
	/// Приватный конструктор для инициализации координат
	/// </summary>
	private DrawingShip()
	{
		_startPosX = null;
		_startPosY = null;
	}

	/// <summary>
	/// Конструктор для базового корабля
	/// </summary>
	public DrawingShip(int speed, double weight, Color bodyColor, int deckCount) : this()
	{
		_entityShip = new EntityShip(speed, weight, bodyColor, deckCount);
	}

	/// <summary>
	/// Конструктор для изменения размеров (для наследников)
	/// </summary>
	protected DrawingShip(int width, int height) : this()
	{
		_drawningShipWidth = width;
		_drawningShipHeight = height;
	}

	/// <summary>
	/// Установка позиции
	/// </summary>
	public void SetPosition(int x, int y)
	{
		_startPosX = x;
		_startPosY = y;
	}

	/// <summary>
	/// Сдвиг влево
	/// </summary>
	public void MoveLeft()
	{
		if (_entityShip is null || !_startPosX.HasValue) return;
		_startPosX -= (int)_entityShip.Step;
	}

	/// <summary>
	/// Сдвиг вправо
	/// </summary>
	public void MoveRight()
	{
		if (_entityShip is null || !_startPosX.HasValue) return;
		_startPosX += (int)_entityShip.Step;
	}

	/// <summary>
	/// Сдвиг вверх
	/// </summary>
	public void MoveUp()
	{
		if (_entityShip is null || !_startPosY.HasValue) return;
		_startPosY -= (int)_entityShip.Step;
	}

	/// <summary>
	/// Сдвиг вниз
	/// </summary>
	public void MoveDown()
	{
		if (_entityShip is null || !_startPosY.HasValue) return;
		_startPosY += (int)_entityShip.Step;
	}

	/// <summary>
	/// Прорисовка объекта (виртуальный для переопределения)
	/// </summary>
	public virtual void DrawTransport(Graphics g)
	{
		if (_entityShip is null || !_startPosX.HasValue || !_startPosY.HasValue)
		{
			return;
		}

		int x = _startPosX.Value;
		int y = _startPosY.Value;

		using (Pen blackPen = new Pen(Color.Black, 1.5f))
		{
			// Корпус корабля
			Point[] hullPoints = new Point[]
			{
				new Point(x + 20, y + 50),
				new Point(x + 0, y + 35),
				new Point(x + 105, y + 35),
				new Point(x + 85, y + 50)
			};

			using (SolidBrush hullBrush = new SolidBrush(Color.Gray))
			{
				g.FillPolygon(hullBrush, hullPoints);
				g.DrawPolygon(blackPen, hullPoints);
			}

			// ========== УСЛОЖНЕННАЯ ЧАСТЬ: отображение количества палуб ==========
			if (_entityShip.DeckCount > 1)
			{
				using (Pen deckPen = new Pen(Color.SaddleBrown, 1.5f))
				{
					// Вторая палуба (линия на корпусе)
					g.DrawLine(deckPen, x + 15, y + 45, x + 100, y + 45);

					if (_entityShip.DeckCount > 2)
					{
						// Третья палуба (еще одна линия)
						g.DrawLine(deckPen, x + 20, y + 40, x + 95, y + 40);
					}
				}
			}

			// Рубка
			Rectangle superstructure = new Rectangle(x + 35, y + 22, 40, 18);
			using (SolidBrush superBrush = new SolidBrush(Color.DarkOliveGreen))
			{
				g.FillRectangle(superBrush, superstructure);
				g.DrawRectangle(blackPen, superstructure);
			}

			// Башня
			Rectangle turret = new Rectangle(x + 75, y + 28, 18, 10);
			using (SolidBrush turretBrush = new SolidBrush(Color.DarkGreen))
			{
				g.FillEllipse(turretBrush, turret);
				g.DrawEllipse(blackPen, turret);
			}

			// Пушка
			using (Pen gunPen = new Pen(Color.Black, 2f))
			{
				g.DrawLine(gunPen, x + 93, y + 33, x + 110, y + 33);
			}

			// Мачта
			using (Pen mastPen = new Pen(Color.Brown, 2f))
			{
				g.DrawLine(mastPen, x + 50, y + 22, x + 50, y + 0);
			}

			// Флаг
			Point[] flagPoints = new Point[]
			{
				new Point(x + 50, y + 2),
				new Point(x + 63, y + 5),
				new Point(x + 50, y + 8)
			};
			using (SolidBrush flagBrush = new SolidBrush(Color.Red))
			{
				g.FillPolygon(flagBrush, flagPoints);
			}

			// Труба
			Rectangle chimney = new Rectangle(x + 62, y + 12, 8, 15);
			using (SolidBrush chimneyBrush = new SolidBrush(Color.DarkGray))
			{
				g.FillRectangle(chimneyBrush, chimney);
				g.DrawRectangle(blackPen, chimney);
			}

			// Иллюминаторы
			using (SolidBrush windowBrush = new SolidBrush(Color.Yellow))
			{
				int[] xPositions = { 28, 45, 62, 79 };
				foreach (int xOffset in xPositions)
				{
					Rectangle window = new Rectangle(x + xOffset, y + 43, 4, 4);
					g.FillEllipse(windowBrush, window);
					g.DrawEllipse(blackPen, window);
				}
			}
		}
	}
}