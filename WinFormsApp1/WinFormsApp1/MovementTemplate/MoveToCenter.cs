using WinFormsApp1.Drawings;

namespace WinFormsApp1.MovementStrategy;

/// <summary>
/// Стратегия перемещения объекта к центру экрана
/// </summary>
public class MoveToCenter : BaseTemplateMovement
{
    protected override bool IsTargetDestination()
    {
        ObjectCoordinates? objParams = GetObjectCoordinates();
        if (objParams is null) return false;

        int step = 10; // константный шаг

        int targetX = FieldWidth / 2;
        int targetY = FieldHeight / 2;

        int diffX = Math.Abs(objParams.ObjectMiddleHorizontal - targetX);
        int diffY = Math.Abs(objParams.ObjectMiddleVertical - targetY);

        // Достигли центра (осталось меньше или равно шагу)
        return diffX <= step && diffY <= step;
    }

    protected override void MoveToTarget()
    {
        ObjectCoordinates? objParams = GetObjectCoordinates();
        if (objParams is null) return;

        int step = 10; // константный шаг

        int targetX = FieldWidth / 2;
        int targetY = FieldHeight / 2;

        int diffX = objParams.ObjectMiddleHorizontal - targetX;
        int diffY = objParams.ObjectMiddleVertical - targetY;

        // Движение по горизонтали
        if (Math.Abs(diffX) > step)
        {
            if (diffX > 0)
                MoveLeft();
            else
                MoveRight();
        }
        else if (diffX != 0)
        {
            // Точная подгонка по X
            if (diffX > 0)
                MoveLeft();
            else
                MoveRight();
        }

        // Обновляем координаты после движения по X
        objParams = GetObjectCoordinates();
        if (objParams is null) return;

        diffY = objParams.ObjectMiddleVertical - targetY;

        // Движение по вертикали
        if (Math.Abs(diffY) > step)
        {
            if (diffY > 0)
                MoveUp();
            else
                MoveDown();
        }
        else if (diffY != 0)
        {
            // Точная подгонка по Y
            if (diffY > 0)
                MoveUp();
            else
                MoveDown();
        }
    }
}