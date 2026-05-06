namespace WinFormsApp1.MovementStrategy;

/// <summary>
/// Цель перемещения объекта в центр экрана
/// </summary>
public class MoveToCenter : BaseTemplateMovement
{
	protected override bool IsTargetDestination()
	{
		ObjectCoordinates? objParams = GetObjectCoordinates();
		if (objParams is null) return false;

		int? step = GetStep();
		if (step is null) return false;

		return Math.Abs(objParams.ObjectMiddleHorizontal - FieldWidth / 2) <= step.Value &&
			   Math.Abs(objParams.ObjectMiddleVertical - FieldHeight / 2) <= step.Value;
	}

	protected override void MoveToTarget()
	{
		ObjectCoordinates? objParams = GetObjectCoordinates();
		int? step = GetStep();

		if (objParams is null || step is null) return;

		int diffX = objParams.ObjectMiddleHorizontal - FieldWidth / 2;
		if (Math.Abs(diffX) > step.Value)
		{
			if (diffX > 0) MoveLeft();
			else MoveRight();
		}

		int diffY = objParams.ObjectMiddleVertical - FieldHeight / 2;
		if (Math.Abs(diffY) > step.Value)
		{
			if (diffY > 0) MoveUp();
			else MoveDown();
		}
	}
}