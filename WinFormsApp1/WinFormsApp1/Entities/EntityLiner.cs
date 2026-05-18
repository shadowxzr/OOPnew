namespace WinFormsApp1.Entities;

public class EntityLiner : EntityShip
{
    public Color AdditionalColor { get; init; }
    public bool HasPool => true;
    public bool HasRestaurant => true;

    public EntityLiner(int speed, double weight, Color bodyColor, int deckCount, Color additionalColor)
        : base(speed, weight, bodyColor, deckCount)
    {
        AdditionalColor = additionalColor;
    }
}