namespace tp_emprunt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            Console.WriteLine("{0:C2}", avoirMensConstPret(0.05, 10_000, 3));
            Console.WriteLine();

            double[,] tableauAmortPret = avoirTableauAmortPret(0.05, 10_000, 3);
            afficherTableauAmortPret(tableauAmortPret);
        }

        enum titre
        {
            numero_mois = 0,
            part_interet = 1,
            part_capital = 2,
            capital_restant = 3,
            mensualite = 4,
        }

        static double avoirMensConstPret(double _txannuel, double _capitalEmprunte, int _nbrAnneeRbmt)
        {
            double a;
            double k;
            double n;
            double tm;

            k = _capitalEmprunte;
            n = _nbrAnneeRbmt * 12;
            tm = _txannuel / 12;

            a = k * tm / (1 - Math.Pow(1 + tm, -n));

            return a;
        }

        static double[,] avoirTableauAmortPret(double _txannuel, double _capitalEmprunte, int _nbrAnneeRbmt)
        {
            double partCapital;
            double partInteret;
            double capitalRestant;
            double tm;
            double mensualite;
            double[,] tableauAmortPret;
            int nbrMois;

            capitalRestant = 0;
            tm = _txannuel / 12;
            nbrMois = _nbrAnneeRbmt * 12;
            tableauAmortPret = new double[nbrMois, Enum.GetValues(typeof(titre)).Length];

            for (int n = 0; n < nbrMois; n++)
            {
                if (n == 0)
                {
                    capitalRestant = _capitalEmprunte;
                    partInteret = 0;
                    mensualite = 0;
                    partCapital = 0;
                }
                else
                {
                    partInteret = capitalRestant * tm;
                    mensualite = capitalRestant * tm / (1 - Math.Pow(1 + tm, -(nbrMois - n)));
                    partCapital = mensualite - partInteret;
                    capitalRestant -= partCapital;
                }

                tableauAmortPret[n, (int)titre.numero_mois] = n;
                tableauAmortPret[n, (int)titre.part_interet] = partInteret;
                tableauAmortPret[n, (int)titre.part_capital] = partCapital;
                tableauAmortPret[n, (int)titre.capital_restant] = capitalRestant;
                tableauAmortPret[n, (int)titre.mensualite] = mensualite;
            }

            return tableauAmortPret;
        }

        static void afficherTableauAmortPret(double[,] _tableauAmortPret)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("{0, 10} | ", "num mois"); ;
            Console.Write("{0, 15} | ", "part interet");
            Console.Write("{0, 15} | ", "part capital");
            Console.Write("{0, 15} | ", "capital restant");
            Console.WriteLine("{0, 10}", "mensualité");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            for (int n = 0; n < 36; n++)
            {
                // numero mois
                Console.Write("{0, 10} | ", _tableauAmortPret[n, 0]);

                // part interet
                Console.Write("{0, 15:C1} | ", _tableauAmortPret[n, 1]);

                // part capital                
                Console.Write("{0, 15:C1} | ", _tableauAmortPret[n, 2]);

                // capital restant     
                Console.Write("{0, 15:C0} | ", Math.Abs(_tableauAmortPret[n, 3]));

                // mensualité
                Console.WriteLine("{0, 10:C0}", _tableauAmortPret[n, 4]);
            }
        }
    }
}