import { Db } from './Db.js';
import { Cereal } from './Cereal.js';

const apiUrl = 'https://arfp.github.io/tp/web/vuejs/10-cereals/cereals.json'

const app = {
  data() {
    return {
      cereals: [],
      dataSource: [],
      nutriscoreList: [],
      selCategory: '',
      checkedNutriments: [],
      total: '',
      average: '',
      searchedName: '',
      sortedAscTitles: {}
    }
  },
  async mounted() {
    if (localStorage.getItem("cereals") == null) {

      let json = await Db.fetchJson(apiUrl);

      for (let item of json) {
        let c = new Cereal(item);
        this.cereals.push(c);
        this.dataSource.push(c);
      }

      this.saveLocalStorage();
    } else {
      this.loadLocalStorage();
    }

    this.updateLastRow();

    this.listNutriscore()
  },
  methods: {
    updateLastRow() {
      this.total = `${this.cereals.length} eléments`;
      this.average = `Moyenne calories ${Math.round(this.averageCalories())}`;
    },
    deleteCereal(e) {
      this.cereals = this.cereals.filter(c => c.id != e.target.id);
      this.updateLastRow();
      this.saveLocalStorage();
    },
    searchCereal() {
      this.cereals = this.cereals.filter(c => c.name.toLowerCase().includes(this.searchedName.toLowerCase()));
    },
    filterData() {
      this.cereals = [...this.dataSource];

      this.filterCategory();
      this.filterNutri();
      this.searchCereal();

      this.updateLastRow();
    },
    filterCategory() {
      if (this.selCategory == 'without-sugar') {
        this.cereals = this.cereals.filter(c => c.sugars < 1 && c.sugars != -1)
      } else if (this.selCategory == 'poor-salt') {
        this.cereals = this.cereals.filter(c => c.sodium < 50)
      } else if (this.selCategory == 'boost') {
        this.cereals = this.cereals.filter(c => c.vitamins >= 25 && c.fiber >= 10)
      }
    },
    filterNutri() {
      if (this.checkedNutriments.length > 0) {
        this.cereals = this.cereals.filter(c => this.checkedNutriments.includes(c.nutriscore));
      }
    },
    averageCalories() {
      let sumCalory = 0;

      sumCalory = this.cereals.reduce((a, b) => a + b.calories, 0);

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
    },
    listNutriscore() {
      for (let cereal of this.cereals) {
        if (!this.nutriscoreList.includes(cereal.nutriscore)) {
          this.nutriscoreList.push(cereal.nutriscore)
        }
      }

      this.nutriscoreList.sort();
    },
    saveLocalStorage() {
      localStorage.setItem("cereals", JSON.stringify(this.cereals));
    },
    loadLocalStorage() {
      let cerealsJson = JSON.parse(localStorage.getItem("cereals"));

      if (cerealsJson) {
        for (let item of cerealsJson) {
          let c = new Cereal(item)
          this.cereals.push(c);
          this.dataSource.push(c);
        }
      }
    },
    async reset() {
      this.cereals = [];
      this.dataSource = [];

      let json = await Db.fetchJson(apiUrl);

      for (let item of json) {
        let c = new Cereal(item);
        this.cereals.push(c);
        this.dataSource.push(c);
      }

      this.updateLastRow();

      this.saveLocalStorage();
    },
    exportJson() {
      this.createDownloadJson(JSON.stringify(this.cereals), 'cereals');
    },
    createDownloadJson(json, filename) {
      var dataStr = 'data:text/json;charset=utf-8,' + encodeURIComponent(json);
      var downloadAnchorNode = document.createElement('a');
      downloadAnchorNode.setAttribute('href', dataStr);
      downloadAnchorNode.setAttribute('download', filename + '.json');
      document.body.appendChild(downloadAnchorNode);
      downloadAnchorNode.click();
      downloadAnchorNode.remove();
    }
  }
}

Vue.createApp(app).mount('#app');
