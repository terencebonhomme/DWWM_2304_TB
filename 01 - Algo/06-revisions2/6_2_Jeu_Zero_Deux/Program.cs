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

                if(Math.Abs(cpuNumber - playerNumber) == 2)
                {
                    if(cpuNumber > playerNumber)
                    {
                        cpuScore++;
                    }
                    else
                    {
                        playerScore++;
                    }
                }
                else if(Math.Abs(cpuNumber - playerNumber) == 1)
                {
                    if (cpuNumber < playerNumber)
                    {
                        cpuScore++;
                    }
                    else
                    {
                        playerScore++;
                    }
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