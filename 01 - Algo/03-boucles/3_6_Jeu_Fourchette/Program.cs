namespace _3_6_Jeu_Fourchette
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // VARIABLES

            int choice, n, min, max, attempts;
            string input;
            bool inputOk;
            Random rnd;

            // TRAITEMENT

            attempts = 0;
            min = 0;
            max = 100;

            rnd = new Random();
            n = rnd.Next(101);

            do
            {
                attempts++;

                do
                {
                    Console.Write("Saisir un nombre entier : ");
                    input = Console.ReadLine();
                    inputOk = int.TryParse(input, out choice);
                } while (!inputOk);

                if (choice < n)
                {
                    min = choice;
                }
                else
                {
                    max = choice;
                }

                if(choice != n)
                {
                    Console.WriteLine(min + " - " + max);
                }
            } while(choice != n);

            // AFFICHAGE

            Console.WriteLine("Bravo vous avez trouvé en " + attempts + " essais");
        }
    }
}