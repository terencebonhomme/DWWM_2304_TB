namespace Fraction
{
    public class Fraction
    {
        int numerateur;
        int denominateur;

        public int Numerateur { get => numerateur; set => numerateur = value; }
        public int Denominateur { get => denominateur; set => denominateur = value; }

        public Fraction()
        {
            this.numerateur = 1;
            this.denominateur = 1;
        }

        public Fraction(int _numerateur, int _denominateur)
        {
            this.numerateur = _numerateur;
            this.denominateur = _denominateur;
        }

        public Fraction(int _numerateur)
        {
            this.numerateur = _numerateur;
            this.denominateur = 1;
        }

        public Fraction(Fraction copieDeFraction)
        {
            this.numerateur = copieDeFraction.numerateur;
            this.denominateur = copieDeFraction.denominateur;
        }

        public string ToDisplay()
        {
            throw new NotImplementedException();
        }

        public void Oppose()
        {
            throw new NotImplementedException();
        }

        public void Inverse()
        {
            throw new NotImplementedException();
        }

        public bool SuperieurA(Fraction autreFraction)
        {
            throw new NotImplementedException();
        }

        public bool EgalA(Fraction autreFraction)
        {
            throw new NotImplementedException();
        }

        private void Reduire()
        {
            throw new NotImplementedException();
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
                        a = b - a;
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
            throw new NotImplementedException();
        }

        public Fraction Plus(Fraction _autreFraction)
        {
            throw new NotImplementedException();
        }

        public Fraction Moins(Fraction _autreFraction)
        {
            throw new NotImplementedException();
        }

        public Fraction Multiplie(Fraction _autreFraction)
        {
            throw new NotImplementedException();
        }

        public Fraction Divise(Fraction _autreFraction)
        {
            throw new NotImplementedException();
        }
    }
}
