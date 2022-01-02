using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WycinanieObrazu
{
    public partial class Form1 : Form
    {
        private bool click1 = false, click2 = false;
        private Tuple<int, int> cord1, cord2;

        private int widthImage = 1, heigthImage = 1;

        public Form1() {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e) {
            int width = cord2.Item1 - cord1.Item1;
            int height = cord2.Item2 - cord1.Item2;

            Bitmap bitmap = new Bitmap(width+1, height+1);
            Bitmap bitmap2 = new Bitmap(widthImage, heigthImage);

            for (int i = cord1.Item1; i <= cord2.Item1; ++i) {
                for (int j = cord1.Item2; j <= cord2.Item2; ++j) {
                    Color c = ((Bitmap)pictureBox1.Image).GetPixel(i, j);
                    bitmap.SetPixel(i-cord1.Item1, j-cord1.Item2, c);
                }
            }

            try {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PNG|*.png";
                if(saveFileDialog.ShowDialog() == DialogResult.OK) {
                    bitmap.Save(saveFileDialog.FileName, ImageFormat.Png);
                }
            }
            catch (Exception) {
                MessageBox.Show("Wystąpił bląd");
            }
        }

        private void resetButton_Click(object sender, EventArgs e) {
            ResetImage();
        }

        private void deleteBtn_Click(object sender, EventArgs e) {
            Bitmap bitmap = new Bitmap(1, 1);
            bitmap.SetPixel(0, 0, Color.FromArgb(255, 255, 255));
            pictureBox1.Image = bitmap;
            pictureBox2.Image = bitmap;
            ResetImage();
        }

        private void getFileButton_Click(object sender, EventArgs e) {
            Bitmap bitmap;

            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Multiselect = false;
            if (openDialog.ShowDialog() == DialogResult.OK) {
                bitmap = new Bitmap(openDialog.FileName);
                widthImage = bitmap.Width;
                heigthImage = bitmap.Height;
                pictureBox1.Image = (Image)bitmap;
            }

            ResetImage();
        }

        private void Form1_Load(object sender, EventArgs e) {
            pictureBox1.BackColor = Color.FromArgb(100,200,124);

            Bitmap bitmap = new Bitmap(1,1);
            bitmap.SetPixel(0, 0, Color.FromArgb(255, 255, 255));

            panel1.AutoScroll = true;
            pictureBox1.Image = bitmap;

            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;

            pictureBox2.Hide();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                if (!click1) {
                    //label3.Text = e.X.ToString() + " " + e.Y.ToString();
                    cord1 = new Tuple<int, int>(e.X, e.Y);
                    click1 = true;
                }
                else if (!click2) {
                    //label4.Text = e.X.ToString() + " " + e.Y.ToString();
                    cord2 = new Tuple<int, int>(e.X, e.Y);
                    click2 = true;
                }
            }
            
            if(click1 && click2) {
                Bitmap bitmap = new Bitmap(widthImage, heigthImage);
                Random r = new Random();

                for (int i = 0; i < widthImage; ++i) {
                    for (int j = 0; j < heigthImage; ++j) {
                        if((i>=cord1.Item1 && i<= cord2.Item1) && (j>=cord1.Item2 && j <= cord2.Item2)) {
                            Color c = ((Bitmap)pictureBox1.Image).GetPixel(i, j);
                            bitmap.SetPixel(i, j, c);
                        }
                        else {
                            bitmap.SetPixel(i, j, Color.FromArgb(1, 1, 1));
                            
                        }
                    }
                }

                pictureBox2.Image = bitmap;
                pictureBox2.Show();
                pictureBox1.Hide();


            }

        }

        private void ResetImage() {
            Bitmap bitmapClear = new Bitmap(1, 1);
            bitmapClear.SetPixel(0, 0, Color.FromArgb(255, 255, 255));
            pictureBox2.Image = bitmapClear;
            pictureBox2.Hide();
            pictureBox1.Show();
            click1 = false;
            click2 = false;
        }

    }
}
