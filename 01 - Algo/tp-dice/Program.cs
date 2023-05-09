using System.Net.Http.Json;

namespace tp_dice
{
    public class Dice
    {
        public string? poll { get; set; }
        public int turns { get; set; }
        public string[]? results { get; set; }
    }
    internal class Program
    {
        public static async Task Main()
        {
            // VARIABLES

            int[] playerScore;
            int dice1;
            int dice2;
            int sumDices;
            int playerNum;
            int? nbTurn;
            string conclusion;
            string[]? results;
            string[] turnResult;            
            bool parsePlayerNumOk;
            bool parseDice1Ok;
            bool parseDice2Ok;
            bool valid;

            // TRAITEMENT

            // récupérer une partie générée par l'API

            using HttpClient client = new()
            {
                BaseAddress = new Uri("https://api.devoldere.net")
            };

            Dice? dice = await client.GetFromJsonAsync<Dice>("polls/dice");

            nbTurn = dice?.turns;
            playerNum = 0;
            playerScore = new int[] { 0, 0, 0 };
            results = dice?.results;

            valid = results!= null;

            // calculer les scores si on a des résultats

            if (valid)
            {
                for (int turn = 0; turn <= nbTurn; turn++)
                {
                    // récupérer le joueur et les tirages dans des variables avec le bon type

                    turnResult = results[turn].Split(" ");

                    parsePlayerNumOk = int.TryParse(turnResult[0], out playerNum);
                    parseDice1Ok = int.TryParse(turnResult[1], out dice1);
                    parseDice2Ok = int.TryParse(turnResult[2], out dice2);

                    if (parsePlayerNumOk && parseDice1Ok && parseDice2Ok)
                    {
                        // calculer les scores en suivant les règles du jeu

                        sumDices = dice1 + dice2;

                        playerNum--;

                        if (dice1 == dice2)
                        {
                            if (playerScore[playerNum] >= 2)
                            {
                                playerScore[playerNum] -= 2;
                            }
                        }
                        else if (sumDices < 6)
                        {
                            playerScore[playerNum] += 0;
                        }
                        else if (sumDices <= 10)
                        {
                            playerScore[playerNum] += 1;
                        }
                        else
                        {
                            playerScore[playerNum] += 3;
                        }
                    }
                }

                conclusion = playerScore[0] + "/" + playerScore[1] + "/" + playerScore[2];
            }
            else
            {
                conclusion = "to investigate";
            }

            // AFFICHAGE

            Console.WriteLine(conclusion);            
        }
    }
}