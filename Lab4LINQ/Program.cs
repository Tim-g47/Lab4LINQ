using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


namespace Lab4LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Random ran = new Random();
            Stopwatch time = new Stopwatch();
            TimeSpan resulttime1; TimeSpan resulttime2;
            Console.WriteLine("Введите кол-во элементов");
            int n = Int32.Parse(Console.ReadLine());
            Console.WriteLine();
            string[] mas = new string[n];
            for (int i = 0; i < n; i++)
            {
                mas[i] = Convert.ToString(ran.Next(0, 1000000000)); //1000000000
            }

            Console.WriteLine("Чётные числа:");
            time.Restart();
            string[] vubor = mas.Where(s => (Convert.ToInt32(s) % 2 == 0)).OrderBy(s => s).ToArray();
            time.Stop();
            resulttime1 = time.Elapsed;
            time.Restart();
            vubor = mas.AsParallel().Where(s => (Convert.ToInt32(s) % 2 == 0)).OrderBy(s => s).ToArray();
            time.Stop();
            resulttime2 = time.Elapsed;
            Console.Write(String.Join(" ", vubor.Skip(vubor.Length / 10).Take(10)));
            Console.WriteLine();
            Console.Write("Время рассчёта: ");
            Console.WriteLine(resulttime1);
            Console.Write("Время рассчёта паралельно: ");
            Console.WriteLine(resulttime2);
            Console.WriteLine();

            Console.WriteLine("Нечётные числа:");
            time.Restart();
            vubor = mas.Where(s => (Convert.ToInt32(s) % 2 == 1)).OrderBy(s => s).ToArray();
            time.Stop();
            resulttime1 = time.Elapsed;
            time.Restart();
            vubor = mas.AsParallel().Where(s => (Convert.ToInt32(s) % 2 == 1)).OrderBy(s => s).ToArray();
            time.Stop();
            resulttime2 = time.Elapsed;
            Console.Write(String.Join(" ", vubor.Skip(vubor.Length / 10).Take(10)));
            Console.WriteLine();
            Console.Write("Время рассчёта: ");
            Console.WriteLine(resulttime1);
            Console.Write("Время рассчёта паралельно: ");
            Console.WriteLine(resulttime2);
            Console.WriteLine();

            Console.WriteLine("Сумма второй и предпоследней цифры равна 6:");
            time.Restart();
            vubor = mas.Where(s => s.Length == 2 || s.Length == 3).Where(s => int.Parse(s[1].ToString()) + int.Parse(s[^2].ToString()) == 6).OrderBy(s => s).ToArray();
            time.Stop();
            resulttime1 = time.Elapsed;
            time.Restart();
            vubor = mas.AsParallel().Where(s => s.Length == 2 || s.Length == 3).Where(s => int.Parse(s[1].ToString()) + int.Parse(s[^2].ToString()) == 6).OrderBy(s => s).ToArray(); 
            time.Stop();
            resulttime2 = time.Elapsed;
            Console.Write(String.Join(" ", vubor.Skip(vubor.Length / 10).Take(10)));
            if (vubor.Length == 0)
                Console.WriteLine("Таких чисел нет");
            else
                Console.WriteLine();
            Console.Write("Время рассчёта: ");
            Console.WriteLine(resulttime1);
            Console.Write("Время рассчёта паралельно: ");
            Console.WriteLine(resulttime2);
            Console.WriteLine();
            
            Console.WriteLine("Сумма цифр числа равен 13:");
            time.Restart();
            vubor = mas.Where(s => (s.ToCharArray().Select(i => int.Parse(i.ToString())).Sum() == 13)).OrderBy(s => s).ToArray();
            time.Stop();
            resulttime1 = time.Elapsed;
            time.Restart();
            vubor = mas.AsParallel().Where(s => s.ToCharArray().Select(i => int.Parse(i.ToString())).Sum() == 13).OrderBy(s => s).ToArray();
            time.Stop();
            resulttime2 = time.Elapsed;
            Console.Write(String.Join(" ", vubor.Skip(6).Take(10)));

            Console.WriteLine();
            Console.Write("Время рассчёта: ");
            Console.WriteLine(resulttime1);
            Console.Write("Время рассчёта паралельно: ");
            Console.WriteLine(resulttime2);
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
