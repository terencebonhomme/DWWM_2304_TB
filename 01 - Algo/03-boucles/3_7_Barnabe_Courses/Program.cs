﻿namespace _3_7_Barnabe_Courses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // VARIABLES

            int marketNb;
            double cash;
            string input;
            bool inputOk;

            // TRAITEMENT

            marketNb = 0;

            do
            {
                Console.Write("Saisir le solde : ");
                input = Console.ReadLine();
                inputOk = double.TryParse(input, out cash);
            } while (!inputOk);

            while(cash >= 2)
            {
                marketNb++;
                cash = cash / 2 - 1;
            }

            marketNb++;

            // AFFICHAGE

            Console.WriteLine("Barbabé est passé dans " + marketNb + " magasins");
        }
    }
}