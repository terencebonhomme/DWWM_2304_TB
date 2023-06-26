namespace CompteBancaire
{
    public class Compte : IComparable
    {
        double montantDecouvertAutorise;
        string nomProprietaire;
        int numero;
        double solde;

        public Compte(
            int _numero,
            string _nomProprietaire,
            double _solde,
            double _montantDecouvertAutorise
            )
        {
            numero = _numero;
            nomProprietaire = _nomProprietaire;
            solde = _solde;
            montantDecouvertAutorise = _montantDecouvertAutorise;
        }

        public Compte()
        {
            numero = 0;
            nomProprietaire = "";
            solde = 0.0;
            montantDecouvertAutorise = 100.0;
        }

        public int Comparer(Compte _compte)
        {
            int comparaison;

            if (solde > _compte.solde)
            {
                comparaison = 1;
            }
            else if (solde < _compte.solde)
            {
                comparaison = -1;
            }
            else
            {
                comparaison = 0;
            }

            return comparaison;
        }

        public bool Debiter(double _montant)
        {
            bool operationOK;

            if (solde - montantDecouvertAutorise >= _montant)
            {
                solde -= _montant;
                operationOK = true;
            }
            else
            {
                operationOK = false;
            }

            return operationOK;
        }

        public void Crediter(double _montant)
        {
            solde += _montant;
        }

        public override string ToString()
        {
            return "\nnuméro : " + numero
                + "\nnom propriétaire : " + nomProprietaire
                + "\nsolde : " + solde
                + "\nmontant découvert autorisé : " + montantDecouvertAutorise;
        }

        public bool Transferer(double _montant, Compte _compte)
        {
            bool operationOK;

            if (this.Debiter(_montant))
            {
                _compte.Crediter(_montant);
                operationOK = true;
            }
            else
            {
                operationOK = false;
            }

            return operationOK;
        }

        public int CompareTo(object? obj)
        {
            if (obj == null) return 1;

            Compte autreCompte = obj as Compte;
            if (autreCompte != null)
            {
                return this.solde.CompareTo(autreCompte.solde);
            }
            else
            {
                throw new ArgumentException("Objet n'est pas un Compte");
            }
        }
    }
}
