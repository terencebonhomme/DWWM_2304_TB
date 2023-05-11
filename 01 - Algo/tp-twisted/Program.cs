using System.Text;

namespace tp_dice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // VARIABLES

            int sumDices;

            int[] score;
            int maxScore;
            int nbMaxScore;

            int[] nbColor;
            string[] nameColor;
            int colorMax;
            string logoColor;

            int nbPlayer;
            int nbRound;
            int nbDice;
            int[,,] game; 

            double reward;

            bool debug;
            string result;

            Random random;

            // TRAITEMENT

            Console.OutputEncoding = Encoding.UTF8;            

            debug = true;

            score = new int[20];
            random = new Random();

            nbPlayer = 20;
            nbRound = 20;
            nbDice = 3;
            game = new int[nbPlayer, nbRound, nbDice];

            nameColor = new string[] { "orange", "bleu", "jaune", "rouge", "vert"};
            nbColor = new int[nameColor.Length];

            // remplir le tableau des lancers de dés de la partie

            for (int iPlay = 0; iPlay < nbPlayer; iPlay++)
            {
                for (int iRound = 0; iRound < nbRound; iRound++)
                {
                    for(int indDice = 0; indDice < nbDice; indDice++)
                    {
                        game[iPlay, iRound, indDice] = random.Next(1, 7); ;
                    }
                }
            }

            // calcul des points selon les lancers de dés

            for (int iPlayer = 0; iPlayer < nbPlayer; iPlayer++)
            {
                for (int iRound = 0; iRound < nbRound; iRound++)
                {
                    sumDices = 0;

                    for (int iDice = 0; iDice < nbDice; iDice++)
                    {
                        sumDices += game[iPlayer, iRound, iDice];
                    }                        

                    if (sumDices == 3 || sumDices == 18)
                    {
                        score[iPlayer] = score[iPlayer] + 3;
                    }
                    else if (sumDices <= 6)
                    {
                        score[iPlayer] = score[iPlayer] + 1;
                    }
                    else if (sumDices >= 12)
                    {
                        score[iPlayer] = score[iPlayer] + 2;
                    }

                    for(int d1 = 0; d1 < nbDice; d1++)
                    {
                        for (int d2 = 0; d2 < nbDice; d2++)
                        {
                            if(d1 != d2 && game[iPlayer, iRound, d1] == game[iPlayer, iRound, d2])
                            {
                                nbColor[random.Next(nbColor.Length)]++;
                            }
                        }
                    }
                }
            }

            // couleur gagnante

            logoColor = "";
            colorMax = 0;

            for(int i = 0; i < nameColor.Length; i++)
            {
                if (nbColor[i] > colorMax)
                {
                    colorMax = nbColor[i];
                    logoColor = nameColor[i];
                }
            }

            // score max

            maxScore = 0;

            for(int i = 0; i < score.Length; i++)
            {
                if (score[i] > maxScore)
                {
                    maxScore = score[i];
                }
            }

            // gains de bons d'achats

            nbMaxScore = 0;

            for(int i = 0; i < score.Length; i++)
            {
                if (score[i] == maxScore)
                {
                    nbMaxScore++;
                }
            }

            reward = 6_000 / nbMaxScore;

            // AFFICHAGE

            Console.WriteLine($"couleur du logo : {logoColor}");
            Console.WriteLine($"meilleur score : {maxScore}");
            for(int numPlayer = 1; numPlayer <= nbPlayer; numPlayer++)
            {
                if (score[numPlayer - 1] == maxScore)
                {
                    Console.WriteLine($"joueur {numPlayer} gagne la " +
                        $"partie et remporte {reward}€ en bons d'achat");
                }                
            }

            if (debug)
            {
                for (int i = 0; i < score.Length; i++)
                {
                    Console.WriteLine(i + " " + score[i]);
                }

                Console.WriteLine();

                for (int iPlayer = 0; iPlayer < nbPlayer; iPlayer++)
                {
                    for (int iRound = 0; iRound < nbRound; iRound++)
                    {
                        result = "" + (iPlayer + 1);
                        result += " " + iRound;
                        for (int iDice = 0; iDice < nbDice; iDice++)
                        {
                            result += " " + game[iPlayer, iRound, iDice];
                        }
                        Console.WriteLine(result);
                    }
                }
            }

            // FIN PROGRAMME

            Console.ReadLine();
        }
    }
}