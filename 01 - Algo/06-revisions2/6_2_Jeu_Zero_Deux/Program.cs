namespace _6_2_Jeu_Zero_Deux
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int cpuNumber;
            int playerNumber;
            int cpuScore;
            int playerScore;
            long diff;
            string input;
            bool inputOk;
            Random rand = new Random();

            playerScore = 0;
            cpuScore = 0;

            do
            {
                cpuNumber = rand.Next(0, 3);

                do
                {
                    Console.Write("Saisir un nombre : ");
                    input = Console.ReadLine() ?? "";
                    inputOk = int.TryParse(input, out playerNumber);
                } while (!inputOk && playerNumber < 0 && playerNumber > 2);

                diff = Math.Abs(cpuNumber - playerNumber);

                switch (diff)
                {
                    case 2:
                        if (cpuNumber > playerNumber)
                        {
                            cpuScore++;
                            Console.WriteLine("Ordinateur gagne " + 1 + " point");
                        }
                        else
                        {
                            playerScore++;
                            Console.WriteLine("Joueur gagne " + 1 + " point");
                        }
                        
                        break;
                    case 1:
                        if (cpuNumber < playerNumber)
                        {
                            Console.WriteLine("Ordinateur gagne " + 1 + " point");
                            cpuScore++;
                        }
                        else
                        {
                            playerScore++;
                            Console.WriteLine("Joueur gagne " + 1 + " point");
                        }
                        break;
                    case 0:
                        Console.WriteLine("Personne gagne de point");
                        break;
                    default:
                        Console.WriteLine("La différence est anormale");
                        break;
                }

                Console.WriteLine("Joueur : " + playerScore + " ; Ordinateur : " + cpuScore);
            } while (playerNumber >= 0 && playerScore < 10 && cpuScore < 10);            

            // AFFICHAGE

            if(cpuScore > playerScore)
            {
                Console.WriteLine("Ordinateur gagne !");
            }
            else
            {
                Console.WriteLine("Joueur gagne !");
            }
        }
    }
}