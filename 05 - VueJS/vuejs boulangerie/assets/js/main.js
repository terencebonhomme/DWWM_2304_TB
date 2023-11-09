import { Bakery } from './Bakery.js';

const { createApp } = Vue;

const app = {
  data() {
    return {
      bakery: new Bakery(),
      interv: null,
      commands: [],
      commandId: 1,
      logs: []
    }
  },
  computed: {
    earning(){
      return ((0.7 * ((30 * this.bakery.level / 100) - (this.bakery.level / 100)) + (this.bakery.level / 100)) * 5)
    },
    inTime(){
      this.bakery.nb_breads + this.bakery.time * this.bakery.level
    }
  },
  mounted() {
    this.initCommands();
  },
  methods: {
    upgrade() {
      if (this.bakery.gold >= this.bakery.upgrade_cost) {
        this.bakery.level++;
        this.bakery.gold -= this.bakery.upgrade_cost;
        this.bakery.gold_spent += this.bakery.upgrade_cost;
        this.bakery.upgrade_cost *= 1.5;
      }
    },
    buyMill() {
      if (this.bakery.gold >= this.bakery.mill_cost) {
        this.bakery.nb_mills++;
        this.bakery.gold -= this.bakery.mill_cost;
        this.bakery.gold_spent += this.bakery.mill_cost;
        this.bakery.mill_cost *= 1.5;
      }
    },
    open() {
      this.bakery.opened = true;
      this.interv = setInterval(() => {
        this.bakery.gold -= 0.05 * this.bakery.level * this.bakery.nb_mills;
        this.bakery.gold_spent += 0.05 * this.bakery.level * this.bakery.nb_mills;
        this.bakery.flour += this.bakery.nb_mills;
        this.bakery.flour_produced += this.bakery.nb_mills;
        if(this.bakery.flour >= this.bakery.level + 1){
          this.bakery.flour -= this.bakery.level + 1;
        }        
        if(this.bakery.flour >= this.bakery.level){
          this.bakery.nb_breads += this.bakery.level;
          this.bakery.breads_produced += this.bakery.level;
        }
        
      }, 1000);
    },
    close() {
      clearInterval(this.interv);
      this.bakery.opened = false;
    },
    accept(id) {
      this.commands[id - 1].state = 'accepted';

      let eventAccept = {};
      eventAccept.date = new Date().toLocaleTimeString('fr');
      eventAccept.description = `La commande ${this.commands[id - 1].id} a été acceptée`;
      this.logs.unshift(eventAccept);  
      if(this.logs.length == 21){
        this.logs.pop();
      }

      setTimeout(() => {
        let inter = setInterval(() => {
          if (this.commands[id - 1].time > 0) {
            this.commands[id - 1].time--;
          } else {
            clearTimeout(inter);
            this.commands[id - 1].id = id;
            this.commands[id - 1].state = 'waiting';
            this.commands[id - 1].nb_breads = 0;
            this.commands[id - 1].unit_price = 0;
            this.commands[id - 1].time = 0;

            setTimeout(() => {
              this.createCommand(this.commands[id - 1]);
              clearInterval(inter)
            }, 3000);
          }
        }, 1000);
      }, this.commands[id - 1].time)
    },
    cancel(id) {

      this.commands[id - 1].state = 'canceled';

      setTimeout(() => {
        this.commands[id - 1].id = id;
        this.commands[id - 1].state = 'waiting';
        this.commands[id - 1].nb_breads = 0;
        this.commands[id - 1].unit_price = 0;
        this.commands[id - 1].time = 0;

        setTimeout(() => {
          this.createCommand(this.commands[id - 1]);
        }, 3000);

        clearInterval(inter)
      }, 3000);
    },
    initCommands() {
      for (let i = 0; i < 10; i++) {
        let c = {};
        c.id = i + 1;
        c.state = 'waiting';
        c.nb_breads = 0;
        c.unit_price = 0;
        c.time = 0;

        this.commands.push(c);
      }

      setTimeout(() => {
        for (let i = 0; i < 10; i++) {
          this.createCommand(this.commands[i], i + 1);
        }
      }, 3000);
    },
    resetCommand(command, id) {
      command.id = id;
      command.state = 'waiting';
      command.nb_breads = 0;
      command.unit_price = 0;
      command.time = 0;

      setTimeout(() => {
        this.createCommand(command, id);
      }, 3000);
    },
    createCommand(command, id) {
      command.state = 'request';
      command.nb_breads = Math.round(Math.random() * ((30 * this.bakery.level) - 5) + 5);
      command.unit_price = (Math.random() * ((30 * this.bakery.level / 100) - (this.bakery.level / 100)) + (this.bakery.level / 100)) * 5;
      command.time = Math.round(Math.random() * (18 - 3) + 3);
      console.log(command)
    },
    complete(id) {
      if (this.bakery.nb_breads >= this.commands[id - 1].nb_breads) {
        this.bakery.nb_breads -= this.commands[id - 1].nb_breads;
        this.bakery.gold += this.commands[id - 1].unit_price * this.commands[id - 1].nb_breads;
        this.bakery.gold_gained += this.commands[id - 1].unit_price * this.commands[id - 1].nb_breads;

        let eventDelivery = {};
        eventDelivery.date = new Date().toLocaleTimeString('fr');
        eventDelivery.description = `La boulangerie a livré ${this.commands[id - 1].nb_breads} baguettes`;
        this.logs.unshift(eventDelivery);  
        if(this.logs.length == 21){
          this.logs.pop();
        }
        
        let eventGain = {};
        eventGain.date = new Date().toLocaleTimeString('fr');
        eventGain.description = `La boulangerie a gagné ${(this.commands[id - 1].nb_breads * this.commands[id - 1].unit_price).toFixed(2)} Or`;
        this.logs.unshift(eventGain); 
        if(this.logs.length == 21){
          this.logs.pop();
        }

        this.resetCommand(this.commands[id - 1], id);
      }
    },
  }
}

createApp(app).mount('#app');