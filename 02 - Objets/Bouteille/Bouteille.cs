namespace Bouteille
{
    public class Bouteille
    {
        private double capaciteEnCl;
        private double quantiteEnCl;
        private string contenu;
        private bool estOuverte;

        public double CapaciteEnCl { get => capaciteEnCl; set => capaciteEnCl = value; }
        public double QuantiteEnCl { get => quantiteEnCl; set => quantiteEnCl = value; }
        public string Contenu { get => contenu; set => contenu = value; }
        public bool EstOuverte { get => estOuverte; set => estOuverte = value; }

        public Bouteille(string _contenu, bool _estOuverte, double _quantiteEnCl, double _capaciteEnCl)
        {
            this.contenu = _contenu;
            this.estOuverte = _estOuverte;
            this.quantiteEnCl = _quantiteEnCl;
            this.capaciteEnCl = _capaciteEnCl;
        }

        public Bouteille() : this("eau", true, 100, 150)
        {

        }

        public Bouteille(Bouteille bouteilleACopier)
        {
            contenu = bouteilleACopier.contenu;
            estOuverte = bouteilleACopier.estOuverte;
            quantiteEnCl = bouteilleACopier.quantiteEnCl;
            capaciteEnCl = bouteilleACopier.capaciteEnCl;
        }

        public bool Ouvrir()
        {
            bool ouvertureOK;

            if (estOuverte)
            {
                ouvertureOK = false;
            }
            else
            {
                this.estOuverte = true;
                ouvertureOK = true;
            }

            return ouvertureOK;
        }

        public bool Fermer()
        {
            bool fermetureOK;

            if (estOuverte)
            {
                this.estOuverte = false;
                fermetureOK = true;
            }
            else
            {
                fermetureOK = false;
            }

            return fermetureOK;
        }

        public bool Vider(double _quantiteEnCl)
        {
            bool vidageOK;

            if (this.estOuverte
                && _quantiteEnCl > 0
                && this.quantiteEnCl - _quantiteEnCl >= 0)
            {
                this.quantiteEnCl -= _quantiteEnCl;
                vidageOK = true;
            }
            else
            {
                vidageOK = false;
            }

            return vidageOK;
        }

        public bool Vider()
        {
            bool vidageOK;

            if (this.estOuverte && this.quantiteEnCl > 0)
            {
                this.quantiteEnCl = 0;
                vidageOK = true;
            }
            else
            {
                vidageOK = false;
            }

            return vidageOK;
        }

        public bool Remplir(double _quantiteEnCl)
        {
            bool remplissageOK;

            if (this.estOuverte
                && this.quantiteEnCl + _quantiteEnCl <= this.capaciteEnCl
                && _quantiteEnCl > 0)
            {
                this.quantiteEnCl += _quantiteEnCl;
                remplissageOK = true;
            }
            else
            {
                remplissageOK = false;
            }

            return remplissageOK;
        }

        public bool Remplir()
        {
            bool remplissageOK;

            if (this.estOuverte
                && this.quantiteEnCl < this.capaciteEnCl)
            {
                this.quantiteEnCl = this.capaciteEnCl;
                remplissageOK = true;
            }
            else
            {
                remplissageOK = false;
            }

            return remplissageOK;
        }

        public override string ToString()
        {
            return "\ncapaciteEnCl : " + this.capaciteEnCl
                + "\nEstOuverte : " + this.estOuverte
                + "\nquantiteEnCl : " + this.quantiteEnCl
                + "\ncontenu : " + this.contenu;
        }
    }
}
