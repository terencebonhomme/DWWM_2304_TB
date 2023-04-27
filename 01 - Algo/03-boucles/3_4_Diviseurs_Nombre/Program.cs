namespace _3_4_Diviseurs_Nombre
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // VARIABLES

            int n;
            string input;
            bool inputOk;

            // TRAITEMENT

            do
            {
                Console.Write("Saisir un nombre : ");
                input = Console.ReadLine();
                inputOk = int.TryParse(input, out n);
            } while (!inputOk);

            for (int i = 2; i <= n / 2; i++)
            {
                if (n % i == 0)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}