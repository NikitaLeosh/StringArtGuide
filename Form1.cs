using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.ImageProcessing;
using static System.Net.Mime.MediaTypeNames;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Bitmap image;
        Bitmap greyScaleImage;
        static int width;
        static int height;


        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                image = new Bitmap(openFileDialog1.FileName);
                width = image.Width;
                height = image.Height;

                pictureBox1.Image = image;
            }
        }
        

        private async void button1_Click(object sender, EventArgs e)
        {
            var progress = new Progress<int>((prog) =>
            {
                UpdateProgressBar(prog); 
                Text = $"GreyScaling image {prog}%";
            });
            if (image != null)
            {
                button1.Enabled = false;
                await Task.Run(() =>
                {
                    GreyScaling.GreyScale10grd(image, ref greyScaleImage, progress);

                });
                button1.Enabled = true;
            }
            Text = "String Art Guide";
            pictureBox2.Image = greyScaleImage;

        }
        private void UpdateProgressBar(int i)
        {
            if (i == progressBar1.Maximum)
            {
                progressBar1.Maximum = i + 1;
                progressBar1.Value = i + 1;
                progressBar1.Maximum = i;
            }
            else
            {
                progressBar1.Value = i + 1;
            }
            progressBar1.Value = i;
        }
    }
}