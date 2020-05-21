using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task2
//ТАРАНУХА ЯНА
{
    /*
Модифицировать программу нахождения минимума функции так, 
чтобы можно было передавать функцию в виде делегата. 
а) Сделать меню с различными функциями и представить пользователю выбор, 
для какой функции и на каком отрезке находить минимум. 
Использовать массив (или список) делегатов, 
в котором хранятся различные функции.
     */

    class Program
    {
        public static double F1(double x)
        {
            double y = x * Math.Cos(x) - 10;
            //Console.WriteLine("F1 min =   " + x);
            return y;
        }
        public static double F2(double x)
        {
            double y = x * Math.Cos(x) + 10;
            //Console.WriteLine("F2 min =   " + x);
            return y;

        }
        public static void SaveFunc(string fileName, double a, double b, double h)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);

            Console.Write("Выбирете функцию. F1 - цифра 1; F2 - цифра 2:  ");
            int q = Convert.ToInt32(Console.ReadLine());
            double x = a;
            while (x <= b)
            {
                if (q == 1)
                {
                    bw.Write(F1(x));
                    x += h;
                }
                else
                {
                    bw.Write(F2(x));
                    x += h;
                }

            }
            bw.Close();
            fs.Close();
        }

        public static double Load(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            double min = double.MaxValue;
            double d;
            for (int i = 0; i < fs.Length / sizeof(double); i++)
            {

                d = bw.ReadDouble();
                if (d < min) min = d;
            }
            bw.Close();
            fs.Close();
            return min;
        }
        static void Main(string[] args)
        {


            Console.Write("Первое значение х =  ");
            var a = Convert.ToDouble(Console.ReadLine());

            Console.Write("Последнее значение х =  ");
            var b = Convert.ToDouble(Console.ReadLine());

            SaveFunc("data.bin", a, b, 1);
            Console.WriteLine(Load("data.bin"));

            SaveFunc("data.bin", a, b, 1);
            Console.WriteLine(Load("data.bin"));

            Console.ReadKey();
        }
    }
}
