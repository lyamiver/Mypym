using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задача3
{
    class Program
    {
        static void Main(string[] args)
        {
            int r = 1;
            double u, y, x;
            Console.WriteLine("Введите координату x: ");
            while (!double.TryParse(Console.ReadLine(), out x))
            {
                Console.WriteLine("Ошибка, введите целое число");
            }
            Console.WriteLine("Введите координату y: ");
           
            while (!double.TryParse(Console.ReadLine(), out y))
            {
                Console.WriteLine("Ошибка, введите целое число");
            }
            if ((x*x+y*y < r) && (y < x / 2))
            {
                u = -3;
                Console.WriteLine(u);
            }
            else
            {
                 u = y * y;
                Console.WriteLine(u);
            }

            Console.ReadKey();
        }
        
    }
}
