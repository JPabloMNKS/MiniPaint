using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCE3Paint
{
    public partial class Form1 : Form
    {
        
        Graphics g;
        int c=1;
        //        Pen punto = new Pen(Color.Black,1);

        Pen punto = new Pen(Color.Black );

        Point pini = new Point(10, 10);
        Point pfin = new Point(100, 100);
        Color color;
        public Form1()
        {
            InitializeComponent();
        }
        public int da()
        {
            int a = comboBox1.SelectedIndex;
            return a;
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
//            saveFileDialog1.DefaultExt = ".jpg";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            g = pictureBox1.CreateGraphics();
        }

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            label1.Text = "X: " + e.X.ToString();
            label2.Text = "Y: " + e.Y.ToString();
            if(e.Button == MouseButtons.Left)
            {
                pfin = e.Location;
                g.DrawLine(punto, pini, pfin);
                pini = pfin;
            }

        }

        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            label3.Text = "X1: "+ e.X.ToString();
            label4.Text = "X1: " + e.X.ToString();
            pini = e.Location;

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            punto.Color = colorDialog1.Color;
        }

        private void AbrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           c = comboBox1.SelectedIndex;
            punto.Width = c;
        }
    }
}
