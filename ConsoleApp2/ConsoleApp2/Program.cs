using System;
using System.Reflection.Metadata;
using System.Xml.Schema;

namespace ConsoleApp2
{
    class Program
    {
        static double Try_read()
        {
            double number;
            bool beacon;
            Console.Write("Введите R= ");
            do
            {
                string input = Console.ReadLine().Replace(',', '.');
                beacon = double.TryParse(input, out number);
                if (beacon == false)
                {
                    input = input.Replace('.', ',');
                    beacon = double.TryParse(input, out number);
                    if (beacon == false)
                    {
                        Console.WriteLine("Обнаружен некорректный ввод! Пожалуйста, повторите ввод.\n");
                    }
                }
                if (number < 0 || number > 2)
                {
                    Console.WriteLine("R не попало в диапозон! Пожалуйста, повторите ввод.\n");
                }
            } while ((beacon == false) || (number < 0 || number > 2));
            return number;
        }
        static double segment1(double x)
        {

            return 2.0;
        }
        static double segment2(double x)
        {
            double y = x / 4 + 0.5;
            return y;
        }
        static double segment3(double x, double R)
        {
            double a = -2.0;
            double b = 2.0;
            double y;

            double pattern = 2.0;
            if (R == pattern)
            {
                y = -Math.Sqrt(R * R - (x - a) * (x - a)) + b;
            }
            else
            {
                if (R == 0 && x == -2)
                {
                    return a;
                }
                else
                {

                    if (-x < Math.Abs(Math.Abs(a) - R))
                    {
                        Console.WriteLine("Функция не определена");
                        y = -100.0;
                    }
                    else
                    {
                        y = -Math.Sqrt(R * R - (x - a) * (x - a)) + b;
                    }

                }
            }
            return y;
        }
        static double segment4(double x, double R)
        {
            double a = 0;
            double b = 0;
            double y;
            double pattern = 2.0;
            if (R == pattern)
            {
                y = Math.Sqrt(R * R - (x - a) * (x - a)) - b;
            }
            else
            {
                if (R == 0 && x == 0)
                {
                    return 0.0;
                }
                else
                {
                    if (x > Math.Abs(R - a))
                    {
                        Console.WriteLine("Функция не определена");
                        y = -100.0;
                    }
                    else
                    {
                        y = Math.Sqrt(R * R - (x - a) * (x - a)) - b;
                    }
                }
            }
            return y;
        }
        static double segment5(double x)
        {
            double y = -x + 2;
            return y;
        }
        static void Main(string[] args)
        {
            double x;
            double R = Try_read();
            for (int i= 0; i <= 50; i ++)
            {
                x = -7 + 0.2 * i;
                x = Math.Round(x, 2);
                if (x < -7)
                {
                    Console.WriteLine("Функция не определена");
                }
                else if (x < -6)
                {
                    Console.WriteLine("y({0:0.00}) = {1:0.00}", x, segment1(x));
                }
                else if (i == 5)
                {
                    Console.WriteLine("y({0:0.00}) = {1:0.00}", x, segment1(x));
                    Console.WriteLine("y({0:0.00}) = {1:0.00}", x, segment2(x));
                }
                else if (x <= -2)
                {
                    Console.WriteLine("y({0:0.00}) = {1:0.00}", x, segment2(x));
                }
                else if (x < 0)
                {

                    double check = segment3(x, R);
                    if (check != -100.0)
                    {
                        Console.WriteLine("y({0:0.00}) = {1:0.00}", x, segment3(x, R));
                    }
                }
                else if (x <= 2)
                {
                    double check = segment4(x, R);
                    if (check != -100.0)
                    {
                        Console.WriteLine("y({0:0.00}) = {1:0.00}", x, segment4(x, R));
                    }
                }
                else if (x <= 3)
                {
                    Console.WriteLine("y({0:0.00}) = {1:0.00}", x, segment5(x));
                }
                else if (x > 3)
                {
                    Console.WriteLine("Функция не определена");
                }
            }
        }
    }
}
