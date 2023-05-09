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
            List<Color> maxList;
            List<Color> colorChoice;
            List<string> usedColors;
            List<string> res;

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
                colorChoice = new List<Color>();

                // utiliser des valeurs de tests qui ne dépendent pas de l'API
                if (test == 1) 
                {
                    colorChoice.Add(new Color("yellow", 4, 200));
                    colorChoice.Add(new Color("red", 2, 500));
                    colorChoice.Add(new Color("orange", 3, 500));
                    colorChoice.Add(new Color("blue", 0, 500));
                    colorChoice.Add(new Color("green", 1, 500));
                    colorChoice.Add(new Color("pink", 5, 200));                    
                }
                else if (test == 2)
                {
                    colorChoice.Add(new Color("yellow", 4, 200));
                    colorChoice.Add(new Color("red", 2, 500));
                    colorChoice.Add(new Color("orange", 1, 500));
                    colorChoice.Add(new Color("blue", 0, 600));
                    colorChoice.Add(new Color("green", 3, 500));
                    colorChoice.Add(new Color("pink", 5, 200));
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
                            colorChoice.Add(new Color(results[i], i));
                        }                    
                    }

                    // compter le nombre de votes pour chaque couleur

                    for (int i = 0; i < results?.Length; i++)
                    {
                        foreach (Color c in colorChoice)
                        {
                            if (c.name == results[i])
                            {
                                c.quantity++;
                            }
                        }
                    }
                }

                // si débogage, afficher les différentes couleurs relevées

                if (debug)
                {
                    foreach (Color c in colorChoice)
                    {
                        Console.WriteLine(c.name + " " + c.firstPosition + " " + c.quantity);
                    }
                }

                // créer une liste de valeurs max

                max = int.MinValue;

                foreach (Color c in colorChoice)
                {
                    if (c.quantity > max)
                    {
                        max = c.quantity;
                    }
                }

                maxList = new List<Color>();

                foreach (Color c in colorChoice)
                {
                    if(c.quantity == max)
                    {
                        maxList.Add(c);
                    }                    
                }

                res = new List<string>();
              
                // trier les valeurs maximales par leur position
                if (maxList.Count > 1)
                {
                    maxList = maxList.OrderBy(c => c.firstPosition).ToList();

                    foreach (Color c in maxList)
                    {
                        res.Add(c.name);
                    }
                }                
                // ajouter le max et trier les secondes valeurs maximales par leur position
                else if ((maxList.Count == 1))
                {
                    // ajouter le max

                    firstColor = "";                    
                    max = int.MinValue;

                    foreach (Color c in colorChoice)
                    {
                        if (c.quantity > max)
                        {
                            max = c.quantity;
                            firstColor = c.name;
                        };
                    }

                    res.Add(firstColor);                                           

                    // comparer si besoin les deuxièmes valeurs maximales

                    max = int.MinValue;

                    foreach (Color c in colorChoice)
                    {
                        if (c.quantity > max && c.name != firstColor)
                        {
                            max = c.quantity;
                        }
                    }

                    maxList = new List<Color>();

                    foreach (Color c in colorChoice)
                    {
                        if (c.quantity == max)
                        {
                            maxList.Add(c);
                        }
                    }

                    maxList = maxList.OrderBy(c => c.firstPosition).ToList();

                    foreach(Color c in maxList)
                    {
                        res.Add(c.name);
                    }
                }

                // AFFICHAGE
                Console.WriteLine(res.Count);
                Console.WriteLine(res.ElementAt(0) + " " + res.ElementAt(1));
            }
            else
            {
                Console.WriteLine("données non valides");
            }
        }
    }
}