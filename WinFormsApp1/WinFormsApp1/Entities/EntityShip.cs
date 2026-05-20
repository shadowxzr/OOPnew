namespace WinFormsApp1.Entities;

/// <summary>
/// Класс-сущность "Корабль" (базовый)
/// </summary>
public class EntityShip
{
	/// <summary>
	/// Скорость
	/// </summary>
	public int Speed { get; init; }

	/// <summary>
	/// Вес
	/// </summary>
	public double Weight { get; init; }

	/// <summary>
	/// Основной цвет
	/// </summary>
	public Color BodyColor { get; init; }

	/// <summary>
	/// Количество палуб (для усложненной части)
	/// </summary>
	public int DeckCount { get; init; }

	/// <summary>
	/// Шаг перемещения корабля
	/// </summary>
	public double Step => 10;

	/// <summary>
	/// Конструктор для инициализации полей
	/// </summary>
	public EntityShip(int speed, double weight, Color bodyColor, int deckCount)
	{
		Speed = speed;
		Weight = weight;
		BodyColor = bodyColor;
		DeckCount = deckCount;
	}
}