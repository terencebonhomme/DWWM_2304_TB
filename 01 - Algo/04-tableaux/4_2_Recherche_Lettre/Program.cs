namespace _4_2_Recherche_Lettre
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // VARIABLES

            int indice;
            int occurenceNb;
            char letter;
            string str;
            bool isEmpty;

            // TRAITEMENT

            isEmpty = false;
            occurenceNb = 0;
            indice = 0;

            Console.Write("Saisir une phrase : ");
            str = Console.ReadLine();

            if(str.Length == 0 || str[0] == '.')
            {
                Console.WriteLine("LA CHAINE EST VIDE");
                isEmpty = true;
            }
           
            if (!isEmpty)
            {
                Console.Write("Saisir une lettre : ");
                letter = (char)Console.Read();

                for(int i = 0; i < str.Length && str[i] != '.'; i++)
                {
                    if(letter == str[i])
                    {
                        occurenceNb++;
                    }
                }

                Console.WriteLine(occurenceNb);
            }

            // FIN PROGRAMME

            Console.ReadLine();
        }
    }
}