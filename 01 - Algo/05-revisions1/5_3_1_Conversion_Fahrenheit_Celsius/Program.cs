using System.Formats.Asn1;

namespace _5_3_1_Conversion_Fahrenheit_Celsius
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // VARIABLES

            string temperature;
            string unit;
            double value;
            double result;
            int spacePos;
            bool valueOk;

            // TRAITEMENT

            do
            {
                Console.Write("Saisir une température suivie de l'unité C/F (exemple 32 C) : ");
                temperature = Console.ReadLine() ?? "";

                spacePos = 0;
                unit = "";

                for (int i = 0; i < temperature.Length; i++)
                {
                    if (temperature.ElementAt(i) == ' ')
                    {
                        spacePos = i;
                    }
                }

                valueOk = double.TryParse(temperature.Substring(0, spacePos), out value);

                if(spacePos != 0)
                {
                    unit = temperature.Substring(spacePos + 1);
                }

            } while (!valueOk || (unit != "C" && unit != "F" || unit == "") || (value < -459.67 || value > 5_000_000));

            if(unit == "F")
            {
                result = (value - 32) * 5 / 9;
            }
            else
            {
                result = (value * 9 / 5) + 32;
            }

            // AFFICHAGE

            Console.WriteLine(String.Format("{0:0.##}", result));
        }
    }
}