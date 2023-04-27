namespace _4_3_Denombrer_Alphabet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // VARIABLES

            string text;
            int counter;

            // TRAITEMENT

            text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla sit amet justo egestas, imperdiet mauris ac, tincidunt mi. Aliquam lorem ligula, rhoncus a sagittis a, varius id diam. Maecenas viverra, turpis non ullamcorper varius, turpis velit efficitur risus, in vestibulum eros ante tincidunt tellus. Curabitur congue nisl id ultrices porta. Nullam ultrices nec ligula sit amet accumsan. Nullam elementum elit velit, eget lacinia lectus molestie at. Morbi molestie quis diam sit amet rhoncus. Phasellus luctus erat nec porta ornare. Curabitur eget hendrerit augue.";

            for (int letter = 'a'; letter <= 'z'; letter++)
            {
                counter = 0;

                for(int j = 0; j < text.Length; j++)
                {
                    if (letter == text[j])
                    {
                        counter++;
                    }
                }

                Console.WriteLine((char) letter + " : " + counter);
            }           

            // FIN PROGRAMME

            Console.ReadLine();   
        }
    }
}