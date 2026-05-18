using WinFormsApp1.Drawings;

namespace WinFormsApp1.MovementStrategy;

/// <summary>
/// Класс-шаблон стратегии перемещения объекта
/// </summary>
public abstract class BaseTemplateMovement
{
    private IMoveableObject? _moveableObject;
    private MovementStatus _state = MovementStatus.NotInit;

    protected int FieldWidth { get; private set; }
    protected int FieldHeight { get; private set; }
    public bool IsFinishReached => _state == MovementStatus.Finish;

    public void SetData(IMoveableObject moveableObject, int width, int height)
    {
        if (moveableObject is null)
        {
            _state = MovementStatus.NotInit;
            return;
        }
        _state = MovementStatus.InProgress;
        _moveableObject = moveableObject;
        FieldWidth = width;
        FieldHeight = height;
    }

    public void MakeStep()
    {
        if (_state != MovementStatus.InProgress) return;
        if (IsTargetDestination())
        {
            _state = MovementStatus.Finish;
            return;
        }
        MoveToTarget();
    }

    protected void MoveLeft() => MoveTo(MovementDirection.Left);
    protected void MoveRight() => MoveTo(MovementDirection.Right);
    protected void MoveUp() => MoveTo(MovementDirection.Up);
    protected void MoveDown() => MoveTo(MovementDirection.Down);

    protected ObjectCoordinates? GetObjectCoordinates() => _moveableObject?.ObjectCoordinates;
    protected int? GetStep() => _moveableObject?.ObjectStep;

    /// <summary>
    /// Точная установка позиции объекта (для дотягивания до границы)
    /// </summary>
    protected void SnapToPosition(int x, int y) => _moveableObject?.SetObjectPosition(x, y);

    protected abstract void MoveToTarget();
    protected abstract bool IsTargetDestination();

    private void MoveTo(MovementDirection direction)
    {
        if (_state != MovementStatus.InProgress || _moveableObject is null) return;
        _moveableObject.MoveObject(direction);
    }
}