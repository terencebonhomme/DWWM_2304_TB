namespace _4_1_Recherche_Nombre
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // VARIABLES

            int n, i;
            string input;
            bool inputOk, found;
            int[] exemple; 

            // TRAITEMENT
            
            exemple = new int[] {8, 16, 32, 64, 128, 256, 512};
            found = false;

            do
            {
                Console.Write("Saisir n : ");
                input = Console.ReadLine();
                inputOk = int.TryParse(input, out n);
            } while (!inputOk);

            for(i = 0; i < exemple.Length && !found; i++)
            {
                if(n == exemple[i])
                {
                    found = true;
                    i--;
                }
            }

            // AFFICHAGE

            if (found)
            {
                Console.WriteLine(i);
            }
            else
            {
                Console.WriteLine("Nombre non trouvé");
            }
        }
    }
}