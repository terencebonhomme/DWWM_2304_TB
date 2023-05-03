namespace _3_5_Nombre_Premier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // VARIABLES

            int n;
            int i;
            bool isPrime, inputOk;
            string input;

            // TRAITEMENT

            do
            {
                Console.Write("Saisir un nombre entier : ");
                input = Console.ReadLine();
                inputOk = int.TryParse(input, out n);
            } while (!inputOk);

            isPrime = true;

            if(n < 2)
            {
                isPrime = false;
            }

            i = 2;
            while (isPrime && i < n / 2)
            {
                if(n % i == 0)
                {
                    isPrime = false;
                }

                i++;
            }

            // AFFICHAGE

            if (isPrime)
            {
                Console.WriteLine(n + " est un nombre premier");
            }
            else
            {
                Console.WriteLine(n + " n'est pas un nombre premier");
            }
        }
    }
}