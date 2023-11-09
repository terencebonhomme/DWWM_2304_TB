import { Db } from './Db.js';
import { Legumos } from './Legumos.js';
import { Sale } from './Sale.js';

const apiUrlLegumos = 'https://arfp.github.io/tp/web/vuejs/11-grocery/legumos.json'
const apiUrlSales = 'https://arfp.github.io/tp/web/vuejs/11-grocery/legumos-sales.json'

const { createApp } = Vue;

const app = {
  data() {
    return {
      legumos: [],
      sales: [],
      disabl: {},
      emptyData: false,
      sortedAscTitles: {}
    }
  },
  async mounted() {
    await this.fetch();
  },
  methods: {
    async fetch() {
      let legumosJson;
      if (localStorage.getItem("legumos") == null && localStorage.getItem("empty-data") == null) {
        console.log('fetch')
        legumosJson = await Db.fetchJson(apiUrlLegumos);
        console.log(legumosJson)

        this.legumos = [];

        for (let item of legumosJson) {
          this.legumos.push(new Legumos(item));
        }
        this.saveLegumos();
      } else {
        console.log('local storage')
        this.loadLegumos();
      }

      if (localStorage.getItem("sales") == null && localStorage.getItem("empty-data") == null) {
        let salesJson = await Db.fetchJson(apiUrlSales);

        this.sales = [];

        for (let item of salesJson) {
          this.sales.push(new Sale(item));
        }
        this.saveSale();
      } else {
        this.loadSale();
      }
    },
    saveLegumos() {
      console.log('save');
      localStorage.setItem("legumos", JSON.stringify(this.legumos))
    },
    saveSale() {
      console.log('save');
      localStorage.setItem("sales", JSON.stringify(this.sales))
    },
    loadLegumos() {
      console.log('load')

      let legumosJson = JSON.parse(localStorage.getItem("legumos"));
      console.log(legumosJson)
      if (legumosJson) {
        for (let item of legumosJson) {
          this.legumos.push(new Legumos(item));
        }
      }

    },
    loadSale() {
      let salesJson = JSON.parse(localStorage.getItem("sales"));
      if (salesJson) {
        for (let item of salesJson) {
          this.sales.push(new Sale(item));
        }
      }
    },
    editName(e) {
      console.log(e)
      console.log(e.data)
      console.log(e.target._value)
    },
    editLegumo(e) {
      console.log(e.target.id.slice(1));
    },
    deleteLegumo(e) {
      this.legumos = this.legumos.filter(l => l.Id != e.target.id);
      this.saveLegumos();
    },
    addLegumo() {
      let item = {};

      if (this.legumos.length > 0) {
        item.Id = this.legumos[this.legumos.length - 1].Id + 1;
      } else {
        item.Id = 1;
      }

      item.Name = document.getElementById('input-legumos-name').value;
      item.Variety = document.getElementById('input-legumos-variety').value;
      item.PrimaryColor = document.getElementById('input-legumos-color').value;
      item.LifeTime = document.getElementById('input-legumos-lifetime').value;
      item.Fresh = document.getElementById('input-legumos-fresh').value;
      item.Price = document.getElementById('input-legumos-price').value;

      this.legumos.push(new Legumos(item));
      this.saveLegumos();
    },
    addSale() {
      let sale = {};

      if (this.sales.length > 0) {
        sale.SaleId = this.sales[this.sales.length - 1].Id + 1;
      } else {
        sale.SaleId = 1;
      }
      sale.Name = document.getElementById('input-sale-name').value;
      sale.SaleActive = document.getElementById('input-sale-active').value;
      sale.SaleDate = document.getElementById('input-sale-date').value;
      sale.SaleUnitPrice = document.getElementById('input-sale-unit-price').value;
      sale.SaleWeight = document.getElementById('input-sale-weight').value;
      sale.Variety = document.getElementById('input-sale-variety').value;
      sale.VegetableId = document.getElementById('input-sale-vegetable-id').value;

      this.sales.push(new Sale(sale));
      this.saveSale();
    },
    deleteData() {
      this.legumos = [];
      this.sales = [];
      this.emptyData = true;
      localStorage.removeItem('legumos');
      localStorage.removeItem('sales');
      localStorage.setItem("empty-data", true);
    },
    exportJson() {
      this.createDownloadJson(JSON.stringify(this.legumos), 'legumos');
      this.createDownloadJson(JSON.stringify(this.sales), 'sales');
    },
    createDownloadJson(json, filename){
      var dataStr = "data:text/json;charset=utf-8," + encodeURIComponent(json);
      var downloadAnchorNode = document.createElement('a');
      downloadAnchorNode.setAttribute("href",     dataStr);
      downloadAnchorNode.setAttribute("download", filename + ".json");
      document.body.appendChild(downloadAnchorNode);
      downloadAnchorNode.click();
      downloadAnchorNode.remove();
    },
    sortColumn(e) {
      let titles = {
        'Nom': 'Name',
        'Variété': 'Variety',
        'Couleur': 'PrimaryColor',
        'Durée Conservation': 'LifeTime',
        'Frais': 'Fresh'
      }

      let clickedTitle = e.target.textContent;

      if (this.legumos.length > 0) {

        // trier les nombres    

        if (typeof this.legumos[0][titles[clickedTitle]] == 'number') {
          if (this.sortedAscTitles[titles[clickedTitle]]) {
            this.legumos.sort((a, b) => {
              return b[titles[clickedTitle]] - a[titles[clickedTitle]]
            })
            this.sortedAscTitles[titles[clickedTitle]] = false;
          } else {
            this.legumos.sort((a, b) => {
              return a[titles[clickedTitle]] - b[titles[clickedTitle]]
            })
            this.sortedAscTitles[titles[clickedTitle]] = true;
          }
        } else {

          // trier les chaînes de caractères

          if (this.sortedAscTitles[titles[clickedTitle]]) {
            this.legumos.sort((a, b) => {
              if (a[titles[clickedTitle]] < b[titles[clickedTitle]]) {
                return -1;
              } else if (a[titles[clickedTitle]] > b[titles[clickedTitle]]) {
                return 1;
              }
              return 0;
            })
            this.sortedAscTitles[titles[clickedTitle]] = false;
          } else {
            this.legumos.sort((a, b) => {
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
    aa() {

    }   
  }
}

createApp(app).mount('#app');

