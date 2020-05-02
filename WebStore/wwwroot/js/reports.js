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
            strResult += "<tr><td>" + x.city + "</td><td> " + x.total + "</td><td>";
        });
        strResult += "</table>";

        document.getElementById('DateTable').innerHTML = strResult;
    }
}

function GetProductInStore(method) {
    HideCalendar();
    let url;
    switch (method) {
        case "best-selling" : url = "https://localhost:5001/api/report/best-selling-product";
            break;
        case "in-warehouse-absent-msc-spb": url = "https://localhost:5001/api/report/products-in-warehouse-and-absent-in-moscow-and-spb";
            break;
    }
    fetch(url)
        .then((response) => response.json())
        .then((data) => {
            CreateTable(data);
        });

    function CreateTable(reportModel) {
        var strResult = "<table><th>City</th><th>Address</th><th>Manufacturer</th><th>Model</th><th>Price</th>";
        reportModel.forEach(x => {
            strResult += "<tr><td>" + x.city + "</td><td> " + x.address + "</td><td>" + x.manufacturer + "</td><td>"
                + x.model + "</td><td>" + x.price + "</td><td>";
        });
        strResult += "</table>";

        document.getElementById('DateTable').innerHTML = strResult;
    }
}

function GetCategoryWithFiveAndMoreProducts() {
    HideCalendar()
    fetch('https://localhost:5001/api/report/category-with-five-and-more-product')
        .then((response) => response.json())
        .then((data) => {
            CreateTable(data);
        });

    function CreateTable(reportModel) {
        var strResult = "<table><th>Category</th><th>Count of Product</th>";
        reportModel.forEach(x => {
            strResult += "<tr><td>" + x.category + "</td><td> " + x.countProduct + "</td><td>";
        });
        strResult += "</table>";

        document.getElementById('DateTable').innerHTML = strResult;
    }
}

function GetProduct(method) {
    HideCalendar()
    let url;
    switch (method) {
        case "sold-out": url = "https://localhost:5001/api/report/sold-out-product";
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
        var strResult = "<table><th>Manufacturer</th><th>Model</th><th>Price</th>";
        reportModel.forEach(x => {
            strResult += "<tr><td>" + x.manufacturer + "</td><td> " + x.model + "</td><td>" + x.price + "</td><td>";
        });
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
        var strResult = "<table><th>City</th>" +
                        "<th>Address</th>" +
                        "<th>Manufacturer</th>" +
                        "<th>Model</th>" +
                        "<th>Price</th>" +
                        "<th>Quantity</th>" +
                        "<th>Total</th>" +
                        "<th>OrderAddress</th>" +
                        "<th>Date</th>";
        reportModel.forEach(x => {
            strResult += "<tr><td>" + x.city +
                         "</td><td>" + x.address +
                         "</td><td>" + x.manufacturer +
                         "</td><td>" + x.model +
                         "</td><td>" + x.price +
                         "</td><td>" + x.quantity +
                         "</td><td>" + x.total +
                         "</td><td>" + x.orderAddress +
                         "</td><td>" + x.date +
                         "</td><td>";
        });
        strResult += "</table>";

        document.getElementById('DateTable').innerHTML = strResult;
    }

    function FormateDate(date) {
        return date.substring(8, 10) + date.substring(5, 7) + date.substring(0, 4);
    }
}
function HideCalendar() {
    document.getElementById('date').style.display = 'none';
}

function OpenCalendar() {
    document.getElementById('DateTable').innerHTML = ' ';
    document.getElementById('date').style.display = 'block';
}

window.onload = function () {
    document.getElementById('moneyInCity').addEventListener("click", () => GetMoneyInCity());
    document.getElementById('bestSellingProduct').addEventListener("click", () => GetProductInStore("best-selling"));
    document.getElementById('inWareHouseAbsentMscSpb').addEventListener("click", () => GetProductInStore("in-warehouse-absent-msc-spb"));
    document.getElementById('categoryWithFiveAndMoreProducts').addEventListener("click", () => GetCategoryWithFiveAndMoreProducts());
    document.getElementById('soldOutProduct').addEventListener("click", () => GetProduct("sold-out"));
    document.getElementById('noOrderedProduct').addEventListener("click", () => GetProduct("no-ordered"));
    document.getElementById('openCalendar').addEventListener("click", () => OpenCalendar()());
    document.getElementById('orderByDate').addEventListener("click", () => GetOrdersByDate());
    HideCalendar();
}

