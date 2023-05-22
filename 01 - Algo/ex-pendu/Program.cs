using System.Transactions;

namespace ex_pendu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word;
            string maskedWord;
            char letter;
            int currentPlayer;
            int winningPlayer;
            int attemptNb;

            do
            {
                Console.Write("Saisir un mot : ");
                word = Console.ReadLine() ?? "";
            }
            while (word.Length < 5);

            maskedWord = maskWord(word);
            Console.WriteLine(maskedWord);

            currentPlayer = 1;
            winningPlayer = 0;
            attemptNb = 0;

            do
            {
                Console.Write("joueur " + currentPlayer + " veuillez saisir une lettre : ");
                letter = Console.ReadLine()[0];

                maskedWord = revealWord(word, maskedWord, letter);
                Console.WriteLine(maskedWord);

                if(maskedWord != word)
                {
                    if(currentPlayer == 2)
                    {
                        attemptNb++;
                    }

                    currentPlayer = changeCurrentPlayer(currentPlayer);
                }
                else
                {
                    winningPlayer = currentPlayer;
                }
            }
            while (maskedWord != word && attemptNb < 6);

            if(winningPlayer != 0)
            {
                Console.WriteLine("joueur " + winningPlayer + " a gagné");
            }
            else
            {
                Console.WriteLine("personne n'a gagné");
            }
            
        }

        static string revealWord(string word, string maskedWord, char letter)
        {
            char[] revealedWord;
            
            revealedWord = maskedWord.ToCharArray();

            if (word.ElementAt(0) == letter)
            {
                revealedWord[0] = letter;
            }
            else if(word.ElementAt(^1) == letter)
            {
                revealedWord[^1] = letter;
            }

            return new string(revealedWord);
        } 

        static string maskWord(string word)
        {
            return "-" + word.Substring(1, word.Length - 2) + "-";
        }

        static int changeCurrentPlayer(int currentPlayer)
        {
            int round;

            if(currentPlayer == 1)
            {
                round = 2;
            }
            else
            {
                round = 1;
            }

            return round;
        }
    }
}