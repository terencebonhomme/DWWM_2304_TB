using System;

namespace _2_5_Bicyclette
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // VARIABLES

            bool goodWeather;
            bool bicyclePerfectState;
            bool immediateFixes;
            bool GoTInLivingRoom;
            bool GoTInLibrary;

            string action = "";

            // TRAITEMENT

            Console.WriteLine("\"o\" pour \"oui\" sinon n'importe quelle touche");

            Console.Write("Fera t'il beau ? (O/n)");
            goodWeather = Console.ReadLine() != "n";

            if (goodWeather)
            {
                Console.Write("Le vélo sera t'il en parfait état ? (O/n)");
                bicyclePerfectState = Console.ReadLine() != "n";

                if (bicyclePerfectState)
                {
                    action = "Je ferai une balade à bicyclette.";
                }
                else
                {
                    Console.WriteLine("Je ferai réparer mon vélo.");

                    Console.Write("Les réparations seront-elles immédiates ? (O/n)");
                    immediateFixes = Console.ReadLine() != "n";

                    if (immediateFixes)
                    {
                        action = "Je ferai une balade à bicyclette.";
                    }
                    else
                    {
                        action = "J'irai à pied jusqu'à l'étang pour ceuillir les joncs.";
                    }
                }                                
            } 
            else
            {
                Console.WriteLine("J'irai lire un livre.");

                Console.Write("Le tome de Game of Thrones sera dans le salon ? (O/n)");
                GoTInLivingRoom = Console.ReadLine() != "n";

                if (GoTInLivingRoom)
                {
                    action = "Je lirai le tome de Game of Thrones du salon dans mon fauteuil.";
                }
                else
                {
                    Console.WriteLine("J'irai à la bibliothèque.");

                    Console.Write("Le tome de Game of Thrones sera à la bibliothèque ? (O/n)");
                    GoTInLibrary = Console.ReadLine() != "n";

                    if (GoTInLibrary)
                    {
                        action = "Je lirai le tome de Game of Thrones de la bibliothèque dans mon fauteuil.";
                    }
                    else
                    {
                        action = "Je lirai un roman policier dans mon fauteuil.";
                    }
                }
            }

            // AFFICHAGE

            Console.WriteLine(action);
        }
    }
}