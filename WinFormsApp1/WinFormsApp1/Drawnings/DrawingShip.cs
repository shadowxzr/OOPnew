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
		int deckCount = _entityShip.DeckCount;  // ← количество палуб (1,2,3)

		using (Pen blackPen = new Pen(Color.Black, 1.5f))
		{
			// ===== 1. КОРПУС ЛАЙНЕРА =====
			Point[] hullPoints = new Point[]
			{
				 new Point(x + 20, y + 50),
				 new Point(x + 0, y + 35),
				 new Point(x + 105, y + 35),
				 new Point(x + 85, y + 50)
			};

			// ← ИСПОЛЬЗУЕМ ЦВЕТ ИЗ ENTITYSHIP
			using (SolidBrush hullBrush = new SolidBrush(_entityShip.BodyColor))
			{
				g.FillPolygon(hullBrush, hullPoints);
				g.DrawPolygon(blackPen, hullPoints);
			}

			// ===== 2. ПАЛУБЫ (исправленная геометрия) =====
			using (Pen deckPen = new Pen(Color.SandyBrown, 1.5f))
			{
				// Корпус имеет верхнюю грань от x+0 до x+105

				// 1-я палуба (главная, почти во всю длину)
				g.DrawLine(deckPen, x + 3, y + 47, x + 103, y + 47);

				// 2-я палуба (надстройка, короче)
				if (deckCount >= 2)
				{
					g.DrawLine(deckPen, x + 18, y + 42, x + 92, y + 42);
				}

				// 3-я палуба (самая верхняя, еще короче - место под каютами/бассейном)
				if (deckCount >= 3)
				{
					g.DrawLine(deckPen, x + 28, y + 37, x + 80, y + 37);
				}
			}

			// ===== 4. КАЮТЫ (надстройка) =====
			Rectangle cabins = new Rectangle(x + 30, y + 22, 45, 16);
			using (SolidBrush cabinsBrush = new SolidBrush(Color.White))
			{
				g.FillRectangle(cabinsBrush, cabins);
				g.DrawRectangle(blackPen, cabins);
			}

			// Окна в каютах
			using (SolidBrush windowBrush = new SolidBrush(Color.LightGray))
			{
				for (int i = 0; i < 4; i++)
				{
					Rectangle cabinWindow = new Rectangle(x + 35 + (i * 10), y + 26, 5, 5);
					g.FillRectangle(windowBrush, cabinWindow);
					g.DrawRectangle(blackPen, cabinWindow);
				}
			}
			// ===== 6. МАЧТА И ФЛАГ =====
			using (Pen mastPen = new Pen(Color.Brown, 2f))
			{
				g.DrawLine(mastPen, x + 50, y + 22, x + 50, y + 0);
			}

			// Флаг
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

			// ===== 7. ИЛЛЮМИНАТОРЫ (окна по борту) =====
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