﻿window.onload = function () {
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

            document.getElementById('dataViewer').innerHTML = strResult;
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

            document.getElementById('dataViewer').innerHTML = strResult;
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

            document.getElementById('dataViewer').innerHTML = strResult;
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

            document.getElementById('dataViewer').innerHTML = strResult;
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
            var strResult = "<table class='table'><thead><tr>" +
                            "<th scope='col'>OrderId</th>" +
                            "<th scope='col'>City</th>" +
                            "<th scope='col'>Address</th>" +
                            "<th scope='col'>Manufacturer</th>" +
                            "<th scope='col'>Model</th>" +
                            "<th scope='col'>Price</th>" +
                            "<th scope='col'>Quantity</th>" +
                            "<th scope='col'>Total, RUB</th>" +
                            "<th scope='col'>Order Address</th>" +
                            "<th scope='col'>Date</th>" +
                            "</tr></thead><tbody>";

            let length = reportModel.length > 100 ? 100 : reportModel.length;

            for (let i = 0; i < length; i++) {
                strResult += "<tr><td scope='row'>" + reportModel[i].orderId +
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
            strResult += "</tbody></table>";

            document.getElementById('dataViewer').innerHTML = strResult;
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

            document.getElementById('dataViewer').innerHTML = strResult;
        }
    }


    function HideCalendar() {
        document.getElementById('date').style.display = 'none';
    }

    function ShowCalendar() {
        document.getElementById('dataViewer').innerHTML = ' ';
        document.getElementById('date').style.display = 'block';
    }

    {
        document.getElementById('moneyInCity-btn').addEventListener("click", () => GetMoneyInCity());
        document.getElementById('bestSellingProduct-btn').addEventListener("click", () => GetProductInStore("best-selling"));
        document.getElementById('inWareHouseAbsentMscSpb-btn').addEventListener("click", () => GetProductInStore("in-warehouse-absent-msc-spb"));
        document.getElementById('categoryWithFiveAndMoreProducts-btn').addEventListener("click", () => GetCategoryWithFiveAndMoreProductss());
        document.getElementById('soldOutProduct-btn').addEventListener("click", () => GetProduct("sold-out"));
        document.getElementById('noOrderedProduct-btn').addEventListener("click", () => GetProduct("no-ordered"));
        document.getElementById('showCalendar-btn').addEventListener("click", () => ShowCalendar());
        document.getElementById('orderByDate-btn').addEventListener("click", () => GetOrdersByDate());
        document.getElementById('salesByWorldAndRF-btn').addEventListener("click", () => GetSalesByWorldAndRF());
        HideCalendar();
    }
}


