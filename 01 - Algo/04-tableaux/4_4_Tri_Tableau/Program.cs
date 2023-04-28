namespace _4_4_Tri_Tableau
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // VARIABLES

            int[] a;
            int index = 0;
            int min;
            int temp;

            // TRAITEMENT

            a = new int[] { 128, 64, 8, 512, 16, 32, 256 };

            for (int i = 0; i < a.Length; i++)
            {
                min = a[i];

                for (int j = i + 1; j < a.Length; j++)
                {
                    if (a[j] < min)
                    {
                        min = a[j];
                        index = j;
                    }
                }

                temp = a[i];
                a[i] = a[index];
                a[index] = temp;                
            }

            // AFFICHAGE

            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i] + " ");
            }

            // FIN PROGRAMME

            Console.ReadLine();
        }
    }
}