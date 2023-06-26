namespace Fraction
{
    public class Fraction
    {
        int numerateur;
        int denominateur;

        public int Numerateur { get => numerateur; set => numerateur = value; }
        public int Denominateur { get => denominateur; set => denominateur = value; }

        public Fraction() : this(0, 1)
        {
        }

        public Fraction(int _numerateur, int _denominateur)
        {
            this.numerateur = _numerateur;
            this.denominateur = _denominateur;
        }

        public Fraction(int _numerateur) : this(_numerateur, 1)
        {
        }

        public Fraction(Fraction copieDeFraction)
        {
            this.numerateur = copieDeFraction.numerateur;
            this.denominateur = copieDeFraction.denominateur;
        }

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

        public void Oppose()
        {
            this.numerateur = - this.numerateur;
        }

        public void Inverse()
        {
            int temp = this.numerateur;
            this.numerateur = this.denominateur;
            this.denominateur = temp;
        }

        public bool SuperieurA(Fraction autreFraction)
        {
            return this.GetValue() > autreFraction.GetValue();            
        }

        public bool EgalA(Fraction autreFraction)
        {
            return this.GetValue() == autreFraction.GetValue();
        }

        public void Reduire()
        {
            int pgcd = this.GetPgcd();
            this.numerateur = this.numerateur / pgcd;
            this.denominateur = this.denominateur / pgcd;
        }

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

        public double GetValue()
        {
            return (double) this.numerateur / this.denominateur;
        }

        public Fraction Plus(Fraction _autreFraction)
        {
            int resNumerateur = this.numerateur * _autreFraction.denominateur + _autreFraction.numerateur * this.denominateur;
            int resDenominateur = this.denominateur * _autreFraction.denominateur;

            Fraction res = new Fraction(resNumerateur, resDenominateur);

            res.Reduire();

            return res;
        }

        public Fraction Moins(Fraction _autreFraction)
        {
            _autreFraction.Oppose();

            return this.Plus(_autreFraction);
        }

        public Fraction Multiplie(Fraction _autreFraction)
        {          
            this.numerateur *= _autreFraction.numerateur;
            this.denominateur *= _autreFraction.denominateur;

            Fraction res = new Fraction(this.numerateur, this.denominateur);

            res.Reduire();

            return res;
        }

        public Fraction Divise(Fraction _autreFraction)
        {
            _autreFraction.Inverse();

            this.Multiplie(_autreFraction);

            return new Fraction(this.numerateur, this.denominateur);
        }
    }
}
