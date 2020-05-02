function GetMoneyInCity() {

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

    fetch('https://localhost:5001/api/report/info-about-orders-by-date', { body: { StartDate: '01.01.2015', EndDate: '01.01.2018' } })
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

window.onload = function () {
    document.getElementById('moneyInCity').addEventListener("click", () => GetMoneyInCity());
    document.getElementById('bestSellingProduct').addEventListener("click", () => GetProductInStore("best-selling"));
    document.getElementById('inWareHouseAbsentMscSpb').addEventListener("click", () => GetProductInStore("in-warehouse-absent-msc-spb"));
    document.getElementById('categoryWithFiveAndMoreProducts').addEventListener("click", () => GetCategoryWithFiveAndMoreProducts());
    document.getElementById('soldOutProduct').addEventListener("click", () => GetProduct("sold-out"));
    document.getElementById('noOrderedProduct').addEventListener("click", () => GetProduct("no-ordered"));
    document.getElementById('orderByDate').addEventListener("click", () => GetOrdersByDate());
}

