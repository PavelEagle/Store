window.onload = function () {
    function GetMoneyInCity() {
        HideCalendar();
        fetch('https://localhost:5001/api/report/money-in-city')
            .then((response) => response.json())
            .then((data) => {
                CreateTable(data);
            });

        function CreateTable(reportModel) {
            var strResult = "<table><th>City</th><th>Total Money</th>";
            reportModel.forEach(x => {
                strResult += "<tr><td>" + x.city +
                             "</td><td> " + x.total +
                             "</td>";
            });
            strResult += "</table>";

            document.getElementById('DateTable').innerHTML = strResult;
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
            var strResult = "<table><th>City</th>" +
                            "<th> Address</th>" +
                            "<th> Manufacturer</th>" +
                            "<th> Model</th>" +
                             "<th> Price</th>";

            let length = reportModel.length > 100 ? 100 : reportModel.length;
                
            for (let i = 0; i < length; i++) {
                strResult += "</tr><td> " + reportModel[i].city +
                    "</td><td>" + reportModel[i].address +
                    "</td><td>" + reportModel[i].manufacturer +
                    "</td><td>" + reportModel[i].model +
                    "</td><td>" + reportModel[i].price +
                    "</td>";
            }
            strResult += "</table>";

            document.getElementById('DateTable').innerHTML = strResult;
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
            var strResult = "<table><th>Category</th>" +
                            "<th>Count of Product</th> ";
            reportModel.forEach(x => {
                strResult += "<tr><td>" + x.category +
                            "</td><td> " + x.countProduct +
                            "</td>";
            });
            strResult += "</table>";

            document.getElementById('DateTable').innerHTML = strResult;
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
            var strResult = "<table><th>Manufacturer</th>" +
                            "<th> Model</th>" +
                            "<th> Model</th>";

            let length = reportModel.length > 100 ? 100 : reportModel.length;

            for (let i = 0; i < length; i++) {
                strResult += "<tr><td>" + reportModel[i].manufacturer +
                    "</td><td> " + reportModel[i].model +
                    "</td><td>" + reportModel[i].price +
                    "</td>";
                }
            strResult += "</table>";

            document.getElementById('DateTable').innerHTML = strResult;
        }
    }

    async function GetOrdersByDate() {

        let startDateForUrl = FormateDate(this.document.getElementById("startDate").value);
        let endDateForUrl = FormateDate(this.document.getElementById("endDate").value);
        let url = 'https://localhost:5001/api/report/info-about-orders-by-date/' + startDateForUrl + '/' + endDateForUrl;

        fetch(url)
            .then((response) => response.json())
            .then((data) => {
                CreateTable(data);
            });

        function CreateTable(reportModel) {
            var strResult = "<table><th>OrderId</th>" +
                            "<th>City</th>" +
                            "<th>Address</th>" +
                            "<th>Manufacturer</th>" +
                            "<th>Model</th>" +
                            "<th>Price</th>" +
                            "<th>Quantity</th>" +
                            "<th>Total</th>" +
                            "<th>OrderAddress</th>" +
                            "<th>Date</th>";

            let length = reportModel.length > 100 ? 100 : reportModel.length;

            for (let i = 0; i < length; i++) {
                strResult += "<tr><td>" + reportModel[i].orderId +
                             "</td><td>" + reportModel[i].city +
                             "</td><td>" + reportModel[i].address +
                             "</td><td>" + reportModel[i].manufacturer +
                             "</td><td>" + reportModel[i].model +
                             "</td><td>" + reportModel[i].price +
                             "</td><td>" + reportModel[i].quantity +
                             "</td><td>" + reportModel[i].total +
                             "</td><td>" + reportModel[i].orderAddress +
                             "</td><td>" + reportModel[i].date +
                             "</td>";
                }
            strResult += "</table>";

            document.getElementById('DateTable').innerHTML = strResult;
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
            var strResult = "<table><th>SalesInRF</th>" +
                "<th>SalesInTheWorld</th> ";
            strResult += "<tr><td>" + Math.round(reportModel.salesInRF) +
                "</td><td> " + Math.round(reportModel.salesInTheWorld)+
                "</td></table>";

            document.getElementById('DateTable').innerHTML = strResult;
        }
    }


    function HideCalendar() {
        document.getElementById('date').style.display = 'none';
    }

    function ShowCalendar() {
        document.getElementById('DateTable').innerHTML = ' ';
        document.getElementById('date').style.display = 'block';
    }

    {
        document.getElementById('moneyInCity').addEventListener("click", () => GetMoneyInCity());
        document.getElementById('bestSellingProduct').addEventListener("click", () => GetProductInStore("best-selling"));
        document.getElementById('inWareHouseAbsentMscSpb').addEventListener("click", () => GetProductInStore("in-warehouse-absent-msc-spb"));
        document.getElementById('categoryWithFiveAndMoreProducts').addEventListener("click", () => GetCategoryWithFiveAndMoreProductss());
        document.getElementById('soldOutProduct').addEventListener("click", () => GetProduct("sold-out"));
        document.getElementById('noOrderedProduct').addEventListener("click", () => GetProduct("no-ordered"));
        document.getElementById('showCalendar').addEventListener("click", () => ShowCalendar());
        document.getElementById('orderByDate').addEventListener("click", () => GetOrdersByDate());
        document.getElementById('salesByWorldAndRF').addEventListener("click", () => GetSalesByWorldAndRF());
        HideCalendar();
    }
}


