namespace _1_2_Hello_You
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String firstname;

            Console.WriteLine("Veuillez saisir votre prénom");
            firstname = Console.ReadLine();

            Console.WriteLine("Bonjour " + firstname + ".");
        }
    }
}