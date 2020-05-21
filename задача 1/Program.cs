using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    /*
Изменить программу вывода таблицы функции так, 
чтобы можно было передавать функции типа double (double, double). 
Продемонстрировать работу на функции с функцией 
a*x^2 и функцией a*sin(x).
*/
    
    
    public delegate double Fun(double x);
   
    class Program
    {
        public static void Table(Fun F, double x, double b)
        {
            Console.WriteLine("------ X ----- Y ------");
            while (x <= b)
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", x, F(x));
                x += 1;
            }
            Console.WriteLine("-----------------------");
        }
        static void Main()
        {
            Console.WriteLine("Первое значение х =  ");
            var a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Последнее значение х =  ");
            var b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Константа k =  ");
            int k = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Таблица функции k*x^2");
            Table(delegate (double x) { return a * x * x; }, a, b);
            
            Console.WriteLine("Таблица функции k*Sin");
            Table(delegate (double x) { return a * Math.Sin(x); }, a, b);
            
            Console.ReadKey();
        }
    }
}
