using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCE3Paint
{
    public partial class Form1 : Form
    {
        string funcionsita = "";
        bool soltar = true;
        int px = 0;
        int py = 0;
        int pxf = 0;
        int pyf = 0;

        Graphics g;
        int c=1;
        //        Pen punto = new Pen(Color.Black,1);

        Pen punto = new Pen(Color.Black);

        Point pini = new Point(10, 10);
        Point pfin = new Point(100, 100);
        Color color;
        Image imagen;
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            g = pictureBox1.CreateGraphics();
            btn1.FlatStyle = FlatStyle.Flat;
        }

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            label1.Text = "X: " + e.X.ToString();
            label2.Text = "Y: " + e.Y.ToString();
  /*          if(e.Button == MouseButtons.Left)
            {
                pfin = e.Location;
                g.DrawLine(punto, pini, pfin);
//                g.DrawImage(pictureBox1.Image, e.X, e.Y);
                pini = pfin;
            }*/

            if (e.Button == MouseButtons.Left && funcionsita == "Linea")
            {
                pfin = e.Location;
                g.DrawLine(punto, pini, pfin);
                pini = pfin;
            }
            else if (e.Button == MouseButtons.Left && funcionsita == "Rectangulo" &&  soltar == false)
            {
                pfin = e.Location;
                g.DrawRectangle(punto, px, py, e.X-px, e.Y-py);
                pini = pfin;
            }
            else if (e.Button == MouseButtons.Left && funcionsita == "Pincel")
            {
                pfin = e.Location;
                g.DrawImage(pictureBox2.Image, e.X, e.Y);
                pini = pfin;
            }
            else if (e.Button == MouseButtons.Left && funcionsita == "Goma")
            {
                pfin = e.Location;
                g.DrawImage(goma.Image, e.X, e.Y);
                pini = pfin;
            }


        }

        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            label3.Text = "X1: "+ e.X.ToString();
            label4.Text = "Y1: " + e.X.ToString();
            pini = e.Location;
            px = e.X;
            py = e.Y;
            soltar = false;

        }
        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            pxf = e.X - px;
            pyf = e.Y - py;
            soltar = true;
        }


        private void Button2_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            punto.Color = colorDialog1.Color;
            pictureBox3.BackColor = colorDialog1.Color;
        }

        private void AbrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "JPG(*.JPG)|*.jpg";
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                imagen = Image.FromFile(openFileDialog1.FileName);
                pictureBox1.Image = imagen;
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            punto.Width = comboBox1.SelectedIndex;
        }

        private void GuardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = "jpg";
            save.Filter = "Image files(*.jpg)|*.jpg |Image Files(*.png)|*.png";

            if(save.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image.Save(save.FileName);
            }

        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            btn6.FlatStyle = FlatStyle.Standard;
            btn2.FlatStyle = FlatStyle.Standard;
            btn3.FlatStyle = FlatStyle.Standard;
            btn4.FlatStyle = FlatStyle.Standard;
            btn5.FlatStyle = FlatStyle.Standard;
            btn1.FlatStyle = FlatStyle.Flat;
            funcionsita = "";
        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            btn1.FlatStyle = FlatStyle.Standard;
            btn6.FlatStyle = FlatStyle.Standard;
            btn3.FlatStyle = FlatStyle.Standard;
            btn4.FlatStyle = FlatStyle.Standard;
            btn5.FlatStyle = FlatStyle.Standard;
            btn2.FlatStyle = FlatStyle.Flat;
            funcionsita = "Linea";
        }

        private void Btn3_Click(object sender, EventArgs e)
        {
            btn1.FlatStyle = FlatStyle.Standard;
            btn2.FlatStyle = FlatStyle.Standard;
            btn6.FlatStyle = FlatStyle.Standard;
            btn4.FlatStyle = FlatStyle.Standard;
            btn5.FlatStyle = FlatStyle.Standard;
            btn3.FlatStyle = FlatStyle.Flat;
            funcionsita = "Rectangulo";

        }

        private void Btn4_Click(object sender, EventArgs e)
        {
            btn1.FlatStyle = FlatStyle.Standard;
            btn2.FlatStyle = FlatStyle.Standard;
            btn3.FlatStyle = FlatStyle.Standard;
            btn6.FlatStyle = FlatStyle.Standard;
            btn5.FlatStyle = FlatStyle.Standard;
            btn4.FlatStyle = FlatStyle.Flat;
            funcionsita = "Pincel";
        }

        private void Btn5_Click(object sender, EventArgs e)
        {
            btn1.FlatStyle = FlatStyle.Standard;
            btn2.FlatStyle = FlatStyle.Standard;
            btn3.FlatStyle = FlatStyle.Standard;
            btn4.FlatStyle = FlatStyle.Standard;
            btn6.FlatStyle = FlatStyle.Standard;
            btn5.FlatStyle = FlatStyle.Flat;
            funcionsita = "Goma";
        }
        private void Btn6_Click(object sender, EventArgs e)
        {
            btn1.FlatStyle = FlatStyle.Standard;
            btn2.FlatStyle = FlatStyle.Standard;
            btn3.FlatStyle = FlatStyle.Standard;
            btn4.FlatStyle = FlatStyle.Standard;
            btn5.FlatStyle = FlatStyle.Standard;
            btn6.FlatStyle = FlatStyle.Flat;
            pictureBox1.Invalidate();
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBox2.Load(comboBox2.Text.ToString() + ".jpg");
        }

        private void SalirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
