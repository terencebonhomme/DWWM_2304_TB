namespace _05_revisions1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // VARIABLES

            int sum;
            int counter;
            int number;
            int[] perfectNumbers = new int[4];

            // TRAITEMENT

            counter = 0;
            number = 2;

            while(counter < 4)
            {
                sum = 0;

                for (int i = 1; i < number; i++)
                {
                    if(number % i == 0)
                    {
                        sum += i;
                    }
                }

                if(sum == number)
                {
                    perfectNumbers[counter] = number;
                    counter++;
                }

                number++;
            }

            // AFFICHAGE

            Console.WriteLine("Affichage des 4 premiers nombres parfaits : ");

            for(int i = 0; i < 4; i++)
            {
                Console.WriteLine(perfectNumbers[i] + " est un nombre parfait.");

            }

        }
    }
}