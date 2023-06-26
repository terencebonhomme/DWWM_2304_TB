namespace Point
{
    public class Point
    {
        double x;
        double y;

        public Point()
        {
            this.x = 0;
            this.y = 0;
        }

        public Point(double _abscisse, double _ordonnee)
        {
            this.x = _abscisse;
            this.y = _ordonnee;
        }

        public Point(Point _pointACloner)
        {
            this.x = _pointACloner.x;
            this.y = _pointACloner.y;
        }

        public Point SymetrieAxeAbscisse()
        {
            return new Point(this.x, - this.y);
        }

        public Point SymetrieAxeOrdonnee()
        {
            return new Point(- this.x, this.y);
        }

        public Point SymetrieOrigine()
        {
            return new Point(-this.x, -this.y);
        }

        public void Deplacer(double _x, double _y)
        {
            this.x = _x;
            this.y = _y;
        }

        public void PermuterCoordonnees()
        {
            this.Deplacer(this.y, this.x);
        }

        public override string ToString()
        {
            return "(" + this.x + " ; " + this.y + ")";
        }
    }
}
