namespace _5_2_1_Conversion_Kilometres_Miles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // VARIABLES

            double kmDistance;
            double miDistance;
            string input;
            bool inputOk;

            // TRAITEMENT
            
            do
            {
                Console.Write("Saisir une valeur en kilomètres comprise entre 0.01 et 1 000 000 : ");
                input = Console.ReadLine();
                inputOk = double.TryParse(input, out kmDistance);
            } while (!inputOk);

            miDistance = kmDistance / 1.609;

            // AFFICHAGE

            Console.WriteLine(miDistance);
        }
    }
}