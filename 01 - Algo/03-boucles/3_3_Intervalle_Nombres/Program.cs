namespace _3_3_Intervalle_Nombres
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // VARIABLES

            int a, b;
            string input, result;
            bool inputOk;

            // TRAITEMENT

            do
            {
                Console.Write("Saisir a : ");
                input = Console.ReadLine();
                inputOk = int.TryParse(input, out a);
            } while (!inputOk);

            do
            {
                Console.Write("Saisir b : ");
                input = Console.ReadLine();
                inputOk = int.TryParse(input, out b);
            } while (!inputOk);

            result = "";

            for(int i = a; i <= b; i++)
            {
                result += " " + i;
            }

            // AFFICHAGE

            Console.WriteLine(result);
        }
    }
}