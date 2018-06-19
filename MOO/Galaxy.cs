using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOO
{
    public enum GalaxyType {Spiral, Oval}
    class Galaxy
    {
        public int Size { get; set; }
        public GalaxyType Type { get; set; }
        public List<Star> globes { get; set; }
        public Galaxy()
        {
            Size = 500;
            Type = GalaxyType.Spiral;
            InitGlobes();
        }
        public void InitGlobes()
        {
            globes = new List<Star>();
            Random r = new Random();
            globes.Add(new Star(112, 314, 22, Color.Red, "Bernard",r.Next()));
            globes.Add(new Star(52, 72, 44, Color.Blue,"Oceania", r.Next()));
            globes.Add(new Star(152, 172, 22, Color.Yellow,"Sol", r.Next()));
            globes.Add(new Star(423, 542, 22, Color.Yellow, "Ur", r.Next()));
            globes.Add(new Star(500, 343, 22, Color.Yellow, "zatl", r.Next()));
        }
    }
}
