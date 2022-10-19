using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2.ImageProcessing
{
    class GradesProcessor
    {
        private const int NumberOfGrades = 10;
        private static List<Bitmap> _grades;
        public GradesProcessor(Bitmap _image)
        {
            _grades = SetList(_image);
        }
        private static List<Bitmap> SetList(Bitmap image)
        {
            List<Bitmap> grades = new List<Bitmap>(9);

            for (int i=0; i < NumberOfGrades; i++)
            {
                grades.Add(new Bitmap(image.Width, image.Height));
            }
            return grades;
        }
        public void SaveGrades(List<Bitmap> Grades)
        {
            GradesSaver(Grades);
        }
        public void DivideGrades(Pixel pixel, int color, int Acolor)
        {
            GradesDivider(pixel, color, Acolor);
        }

        private static void GradesDivider(Pixel pixel, int color, int Acolor)
        {
            if (color >= 0 && color < 25)
                _grades[0].SetPixel(pixel.point.X, pixel.point.Y, Color.FromArgb(Acolor, color, color, color));
            else if (color >= 25 && color < 50)
                _grades[1].SetPixel(pixel.point.X, pixel.point.Y, Color.FromArgb(Acolor, color, color, color));
            else if (color >= 50 && color < 75)
                _grades[2].SetPixel(pixel.point.X, pixel.point.Y, Color.FromArgb(Acolor, color, color, color));
            else if (color >= 75 && color < 100)
                _grades[3].SetPixel(pixel.point.X, pixel.point.Y, Color.FromArgb(Acolor, color, color, color));
            else if (color >= 100 && color < 125)
                _grades[4].SetPixel(pixel.point.X, pixel.point.Y, Color.FromArgb(Acolor, color, color, color));
            else if (color >= 125 && color < 150)
                _grades[5].SetPixel(pixel.point.X, pixel.point.Y, Color.FromArgb(Acolor, color, color, color));
            else if (color >= 150 && color < 175)
                _grades[6].SetPixel(pixel.point.X, pixel.point.Y, Color.FromArgb(Acolor, color, color, color));
            else if (color >= 175 && color < 200)
                _grades[7].SetPixel(pixel.point.X, pixel.point.Y, Color.FromArgb(Acolor, color, color, color));
            else if (color >= 200 && color < 225)
                _grades[8].SetPixel(pixel.point.X, pixel.point.Y, Color.FromArgb(Acolor, color, color, color));
            else
                _grades[9].SetPixel(pixel.point.X, pixel.point.Y, Color.FromArgb(Acolor, color, color, color));

        }
        private static void GradesSaver(List<Bitmap> Grades)
        {

            Directory.CreateDirectory($"{Environment.CurrentDirectory}\\ShadesOfGray");

            for (int i = 0; i < Grades.Count; i++)
                Grades[i].Save($"{Environment.CurrentDirectory}\\ShadesOfGray\\Shade # {i + 1}.jpg");
        }
    }

}
