using System;


namespace TaschenrechnerWinTut
{
    class Calculator
    {
        public static double DoOperation(double num1, double num2, string op)
        {
            double result = double.NaN;

            switch (op)
            {
                case "a":
                    result = num1 + num2;
                    break;
                case "s":
                    result = num1 - num2;
                    break;
                case "m":
                    result = num1 * num2;
                    break;
                case "d":
                    if (num2 != 0)
                        result = num1 / num2;
                    break;
                default:
                    break;
            }
            return result;
        }
    }

    class Program
    {
        static void Main()
        {
            bool endApp = false;
            while (!endApp)
            {
                string numInput1 = "";
                string numInput2 = "";
                double result = 0;

                Console.WriteLine("Kleiner Taschenrechner.");
                Console.WriteLine("Bitte eine Zahl eingeben: ");

                numInput1 = Console.ReadLine();

                double cleanNum1 = 0;
                while (!double.TryParse(numInput1, out cleanNum1))
                {
                    Console.WriteLine("Ungültig. Bitte eine Zahl eingeben: ");
                    numInput1 = Console.ReadLine();
                }

                Console.WriteLine("Danke, jetzt die andere: ");
                numInput2 = Console.ReadLine();

                double cleanNum2 = 0;
                while (!double.TryParse(numInput2, out cleanNum2))
                {
                    Console.WriteLine("Ungültig. Bitte einezahl eingeben: ");
                    numInput2 = Console.ReadLine();
                }

                Console.WriteLine("Super. Bitte eine Operation angeben: ");
                Console.WriteLine("\ta - addieren");
                Console.WriteLine("\ts - subtrahieren");
                Console.WriteLine("\tm - multiplizieren");
                Console.WriteLine("\td - dividieren");

                string op = Console.ReadLine();

                try
                {
                    result = Calculator.DoOperation(cleanNum1, cleanNum2, op);
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("Des hat jetzt nicht so gut geklappt.");
                    }
                    else
                        Console.WriteLine("Dein ergebnis: {0:0.##}\n", result);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Da lief was Schief. \n - Details: " + e.Message);
                }

                Console.WriteLine("Bitte n eingeben wenn du nichtmehr willst, sonst geht noch eine Runde.");
                if (Console.ReadLine() == "n")
                    endApp = true;

                Console.WriteLine("\n");
            }
            return;
        }
    }
}