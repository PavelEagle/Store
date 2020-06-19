let reportsDataModule = {
    getMoneyInCity: function(){
        reportsAnimate.hideCalendar();
        fetch('https://localhost:5001/api/report/money-in-city')
            .then((response) => response.json())
            .then((data) => {
                //data = dt;
                reportCreateTableModule.moneyInCityCreateTable(data);
                console.log(data);
                document.getElementsByClassName('city-sort')[0].addEventListener("click", () => sortModule.citySort.citySortMethod());
            });

        document.getElementById('report-info').innerHTML = "Money In City";
    },
    getProductInStore: function (method) {
        reportsAnimate.hideCalendar();
        let url = "https://localhost:5001/api/report/";
        switch (method) {
            case "best-selling": url += "best-selling-products";
                break;
            case "in-warehouse-absent-msc-spb": url += "products-in-warehouse-and-absent-in-msk-and-spb";
                break;
        }
        fetch(url)
            .then((response) => response.json())
            .then((data) => {
                reportCreateTableModule.productInStoreCreateTable(data);
            });

        switch (method) {
            case "best-selling": document.getElementById('report-info').innerHTML = "Best selling";
                break;
            case "in-warehouse-absent-msc-spb": document.getElementById('report-info').innerHTML = "In stock in warehouse, absent in Msc and Spb";
                break;
        }
    },
    getCategoryWithFiveAndMoreProducts: function() {
        reportsAnimate.hideCalendar();
        fetch('https://localhost:5001/api/report/category-with-five-and-more-products')
            .then((response) => response.json())
            .then((data) => {
                reportCreateTableModule.categoryCreateTable(data);
            });

        document.getElementById('report-info').innerHTML = "Category with 5 and more products";
    },
    getProduct: function (method) {
        reportsAnimate.hideCalendar();
        let url = "https://localhost:5001/api/report/";
        switch (method) {
            case "sold-out": url += "sold-out-products";
                break;
            case "no-ordered": url += "no-ordered-products";
                break;
        }
        fetch(url)
            .then((response) => response.json())
            .then((data) => {
                reportCreateTableModule.productCreateTable(data);
            });

        switch (method) {
            case "sold-out": document.getElementById('report-info').innerHTML = "Sold out products";
                break;
            case "no-ordered": document.getElementById('report-info').innerHTML = "No ordered products";
                break;
        }
    },
    getOrdersByDate: async function () {
        let startDateForUrl = FormateDate(document.getElementById("start-date").value);
        let endDateForUrl = FormateDate(document.getElementById("end-date").value);
        let url = 'https://localhost:5001/api/report/info-about-orders-by-date/' + startDateForUrl + '/' + endDateForUrl;

        fetch(url)
            .then((response) => response.json())
            .then((data) => {
                reportCreateTableModule.ordersByDateCreateTable(data);
            });

        function FormateDate(date) {
            return date.substring(8, 10) + date.substring(5, 7) + date.substring(0, 4);
        }

        document.getElementById('report-info').innerHTML = "Orders by date";
    },
    GetSalesByWorldAndRF: function () {
        reportsAnimate.hideCalendar();
        fetch('https://localhost:5001/api/report/sales-by-world-and-rf')
            .then((response) => response.json())
            .then((data) => {
                reportCreateTableModule.salesByWorldAndRFCreateTable(data);
            });

        document.getElementById('report-info').innerHTML = "Sales By World And RF";
    }
}


