namespace WinFormsApp1.Entities;

/// <summary>
/// Класс-сущность "Лайнер" (продвинутый объект для варианта 25)
/// </summary>
public class EntityLiner : EntityShip
{
    /// <summary>
    /// Дополнительный цвет (для бассейна и других элементов)
    /// </summary>
    public Color AdditionalColor { get; init; }

    /// <summary>
    /// Признак наличия бассейна (ВСЕГДА ЕСТЬ)
    /// </summary>
    public bool HasPool => true;

    /// <summary>
    /// Признак наличия ресторана (ВСЕГДА ЕСТЬ)
    /// </summary>
    public bool HasRestaurant => true;

    /// <summary>
    /// Конструктор лайнера
    /// </summary>
    public EntityLiner(int speed, double weight, Color bodyColor, int deckCount, Color additionalColor)
        : base(speed, weight, bodyColor, deckCount)
    {
        AdditionalColor = additionalColor;
    }
}