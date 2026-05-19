namespace WinFormsApp1.Entities;

public class EntityShip
{
    public int Speed { get; init; }
    public double Weight { get; init; }
    public Color BodyColor { get; init; }
    public int DeckCount { get; init; }
    public double Step => Math.Min(Speed * 100 / Weight, 15);

    public EntityShip(int speed, double weight, Color bodyColor, int deckCount)
    {
        Speed = speed;
        Weight = weight;
        BodyColor = bodyColor;
        DeckCount = deckCount;
    }
}