using System.Security.Cryptography;

namespace _2_1_Tri_Nombres
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // VARIABLES

            int a, b;
            string input, sort;
            bool inputOk;

            // TRAITEMENT

            do
            {
                Console.WriteLine("Saisir A");
                input = Console.ReadLine();
                inputOk = Int32.TryParse(input, out a);
            } while (!inputOk);

            do
            {
                Console.WriteLine("Saisir B");
                input = Console.ReadLine();
                inputOk = Int32.TryParse(input, out b);
            } while (!inputOk);

            sort = a < b ? a + " " + b : b + " " + a;

            // AFFICHAGE

            Console.WriteLine(sort);
        }
    }
}