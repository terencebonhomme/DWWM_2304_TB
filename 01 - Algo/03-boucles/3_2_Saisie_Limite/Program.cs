namespace _3_2_Saisie_Limite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // VARIABLES

            string input, password, result;
            int nbAttempts, maxAttempts;

            nbAttempts = 0;
            maxAttempts = 3;
            password = "formation";

            // TRAITEMENT

            do
            {
                Console.WriteLine("Saisir le mot de passe");
                input = Console.ReadLine();
                nbAttempts++;
            } while (input != password && nbAttempts < maxAttempts);

            if(input == password)
            {
                result = "Vous êtes connecté";
            }
            else
            {
                result = "Votre compte est bloqué";
            }

            // AFFICHAGE

            Console.WriteLine(result);
        }
    }
}