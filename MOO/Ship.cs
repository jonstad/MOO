using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOO
{
    public class Ship
    {
        public Location CurrentLocation { get; set; }
        public Planet Destination { get; set; }
        public bool Docked { get; set; }
        public int  HomePlanet { get; set; }
        public int Size { get; set; }
        public Color BodyColor { get; set; }
        public int Speed { get; set; }
        public Ship(int homeplanet, Location currentlocation)
        {
            CurrentLocation = currentlocation;
            HomePlanet = homeplanet;
            Docked = true;
            Size = 4;
            BodyColor = Color.Red;
            Speed = 1;
        }
        public void Update()
        {
            Location dest = Galaxy.stars[Destination.IDHomeStar].Location;
            CurrentLocation.X = (dest.X >= CurrentLocation.X) ? CurrentLocation.X + Speed: CurrentLocation.X - Speed;
            CurrentLocation.Y = (dest.Y >= CurrentLocation.Y) ? CurrentLocation.Y+ Speed : CurrentLocation.Y- Speed;

          //  if (CurrentLocation.X==dest.X && CurrentLocation.Y == dest.Y)
                if (Math.Abs(CurrentLocation.X - dest.X)<2 && Math.Abs(CurrentLocation.Y - dest.Y)<2)
                {
                    Random r = new Random(Environment.TickCount);
                int rnd = MooRandom.GetRnd(0, Galaxy.stars.Count);
                Star destinationstar = Galaxy.stars[rnd];
                Destination = destinationstar.Planets[0];
                Destination.IDHomeStar = destinationstar.ID;
            }
        }
    }
}
