namespace Voiture
{
    public class Voiture
    {
        string? marque;
        Moteur sonMoteur;
        List<Roue> ses4Roues;

        public Moteur SonMoteur { get => sonMoteur; }
        public List<Roue> Ses4Roues { get => ses4Roues; }

        public Voiture()
        {
            this.sonMoteur = new Moteur();
            this.ses4Roues = new List<Roue>() { 
                new(Roue.Position.AvantDroite), 
                new(Roue.Position.AvantGauche), 
                new(Roue.Position.ArriereDroite), 
                new(Roue.Position.ArriereGauche) 
            };
        }

        public Voiture(Voiture voitureACopier)
        {
            this.sonMoteur = voitureACopier.SonMoteur;
            this.ses4Roues = voitureACopier.Ses4Roues;
        }

        public Voiture(string? marque, Moteur sonMoteur, List<Roue> ses4Roues)
        {
            if(ses4Roues != null 
                && ses4Roues.Count == 4 
                && ses4Roues.Exists(r => r.EmplacementRoue == Roue.Position.AvantDroite)
                && ses4Roues.Exists(r => r.EmplacementRoue == Roue.Position.AvantGauche)
                && ses4Roues.Exists(r => r.EmplacementRoue == Roue.Position.ArriereDroite)
                && ses4Roues.Exists(r => r.EmplacementRoue == Roue.Position.ArriereGauche)
                )
            {
                this.marque = marque;
                this.sonMoteur = sonMoteur;
                this.ses4Roues = ses4Roues;
            }
            else
            {
                throw new Exception("Une voiture doit avoir 4 roues et 1 roue par emplacement!");
            }
        }

        public bool Demarrer()
        {
            bool demarrageOK;

            demarrageOK = sonMoteur.Demarrer();            

            return demarrageOK;
        }

        public bool CouperContact()
        {
            bool coupureContactOK;

            coupureContactOK = this.sonMoteur.Eteindre();           

            return coupureContactOK;
        }

        public bool Avancer()
        {
            bool avancementOK;
            Roue? roue1;                       
            Roue? roue2;

            roue2 = this.ses4Roues.Find(r => r.EmplacementRoue == Roue.Position.AvantDroite);
            roue1 = this.ses4Roues.Find(r => r.EmplacementRoue == Roue.Position.AvantGauche);

            if (this.sonMoteur.EnMarche)
            {               
                if(roue1 != null && roue2 != null)
                {
                    avancementOK = this.sonMoteur.EntrainerRoues(roue1, roue2);
                }
                else
                {
                    avancementOK = false;
                }
            }
            else
            {
                avancementOK = false;
            }

            return avancementOK;
        }

        public bool Freiner()
        {
            bool freinageOK;
            Roue? roue1;
            Roue? roue2;

            roue1 = this.ses4Roues.Find(r => r.EmplacementRoue == Roue.Position.AvantGauche);
            roue2 = this.ses4Roues.Find(r => r.EmplacementRoue == Roue.Position.AvantDroite);            

            if (this.sonMoteur.EnMarche)
            {
                if (roue1 != null && roue2 != null)
                {
                    freinageOK = this.sonMoteur.ArreterRoues(roue1, roue2);
                }
                else
                {
                    freinageOK = false;
                }
            }
            else
            {
                freinageOK = false;
            }

            return freinageOK;
        }
    }
}
