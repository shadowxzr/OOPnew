namespace WinFormsApp1.Entities;

/// <summary>
/// Класс-сущность "Линкор" (продвинутый объект)
/// </summary>
public class EntityBattleship : EntityShip
{
	/// <summary>
	/// Дополнительный цвет (для опциональных элементов) - меняется случайно
	/// </summary>
	public Color AdditionalColor { get; init; }

	/// <summary>
	/// Признак наличия орудийной башни (ВСЕГДА ЕСТЬ)
	/// </summary>
	public bool HasGunTurret => true;

	/// <summary>
	/// Признак наличия ракетного отсека (ВСЕГДА ЕСТЬ)
	/// </summary>
	public bool HasRocketPod => true;

	/// <summary>
	/// Конструктор линкора
	/// </summary>
	public EntityBattleship(int speed, double weight, Color bodyColor, int deckCount, Color additionalColor)
		: base(speed, weight, bodyColor, deckCount)
	{
		AdditionalColor = additionalColor;
	}
}