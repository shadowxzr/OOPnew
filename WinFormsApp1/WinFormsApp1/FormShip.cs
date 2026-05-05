namespace WinFormsApp1
{
    public partial class FormShip : Form
    {
        /// <summary>
        /// Поле-объект полотно
        /// </summary>
        private readonly CanvasForShip _canvas;

        /// <summary>
        /// Поле для фиксации состояния для следующего шага проверки выхода за границы
        /// </summary>
        private DirectionType _checkBordersState;

        /// <summary>
        /// Инициализация формы
        /// </summary>
        public FormShip()
        {
            InitializeComponent();
            _canvas = new CanvasForShip();
            _canvas.SetPictureSize(pictureBoxShip.Width, pictureBoxShip.Height);
            _checkBordersState = DirectionType.None;
        }

        /// <summary>
        /// Метод прорисовки корабля
        /// </summary>
        private void Draw() => pictureBoxShip.Image = _canvas.DrawCanvas();

        /// <summary>
        /// Обработка нажатия кнопки "Создать"
        /// </summary>
        private void ButtonCreateShip_Click(object sender, EventArgs e)
        {
            Random random = new();
            DrawingShip ship = new();

            // Случайные характеристики
            int speed = random.Next(100, 300);
            double weight = random.Next(1000, 3000);
            Color bodyColor = Color.FromArgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));
            int deckCount = random.Next(1, 4); // Количество палуб: 1, 2, 3

            ship.Init(speed, weight, bodyColor, deckCount);

            if (_canvas.InsertShip(ship))
            {
                _canvas.SetShipPosition(random.Next(10, 100), random.Next(10, 100));
                Draw();

                Text = $"Корабль - Скорость: {speed}, Вес: {weight}, Палубы: {deckCount}";
            }
        }

        /// <summary>
        /// Перемещение объекта по форме (нажатие кнопок навигации)
        /// </summary>
        private void ButtonMove_Click(object sender, EventArgs e)
        {
            string name = ((Button)sender)?.Name ?? string.Empty;
            DirectionType direction = DirectionType.None;

            switch (name)
            {
                case "buttonUp":
                    direction = DirectionType.Up;
                    break;
                case "buttonDown":
                    direction = DirectionType.Down;
                    break;
                case "buttonLeft":
                    direction = DirectionType.Left;
                    break;
                case "buttonRight":
                    direction = DirectionType.Right;
                    break;
            }

            if (_canvas.MoveTransport(direction))
            {
                Draw();
            }
        }

        /// <summary>
        /// Проверка, что объект не выходит за границы при неверно заданных координатах
        /// </summary>
        private void ButtonCheckBorders_Click(object sender, EventArgs e)
        {
            Random random = new();

            switch (_checkBordersState)
            {
                case DirectionType.None:
                case DirectionType.Down:
                    _canvas.SetShipPosition(random.Next(10, 100) - 1000, random.Next(10, 100));
                    _checkBordersState = DirectionType.Left;
                    break;
                case DirectionType.Left:
                    _canvas.SetShipPosition(random.Next(10, 100), random.Next(10, 100) - 1000);
                    _checkBordersState = DirectionType.Up;
                    break;
                case DirectionType.Up:
                    _canvas.SetShipPosition(random.Next(10, 100) + pictureBoxShip.Width, random.Next(10, 100));
                    _checkBordersState = DirectionType.Right;
                    break;
                case DirectionType.Right:
                    _canvas.SetShipPosition(random.Next(10, 100), random.Next(10, 100) + pictureBoxShip.Height);
                    _checkBordersState = DirectionType.Down;
                    break;
            }

            Draw();
        }
    }
}
