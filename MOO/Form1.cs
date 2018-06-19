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
        Galaxy galaxy = new Galaxy();
        public Form1()
        {
            InitializeComponent();
            
            DrawGlobes();
        }
        public void DrawGlobes()
        {
            Bitmap a = new Bitmap(pictureBox1.Size.Width, pictureBox1.Size.Height);
            foreach (var globe in galaxy.globes)
            {
                using (Graphics g = Graphics.FromImage(a))
                {
                    Pen pen = new Pen(globe.Color);
                    var brush = new SolidBrush(pen.Color);
                    g.FillEllipse(brush, new Rectangle(globe.X, globe.Y, globe.Diameter, globe.Diameter));
                }
            }
            pictureBox1.Image = a;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
          //  textBox1.Text = e.Location.ToString();
           // textBox1.AppendText(Environment.NewLine);
            Rectangle mouserectangle = new Rectangle(e.X, e.Y, 1, 1);
          //  textBox1.AppendText(Environment.NewLine);
            if (MouserOverStar(new Point(e.X, e.Y)))
            {
                Star foundstar = GetStar(new Point(e.X, e.Y));
                textBox1.Text= "Name: "+foundstar.Name+" has " + foundstar.Planets.Count.ToString()+" planets";
            }
            else
            {
            textBox1.Clear();

            }
        }
        private bool MouserOverStar(Point point)
        {
            bool overstar = false;
            foreach (var item in galaxy.globes)
            {
                Rectangle globerect = new Rectangle(item.X, item.Y, item.Diameter, item.Diameter);
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
            foreach (var item in galaxy.globes)
            {
                Rectangle globerect = new Rectangle(item.X, item.Y, item.Diameter, item.Diameter);
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
            MouseEventArgs ee = e as MouseEventArgs;
            textBox1.Text = ee.Location.ToString();
            textBox1.AppendText(Environment.NewLine);

            Rectangle rec1 = new Rectangle(ee.X, ee.Y, 5, 5);
            textBox1.AppendText(Environment.NewLine);

            // textBox1.AppendText((100*e.Y / galaxy.Size).ToString());
            foreach (var item in galaxy.globes)
            {
                Rectangle globerect = new Rectangle(item.X, item.Y, 5, 5);
                if (Inside(rec1, globerect))
                {
                    textBox1.AppendText("Inside: " + item.Name);
                    textBox1.AppendText(Environment.NewLine);
                }
            }
        }
    }
}
