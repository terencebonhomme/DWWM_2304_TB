using System.Globalization;

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
            int j;
            double average;
            bool isDigit;
            bool isVowel;
            string digits;
            string vowels;

            // TRAITEMENT

            digits = "0123456789";
            vowels = "aeiouy";

            digitNb = 0;
            vowelNb = 0;
            consonantNb = 0;
            digitSum = 0;            
            average = 0;
                       
            text = "Lorem ipsum dolor6 sit amet,3 consectetu4r adip7iscing elit. " +
                "Inte9ger9 vitae interdum5 magna. Etiam mol9estie 2odio et consequat " +
                "bibendum.";            

            for (int i = 0; i < text.Length; i++)
            {
                isDigit = false;

                j = 0;
                while(!isDigit && j < digits.Length)
                {
                    if (text[i] == digits[j])
                    {
                        digitNb++;
                        digitSum += text[i];
                        isDigit = true;
                    }
                    j++;
                }

                if (!isDigit)
                {
                    isVowel = false;

                    j = 0;
                    while (!isVowel && j < vowels.Length)
                    {
                        if (text[i] == vowels[j])
                        {
                            vowelNb++;
                            isVowel = true;
                        }
                        j++;
                    }

                    if (!isVowel)
                    {
                        consonantNb++;
                    }
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