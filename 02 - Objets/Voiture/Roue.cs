namespace Voiture
{
    public class Roue
    {
        bool tourne;
        string? dimensionPneu;
        Position emplacementRoue;

        public Roue()
        {
            this.tourne = false;
            this.emplacementRoue = Roue.Position.AvantDroite;
        }

        public Roue(bool tourne, Position position)
        {
            this.tourne = tourne;
            this.emplacementRoue = position;
        }

        public Roue(Position position)
        {
            this.tourne = false;
            this.emplacementRoue = position;
        }

        public Roue(Roue roueACopier)
        {
            this.tourne = roueACopier.tourne;
            this.dimensionPneu = roueACopier.dimensionPneu;
            this.emplacementRoue = roueACopier.emplacementRoue;
        }

        public enum Position
        {
            AvantDroite,
            AvantGauche,
            ArriereDroite,
            ArriereGauche
        }

        public bool Tourne { get => tourne; }
        public Position EmplacementRoue { get => emplacementRoue; }

        public bool Tourner()
        {
            bool tournoiementOK;

            if (!this.tourne)
            {
                this.tourne = true;
                tournoiementOK = true;
            }
            else
            {
                tournoiementOK = false;
            }

            return tournoiementOK;
        }

        public bool Stopper()
        {
            bool stopOK;

            if(this.tourne)
            {
                this.tourne = false;
                stopOK = true;
            }
            else
            {
                stopOK = false;
            }

            return stopOK;
        }
    }
}
