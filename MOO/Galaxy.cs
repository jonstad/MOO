using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOO
{
    public enum GalaxyType {Spiral, Oval}
    public static class Galaxy
    {
        public static  int Size { get; set; }
        public static GalaxyType Type { get; set; }
        public  static List<Star> stars { get; set; }
        public static List<Ship> Ships { get; set; }
        public static void Init()
        {
            Size = 500;
            Type = GalaxyType.Spiral;
            Ships = new List<Ship>();
            InitStars();
            InitShips();
        }
        private static void InitShips()
        {
            Ships.Add(new Ship(0, new Location(100, 100)));
            Ships.Add(new Ship(2, new Location(150, 50)));
            Ships[0].Destination = stars[0].Planets[0];
            Ships[1].Destination = stars[1].Planets[0];
        }
        static void InitStars()
        {
            stars = new List<Star>();
            Random r = new Random();
            stars.Add(new Star(112, 314, 22, Color.Red, "Bernard",r.Next(), stars.Count));
            stars.Add(new Star(52, 72, 44, Color.Blue,"Oceania", r.Next(), stars.Count));
            stars.Add(new Star(152, 172, 22, Color.Yellow,"Sol", r.Next(), stars.Count));
            stars.Add(new Star(323, 242, 22, Color.Yellow, "Ur", r.Next(), stars.Count));
            stars.Add(new Star(400, 343, 22, Color.Yellow, "zatl", r.Next(), stars.Count));
        }
       public  static void Update()
        {
            foreach (var star in stars)
            {
                star.UpdateStar();
            }
            foreach (var ship in Ships)
            {
                ship.Update();
            }
        }
    }
}
