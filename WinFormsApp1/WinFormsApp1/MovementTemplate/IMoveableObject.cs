namespace WinFormsApp1.MovementStrategy;

/// <summary>
/// Интерфейс для работы с перемещаемым объектом
/// </summary>
public interface IMoveableObject
{
	ObjectCoordinates? ObjectCoordinates { get; }
	int ObjectStep { get; }
	void SetObjectPosition(int x, int y);
	void MoveObject(MovementDirection direction);
	void DrawObject(Graphics graphics);
}