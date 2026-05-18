using WinFormsApp1.Drawings;
using WinFormsApp1.MovementStrategy;

namespace WinFormsApp1;

public partial class FormShip : Form
{
	private readonly CanvasForShip _canvas;
	private DirectionType _checkBordersState;
	private BaseTemplateMovement? _templateMovement;

    /// <summary>
    /// Получение корабля из коллекции (для передачи из формы коллекции)
    /// </summary>
    public void SetDrawingShip(DrawingShip ship) => InsertShipObject(ship);

    /// <summary>
    /// Добавление на полотно корабля
    /// </summary>
    private void InsertShipObject(DrawingShip ship, Random? random = null)
    {
        random ??= new();
        if (_canvas.InsertShip(ship))
        {
            _canvas.SetShipPosition(random.Next(10, 100), random.Next(10, 100));
            comboBoxDestination.Enabled = true;
            comboBoxDestination.SelectedIndex = -1;
            _templateMovement = null;
            Draw();
            Text = $"Получен корабль из коллекции - {ship.GetType().Name}";
        }
    }

    public FormShip()
	{
		InitializeComponent();
		_canvas = new CanvasForShip();
		_canvas.SetPictureSize(pictureBoxShip.Width, pictureBoxShip.Height);
		_checkBordersState = DirectionType.None;

		comboBoxDestination.Items.Clear();
		comboBoxDestination.Items.Add("К центру");
		comboBoxDestination.Items.Add("К правому нижнему углу");
		comboBoxDestination.DropDownStyle = ComboBoxStyle.DropDownList;
		comboBoxDestination.Enabled = false;

		this.Resize += FormShip_Resize;
	}

	private void FormShip_Resize(object? sender, EventArgs e)
	{
		if (_canvas != null && pictureBoxShip != null)
		{
			_canvas.SetPictureSize(pictureBoxShip.Width, pictureBoxShip.Height);
			Draw();
		}
	}

	private void Draw()
	{
		var oldImage = pictureBoxShip.Image;
		pictureBoxShip.Image = _canvas.DrawCanvas();
		oldImage?.Dispose();
	}

	/// <summary>
	/// Создание простого корабля (с палубами)
	/// </summary>
	private void ButtonCreateShip_Click(object sender, EventArgs e)
	{
		Random random = new();

		int speed = random.Next(100, 300);
		double weight = random.Next(1000, 3000);
		Color bodyColor = Color.FromArgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));
		int deckCount = random.Next(1, 4);

		DrawingShip ship = new DrawingShip(speed, weight, bodyColor, deckCount);

		if (_canvas.InsertShip(ship))
		{
			_canvas.SetShipPosition(random.Next(10, 100), random.Next(10, 100));
			comboBoxDestination.Enabled = true;
			comboBoxDestination.SelectedIndex = -1;
			_templateMovement = null;
			Draw();

			Text = $"Корабль - Скорость: {speed}, Вес: {weight}, Палубы: {deckCount}";
		}
	}

    /// <summary>
    /// Создание лайнера (продвинутого объекта)
    /// </summary>
    private void ButtonCreateBattleship_Click(object sender, EventArgs e)
    {
        Random random = new();

        int speed = random.Next(300, 600);
        double weight = random.Next(2000, 6000);
        Color bodyColor = Color.FromArgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));
        Color additionalColor = Color.FromArgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));
        int deckCount = random.Next(2, 5);

        DrawingLiner liner = new DrawingLiner(speed, weight, bodyColor, deckCount, additionalColor);

        if (_canvas.InsertShip(liner))
        {
            _canvas.SetShipPosition(random.Next(10, 100), random.Next(10, 100));
            comboBoxDestination.Enabled = true;
            comboBoxDestination.SelectedIndex = -1;
            _templateMovement = null;
            Draw();

            Text = $"ЛАЙНЕР - Скорость: {speed}, Вес: {weight}, " +
                   $"Палубы: {deckCount}, Доп.цвет: RGB({additionalColor.R},{additionalColor.G},{additionalColor.B})";
        }
    }

    private void ButtonMove_Click(object sender, EventArgs e)
	{
		string name = ((Button)sender)?.Name ?? string.Empty;
		DirectionType direction = DirectionType.None;

		switch (name)
		{
			case "buttonUp": direction = DirectionType.Up; break;
			case "buttonDown": direction = DirectionType.Down; break;
			case "buttonLeft": direction = DirectionType.Left; break;
			case "buttonRight": direction = DirectionType.Right; break;
		}

		if (_canvas.MoveTransport(direction))
		{
			Draw();
		}
	}

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

	private void ComboBoxDestination_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (_canvas is null || _canvas.DrawingShip is null) return;

		_templateMovement = comboBoxDestination.SelectedIndex switch
		{
			0 => new MoveToCenter(),
			1 => new MoveToRightDownBorder(),
			_ => null
		};

		if (_templateMovement is null) return;

		_templateMovement.SetData(new MoveableAdapterShip(_canvas.DrawingShip),
			pictureBoxShip.Width, pictureBoxShip.Height);
		comboBoxDestination.Enabled = false;
	}

	private void ButtonMovementStep_Click(object sender, EventArgs e)
	{
		if (_templateMovement is null) return;

		_templateMovement.MakeStep();
		if (_templateMovement.IsFinishReached)
		{
			comboBoxDestination.Enabled = true;
			comboBoxDestination.SelectedIndex = -1;
		}
		Draw();
	}
}