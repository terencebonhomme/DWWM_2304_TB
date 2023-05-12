namespace _5_1_Fruits_Legumes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // VARIABLES

            string command;
            string name;
            string nameCheapest;
            double price;                        
            double priceCheapest;
            int spacePos;
            int i;
            bool quit;
            bool parseOk;;

            // TRAITEMENT

            quit = false;
            nameCheapest = "";
            priceCheapest = double.MaxValue;

            Console.WriteLine("\"nom prix\" par exemple carottes 2.99 pour entrer un légume");
            Console.WriteLine("\"go\" pour afficher le moins cher");
            Console.WriteLine("\"help\" pour afficher l'aide");
            Console.WriteLine("\"quit\" pour quitter");
            Console.WriteLine();

            do
            {
                Console.Write("Saisir une commande : ");
                command = Console.ReadLine() ?? "";

                if (command == "go")
                {
                    if(nameCheapest != "")
                    {
                        Console.WriteLine("Légume de moins cher au kilo : " + nameCheapest);
                    }                    
                }
                else if (command == "quit")
                {
                    quit = true;
                }
                else if(command == "help")
                {
                    Console.WriteLine("\"nom prix\" pour entrer un légume (par exemple carottes 2.99)");
                    Console.WriteLine("\"go\" pour afficher le moins cher");
                    Console.WriteLine("\"help\" pour afficher l'aide");
                    Console.WriteLine("\"quit\" pour quitter");
                }
                else
                {
                    spacePos = -1;

                    i = 0;
                    while(spacePos == -1 && i < command.Length)
                    {
                        if (command.ElementAt(i) == ' ')
                        {
                            spacePos = i;
                        }

                        i++;
                    }
                    
                    if(spacePos != -1)
                    {
                        name = command.Substring(0, spacePos);
                        
                        parseOk = double.TryParse(command.Substring(spacePos + 1), out price);

                        if (parseOk)
                        {
                            Console.WriteLine("1 kilogramme de " + name + " coûte " + price + " euros");

                            if (price < priceCheapest)
                            {
                                nameCheapest = name;
                                priceCheapest = price;
                            }
                        }
                    }                    
                }

                Console.WriteLine();
            } while (!quit);
        }
    }
}