class Cereal {
    static nutriscore;

    /**
     * Constructeur
     * @param {*} _cerealFromJson 
     */
    constructor(_cerealFromJson) {
        Object.assign(this, _cerealFromJson);
        this.nutriscore = this.calcNutriscore();
    }

    calcNutriscore() {
        if (this.rating > 80) {
            return 'A';
        } else if (this.rating > 70) {
            return 'B';
        } else if (this.rating > 55) {
            return 'C';
        } else if (this.rating > 35) {
            return 'D';
        } else {
            return 'E';
        }
    }

    // deleteCereal(e) {
    //     this.cereals = this.cereals.filter(c => c.id != e.target.id)
    // }
}

export { Cereal }