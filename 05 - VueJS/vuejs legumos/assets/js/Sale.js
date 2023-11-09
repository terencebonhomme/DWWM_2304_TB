class Sale {

    /**
     * Constructeur
     * @param {*} _salesFromJson 
     */
    constructor(_salesFromJson) {
        Object.assign(this, _salesFromJson);
        //this.Name = this.translateName(this.Name);
    }

    translateName(_name){
        let idx = {
            'apple': 'pomme',
            'banana': 'banane',
            'blueberries': 'myrtille',
            'cabbage': 'chou',
            'carrot': 'carotte',
            'cherry': 'cerise',
            'coconut': 'noix de coco',            
            'grape': 'raisin',
            'kiwi': 'kiwi',
            'lemon': 'citron',
            'onion': 'oignon',
            'orange': 'orange',            
            'pear': 'poire',
            'pineapple': 'ananas',
            'plum': 'prunes',
            'potatoes': 'pomme de terre',
            'strawberries': 'fraise',
            'tomato': 'tomate',
            'turnip': 'navet',                                                
            'watermelon': 'pastèque'            
        };
        
        return idx[_name];
    }
}

export { Sale }