using WinFormsApp1.Drawings;

namespace WinFormsApp1.MovementStrategy;

/// <summary>
/// Стратегия перемещения объекта к правому нижнему углу экрана
/// </summary>
public class MoveToRightDownBorder : BaseTemplateMovement
{
    protected override bool IsTargetDestination()
    {
        ObjectCoordinates? objParams = GetObjectCoordinates();
        if (objParams is null) return false;

        int step = 10; // константный шаг

        int targetRight = FieldWidth;
        int targetDown = FieldHeight;

        int diffRight = targetRight - objParams.RightBorder;
        int diffDown = targetDown - objParams.DownBorder;

        // Достигли границы (осталось меньше или равно шагу)
        return diffRight <= step && diffDown <= step;
    }

    protected override void MoveToTarget()
    {
        ObjectCoordinates? objParams = GetObjectCoordinates();
        if (objParams is null) return;

        int step = 10; // константный шаг

        int targetRight = FieldWidth;
        int targetDown = FieldHeight;

        int diffRight = targetRight - objParams.RightBorder;
        int diffDown = targetDown - objParams.DownBorder;

        // Движение вправо
        if (diffRight > step)
        {
            MoveRight();
        }
        else if (diffRight > 0)
        {
            // Точная подгонка до правой границы
            MoveRight();
        }

        // Обновляем координаты после движения вправо
        objParams = GetObjectCoordinates();
        if (objParams is null) return;

        diffDown = targetDown - objParams.DownBorder;

        // Движение вниз
        if (diffDown > step)
        {
            MoveDown();
        }
        else if (diffDown > 0)
        {
            // Точная подгонка до нижней границы
            MoveDown();
        }
    }
}