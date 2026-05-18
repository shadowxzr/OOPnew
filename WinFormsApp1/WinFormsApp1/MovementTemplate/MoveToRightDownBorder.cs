using WinFormsApp1.Drawings;

namespace WinFormsApp1.MovementStrategy;

/// <summary>
/// Стратегия перемещения объекта к правой нижней границе экрана
/// </summary>
public class MoveToRightDownBorder : BaseTemplateMovement
{
    protected override bool IsTargetDestination()
    {
        ObjectCoordinates? objParams = GetObjectCoordinates();
        if (objParams is null) return false;

        // Достигли ли правой И нижней границы
        return objParams.RightBorder >= FieldWidth && objParams.DownBorder >= FieldHeight;
    }

    protected override void MoveToTarget()
    {
        ObjectCoordinates? objParams = GetObjectCoordinates();
        if (objParams is null) return;

        bool needMoveRight = objParams.RightBorder < FieldWidth;
        bool needMoveDown = objParams.DownBorder < FieldHeight;

        // Движение по диагонали: одновременно вправо и вниз
        if (needMoveRight && needMoveDown)
        {
            MoveRight();
            MoveDown();
        }
        // Если только вправо нужно
        else if (needMoveRight)
        {
            MoveRight();
        }
        // Если только вниз нужно
        else if (needMoveDown)
        {
            MoveDown();
        }
    }
}