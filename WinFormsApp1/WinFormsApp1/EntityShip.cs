using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class EntityShip
    {
        public int Speed { get; private set; }
        public double Weight { get; private set; }
        public Color BodyColor { get; private set; }
        public int DeckCount { get; private set; }

        public double Step => Speed * 100 / Weight;

        public void Init(int speed, double weight, Color bodyColor, int deckCount)
        {
            Speed = speed;
            Weight = weight;
            BodyColor = bodyColor;
            DeckCount = deckCount;
        }
    }
}
