namespace _2_4_TRI_NOMBRES
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // VARIABLES

            int a, b, c;
            bool inputOk;
            string input, sort;

            // TRAITEMENT
            
            do
            {
                Console.WriteLine("Saisir A");
                input = Console.ReadLine();
                inputOk = Int32.TryParse(input, out a);
            } while (!inputOk);

            do
            {
                Console.WriteLine("Saisir B");
                inputOk = Int32.TryParse(Console.ReadLine(), out b);
            } while (!inputOk);

            do
            {
                Console.WriteLine("Saisir C");
                inputOk = Int32.TryParse(Console.ReadLine(), out c);
            } while (!inputOk);

            if (a < b)
            {
                if(b < c)
                {
                    sort = "a b c";
                }
                else
                {
                    if(a < c)
                    {
                        sort = "a c b";
                    }
                    else
                    {
                        sort = "c a b";
                    }                    
                }
            }
            else
            {
                if(b < c)
                {
                    if(a < c)
                    {
                        sort = "b a c";
                    }
                    else
                    {
                        sort = "b c a";
                    }
                }
                else
                {
                    sort = "c b a";
                }
            }

            // AFFICHAGE

            Console.WriteLine(sort);
        }
    }
}