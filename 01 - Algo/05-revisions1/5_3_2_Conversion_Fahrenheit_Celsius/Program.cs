using System.Diagnostics;

namespace _5_3_2_Conversion_Fahrenheit_Celsius
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // VARIABLES
            
            string unit;
            string command;
            string input;
            int minimum;
            int maximum;
            bool inputOk;

            // TRAITEMENT

            do
            {
                Console.Write("Saisir une unité de mesure (C ou F) ou \"quit\" pour quitter : ");
                command = Console.ReadLine() ?? "";

                if (command == "C" || command == "F")
                {
                    unit = command;

                    do
                    {
                        Console.Write("Saisir l'entier minimum de la plage de valeurs : ");
                        input = Console.ReadLine() ?? "";
                        inputOk = int.TryParse(input, out minimum);
                    } while (!inputOk);

                    do
                    {
                        Console.Write("Saisir l'entier maximum de la plage de valeurs : ");
                        input = Console.ReadLine() ?? "";
                        inputOk = int.TryParse(input, out maximum);
                    } while (!inputOk);

                    if (unit == "F")
                    {
                        for (int i = minimum; i <= maximum; i++)
                        {
                            Console.WriteLine(((maximum - 32) * 5 / 9) + " C\n");
                        }
                    }
                    else
                    {
                        for (int i = minimum; i <= maximum; i++)
                        {
                            Console.WriteLine(((i * 9 / 5) + 32) + " F\n");
                        }
                    }
                }
            } while (command != "quit");
        }
    }
}