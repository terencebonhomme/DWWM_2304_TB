namespace _6_3_2_Nombre_Personnes_Categorie
{
    internal class Program
    {
        static void Main(string[] args)
        {
            uint[] personAge;
            int counter;
            int nbPersonMinus20;
            int nbPersonPlus20;
            int nbPersonEqual20;
            int nbPerson;
            int ageLimit;
            string input;
            bool inputOk;
            bool test;

            nbPerson = 5;
            personAge = new uint[nbPerson];
            nbPersonMinus20 = 0;
            nbPersonPlus20 = 0;
            nbPersonEqual20 = 0;

            test = false;

            if (test)
            {
                // aucun jeune
                personAge = new uint[] { 47, 35, 68, 76, 34, 30, 31, 46, 57, 68, 75, 46, 53, 36, 31, 46, 69, 59, 30, 20 };

                // pas de non-jeunes
                personAge = new uint[] { 15, 5, 5, 6, 4, 2, 11, 12, 7, 8, 7, 3, 13, 16, 11, 18, 8, 9, 19, 3 };

                // des jeunes et des non-jeunes
                personAge = new uint[] { 45, 35, 65, 77, 38, 20, 20, 30, 30, 30, 20, 20, 30, 20, 30, 20, 20, 8, 15, 23 };
            }

            for (int i = 0; i < personAge.Length; i++)
            {                
                if (!test)
                {
                    do
                    {
                        Console.Write("Saisir l'âge de la personne " + (i + 1) + " : ");
                        input = Console.ReadLine() ?? "";
                        inputOk = uint.TryParse(input, out personAge[i]);
                    } while (!inputOk);
                }

                if(personAge[i] < 20)
                {
                    nbPersonMinus20++;
                }
                else if(personAge[i] > 20)
                {
                    nbPersonPlus20++;
                }
                else if (personAge[i] == 20)
                {
                    nbPersonEqual20++;
                }
            }

            if(nbPersonMinus20 == nbPerson)
            {
                Console.WriteLine("TOUTES LES PERSONNES ONT MOINS DE 20 ANS");
            }
            else if(nbPersonPlus20 + nbPersonEqual20 == nbPerson)
            {
                Console.WriteLine("TOUTES LES PERSONNES ONT PLUS DE 20 ANS");
            }
            else
            {
                Console.WriteLine("- de 20 : " + nbPersonMinus20 + ", + de 20 : " + nbPersonPlus20 + " et = à 20 : " +
                nbPersonEqual20);
            }
        }
    }
}