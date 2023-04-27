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

            Console.WriteLine("Fera t'il beau ?");
            goodWeather = Console.ReadLine() == "o";

            if (goodWeather)
            {
                Console.WriteLine("Le vélo sera t'il en parfait état ?");
                bicyclePerfectState = Console.ReadLine() == "o";

                if (bicyclePerfectState)
                {
                    action = "Je ferai une balade à bicyclette.";
                }
                else
                {
                    Console.WriteLine("Je ferai réparer mon vélo.");

                    Console.WriteLine("Les réparations seront-elles immédiates ?");
                    immediateFixes = Console.ReadLine() == "o";

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

                Console.WriteLine("Le tome de Game of Thrones ne sera pas dans le salon ?");
                GoTInLivingRoom = Console.ReadLine() == "o";

                if (GoTInLivingRoom)
                {
                    action = "Je lirai le tome de Game of Thrones du salon dans mon fauteuil.";
                }
                else
                {
                    Console.WriteLine("J'irai à la bibliothèque.");

                    Console.WriteLine("Le tome de Game of Thrones sera à la bibliothèque ?");
                    GoTInLibrary = Console.ReadLine() == "o";

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