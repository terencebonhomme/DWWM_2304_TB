namespace _1_6_Inversion_2_valeurs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a, b, temp;
            string input;
            bool inputOk;

            do
            {
                Console.WriteLine("Saisir A");
                input = Console.ReadLine();
                inputOk = int.TryParse(input, out a);
            } while (!inputOk);

            do
            {
                Console.WriteLine("Saisir B");
                input = Console.ReadLine();
                inputOk = int.TryParse(input, out b);
            } while (!inputOk);

            Console.WriteLine(a + " " + b);

            temp = a;
            a = b;
            b = temp;

            Console.WriteLine(a + " " + b);
        }
    }
}