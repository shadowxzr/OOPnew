
using WinFormsApp1.Drawings;

namespace WinFormsApp1.MovementStrategy;

/// <summary>
/// Реализация интерфейса IMoveableObject с адаптацией под DrawingShip
/// </summary>
public class MoveableAdapterShip : IMoveableObject
{
	private readonly DrawingShip? _ship;

	public MoveableAdapterShip(DrawingShip ship)
	{
		_ship = ship;
	}

	public ObjectCoordinates? ObjectCoordinates
	{
		get
		{
			if (_ship is null || !_ship.PosX.HasValue || !_ship.PosY.HasValue)
				return null;
			return new ObjectCoordinates(_ship.PosX.Value, _ship.PosY.Value,
				_ship.DrawingShipWidth, _ship.DrawingShipHeight);
		}
	}

	public int ObjectStep => (int)(_ship?.ShipStep ?? 0);

	public void MoveObject(MovementDirection direction)
	{
		if (_ship is null) return;
		switch (direction)
		{
			case MovementDirection.Left: _ship.MoveLeft(); break;
			case MovementDirection.Up: _ship.MoveUp(); break;
			case MovementDirection.Right: _ship.MoveRight(); break;
			case MovementDirection.Down: _ship.MoveDown(); break;
		}
	}

	public void SetObjectPosition(int x, int y) => _ship?.SetPosition(x, y);
	public void DrawObject(Graphics graphics) => _ship?.DrawTransport(graphics);
}