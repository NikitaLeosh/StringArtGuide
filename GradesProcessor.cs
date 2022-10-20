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
        private static int currentGrade;
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
            currentGrade = color / 25;
            if (currentGrade < 0)
                currentGrade++;
            if (currentGrade >= NumberOfGrades)
                currentGrade = NumberOfGrades-1;
            _grades[currentGrade].SetPixel(pixel.point.X, pixel.point.Y, Color.FromArgb(Acolor, color, color, color));

        }
        private static void GradesSaver(List<Bitmap> Grades)
        {

            Directory.CreateDirectory($"{Environment.CurrentDirectory}\\ShadesOfGray");

            for (int i = 0; i < Grades.Count; i++)
                Grades[i].Save($"{Environment.CurrentDirectory}\\ShadesOfGray\\Shade # {i + 1}.jpg");
        }
    }

}
