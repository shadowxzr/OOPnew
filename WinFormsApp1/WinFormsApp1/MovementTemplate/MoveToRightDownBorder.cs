using WinFormsApp1.Drawings;

namespace WinFormsApp1.MovementStrategy;

public class MoveToRightDownBorder : BaseTemplateMovement
{
    protected override bool IsTargetDestination()
    {
        ObjectCoordinates? objParams = GetObjectCoordinates();
        if (objParams is null) return false;

        return objParams.RightBorder >= FieldWidth && objParams.DownBorder >= FieldHeight;
    }

    protected override void MoveToTarget()
    {
        ObjectCoordinates? objParams = GetObjectCoordinates();
        if (objParams is null) return;

        bool needMoveRight = objParams.RightBorder < FieldWidth;
        bool needMoveDown = objParams.DownBorder < FieldHeight;

        if (needMoveRight && needMoveDown)
        {
            MoveRight();
            MoveDown();
        }
        else if (needMoveRight)
        {
            MoveRight();
        }
        else if (needMoveDown)
        {
            MoveDown();
        }
    }
}