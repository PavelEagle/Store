let sortModule = {
    cityIsSorted: true,
    methods: {
        citySort: function (data) {
            console.log(sortModule.cityIsSorted);
            if (!sortModule.cityIsSorted) {
                data = data.sort((a, b) => (a.city > b.city) ? 1 : (b.city > a.city) ? -1 : 0);
                sortModule.cityIsSorted = true;
            }
            else {
                data = data.sort((a, b) => (a.city < b.city) ? 1 : (b.city < a.city) ? -1 : 0);
                sortModule.cityIsSorted = false;
            }
            reportCreateTableModule.MoneyInCityCreateTable(data);    
        }      
    }
}