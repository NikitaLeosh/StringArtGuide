using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace WindowsFormsApp2.ImageProcessing
{
    internal class GreyScaling
    {
        public static int prog { get; private set; }
        private static readonly List<Bitmap> GradesList = new List<Bitmap>(9);

        public static void GreyScale10grd(Bitmap image, ref Bitmap greyScaleImage, IProgress<int> progress)
        {
            for(int i=0; i<10; i++)
            {
                GradesList.Add(new Bitmap(image.Width, image.Height));
            }

            Color color;
            greyScaleImage = new Bitmap(image.Width, image.Height);
            GradesProcessor gradesProcessor = new GradesProcessor(image);
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    color = image.GetPixel(x, y);

                    int a = color.A;
                    int r = color.R;
                    int g = color.G;
                    int b = color.B;

                    int avg = (r + g + b) / 3;
                    int avg10grade = (avg / 25) * 25;
                    greyScaleImage.SetPixel(x, y, Color.FromArgb(a, avg10grade, avg10grade, avg10grade));
                    var pixelForSaving = new Pixel()
                    {
                        point = new Point() { X = x, Y = y },
                        color = Color.FromArgb(a, avg10grade, avg10grade, avg10grade)
                    };
                    gradesProcessor.DivideGrades(pixelForSaving, avg10grade, a);
                }
                 progress.Report((int)(((double)y / image.Height) * 100) + 1);
            }
            gradesProcessor.SaveGrades(GradesList); 
        }
        


    }
}
