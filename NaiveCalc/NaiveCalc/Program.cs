using System;

namespace NaiveCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            bool flag = true;
            int mode = 0;
            double a = 0, b = 0, c = 0;
            char[] op = { ' ', '+', '-', '*', '/' };
            while (flag)
            {
                mode = SelectMode();
                if (mode == 0)
                {
                    Console.WriteLine("Now quit");
                    flag = false;
                    continue;
                }
                if (mode < 0 || mode > 4)
                {
                    Console.WriteLine("Invalid mode selected. Retry now");
                    continue;
                }
                Console.WriteLine($"Now calc a {op[mode]} b");
                LoadParam(ref a, ref b);
                Calc(a, b, GetFunc(mode));
                if (! (mode == 4 && b.Equals(0.0)))
                {
                    Console.WriteLine($"{a} {op[mode]} {b} = {c}");
                }
            }
        }

        private static int SelectMode()
        {
            Console.WriteLine("Select mode:");
            Console.WriteLine("  1: +");
            Console.WriteLine("  2: -");
            Console.WriteLine("  3: *");
            Console.WriteLine("  4: /");
            Console.WriteLine("  0: quit");
            bool flag = true;
            string modeStr;
            int mode = 0;
            while (flag)
            {
                try
                {
                    Console.Write("> ");
                    modeStr = Console.ReadLine();
                    mode = Int32.Parse(modeStr);
                    if (mode < 0 || mode > 4)
                    {
                        throw new Exception();
                    }
                    flag = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return mode;
        }

        private static void LoadParam(ref double a, ref double b)
        {
            bool flag = true;
            while (flag)
            {
                try
                {
                    Console.WriteLine("Input a: ");
                    Console.Write("> ");
                    a = Double.Parse(Console.ReadLine());
                    flag = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            flag = true;
            while (flag)
            {
                try
                {
                    Console.WriteLine("Input b: ");
                    Console.Write("> ");
                    b = Double.Parse(Console.ReadLine());
                    flag = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static double Calc(double a, double b, Func<double, double, double> func)
        {
            return func(a, b);
        }

        private static Func<double, double, double> GetFunc(int mode)
        {
            Func<double, double, double> func = null;
            switch (mode)
            {
                case 1:
                    func = (a, b) => a + b;
                    break;
                case 2:
                    func = (a, b) => a - b;
                    break;
                case 3:
                    func = (a, b) => a * b;
                    break;
                case 4:
                    func = (a, b) =>
                    {
                        if (b.Equals(0.0))
                        {
                            Console.WriteLine("Divisor cannot be zero!");
                            return 0;
                        }
                        else
                        {
                            return a / b;
                        }
                    };
                    break;
                default:
                    break;
            }
            return func;
        }
    }
}
