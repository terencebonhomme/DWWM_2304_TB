namespace Fraction
{
    public class Fraction
    {
        int numerateur;
        int denominateur;

        public int Numerateur { get => numerateur; set => numerateur = value; }
        public int Denominateur { get => denominateur; set => denominateur = value; }

        /// <summary>
        /// constructeur par défaut, valeur nulle
        /// </summary>
        public Fraction() : this(0, 1)
        {
        }

        /// <summary>
        /// constructeur classique
        /// </summary>
        /// <param name="_numerateur"></param>
        /// <param name="_denominateur"></param>
        /// <exception cref="DivideByZeroException"></exception>
        public Fraction(int _numerateur, int _denominateur)
        {
            if(_denominateur == 0)
            {
                throw new DivideByZeroException();
            }

            this.numerateur = _numerateur;
            this.denominateur = _denominateur;
        }

        /// <summary>
        /// constructeur d'un nombre entier
        /// </summary>
        /// <param name="_numerateur"></param>
        public Fraction(int _numerateur) : this(_numerateur, 1)
        {
        }

        /// <summary>
        /// constructeur de clonage
        /// </summary>
        /// <param name="fractionACloner"></param>
        public Fraction(Fraction fractionACloner) : this(fractionACloner.numerateur, fractionACloner.denominateur)
        {
        }

        /// <summary>
        /// afficher une fraction réduite avec un denominateur positif
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            this.Reduire();

            if(this.Denominateur < 0)
            {
                this.numerateur *= -1;
                this.denominateur *= -1;
            }

            return this.numerateur + "/" + this.denominateur;
        }

        /// <summary>
        /// inversion de signe
        /// </summary>
        public void Oppose()
        {
            this.numerateur = - this.numerateur;
        }

        /// <summary>
        /// inverse
        /// </summary>
        /// <exception cref="DivideByZeroException"></exception>
        public void Inverse()
        {
            if (this.numerateur == 0)
            {
                throw new DivideByZeroException();
            }

            int temp = this.numerateur;
            this.numerateur = this.denominateur;
            this.denominateur = temp;
        }

        /// <summary>
        /// supériorité
        /// </summary>
        /// <param name="autreFraction"></param>
        /// <returns></returns>
        public bool SuperieurA(Fraction autreFraction)
        {
            return this.GetValue() > autreFraction.GetValue();            
        }

        /// <summary>
        /// infériorité
        /// </summary>
        /// <param name="autreFraction"></param>
        /// <returns></returns>
        public bool InferieurA(Fraction autreFraction)
        {
            return this.GetValue() < autreFraction.GetValue();
        }

        /// <summary>
        /// égalité
        /// </summary>
        /// <param name="autreFraction"></param>
        /// <returns></returns>
        public bool EgalA(Fraction autreFraction)
        {
            return this.GetValue() == autreFraction.GetValue();
        }

        /// <summary>
        /// réduire la fraction
        /// </summary>
        public void Reduire()
        {
            int pgcd = this.GetPgcd();
            this.numerateur = this.numerateur / pgcd;
            this.denominateur = this.denominateur / pgcd;
        }

        /// <summary>
        /// avoir le PGCD
        /// </summary>
        /// <returns></returns>
        private int GetPgcd()
        {
            int a = this.numerateur;
            int b = this.denominateur;
            int pgcd = 1;

            if (a != 0 && b != 0)
            {
                if (a < 0) a = -a;
                if (b < 0) b = -b;

                while (a != b)
                {
                    if (a < b)
                    {
                        b = b - a;
                    }
                    else
                    {
                        a = a - b;
                    }
                }

                pgcd = a;
            }

            return pgcd;
        }      

        /// <summary>
        /// avoir la valeur décimale
        /// </summary>
        /// <returns></returns>
        private double GetValue()
        {
            return (double) this.numerateur / this.denominateur;
        }

        /// <summary>
        /// additionner une autre fraction
        /// </summary>
        /// <param name="_autreFraction"></param>
        /// <returns></returns>
        public Fraction Plus(Fraction _autreFraction)
        {
            int resNumerateur = this.numerateur * _autreFraction.denominateur + _autreFraction.numerateur * this.denominateur;
            int resDenominateur = this.denominateur * _autreFraction.denominateur;

            Fraction fraction = new Fraction(resNumerateur, resDenominateur);

            fraction.Reduire();

            return fraction;
        }

        /// <summary>
        /// soustraire une autre fraction
        /// </summary>
        /// <param name="_autreFraction"></param>
        /// <returns></returns>
        public Fraction Moins(Fraction _autreFraction)
        {
            Fraction fraction = new Fraction(_autreFraction);

            fraction.Oppose();

            return this.Plus(fraction);
        }

        /// <summary>
        /// multiplier par une autre fraction
        /// </summary>
        /// <param name="_autreFraction"></param>
        /// <returns></returns>
        public Fraction Multiplie(Fraction _autreFraction)
        {
            Fraction fraction;

            this.numerateur *= _autreFraction.numerateur;
            this.denominateur *= _autreFraction.denominateur;

            fraction = new Fraction(this.numerateur, this.denominateur);

            fraction.Reduire();

            return fraction;
        }

        /// <summary>
        /// diviser par une autre fraction
        /// </summary>
        /// <param name="_autreFraction"></param>
        /// <returns></returns>
        public Fraction Divise(Fraction _autreFraction)
        {
            Fraction fraction = new Fraction(_autreFraction);
            fraction.Inverse();

            return this.Multiplie(fraction);
        }

        /// <summary>
        /// opérateur d'addition
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fraction operator +(Fraction a, Fraction b)
        {
            return a.Plus(b);
        }

        /// <summary>
        /// opérateur de soustraction
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fraction operator -(Fraction a, Fraction b)
        {
            return a.Moins(b);
        }

        /// <summary>
        /// opérateur de multiplication
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fraction operator *(Fraction a, Fraction b)
        {
            return a.Multiplie(b);
        }

        /// <summary>
        /// opérateur de division
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fraction operator /(Fraction a, Fraction b)
        {
            return a.Divise(b);
        }

        /// <summary>
        /// opérateur pour passer à une valeur positive
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Fraction operator +(Fraction a)
        {
            Fraction fraction = new Fraction(a);

            if (fraction.numerateur < 0)
            {
                fraction.Oppose();                
            }
            
            return fraction;
        }

        /// <summary>
        /// opérateur pour passer à une valeur négative
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Fraction operator -(Fraction a)
        {
            Fraction fraction = new Fraction(a);

            if (fraction.numerateur > 0)
            {
                fraction.Oppose();
            }

            return fraction;
        }

        /// <summary>
        /// opérateur de supériorité
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator >(Fraction a, Fraction b)
        {
            return a.SuperieurA(b);
        }

        /// <summary>
        /// opérateur supériorité ou d'égalité
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator >=(Fraction a, Fraction b)
        {
            return a.SuperieurA(b) || a.EgalA(b);
        }

        /// <summary>
        /// opérateur infériorité
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator <(Fraction a, Fraction b)
        {
            return a.InferieurA(b);
        }

        /// <summary>
        /// opérateur d'infériorité ou d'égalité
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator <=(Fraction a, Fraction b)
        {
            return a.InferieurA(b) || a.EgalA(b);
        }

        /// <summary>
        /// opérateur d'égalité
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(Fraction a, Fraction b)
        {
            return a.EgalA(b);
        }

        /// <summary>
        /// opérateur d'inégalité
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(Fraction a, Fraction b)
        {
            return !a.EgalA(b);
        }

        /// <summary>
        /// opérateur pour d'inversion une fraction
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Fraction operator !(Fraction a)
        {
            Fraction fraction = a;
            fraction.Inverse();
            
            return fraction;
        }
    }
}
