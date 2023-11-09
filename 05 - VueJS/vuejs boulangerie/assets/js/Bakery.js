class Bakery {

    // static bakery_level;
    // static nb_mills;

    /**
     * Constructeur
     */
    constructor() {
        this.level = 1;
        this.nb_mills = 1;
        this.upgrade_cost = 50.0;
        this.mill_cost = 40.0;
        this.gold = 50.0;
        this.flour = 100;
        this.nb_breads = 0;
        this.opened = false;
        this.gold_gained = 0;
        this.gold_spent = 0;
        this.flour_produced = 0;
        this.breads_produced = 0;
        // this.commands = [
        //     {
        //         id: 1,
        //         nb_breads: 11,
        //         unit_price: 0.26,
        //         time: 6,
        //         state: 'request'
        //     }
        // ]
    }
}

export { Bakery }