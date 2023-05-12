namespace _5_2_1_Conversion_Kilometres_Miles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // VARIABLES

            double kmDistance;
            double miDistance;
            string input;
            bool inputOk;

            // TRAITEMENT

            miDistance = 0;
            
            do
            {
                Console.Write("Saisir une valeur en kilomètres comprise entre 0,01 et 1 000 000"
                    + " ou q pour quitter : ");
                input = Console.ReadLine();
                inputOk = double.TryParse(input, out kmDistance);
                Console.WriteLine(inputOk);
            } while (input != "q" && !inputOk || (kmDistance < 0.01 || kmDistance > 1_000_000));

            if (input != "q")
            {
                miDistance = kmDistance / 1.609;
            }                 

            // AFFICHAGE

            if(input != "q")
            {
                Console.WriteLine(miDistance);
            }            
        }
    }
}