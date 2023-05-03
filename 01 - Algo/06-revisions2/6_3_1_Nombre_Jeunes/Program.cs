namespace _6_3_1_Nombre_Jeunes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // VARIABLES

            uint age;
            int counter;
            string input;
            bool inputOk;

            // TRAITEMENT

            counter = 0;

            for (int i = 1; i <= 20; i++)
            {                
                do
                {
                    Console.Write("Saisir la valeur " + i + " : ");
                    input = Console.ReadLine() ?? "";
                    inputOk = uint.TryParse(input, out age);
                } while (!inputOk);

                if(age < 20)
                {
                    counter++;
                }
            }

            // AFFICHAGE

            Console.WriteLine(counter);
        }
    }
}