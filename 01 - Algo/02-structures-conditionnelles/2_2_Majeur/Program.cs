using System.Text;

namespace _2_2_Majeur
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // VARIABLES

            uint a;
            bool inputOk;
            string result;

            // TRAITEMENT

            do
            {
                Console.WriteLine("Saisir votre âge");
                inputOk = UInt32.TryParse(Console.ReadLine(), out a);
            } while (!inputOk);


            if(a >= 18)
            {
                result = "Vous êtes majeur";
            } 
            else if(a < 0)
            {
                result = "Vous n’êtes pas encore né";
            } 
            else
            {
                result = "Vous êtes mineur";
            }

            // AFFICHAGE

            Console.WriteLine(result);                     
        }
    }
}