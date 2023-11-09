class MaDate {
    static ageRetraite;
    static ageMajorite;

    /**
     * Constructeur
     * @param {Date} _date 
     */
    constructor(_date){
        this.dateAujourdui = new Date();
        this.dateNaissance = new Date(_date);
    }

    /**
     * Calculer nombre d'années entre la date d'aujourd'hui et la date de naissance
     * @returns {number} nombre d'années
     */
    deltaAnnees() {
        let deltaDate = this.dateAujourdui - this.dateNaissance;
        return parseInt(deltaDate / (1000 * 60 * 60 * 24 * 365));
    }

    /**
     * Déterminer si la date de naissance est dans le futur
     * @returns {boolean} vrai si la date est dans le futur sinon faux
     */
    estDateFutur(){
        return this.dateAujourdui <= this.dateNaissance;
    }  
    
    /**
     * Déterminer le signe astrologique de la date de naissance
     * @returns {string} signe astrologique
     */
    signeAstro() {
        let numJour = this.dateNaissance.getDate();
        let numMois = this.dateNaissance.getMonth();
    
        let signes = [
            { nom: 'Capricorne', jourFin: 19 },
            { nom: 'Verseau', jourFin: 18 },
            { nom: 'Poissons', jourFin: 20 },
            { nom: 'Bélier', jourFin: 19 },
            { nom: 'Taureau', jourFin: 20 },
            { nom: 'Gémeaux', jourFin: 20 },
            { nom: 'Cancer', jourFin: 22 },
            { nom: 'Lion', jourFin: 22 },
            { nom: 'Vierge', jourFin: 22 },
            { nom: 'Balance', jourFin: 22 },
            { nom: 'Scorpion', jourFin: 21 },
            { nom: 'Sagittaire', jourFin: 21 },
            { nom: 'Capricorne', jourFin: 19 },
        ];
    
        if (numJour <= signes[numMois].jourFin) {
            console.log(signes[numMois].nom)
            return signes[numMois].nom;
        } else {
            console.log(signes[numMois + 1].nom)
            return signes[numMois + 1].nom;
        }
    }
}

export { MaDate };