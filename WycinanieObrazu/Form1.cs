using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            int width = cord2.Item1 - cord1.Item1 + 1;
            int height = cord2.Item2 - cord1.Item2 + 1;

            Bitmap bitmap = new Bitmap(width, height);
            Bitmap bitmap2 = new Bitmap(widthImage, heigthImage);

            /*for (int i = cord1.Item1; i <= cord2.Item1; ++i) {
                for (int j = cord1.Item2; j <= cord2.Item2; ++j) {
                    //MessageBox.Show(i.ToString()+" "+j.ToString());
                    MessageBox.Show((i - cord1.Item1).ToString()+" "+height.ToString());
                    Color c = ((Bitmap)pictureBox2.Image).GetPixel(i, j);
                    bitmap.SetPixel(i - cord1.Item1, j - cord2.Item1, c);
                }
            }*/
            
            //MessageBox.Show(pictureBox1.Size.Width.ToString());
            
            for (int i = 0; i < widthImage; ++i) {
                for (int j = 0; j < heigthImage; ++j) {
                    if ((i >= cord1.Item1 && i <= cord2.Item1) && (j >= cord1.Item2 && j <= cord2.Item2)) {
                        //bitmap.SetPixel(i, j, Color.FromArgb(pictureBox1.BackColor.R, pictureBox1.BackColor.G, pictureBox1.BackColor.B));
                        Color c = ((Bitmap)pictureBox1.Image).GetPixel(i, j);
                        bitmap2.SetPixel(i, j, c);
                        //bitmap.SetPixel(i, j, Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255)));
                    }
                    else {
                        bitmap2.SetPixel(i, j, Color.FromArgb(0, 1, 1, 1));

                    }
                }
            }

            try {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                if(saveFileDialog.ShowDialog() == DialogResult.OK) {
                    //bitmap2.Save("..\\WycinanieObrazu\\WycinanieObrazu\\Obrazy\\obraz2.jpg");
                    bitmap2.Save(saveFileDialog.FileName);
                    //File.WriteAllBytes(saveFileDialog.FileName, );
                }
            }
            catch (Exception) {
                MessageBox.Show("Wystąpił bląd");
            }
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
        }

        private void Form1_Load(object sender, EventArgs e) {
            /*for(int i=0; i<100; ++i) {
                for(int j=0; j<100; ++j) {
                    pictureBox1.BackColor = Color.FromArgb(100,200,124);
                }
            }*/
            pictureBox1.BackColor = Color.FromArgb(100,200,124);

            Bitmap bitmap = new Bitmap(400,400);

            Random r = new Random();

            for(int i=0; i<400; ++i) {
                for(int j=0; j<400; ++j) {
                    //bitmap.SetPixel(i,j,Color.FromArgb(r.Next(0,255), r.Next(0, 255), r.Next(0, 255)));
                    bitmap.SetPixel(i,j,Color.FromArgb(255,255,255));
                }
            }

            panel1.AutoScroll = true;
            pictureBox1.Image = bitmap;

            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;

            pictureBox2.Hide();

            //pictureBox1.Image 
            //bitmap = new Bitmap("..\\WycinanieObrazu\\WycinanieObrazu\\Obrazy\\obraz.jpg");
            //pictureBox1.Image = (Image)bitmap;

        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                if (!click1) {
                    label3.Text = e.X.ToString() + " " + e.Y.ToString();
                    cord1 = new Tuple<int, int>(e.X, e.Y);
                    click1 = true;
                }
                else if (!click2) {
                    label4.Text = e.X.ToString() + " " + e.Y.ToString();
                    cord2 = new Tuple<int, int>(e.X, e.Y);
                    click2 = true;
                }
            }
            
            if(click1 && click2) {
                Bitmap bitmap = new Bitmap(widthImage, heigthImage);
                Random r = new Random();
                //Bitmap bitmap = new Bitmap(Math.Abs(cord2.Item1 - cord1.Item1 + 1), Math.Abs(cord2.Item2 - cord1.Item2 + 1));
                /*for (int i=cord1.Item1; i<cord2.Item1; ++i) {
                    for(int j=cord1.Item2; j<cord2.Item2; ++j) {
                        //bitmap.SetPixel(i, j, Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255)));
                        //pictureBox1.                
                        
                    }
                }*/

                //pictureBox1.DrawToBitmap(bitmap, pictureBox1.ClientRectangle);
                //Color color = bitmap.GetPixel(x)

                for (int i = 0; i < widthImage; ++i) {
                    for (int j = 0; j < heigthImage; ++j) {
                        if((i>=cord1.Item1 && i<= cord2.Item1) && (j>=cord1.Item2 && j <= cord2.Item2)) {
                            //bitmap.SetPixel(i, j, Color.FromArgb(pictureBox1.BackColor.R, pictureBox1.BackColor.G, pictureBox1.BackColor.B));
                            Color c = ((Bitmap)pictureBox1.Image).GetPixel(i, j);
                            bitmap.SetPixel(i, j, c);
                            //bitmap.SetPixel(i, j, Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255)));
                        }
                        else {
                            bitmap.SetPixel(i, j, Color.FromArgb(1, 1, 1));
                            
                        }
                    }
                }
                //bitmap.MakeTransparent();

                pictureBox2.Image = bitmap;
                pictureBox2.Show();
                pictureBox1.Hide();
                //pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;


            }

        }

        /*private void pictureBox1_Click(object sender, MouseEventArgs e) {
            label3.Text = "Clicked";
            //label3.Text = pictureBox1.Location.X.ToString() + " " + pictureBox1.Location.Y.ToString();
            if (e.Button == MouseButtons.Left) {
                label3.Text = e.X.ToString() + " " + e.Y.ToString();
                //label4.Text = panel1.Width.ToString();
            }
                //label3.Text = pictureBox1.ClientRectangle.Width.ToString() + " " + pictureBox1.ClientRectangle.Height.ToString();
        }*/


    }

}
