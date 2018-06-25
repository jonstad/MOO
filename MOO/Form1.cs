using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MOO
{
    public partial class Form1 : Form
    {
        //Galaxy galaxy = new Galaxy();
        Bitmap a;
        public Form1()
        {
            InitializeComponent();
            MooRandom.Init();
            a = new Bitmap(pictureBox1.Size.Width, pictureBox1.Size.Height);
            Galaxy.Init();
            Galaxy.Update();
            shipViewControl1.UpdateList();
            DrawGalaxy();
        }

        public void DrawGalaxy()
        {
            using (Graphics g = Graphics.FromImage(a))
            {
                g.Clear(Color.Black);
            }
            DrawStars(a);
            DrawShips(a);
            pictureBox1.Image = a;
        }

        private static void DrawStars(Bitmap a)
        {
            foreach (var globe in Galaxy.stars)
            {
                using (Graphics g = Graphics.FromImage(a))
                {
                    Pen pen = new Pen(globe.Color);
                    var brush = new SolidBrush(pen.Color);
                    g.FillEllipse(brush, new Rectangle(globe.Location.X, globe.Location.Y, globe.Diameter, globe.Diameter));
                }
            }
        }
        private static void DrawShips(Bitmap a)
        {
            foreach (var ship in Galaxy.Ships)
            {
                using (Graphics g = Graphics.FromImage(a))
                {
                    Pen pen = new Pen(ship.BodyColor);
                    var brush = new SolidBrush(pen.Color);
                    g.FillEllipse(brush, new Rectangle(ship.CurrentLocation.X, ship.CurrentLocation.Y, ship.Size, ship.Size));
                }
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Rectangle mouserectangle = new Rectangle(e.X, e.Y, 1, 1);
            if (MouserOverStar(new Point(e.X, e.Y)))
            {
                Star foundstar = GetStar(new Point(e.X, e.Y));
                starViewControl1.Update(foundstar);
               // textBox1.Text= "Name: "+foundstar.Name+"\n has " + foundstar.Planets.Count.ToString()+" planets";
            }
            else
            {
                //textBox1.Clear();
            }
        }
        private bool MouserOverStar(Point point)
        {
            bool overstar = false;
            foreach (var item in Galaxy.stars)
            {
                Rectangle globerect = new Rectangle(item.Location.X, item.Location.Y, item.Diameter, item.Diameter);
                if (globerect.Contains(point))
                {
                    overstar = true;    
                }
            }
            return overstar;
        }
        private Star GetStar(Point point)
        {
            Star star = new Star();
            foreach (var item in Galaxy.stars)
            {
                Rectangle globerect = new Rectangle(item.Location.X, item.Location.Y, item.Diameter, item.Diameter);
                if (globerect.Contains(point))
                {
                    star = item;
                }
            }
            return star;
        }
        private bool Inside(Rectangle rec1, Rectangle rec2)
        {
            bool inside = false;
            bool over = rec1.Bottom < rec2.Top;
            bool under = rec1.Top > rec2.Bottom;
            bool left = rec1.Right < rec2.Left;
            bool right = rec1.Left > rec2.Right;
            inside = !over && !under && !left && !right;
            return inside;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //MouseEventArgs ee = e as MouseEventArgs;
            //textBox1.Text = ee.Location.ToString();
            //textBox1.AppendText(Environment.NewLine);

            //Rectangle rec1 = new Rectangle(ee.X, ee.Y, 5, 5);
            //textBox1.AppendText(Environment.NewLine);

            //// textBox1.AppendText((100*e.Y / galaxy.Size).ToString());
            //foreach (var item in Galaxy.stars)
            //{
            //    Rectangle globerect = new Rectangle(item.Location.X, item.Location.Y, 5, 5);
            //    if (Inside(rec1, globerect))
            //    {
            //        textBox1.AppendText("Inside: " + item.Name);
            //        textBox1.AppendText(Environment.NewLine);
            //    }
            //}
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            shipViewControl1.UpdateList();
            Galaxy.Update();
            DrawGalaxy();
        }
    }
}
