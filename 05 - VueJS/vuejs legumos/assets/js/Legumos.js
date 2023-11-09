class Legumos {

    /**
     * Constructeur
     * @param {*} _legumosFromJson 
     */
    constructor(_legumosFromJson) {
        Object.assign(this, _legumosFromJson);
        // this.Name = this.translateName(this.Name);
        // this.Variety = this.capitaliseFirstLetter(this.Variety);
        // this.PrimaryColor = this.translateColor(this.PrimaryColor);
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
        // console.log(idx[_name])
        return this.capitaliseFirstLetter(idx[_name]);
    }

    translateColor(_color){
        let colors = {
            'green': 'vert',
            'yellow': 'jaune',
            'red': 'rouge',
            'orange': 'orange',
            'purple': 'violet',
            'yellowgreen': 'jaune vert',
            'white': 'blanc',
            'purplegreen': 'violet vert',
            'darkred': 'rouge foncé',
            'brown': 'marron'
        }

        return colors[_color];
    }

    capitaliseFirstLetter(_word){
        if(_word){
            return _word.charAt(0).toUpperCase() + _word.slice(1);        
        }        
    }
}

export { Legumos }