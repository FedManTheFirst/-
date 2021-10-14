using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Drawing.Drawing2D;

namespace PieChart
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Draw(object sender, PaintEventArgs e)
        {
            Draw();
        }

        private void Draw()
        {
            ArrayList data = new ArrayList();
            data.Add(new PieChartElement("East", (float)50.75));
            data.Add(new PieChartElement("West", (float)22));
            data.Add(new PieChartElement("North", (float)72.32));
            data.Add(new PieChartElement("South", (float)12));
            data.Add(new PieChartElement("Central", (float)44));

            chart.Image = drawPieChart(data, new Size(chart.Width, chart.Height));
        }

        private Image drawPieChart(ArrayList elements, Size s)
        {
            Color[] colors = { Color.Red, Color.Orange, Color.Yellow, Color.Green,
                Color.Blue, Color.Indigo, Color.Violet, Color.DarkRed,
                Color.DarkOrange, Color.DarkSalmon, Color.DarkGreen,
                Color.DarkBlue, Color.Lavender, Color.LightBlue, Color.Coral };

            if (elements.Count > colors.Length)
            {
                throw new ArgumentException("Pie chart must have " + colors.Length + " or fewer elements");
            }

            Bitmap bm = new Bitmap(s.Width, s.Height);
            Graphics g = Graphics.FromImage(bm);
            g.SmoothingMode = SmoothingMode.HighQuality;

            // Calculate total value of all rows
            float total = 0;

            foreach (PieChartElement e in elements)
            {
                if (e.value < 0)
                {
                    throw new ArgumentException("All elements must have positive values");
                }
                total += e.value;
            }

            if (!(total > 0))
            {
                throw new ArgumentException("Must provide at least one PieChartElement with a positive value");
            }

            // Define the rectangle that the pie chart will use
            // Use only half the width to leave room for the legend
            Rectangle rect = new Rectangle(1, 1, (s.Width / 2) - 2, s.Height - 2);

            Pen p = new Pen(Color.Black, 1);

            // Draw the first section at 0 degrees
            float startAngle = 0;
            int colorNum = 0;

            // Draw each of the pie shapes
            foreach (PieChartElement e in elements)
            {
                // Create a brush with a nice gradient
                Brush b = new LinearGradientBrush(rect, colors[colorNum++], Color.White, (float)45);

                // Calculate the degrees that this section will consume,
                // based on the percentage of the total
                float sweepAngle = (e.value / total) * 360;

                // Draw the filled in pie shapes
                g.FillPie(b, rect, startAngle, sweepAngle);

                // Draw the pie shape outlines
                g.DrawPie(p, rect, startAngle, sweepAngle);

                // Calculate the angle for the next pie shape by adding
                // the current shape's degrees to the previous total.
                startAngle += sweepAngle;
            }

            // Define the rectangleB that the legend will use
            Point lRectCornerB = new Point((s.Width / 2) + 2, 1);
            Size lRectSizeB = new Size(s.Width - (s.Width / 2) - 4, (s.Height / 2) - 2);
            Rectangle lRectB = new Rectangle(lRectCornerB, lRectSizeB);

            // Draw a black box with a white background for the legend.
            Brush bb = new SolidBrush(Color.Black);
            Pen bp = new Pen(Color.White, 1);
            g.FillRectangle(bb, lRectB);
            g.DrawRectangle(bp, lRectB);

            // Determine the number of vertical pixels for each legend item
            int vertb = (lRectB.Height - 10) / elements.Count;

            // Calculate the width of the legend box as 20% of the total legend width
            int legendWidthb = lRectB.Width / 5;

            // Calculate the height of the legend box as 75% of the legend item height
            int legendHeightb = (int)(vertb * 0.75);

            // Calculate a buffer space between elements
            int bufferb = (int)(vertb - legendHeightb) / 2;

            // Calculate the left border of the legend text
            int textXb = lRectCornerB.X + legendWidthb + bufferb * 2;

            // Calculate the width of the legend text
            int textWidthb = lRectB.Width - (lRectB.Width / 5) - (bufferb * 2);

            // Start the legend five pixels from the top of the rectangle
            int currentVertb = 5;
            int legendColorb = 0;

            foreach (PieChartElement e in elements)
            {
                // Create a brush with a nice gradient
                Rectangle thisRect = new Rectangle(lRectCornerB.X + bufferb, currentVertb + bufferb, legendWidthb, legendHeightb);
                Brush b = new LinearGradientBrush(thisRect, colors[legendColorb++], Color.White, (float)45);

                // Draw the legend box fill and border
                g.FillRectangle(b, thisRect);
                g.DrawRectangle(p, thisRect);

                // Define the rectangle for the text
                RectangleF textRect = new Rectangle(textXb, currentVertb + bufferb, textWidthb, legendHeightb);

                // Define the font for the text
                Font tf = new Font("Times New Roman", 12);

                // Create the foreground text brush
                Brush tb = new SolidBrush(Color.White);

                // Define the vertical and horizontal alignment for the text
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Near;
                sf.LineAlignment = StringAlignment.Center;

                // Draw the text
                g.DrawString(e.name + ": " + e.value.ToString(), tf, tb, textRect, sf);

                // Increment the current vertical location
                currentVertb += vertb;
            }
            Point lRectCornerW = new Point((s.Width / 2) + 2, (s.Height / 2) - 1);
            Size lRectSizeW = new Size(s.Width - (s.Width / 2) - 4, (s.Height / 2) - 2);
            Rectangle lRectW = new Rectangle(lRectCornerW, lRectSizeW);
            // Draw a black box with a white background for the legend.
            Brush wb = new SolidBrush(Color.White);
            Pen wp = new Pen(Color.Black, 1);
            g.FillRectangle(wb, lRectW);
            g.DrawRectangle(wp, lRectW);
            int vertw = (lRectW.Height - 10) / elements.Count;

            // Calculate the width of the legend box as 20% of the total legend width
            int legendWidthw = lRectW.Width / 5;

            // Calculate the height of the legend box as 75% of the legend item height
            int legendHeightw = (int)(vertw * 0.75);

            // Calculate a buffer space between elements
            int bufferw = (int)(vertw - legendHeightw) / 2;

            // Calculate the left border of the legend text
            int textXw = lRectCornerW.X + legendWidthw + bufferw * 2;

            // Calculate the width of the legend text
            int textWidthw = lRectW.Width - (lRectW.Width / 5) - (bufferw * 2);

            // Start the legend five pixels from the top of the rectangle
            int currentVertw = 205;
            int legendColorw = 0;

            foreach (PieChartElement e in elements)
            {
                // Create a brush with a nice gradient
                Rectangle thisRect = new Rectangle(lRectCornerB.X + bufferw, currentVertw + bufferw, legendWidthw, legendHeightw);
                Brush b = new LinearGradientBrush(thisRect, colors[legendColorw++], Color.White, (float)45);

                // Draw the legend box fill and border
                g.FillRectangle(b, thisRect);
                g.DrawRectangle(p, thisRect);

                // Define the rectangle for the text
                RectangleF textRect = new Rectangle(textXw, currentVertw + bufferw, textWidthw, legendHeightw);

                // Define the font for the text
                Font tf = new Font("Times New Roman", 12);

                // Create the foreground text brush
                Brush tb = new SolidBrush(Color.Black);

                // Define the vertical and horizontal alignment for the text
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Near;
                sf.LineAlignment = StringAlignment.Center;

                // Draw the text
                g.DrawString(e.name + ": " + e.value.ToString(), tf, tb, textRect, sf);

                // Increment the current vertical location
                currentVertw += vertw;
            }
            return bm;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
