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
            }

            // AFFICHAGE

        }
    }
}