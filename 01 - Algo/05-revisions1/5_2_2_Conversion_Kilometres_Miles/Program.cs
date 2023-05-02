namespace _5_2_2_Conversion_Kilometres_Miles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // VARIABLES
            
            string unit;
            double value;
            double result;
            string input;
            bool inputOk;

            // TRAITEMENT

            result = 0;

            do
            {
                Console.Write("Saisir le sens de conversion (km ou mi) : ");
                unit = Console.ReadLine() ?? "";
            } while (unit != "km" && unit != "mi" && unit != "");

            if(unit == "")
            {
                unit = "km";
            }

            do
            {
                if(unit == "km")
                {
                    Console.Write("Saisir une valeur en mi : ");
                }
                else
                {
                    Console.Write("Saisir une valeur en km : ");
                }                
                input = Console.ReadLine() ?? "0";
                inputOk = double.TryParse(input, out value);
            } while (!inputOk);

            if (unit == "mi")
            {
                result = value / 1.609;
            }
            else if (unit == "km")
            {
                result = value * 1.609;
            }            

            // AFFICHAGE

            if(unit == "mi")
            {
                Console.WriteLine(result + " mi");
            }
            else
            {
                Console.WriteLine(result + " km");
            }            
        }
    }
}