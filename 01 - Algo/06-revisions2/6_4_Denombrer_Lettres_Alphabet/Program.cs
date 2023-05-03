namespace _6_4_Denombrer_Lettres_Alphabet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // VARIABLES

            string text;
            int consonantNb;
            int vowelNb;
            int digitNb;
            int digitSum;
            double average;

            // TRAITEMENT

            digitNb = 0;
            vowelNb = 0;
            consonantNb = 0;
            digitSum = 0;            
            average = 0;
                       
            text = "Lorem ipsum dolor6 sit amet,3 consectetur adip7iscing elit. Inte9ger9 vitae interdum5 magna. Etiam mol9estie 2odio et consequat bibendum.";            

            for (int i = 0; i < text.Length; i++)
            {
                if ("0123456789".Contains(text[i]))
                {
                    digitNb++;
                    digitSum += text[i];
                } 
                else if ("aeiouy".Contains(text[i]))
                {
                    vowelNb++;
                }
                else
                {
                    consonantNb++;
                }
            }

            if(digitNb > 0)
            {

                average = (double) digitSum / digitNb;
            }

            // AFFICHAGE

            Console.WriteLine("Nombre de consonnes : " + consonantNb);
            Console.WriteLine("Nombre de voyelles : " + vowelNb);
            Console.WriteLine("Nombre de chiffres : " + digitNb);

            if(digitNb > 0)
            {
                Console.WriteLine("Moyenne : " + average);
            }
        }
    }
}