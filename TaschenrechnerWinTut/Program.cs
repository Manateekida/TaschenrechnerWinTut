using System;
using System.Diagnostics;
using TaschenrechnerLibrary;


namespace TaschenrechnerProgram
{
    class Program
    {
        static void Main()
        {
            bool endApp = false;
            Calculator calculator = new Calculator();
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
                    Console.WriteLine("Ungültig. Bitte eine Zahl eingeben: ");
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
                    result = calculator.DoOperation(cleanNum1, cleanNum2, op);
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
                {
                    Trace.WriteLine("End Calculator Log");
                    endApp = true;
                }
            }
            return;
        }
    }
}