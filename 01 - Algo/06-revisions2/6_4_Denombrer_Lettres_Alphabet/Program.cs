using System.Globalization;
using System.Text.RegularExpressions;

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
            bool isConsonant;
            string digits;
            string vowels;
            string consonants;

            // TRAITEMENT

            digits = "0123456789";
            vowels = "aeiouy";
            consonants = "bcdfghjklmnpqrstvwxz";

            digitNb = 0;
            vowelNb = 0;
            consonantNb = 0;
            digitSum = 0;            
            average = 0;

            Console.WriteLine("Saisir un texte :");
            text = Console.ReadLine() ?? "";

            text = text.ToLower();

            text = text.Replace(" ", "");

            text = Regex.Replace(text, "[äâà]", "a");
            text = Regex.Replace(text, "[ëêèé]", "e");
            text = Regex.Replace(text, "[ïî]", "i");
            text = Regex.Replace(text, "[öô]", "o");
            text = Regex.Replace(text, "[üû]", "u");
            text = Regex.Replace(text, "[ÿ]", "y");

            text = text.Replace("ç", "c");
            text = text.Replace("œ", "oe");

            Console.WriteLine(text);

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
                        isConsonant = false;

                        j = 0;
                        while (!isConsonant && j < consonants.Length)
                        {
                            if (text[i] == consonants[j])
                            {
                                consonantNb++;
                                isConsonant = true;
                            }
                            j++;
                        }                        
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