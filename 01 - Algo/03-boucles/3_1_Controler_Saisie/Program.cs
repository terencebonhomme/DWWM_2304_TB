namespace _3_1_Controler_Saisie
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // VARIABLES

            string firstname, result;
            int nbAttempts, maxAttempts;
            bool validResult;

            nbAttempts = 0;
            maxAttempts = 3;
            validResult = false;
            result = "";

            // TRAITEMENT

            do
            {
                Console.WriteLine("Saisir votre prenom");
                firstname = Console.ReadLine();
                nbAttempts++;
            } while(firstname.Length < 2 && nbAttempts < maxAttempts);

            if (nbAttempts < maxAttempts)
            {
                result = "Bonjour " + firstname;
            }

            // AFFICHAGE

            if (validResult)
            {
                Console.WriteLine(result);
            }            
        }
    }
}