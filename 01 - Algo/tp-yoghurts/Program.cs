using System.Collections.Immutable;
using System.Data;
using System.Net.Http.Json;

namespace tp_yoghurts
{
    internal class Program
    {
        public static async Task Main()
        {
            // VARIABLES

            bool valid;            
            bool debug;
            int? nbVotes;
            string[]? results;

            int test;

            Dictionary<string, int> colorPosition;
            Dictionary<string, int> colorQuantity;            
            Dictionary<string, int> firstGroupColorPos;

            KeyValuePair<string, int> firstColorSample;

            string[] ranking;
            int rank;
            string firstColor;
            int nbRank;

            // TRAITEMENT

            // réglages

            nbRank = 6;

            test = 3;
            debug = true;

            // récupérer une partie générée par l'API

            using HttpClient client = new()
            {
                BaseAddress = new Uri("https://api.devoldere.net")
            };

            Yoghurts? yoghurts = await client.GetFromJsonAsync<Yoghurts>("polls/yoghurts");

            results = yoghurts?.results;
            nbVotes = yoghurts?.votes;

            valid = results != null;            

            // faire le traitement s'il y a des données
            if (valid)
            {
                colorQuantity = new Dictionary<string, int>();
                colorPosition = new Dictionary<string, int>();

                // utiliser des valeurs de tests qui ne dépendent pas de l'API
                if (test == 1) 
                {
                    colorPosition.Add("yellow", 4);
                    colorQuantity.Add("yellow", 200);

                    colorPosition.Add("red", 2);
                    colorQuantity.Add("red", 500);
                    
                    colorPosition.Add("orange", 3);
                    colorQuantity.Add("orange", 500);
                    
                    colorPosition.Add("blue", 0);
                    colorQuantity.Add("blue", 500);
                    
                    colorPosition.Add("green", 1);
                    colorQuantity.Add("green", 500);
                    
                    colorPosition.Add("pink", 5);
                    colorQuantity.Add("pink", 200);
                }
                else if (test == 2)
                {
                    colorPosition.Add("yellow", 4);
                    colorQuantity.Add("yellow", 200);
                    
                    colorPosition.Add("red", 2);
                    colorQuantity.Add("red", 500);
                    
                    colorPosition.Add("orange", 1);
                    colorQuantity.Add("orange", 500);
                    
                    colorPosition.Add("blue", 0);
                    colorQuantity.Add("blue", 600);
                    
                    colorPosition.Add("green", 3);
                    colorQuantity.Add("green", 500);
                    
                    colorPosition.Add("pink", 5);
                    colorQuantity.Add("pink", 200);                    
                }
                else if (test == 3)
                {
                    colorPosition.Add("yellow", 4);
                    colorQuantity.Add("yellow", 200);

                    colorPosition.Add("red", 2);
                    colorQuantity.Add("red", 400);

                    colorPosition.Add("orange", 1);
                    colorQuantity.Add("orange", 200);

                    colorPosition.Add("blue", 0);
                    colorQuantity.Add("blue", 600);

                    colorPosition.Add("green", 3);
                    colorQuantity.Add("green", 400);

                    colorPosition.Add("pink", 5);
                    colorQuantity.Add("pink", 600);
                }
                // calculer les votes si on a des résultats
                else
                {
                    // compter les couleurs utilisées

                    for (int i = 0; i < results?.Length; i++)
                    {
                        if (colorPosition.ContainsKey(results[i]))                   
                        {
                            colorQuantity[results[i]]++;                            
                        }
                        else
                        {
                            colorPosition.Add(results[i], i);
                            colorQuantity.Add(results[i], 1);
                        }
                    }
                }

                // si débogage, afficher les différentes couleurs relevées

                if (debug)
                {
                    foreach (KeyValuePair<string, int> color in colorPosition)
                    {
                        Console.WriteLine(color.Key + " " + color.Value + " " + colorQuantity[color.Key]);
                    }
                }

                // classer les valeurs par gropue

                ranking = new string[nbRank];
                rank = 0;

                firstGroupColorPos = new Dictionary<string, int>();

                while (rank < ranking.Length)
                {
                    firstColorSample = colorQuantity.OrderByDescending(c => c.Value).First();

                    firstGroupColorPos.Clear();

                    foreach (KeyValuePair<string, int> color in colorQuantity)
                    {
                        if(color.Value == firstColorSample.Value)
                        {
                            firstGroupColorPos.Add(color.Key, colorPosition[color.Key]);
                        }
                    }

                    while (firstGroupColorPos.Count > 0)
                    {
                        firstColor = firstGroupColorPos.OrderBy(c => c.Value).First().Key;
                        ranking[rank++] = firstColor;

                        colorQuantity.Remove(firstColor);
                        firstGroupColorPos.Remove(firstColor);
                    }   
                }

                // AFFICHAGE;

                Console.WriteLine();
                for (int i = 0; i < ranking.Length; i++)
                {
                    Console.WriteLine(ranking[i]);
                }
            }
            else
            {
                Console.WriteLine("données non valides");
            }
        }
    }
}