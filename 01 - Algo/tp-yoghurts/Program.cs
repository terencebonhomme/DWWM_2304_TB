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
            string firstColor;
            int max;
            int test;

            List<string> maxName;
            List<int> maxQuantity;
            List<int> maxPosition;
            List<string> colorName;
            List<int> colorPosition;
            List<int> colorQuantity;
            List<string> usedColors;
            List<string> resName;

            int minMaxQuantity;
            string minMaxName;
            int minMaxPosition;
            int tempMaxQuantity;
            string tempMaxName;
            int tempMaxPosition;
            int index;

            // TRAITEMENT

            // réglages pour les tests

            test = 0;
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
                colorName = new List<string>();
                colorPosition = new List<int>();
                colorQuantity = new List<int>();

                // utiliser des valeurs de tests qui ne dépendent pas de l'API
                if (test == 1) 
                {
                    colorName.Add("yellow");
                    colorPosition.Add(4);
                    colorQuantity.Add(200);
                    colorName.Add("red");
                    colorPosition.Add(2);
                    colorQuantity.Add(500);
                    colorName.Add("orange");
                    colorPosition.Add(3);
                    colorQuantity.Add(500);
                    colorName.Add("blue");
                    colorPosition.Add(0);
                    colorQuantity.Add(500);
                    colorName.Add("green");
                    colorPosition.Add(1);
                    colorQuantity.Add(500);
                    colorName.Add("pink");
                    colorPosition.Add(5);
                    colorQuantity.Add(200);
                }
                else if (test == 2)
                {
                    colorName.Add("yellow");
                    colorPosition.Add(4);
                    colorQuantity.Add(200);
                    colorName.Add("red");
                    colorPosition.Add(2);
                    colorQuantity.Add(500);
                    colorName.Add("orange");
                    colorPosition.Add(1);
                    colorQuantity.Add(500);
                    colorName.Add("blue");
                    colorPosition.Add(0);
                    colorQuantity.Add(600);
                    colorName.Add("green");
                    colorPosition.Add(3);
                    colorQuantity.Add(500);
                    colorName.Add("pink");
                    colorPosition.Add(5);
                    colorQuantity.Add(200);                    
                }
                // calculer les votes si on a des résultats
                else
                {                    
                    // ajouter chaque couleur dès la première occurrence
                    // relever les couleurs utilisées

                    usedColors = new List<string>();

                    for (int i = 0; i < results?.Length; i++)
                    {
                        if (!usedColors.Contains(results[i]))                   
                        {
                            usedColors.Add(results[i]);
                            colorName.Add(results[i]);
                            colorPosition.Add(i);
                            colorQuantity.Add(0);
                        }                    
                    }

                    // compter le nombre de votes pour chaque couleur

                    for (int i = 0; i < results?.Length; i++)
                    {
                        for (int j = 0; j < colorName.Count; j++)
                        {
                            if (colorName[j] == results[i])
                            {
                                colorQuantity[j]++;
                            }
                        }
                    }
                }

                // si débogage, afficher les différentes couleurs relevées

                if (debug)
                {
                    for(int i = 0; i < colorName.Count; i++)
                    {
                        Console.WriteLine(colorName[i] + " " + colorPosition[i] + " " + colorQuantity[i]);
                    }
                }

                // créer une liste de valeurs max

                max = int.MinValue;
                
                for (int i = 0; i < colorName.Count; i++)
                {;
                    if (colorQuantity[i] > max)
                    {
                        max = colorQuantity[i];
                    }
                }

                maxName = new List<string>();
                maxQuantity = new List<int>();
                maxPosition = new List<int>();

                for (int i = 0; i < colorName.Count; i++)
                {
                    if (colorQuantity[i] == max)
                    {
                        maxName.Add(colorName[i]);
                        maxQuantity.Add(colorQuantity[i]);
                        maxPosition.Add(colorPosition[i]);
                    }                    
                }

                resName = new List<string>();
              
                // trier les valeurs maximales par leur position
                if (maxName.Count > 1)
                {
                    index = 0;

                    for (int i = 0; i < maxPosition.Count; i++)
                    {
                        minMaxPosition = maxPosition[i];

                        for (int j = i + 1; j < maxPosition.Count; j++)
                        {
                            if (maxPosition[j] < minMaxPosition)
                            {
                                minMaxPosition = maxPosition[j];
                                index = j;
                            }
                        }

                        tempMaxQuantity = maxQuantity[i];
                        maxQuantity[i] = maxQuantity[index];
                        maxQuantity[index] = tempMaxQuantity;

                        tempMaxName = maxName[i];
                        maxName[i] = maxName[index];
                        maxName[index] = tempMaxName;

                        tempMaxPosition = maxPosition[i];
                        maxPosition[i] = maxPosition[index];
                        maxPosition[index] = tempMaxPosition;
                    }

                    for (int i = 0; i < maxName.Count; i++)
                    {
                        resName.Add(maxName[i]);
                    }
                }                
                // ajouter le max et trier les secondes valeurs maximales par leur position
                else if (maxName.Count == 1)
                {
                    // ajouter le max

                    firstColor = "";                    
                    max = int.MinValue;

                    for(int i = 0; i < colorName.Count; i++)
                    {
                        if (colorQuantity[i] > max)
                        {
                            max = colorQuantity[i];
                            firstColor = colorName[i];
                        }
                    }

                    resName.Add(firstColor);                                           

                    // comparer si besoin les deuxièmes valeurs maximales

                    max = int.MinValue;

                    for (int i = 0; i < colorName.Count; i++)
                    {
                        if (colorQuantity[i] > max && colorName[i] != firstColor)
                        {
                            max = colorQuantity[i];
                        }
                    }

                    maxName = new List<string>();
                    maxQuantity = new List<int>();
                    maxPosition = new List<int>();

                    for (int i = 0; i < colorName.Count; i++)
                    {
                        if (colorQuantity[i] == max)
                        {
                            maxName.Add(colorName[i]);
                            maxQuantity.Add(colorQuantity[i]);
                            maxPosition.Add(colorPosition[i]);
                        }
                    }

                    index = 0;

                    for (int i = 0; i < maxPosition.Count; i++)
                    {
                        minMaxPosition = maxPosition[i];

                        for (int j = i + 1; j < maxPosition.Count; j++)
                        {
                            if (maxPosition[j] < minMaxPosition)
                            {
                                minMaxPosition = maxPosition[j];
                                index = j;
                            }
                        }

                        tempMaxQuantity = maxQuantity[i];
                        maxQuantity[i] = maxQuantity[index];
                        maxQuantity[index] = tempMaxQuantity;

                        tempMaxName = maxName[i];
                        maxName[i] = maxName[index];
                        maxName[index] = tempMaxName;

                        tempMaxPosition = maxPosition[i];
                        maxPosition[i] = maxPosition[index];
                        maxPosition[index] = tempMaxPosition;
                    }

                    for (int i = 0; i < maxName.Count; i++)
                    {
                        resName.Add(maxName[i]);
                    }
                }

                // AFFICHAGE;
                Console.WriteLine(resName.ElementAt(0) + " " + resName.ElementAt(1));
            }
            else
            {
                Console.WriteLine("données non valides");
            }
        }
    }
}