namespace _1_3_Moyenne
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            int number1, number2;
            double average;
            bool inputOk;

            do
            {
                Console.Write("Veuillez saisir un premier nombre : ");
                input = Console.ReadLine();
                inputOk = int.TryParse(input, out number1);
            } while (!inputOk);

            do
            {
                Console.Write("Veuillez saisir un second nombre : ");
                input = Console.ReadLine();
                inputOk = int.TryParse(input, out number2);
            } while (!inputOk);

            average = (number1 + number2) / 2d;

            Console.WriteLine("La moyenne de " + number1 + " et " + number2 + " est : " + average.ToString("#.##"));
        }
    }
}