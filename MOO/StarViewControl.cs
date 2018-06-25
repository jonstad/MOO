using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MOO
{
    public partial class StarViewControl : UserControl
    {
        public List<HScrollBar> sliders { get; set; }
        private ResourceDistribution _resourcedistribution { get; set; }
        private Star _linkedstar;
        private int total = 100;
        public StarViewControl()
        {
            InitializeComponent();
            _resourcedistribution = new ResourceDistribution();
            sliders = new List<HScrollBar>();
            sliders.Add(hScrIndustry);
            sliders.Add(hScrlComercial);
            sliders.Add(hScrlEcology);
            sliders.Add(hScrlTechnology);
            SetDefaultValues();
        }
        public void SetDefaultValues()
        {
            foreach (var item in sliders)
            {
                //item.SmallChange = 0;
                //item.LargeChange = 0;
            }

        }


        public void Update(Star star) {
            label11.Text = star.Name;
            _linkedstar = star;
            _resourcedistribution = star.ResourceDistribution;
            UpdateValues();
        }
        public void UpdateValues()
        {
            hScrIndustry.Value = _resourcedistribution.Industry;
            hScrlComercial.Value = _resourcedistribution.Commercial;
            hScrlEcology.Value = _resourcedistribution.Ecology;
            hScrlTechnology.Value = _resourcedistribution.Tehnology;
        }

        private int SumAllSlider()
        {
            int sum = 0;
            foreach (var item in sliders)
            {
                sum += item.Value;
            }
            return sum;

        }
        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            int max = 100;
            int sum = SumAllSlider();
            int remainder = sum-max;
            int lowestslider = sliders.Count()-1;

            HScrollBar source = sender as HScrollBar;
 
            while (sum>max)
            {
                if (lowestslider <0)
                {
                    break;
                }
                if (source.Name != sliders[lowestslider].Name)
                {
                    if (sliders[lowestslider].Value>remainder)
                    {
                        sliders[lowestslider].Value -= remainder;
                        remainder = 0;
                        sum = 0;
                    }
                    else
                    {
                        remainder -= sliders[lowestslider].Value;
                        sliders[lowestslider].Value = 0;
                        lowestslider--;
                    }
                }
                else
                {
                    lowestslider--;
                }
              
            }
            label1.Text = remainder.ToString();
            UpdateStar();
        }
        private void UpdateStar()
        {
                _resourcedistribution.Industry = hScrIndustry.Value ;
                _resourcedistribution.Commercial =hScrlComercial.Value;
                _resourcedistribution.Ecology =hScrlEcology.Value  ;
                _resourcedistribution.Tehnology=hScrlTechnology.Value ;
                _linkedstar.ResourceDistribution = _resourcedistribution;
        }
        private void hScrollBar4_ValueChanged(object sender, EventArgs e)
        {
            
            //1 max er produksjonstak alle får dette.
            //2 Øker produksjon på den en velger. Deretter må de andre nedjusteres i prioritert rekkefølge



            //int MinimumMaxValueOfSliders = 1000;
            //foreach (var item in sliders)
            //{
            //   MinimumMaxValueOfSliders = (MinimumMaxValueOfSliders > item.Maximum) ? item.Maximum : MinimumMaxValueOfSliders;
            //}

            //int tot = 0;
            //textBox1.Clear();
            //foreach (var item in sliders)
            //{
            //    tot += item.Value;
            //}
            //foreach (var item in sliders)
            //{
            //    int newmax = 100 - tot - item.Value;
            //    item.Maximum = newmax;
            //    textBox1.AppendText(item.Name + " " + item.Maximum + " " + Environment.NewLine);
            //}
            //textBox1.AppendText(MinimumMaxValueOfSliders + Environment.NewLine);
            //label1.Text = tot.ToString();
        }
    }
}
