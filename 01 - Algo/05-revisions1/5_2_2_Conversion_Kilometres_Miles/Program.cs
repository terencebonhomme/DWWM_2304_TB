using System.Diagnostics;
using System.Xml.Linq;

namespace _5_2_2_Conversion_Kilometres_Miles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // VARIABLES
            
            string unit;
            double distance;
            double result;
            int spacePos;
            int i;
            string input;
            bool inputOk;
            bool parseOk;

            // TRAITEMENT

            do
            {
                Console.Write("Saisir une valeur entre 0,01 et 1000000 " +
                    "avec son unité (km ou mi) : ");
                input = Console.ReadLine() ?? "";

                spacePos = -1;

                i = 0;
                while (spacePos == -1 && i < input.Length)
                {
                    if (input.ElementAt(i) == ' ')
                    {
                        spacePos = i;
                    }
                    i++;
                }

                if (spacePos != -1)
                {
                    parseOk = double.TryParse(input.Substring(0, spacePos), out distance);
                    unit = input.Substring(spacePos + 1);
                }
                else
                {
                    parseOk = double.TryParse(input, out distance);
                    unit = "km";
                }
            } while (
                (distance < 0.01 || distance > 1_000_000) 
                || !parseOk 
                || unit != "km" && unit != "mi"
            );

            if (unit == "mi")
            {
                result = distance * 1.609;
            }
            else
            {
                result = distance / 1.609;                
            }            

            // AFFICHAGE

            if(unit == "mi")
            {
                Console.WriteLine(result + " km");
            }
            else
            {
                Console.WriteLine(result + " mi");
            }            
        }
    }
}