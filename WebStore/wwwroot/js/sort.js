let sortModule = {
    citySort: {
        cityIsSorted: true,
        citySortMethod: function () {
            let data = sortModule.getData();
            if (!sortModule.cityIsSorted) {
                data = data.sort((a, b) => (a.city > b.city) ? 1 : (b.city > a.city) ? -1 : 0);
                this.cityIsSorted = true;
            }
            else {
                data = data.sort((a, b) => (a.city < b.city) ? 1 : (b.city < a.city) ? -1 : 0);
                this.cityIsSorted = false;
            }
            reportCreateTableModule.moneyInCityCreateTable(data);
        }      
    },
    getData: function () {
        let data = document.getElementById('data-viewer');
        let titles = data.getElementsByTagName('th');
        let tr = data.getElementsByTagName('tbody')[0].getElementsByTagName('tr');
        let result = [];
        for (i = 0; i < tr.length; i++) {
            let temp = tr[i].getElementsByTagName('td');
            let obj = {};
            for (j = 0; j < temp.length; j++) {
                obj[titles[j].textContent] = temp[j].textContent;
            }
            result.push(obj);
        }
        return result;
    }
}