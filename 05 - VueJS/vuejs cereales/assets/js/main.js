import { Db } from './Db.js';
import { Cereal } from './Cereal.js';

const apiUrl = 'https://arfp.github.io/tp/web/vuejs/10-cereals/cereals.json'

const app = {
  data() {
    return {
      cereals: [],
      dataSource: [],
      selCategory: '',
      checkedNutriments: [],
      testCheck: false,
      testVar: 'ok',
      total: '',
      average: '',
      searchedName: '',
      sortedAscTitles: {}
    }
  },
  async mounted() {
    let json = await Db.fetchJson(apiUrl);

    for (let item of json) {
      let c = new Cereal(item);
      this.cereals.push(c);
      this.dataSource.push(c);
    }

    this.updateLastRow();
  },
  methods: {
    async fetch() {
      let json = await Db.fetchJson(apiUrl);

      this.cereals = [];

      for (let item of json) {
        let c = new Cereal(item);
        this.cereals.push(c);
        this.dataSource.push(c);
      }

      this.updateLastRow();
    },
    updateLastRow() {
      this.total = `${this.cereals.length} eléments`;
      this.average = `Moyenne calories ${Math.round(this.averageCalories())}`
    },
    deleteCereal(e) {
      this.cereals = this.cereals.filter(c => c.id != e.target.id)
    },
    async searchCereal(e) {
      this.cereals = [...this.dataSource];
      this.cereals = this.cereals.filter(c => c.name.toLowerCase().includes(this.searchedName.toLowerCase()));
    },
    filterCategory() {
      this.cereals = [...this.dataSource];

      if (this.selCategory == 'without-sugar') {
        this.cereals = this.cereals.filter(c => c.sugars < 1)
      } else if (this.selCategory == 'poor-salt') {
        this.cereals = this.cereals.filter(c => c.sodium < 50)
      } else if (this.selCategory == 'boost') {
        this.cereals = this.cereals.filter(c => c.vitamins >= 25 && c.fiber >= 10)
      }
      this.updateLastRow();
    },
    filterNutri() {
      this.cereals = [...this.dataSource]

      if (this.checkedNutriments.length > 0) {
        this.cereals = this.cereals.filter(c => this.checkedNutriments.includes(c.nutriscore));
        this.updateLastRow();
      }
    },
    averageCalories() {
      let sumCalory = 0;

      this.cereals.forEach(cereal => {
        sumCalory += cereal.calories;
      });

      return sumCalory / this.cereals.length;
    },
    sortColumn(e) {
      let titles = {
        'id': 'id',
        'nom': 'name',
        'calories': 'calories',
        'proteïnes': 'protein',
        'sel': 'sodium',
        'fibres': 'fiber',
        'glucides': 'carbo',
        'sucre': 'sugars',
        'potassium': 'potass',
        'vitamines': 'vitamins',
        'évaluation': 'rating',
        'ns': 'nutriscore'
      }
      let clickedTitle = e.target.textContent.toLowerCase();

      // convertir les évaluations qui ne sont pas considérées comme des number en float

      if (clickedTitle == 'évaluation') {
        this.cereals.forEach(cereal => {
          cereal.rating = parseFloat(cereal.rating)
        });
      }

      if (this.cereals.length > 0) {

        // trier les nombres    

        if (typeof this.cereals[0][titles[clickedTitle]] == 'number') {
          if (this.sortedAscTitles[titles[clickedTitle]]) {
            this.cereals.sort((a, b) => {
              return b[titles[clickedTitle]] - a[titles[clickedTitle]]
            })
            this.sortedAscTitles[titles[clickedTitle]] = false;
          } else {
            this.cereals.sort((a, b) => {
              return a[titles[clickedTitle]] - b[titles[clickedTitle]]
            })
            this.sortedAscTitles[titles[clickedTitle]] = true;
          }
        } else {

          // trier les chaînes de caractères

          if (this.sortedAscTitles[titles[clickedTitle]]) {
            this.cereals.sort((a, b) => {
              if (a[titles[clickedTitle]] < b[titles[clickedTitle]]) {
                return -1;
              } else if (a[titles[clickedTitle]] > b[titles[clickedTitle]]) {
                return 1;
              }
              return 0;
            })
            this.sortedAscTitles[titles[clickedTitle]] = false;
          } else {
            this.cereals.sort((a, b) => {
              if (a[titles[clickedTitle]] < b[titles[clickedTitle]]) {
                return 1;
              } else if (a[titles[clickedTitle]] > b[titles[clickedTitle]]) {
                return -1;
              }
              return 0;
            })
            this.sortedAscTitles[titles[clickedTitle]] = true;
          }
        }
      }
    }
  }
}

Vue.createApp(app).mount('#app');

