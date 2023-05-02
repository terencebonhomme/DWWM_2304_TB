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

            if (a == retirementAge)
            {
                result = "C’est le moment de prendre sa retraite.";
            }
            else if (a > retirementAge)
            {
                result = "Vous êtes à la retraite depuis " + (a - retirementAge) + " années";            
            }
            else if (a < retirementAge)
            {
                result = "Il vous reste " + (retirementAge - a) + " années avant la retraite.";
            }
            else
            {
                result = "La valeur fournie n’est pas un âge valide.";
            }

            // AFFICHAGE

            Console.WriteLine(result);
        }
    }
}