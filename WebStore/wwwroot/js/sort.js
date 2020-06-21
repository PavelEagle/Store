let sortModule = {
    isSorted: true,
    getData: function () {
        let data, titles, tr, result;
        data = document.getElementById('data-viewer');
        titles = data.getElementsByTagName('th');
        tr = data.getElementsByTagName('tbody')[0].getElementsByTagName('tr');

        result = [];
        for (i = 0; i < tr.length; i++) {
            let temp = tr[i].getElementsByTagName('td');
            let obj = {};
            for (j = 0; j < temp.length; j++) {
                obj[titles[j].textContent.toLowerCase()] = temp[j].textContent;
            }
            result.push(obj);
        }
        return result;
    },
    sortMethods: {
        sortAlphabet: function (keyName, reportMethod) {
            let data = sortModule.getData();
            if (!this.isSorted) {
                data = data.sort((a, b) => (a[keyName] > b[keyName]) ? 1 : (b[keyName] > a[keyName]) ? -1 : 0);
                this.isSorted = true;
            }
            else {
                data = data.sort((a, b) => (a[keyName] < b[keyName]) ? 1 : (b[keyName] < a[keyName]) ? -1 : 0);
                this.isSorted = false;
            }
            this.createTable(data, reportMethod);
            
        },
        sortNumbers: function (keyName, reportMethod) {
            let data = sortModule.getData();
            if (!this.isSorted) {
                data = data.sort((a, b) => a[keyName] - b[keyName]);
                this.isSorted = true;
            }
            else {
                data = data.sort((a, b) => b[keyName] - a[keyName]);
                this.isSorted = false;
            }
            this.createTable(data, reportMethod);
        },
        createTable: function (data, reportMethod) {
            switch (reportMethod) {
                case 'moneyInCity': reportCreateTableModule.reportsTableCreator.moneyInCityCreateTable(data);
                    break;
                case 'productInStore': reportCreateTableModule.reportsTableCreator.productInStoreCreateTable(data);
                    break;
                case 'category': reportCreateTableModule.reportsTableCreator.categoryCreateTable(data);
                    break;
                case 'product': reportCreateTableModule.reportsTableCreator.productCreateTable(data);
                    break;
                case 'ordersByDate': reportCreateTableModule.reportsTableCreator.ordersByDateCreateTable(data);
                    break;
            }
        }
    },
   
    sortReports: {
        citySort: function (reportMethod) {
            sortModule.sortMethods.sortAlphabet('city', reportMethod);
        },
        totalMoneySort: function (reportMethod) {
            sortModule.sortMethods.sortNumbers('total', reportMethod);
        },
        addressSort: function (reportMethod) {
            sortModule.sortMethods.sortAlphabet('address', reportMethod);
        },
        manufacturerSort: function (reportMethod) {
            sortModule.sortMethods.sortAlphabet('manufacturer', reportMethod);
        },
        modelSort: function (reportMethod) {
            sortModule.sortMethods.sortAlphabet('model', reportMethod);
        },
        priceSort: function (reportMethod) {
            sortModule.sortMethods.sortNumbers('price', reportMethod);
        },
        quantitySort: function (reportMethod) {
            sortModule.sortMethods.sortNumbers('quantity', reportMethod);
        },
        countProductSort: function (reportMethod) {
            sortModule.sortMethods.sortNumbers('countProduct', reportMethod);
        },
        categorySort: function (reportMethod) {
            sortModule.sortMethods.sortNumbers('category', reportMethod);
        },
    }
}
