using System;
using System.Numerics;

namespace Zespo12CS
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                try
                {
                    Console.WriteLine("Real Imaginary");
                    string[] s = Console.ReadLine().Split();
                    double x = double.Parse(s[0]), y = double.Parse(s[1]);
                    Complex input = new Complex(x, y);
                    Console.WriteLine($"f(z) = { F(input) }, g(z) = { FInverse(input) }, f(g(z)) = { F(FInverse(input)) } = g(f(z)) = { FInverse(F(input)) }");
                    //Console.WriteLine($"Alternative g(z) = {GAlt(input) }");
                    if (x == 0 && y == 1)
                    {
                        Console.WriteLine("Undefined");
                        continue;
                    }
                    if (x == 0)
                    {
                        Real0();
                    }
                    else
                    {
                        RealConst(x);
                    }
                    if (y == 1)
                    {
                        Imaginary1();
                    }
                    else
                    {
                        ImaginaryConst(y);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    Console.WriteLine("");
                }
            } 
            while (true);
        }

        static Complex F(Complex z)
        {
            return (z + new Complex(1, 1)) / (z + new Complex(0, -1));
        }

        static Complex FInverse(Complex z)
        {
            return ((z * new Complex(0, 1)) + new Complex(1, 1)) / (z + new Complex(-1, 0));
        }

        /*static Complex FAlt (Complex z)
        {
            double x = z.Real, y = z.Imaginary;
            double d = ((x - 1d) * (x - 1d)) + (y * y);
            return new Complex();
        }*/

        static Complex GAlt(Complex z)
        {
            double x = z.Real, y = z.Imaginary;
            double d = ((x - 1d) * (x - 1d)) + (y * y);
            double r = x + (2d * y) - 1d;
            double i = (x * x) + (y * y) - y - 1d;
            return new Complex(r / d, i / d);
        }

        static void RealConst(double a)
        {
            Console.WriteLine($"f(z) on circle (x - { ((2d * a) + 1d) / (2d * a) })^2 + (y - { 1d / a })^2 = { 5d / (4d * a * a) } for constant Re");
        }

        static void ImaginaryConst(double b)
        {
            Console.WriteLine($"f(z) on circle (x - { b / (b - 1) })^2 + (y + { 1d / (2d * (b - 1d))})^2 = { 5d / (4d * (b - 1d) * (b - 1d)) } for constant Im");
        }

        static void Real0()
        {
            Console.WriteLine("f(z) on straight line x + 2y - 1 = 0");
        }

        static void Imaginary1()
        {
            Console.WriteLine("f(z) on straight line 2x - y - 2 = 0");
        }
    }
}
