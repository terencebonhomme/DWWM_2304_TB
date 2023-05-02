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
            double minimum;
            double maximum;
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
                        Console.Write("Saisir le minimum de la plage de valeurs : ");
                        input = Console.ReadLine() ?? "";
                        inputOk = double.TryParse(input, out minimum);
                    } while (!inputOk);

                    do
                    {
                        Console.Write("Saisir le maximum de la plage de valeurs : ");
                        input = Console.ReadLine() ?? "";
                        inputOk = double.TryParse(input, out maximum);
                    } while (!inputOk);

                    if (unit == "F")
                    {
                        minimum = (minimum - 32) * 5 / 9;
                        maximum = (maximum - 32) * 5 / 9;
                    }
                    else
                    {
                        minimum = (minimum * 9 / 5) + 32;
                        maximum = (maximum * 9 / 5) + 32;
                    }

                    Console.WriteLine("[" + String.Format("{0:0.##}", minimum) + ";" 
                        + String.Format("{0:0.##}", maximum) + "] " + (unit == "C" ? "F" : "C"));
                }
            } while (command != "quit");
        }
    }
}