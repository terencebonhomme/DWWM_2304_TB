namespace _3_5_Nombre_Premier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // VARIABLES

            int n;
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

            for(int i = 2; i < n / 2 && isPrime; i++)
            {
                if(n % 2 == 0)
                {
                    isPrime = false;
                }
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