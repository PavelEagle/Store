window.onload = function () {
    function GetMoneyInCity() {
        HideCalendar();
        fetch('https://localhost:5001/api/report/money-in-city')
            .then((response) => response.json())
            .then((data) => {
                CreateTable(data);
            });

        function CreateTable(reportModel) {
            var strResult = "<table class='table'><thead><tr>" + 
                            "<th scope='col' >City</th>" +
                            "<th scope='col'>Total Money, RUB</th>" +
                            "</tr></thead><tbody>";
            reportModel.forEach(x => {
                strResult += "<tr><th scope='row'>" + x.city +
                             "</th><td> " + x.total +
                             "</td></tr>";
            });
            strResult += "</tbody></table>";

            document.getElementById('data-viewer').innerHTML = strResult;
            document.getElementById('report-info').innerHTML = "Money In City";
        }
    }

    function GetProductInStore(method) {
        HideCalendar();
        let url;
        switch (method) {
            case "best-selling": url = "https://localhost:5001/api/report/best-selling-products";
                break;
            case "in-warehouse-absent-msc-spb": url = "https://localhost:5001/api/report/products-in-warehouse-and-absent-in-msk-and-spb";
                break;
        }
        fetch(url)
            .then((response) => response.json())
            .then((data) => {
                CreateTable(data);
            });




        function CreateTable(reportModel) {
            console.log(reportModel.length);
            var strResult = "<table class='table'><thead><tr>" +
                            "<th scope='col'>City</th>" +
                            "<th scope='col'>Address</th>" +
                            "<th scope='col'>Manufacturer</th>" +
                            "<th scope='col'>Model</th>" +
                            "<th scope='col'>Price, RUB</th>" +
                            "</tr></thead><tbody>";

            let length = reportModel.length > 100 ? 100 : reportModel.length;
                
            for (let i = 0; i < length; i++) {
               strResult += "<tr><td scope='row'>" + reportModel[i].city +
                            "</td><td>" + reportModel[i].address +
                            "</td><td>" + reportModel[i].manufacturer +
                            "</td><td>" + reportModel[i].model +
                            "</td><td>" + reportModel[i].price +
                            "</td></tr>";
            }
            strResult += "</tbody></table>";

            document.getElementById('data-viewer').innerHTML = strResult;
            switch (method) {
                case "best-selling": document.getElementById('report-info').innerHTML = "Best selling";
                    break;
                case "in-warehouse-absent-msc-spb": document.getElementById('report-info').innerHTML = "In stock in warehouse, absent in Msc and Spb";
                    break;
            }
            
        }
    }

    function GetCategoryWithFiveAndMoreProductss() {
        HideCalendar()
        fetch('https://localhost:5001/api/report/category-with-five-and-more-products')
            .then((response) => response.json())
            .then((data) => {
                CreateTable(data);
            });


        function CreateTable(reportModel) {
            var strResult = "<table class='table'><thead><tr>" +
                            "<th scope='col'>Category</th>" +
                            "<th scope='col'>Count of Product</th>" +
                            "</tr></thead><tbody>";
            reportModel.forEach(x => {
                strResult +="<tr><th scope='row'>" + x.category +
                            "</th><td> " + x.countProduct +
                            "</td>";
            });
            strResult += "</tbody></table>";

            document.getElementById('data-viewer').innerHTML = strResult;
            document.getElementById('report-info').innerHTML = "Category with 5 and more products";
        }
    }

    function GetProduct(method) {
        HideCalendar()
        let url;
        switch (method) {
            case "sold-out": url = "https://localhost:5001/api/report/sold-out-products";
                break;
            case "no-ordered": url = "https://localhost:5001/api/report/no-ordered-products";
                break;
        }
        fetch(url)
            .then((response) => response.json())
            .then((data) => {
                CreateTable(data);
            });

        function CreateTable(reportModel) {
            var strResult = "<table class='table'><thead><tr>" +
                            "<th scope='col'>Manufacturer</th>" +
                            "<th scope='col'>Model</th>" +
                            "<th scope='col'>Price, RUB</th>" +
                            "</tr></thead><tbody>";

            let length = reportModel.length > 100 ? 100 : reportModel.length;

            for (let i = 0; i < length; i++) {
               strResult += "<tr><td scope='row'>" + reportModel[i].manufacturer +
                            "</td><td> " + reportModel[i].model +
                            "</td><td>" + reportModel[i].price +
                            "</td>";
                }
            strResult += "</tbody></table>";

            document.getElementById('data-viewer').innerHTML = strResult;
            switch (method) {
                case "sold-out": document.getElementById('report-info').innerHTML = "Sold out products";
                    break;
                case "no-ordered": document.getElementById('report-info').innerHTML = "No ordered products";
                    break;
            }
        }
    }

    async function GetOrdersByDate() {

        let startDateForUrl = FormateDate(this.document.getElementById("start-date").value);
        let endDateForUrl = FormateDate(this.document.getElementById("end-date").value);
        let url = 'https://localhost:5001/api/report/info-about-orders-by-date/' + startDateForUrl + '/' + endDateForUrl;

        fetch(url)
            .then((response) => response.json())
            .then((data) => {
                CreateTable(data);
            });

        function CreateTable(reportModel) {

            let length = reportModel.length > 100 ? 100 : reportModel.length;

            let lastOrders = reportModel.slice(0, length).sort((a, b) => {
                let datePartsA = a.date.split('.');
                let datePartsB = b.date.split('.');
                let dateA = new Date(datePartsA[2], datePartsA[1] - 1, datePartsA[0]);
                let dateB = new Date(datePartsB[2], datePartsB[1] - 1, datePartsB[0]);

                return dateB - dateA;
            });
                
            console.log(lastOrders);

            var strResult = "";
            for (let i = 0; i < length; i++) {
                var totalAmount = 0;
                strResult += "<div class='accordion'><B>Date:</B> " + lastOrders[i].date +
                            ", <B>Store:</B> " + lastOrders[i].city +
                            ", " + lastOrders[i].storeAddress +
                            "</div>" +
                            "<div class='panel'><table class='table'><thead><tr>" +
                            "<th scope='col'>Manufacturer</th>" +
                            "<th scope='col'>Model</th>" +
                            "<th scope='col'>Price</th>" +
                            "<th scope='col'>Quantity</th>" +
                            "<th scope='col'>Total, RUB</th>" +
                            "</tr></thead><tbody>";

                for (let j = 0; j < lastOrders[i].products.length; j++) {
                    strResult += "<tr><td scope='row'>" + lastOrders[i].products[j].manufacturer +
                        "</td><td>" + lastOrders[i].products[j].model +
                        "</td><td>" + lastOrders[i].products[j].price +
                        "</td><td>" + lastOrders[i].products[j].quantity +
                        "</td><td>" + lastOrders[i].products[j].total +
                        "</td>";
                    totalAmount += lastOrders[i].products[j].total;
                }

                strResult += "<tr class='total-amount'><td scope='row'><b>Total Amount: </b>" +
                    "</td><td>" +
                    "</td><td>" +
                    "</td><td>" + 
                    "</td><td>" + totalAmount +
                    "</td></table></div>";            
            }    

            document.getElementById('data-viewer').innerHTML = strResult;
            document.getElementById('report-info').innerHTML = "Orders by date";
            accordion(); //accordion.js
        }

        function FormateDate(date) {
            return date.substring(8, 10) + date.substring(5, 7) + date.substring(0, 4);
        }
    }

    function GetSalesByWorldAndRF() {
        HideCalendar()
        fetch('https://localhost:5001/api/report/sales-by-world-and-rf')
            .then((response) => response.json())
            .then((data) => {
                CreateTable(data);
            });

        function CreateTable(reportModel) {
            var strResult = "<table class='table'><thead><tr>" +
                            "<th scope='col'>Sales In RF, RUB</th>" +
                            "<th scope='col'>Sales In The World, RUB</th>" +
                            "</tr></thead><tbody>";
               strResult += "<tr><td scope='row'>" + Math.round(reportModel.salesInRF) +
                            "</td><td> " + Math.round(reportModel.salesInTheWorld)+
                            "</td></tbody></table>";

            document.getElementById('data-viewer').innerHTML = strResult;
            document.getElementById('report-info').innerHTML = "Sales By World And RF";
        }
    }


    function HideCalendar() {
        document.getElementById('date').style.display = 'none';
    }

    function ShowCalendar() {
        document.getElementById('data-viewer').innerHTML = ' ';
        document.getElementById('date').style.display = 'block';
    }

    document.getElementById('money-in-city-btn').addEventListener("click", () => GetMoneyInCity());
    document.getElementById('best-selling-product-btn').addEventListener("click", () => GetProductInStore("best-selling"));
    document.getElementById('in-warehouse-absent-msc-spb-btn').addEventListener("click", () => GetProductInStore("in-warehouse-absent-msc-spb"));
    document.getElementById('category-with-five-and-more-products-btn').addEventListener("click", () => GetCategoryWithFiveAndMoreProductss());
    document.getElementById('sold-out-product-btn').addEventListener("click", () => GetProduct("sold-out"));
    document.getElementById('no-ordered-product-btn').addEventListener("click", () => GetProduct("no-ordered"));
    document.getElementById('show-calendar-btn').addEventListener("click", () => ShowCalendar());
    document.getElementById('order-by-date-btn').addEventListener("click", () => GetOrdersByDate());
    document.getElementById('sales-by-world-and-rf-btn').addEventListener("click", () => GetSalesByWorldAndRF());
    HideCalendar();
    GetMoneyInCity();
}


