let reportsDataModule = {
    getMoneyInCity: function(){
        reportsAnimate.hideCalendar();
        fetch('https://localhost:5001/api/report/money-in-city')
            .then((response) => response.json())
            .then((data) => {
                //data = dt;
                reportCreateTableModule.getMoneyInCityCreateTable(data);
                //document.getElementsByClassName('city-sort')[0].addEventListener("click", () => citySort());
            });
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
                reportCreateTableModule.getProductInStoreCreateTable(data);
            });
    },
    getCategoryWithFiveAndMoreProducts: function() {
        reportsAnimate.hideCalendar();
        fetch('https://localhost:5001/api/report/category-with-five-and-more-products')
            .then((response) => response.json())
            .then((data) => {
                reportCreateTableModule.getCategoryCreateTable(data);
            });
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
                reportCreateTableModule.getProductCreateTable(data);
            });
    },
    getOrdersByDate: async function () {
        let startDateForUrl = FormateDate(this.document.getElementById("start-date").value);
        let endDateForUrl = FormateDate(this.document.getElementById("end-date").value);
        let url = 'https://localhost:5001/api/report/info-about-orders-by-date/' + startDateForUrl + '/' + endDateForUrl;

        fetch(url)
            .then((response) => response.json())
            .then((data) => {
                reportCreateTableModule.getOrdersByDateCreateTable(data);
            });

        function FormateDate(date) {
            return date.substring(8, 10) + date.substring(5, 7) + date.substring(0, 4);
        }
    },
    GetSalesByWorldAndRF: function () {
        reportsAnimate.hideCalendar();
        fetch('https://localhost:5001/api/report/sales-by-world-and-rf')
            .then((response) => response.json())
            .then((data) => {
                reportCreateTableModule.GetSalesByWorldAndRFCreateTable(data);
            });
    }
}


