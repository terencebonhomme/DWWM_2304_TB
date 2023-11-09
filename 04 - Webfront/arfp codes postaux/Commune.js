class Commune {
    constructor(_commune) {
        this.codeCommune = _commune.codeCommune;
        this.codePostal = _commune.codePostal;
        this.libelleAcheminenement = _commune.libelleAcheminenement;
        this.nomCommune = _commune.nomCommune;
    }

    /*
            <li>code commune : ${selCommune.codeCommune}</li>
            <li>code postal : ${selCommune.codePostal}</li>
            <li>libelle acheminement : ${selCommune.libelleAcheminement}</li>
            <li>nom commune : ${selCommune.nomCommune}</li>
    */
}

export { Commune }