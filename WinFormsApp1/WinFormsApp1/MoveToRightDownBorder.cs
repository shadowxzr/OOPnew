namespace WinFormsApp1.MovementStrategy;

/// <summary>
/// Цель перемещения объекта в правый нижний угол
/// </summary>
public class MoveToRightDownBorder : BaseTemplateMovement
{
	protected override bool IsTargetDestination()
	{
		ObjectCoordinates? objParams = GetObjectCoordinates();
		if (objParams is null) return false;

		int? step = GetStep();
		if (step is null) return false;

		return Math.Abs(objParams.RightBorder - FieldWidth) <= step.Value &&
			   Math.Abs(objParams.DownBorder - FieldHeight) <= step.Value;
	}

	protected override void MoveToTarget()
	{
		ObjectCoordinates? objParams = GetObjectCoordinates();
		int? step = GetStep();

		if (objParams is null || step is null) return;

		int diffRight = objParams.RightBorder - FieldWidth;
		if (Math.Abs(diffRight) > step.Value)
		{
			if (diffRight > 0) MoveLeft();
			else MoveRight();
		}

		int diffDown = objParams.DownBorder - FieldHeight;
		if (Math.Abs(diffDown) > step.Value)
		{
			if (diffDown > 0) MoveUp();
			else MoveDown();
		}
	}
}