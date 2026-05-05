using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{

    /// <summary>
    /// Класс, отвечающий за прорисовку и перемещение объекта-сущности
    /// </summary>
    public class DrawingShip
    {
        /// <summary>
        /// Класс-сущность
        /// </summary>
        private EntityShip? _entityShip;

        /// <summary>
        /// Левая координата прорисовки корабля
        /// </summary>
        private int? _startPosX;

        /// <summary>
        /// Верхняя координата прорисовки корабля
        /// </summary>
        private int? _startPosY;

        /// <summary>
        /// Ширина прорисовки корабля
        /// </summary>
        private readonly int _drawningShipWidth = 110;

        /// <summary>
        /// Высота прорисовки корабля
        /// </summary>
        private readonly int _drawningShipHeight = 50;

        /// <summary>
        /// Левая координата прорисовки корабля
        /// </summary>
        public int? PosX => _startPosX;

        /// <summary>
        /// Верхняя координата прорисовки корабля
        /// </summary>
        public int? PosY => _startPosY;

        /// <summary>
        /// Шаг перемещения
        /// </summary>
        public double? ShipStep => _entityShip?.Step;

        /// <summary>
        /// Ширина прорисовки корабля
        /// </summary>
        public int DrawingShipWidth => _drawningShipWidth;

        /// <summary>
        /// Высота прорисовки корабля
        /// </summary>
        public int DrawingShipHeight => _drawningShipHeight;

        /// <summary>
        /// Инициализация свойств
        /// </summary>
        /// <param name="speed">Скорость</param>
        /// <param name="weight">Вес корабля</param>
        /// <param name="bodyColor">Основной цвет</param>
        /// <param name="deckCount">Количество палуб</param>
        public void Init(int speed, double weight, Color bodyColor, int deckCount)
        {
            _entityShip = new EntityShip();
            _entityShip.Init(speed, weight, bodyColor, deckCount);
            _startPosX = null;
            _startPosY = null;
        }

        /// <summary>
        /// Установка позиции
        /// </summary>
        /// <param name="x">Координата X</param>
        /// <param name="y">Координата Y</param>
        public void SetPosition(int x, int y)
        {
            _startPosX = x;
            _startPosY = y;
        }

        /// <summary>
        /// Сдвиг изображения влево
        /// </summary>
        public void MoveLeft()
        {
            if (_entityShip is null || !_startPosX.HasValue)
            {
                return;
            }

            _startPosX -= (int)_entityShip.Step;
        }

        /// <summary>
        /// Сдвиг изображения вправо
        /// </summary>
        public void MoveRight()
        {
            if (_entityShip is null || !_startPosX.HasValue)
            {
                return;
            }

            _startPosX += (int)_entityShip.Step;
        }

        /// <summary>
        /// Сдвиг изображения вверх
        /// </summary>
        public void MoveUp()
        {
            if (_entityShip is null || !_startPosY.HasValue)
            {
                return;
            }

            _startPosY -= (int)_entityShip.Step;
        }

        /// <summary>
        /// Сдвиг изображения вниз
        /// </summary>
        public void MoveDown()
        {
            if (_entityShip is null || !_startPosY.HasValue)
            {
                return;
            }

            _startPosY += (int)_entityShip.Step;
        }

        /// <summary>
        /// Прорисовка объекта
        /// </summary>
        /// <param name="g"></param>
        /// <summary>
        /// Прорисовка объекта
        /// </summary>
        /// <param name="g"></param>
        /// <summary>
        /// Прорисовка ЛАЙНЕРА (Вариант 25)
        /// </summary>
        public void DrawTransport(Graphics g)
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

                // ===== 3. БАССЕЙН (по заданию) =====
                Rectangle pool = new Rectangle(x + 5, y + 38, 22, 12);
                using (SolidBrush poolBrush = new SolidBrush(Color.LightBlue))
                {
                    g.FillRectangle(poolBrush, pool);
                    g.DrawRectangle(blackPen, pool);
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
}
