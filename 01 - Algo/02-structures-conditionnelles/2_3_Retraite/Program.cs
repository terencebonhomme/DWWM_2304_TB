namespace _2_3_Retraite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // VARIABLES

            uint a, retirementAge = 60;
            bool isRetired;
            string input, result;

            // TRAITEMENT

            do
            {
                Console.WriteLine("Saisir votre age");
                input = Console.ReadLine();
            } while (!UInt32.TryParse(input, out a));

            if (a >= retirementAge)
            {
                Console.WriteLine("Etes-vous à la retraite ?");
                isRetired = Console.ReadLine().ToLower() == "o";

                if (isRetired)
                {
                    result = "Vous êtes à la retraite depuis " + (a - retirementAge) + " années";
                }
                else
                {
                    result = "C’est le moment de prendre sa retraite.";
                }
            }
            else
            {
                result = "Il vous reste " + (retirementAge - a) + " années avant la retraite.";
            }

            // AFFICHAGE

            Console.WriteLine(result);
        }
    }
}