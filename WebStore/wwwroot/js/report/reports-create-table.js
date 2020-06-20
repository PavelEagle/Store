let reportCreateTableModule = {
    moneyInCityCreateTable: function (reportModel) {
        let strResult = "<table class='table'><thead><tr>" +
            "<th scope='col'><a class = 'city-sort'>City</a></th>" +
            "<th scope='col'><a class = 'total-money-sort'>Total</a></th>" +
            "</tr></thead><tbody>";
        reportModel.forEach(x => {
            strResult += "<tr><td scope='row'>" + x.city +
                "</td><td> " + x.total +
                "</td></tr>";
        });
        strResult += "</tbody></table>";

        document.getElementById('data-viewer').innerHTML = strResult;
        document.getElementsByClassName('city-sort')[0].addEventListener("click", () => sortModule.sortReports.citySort('moneyInCity'));
        document.getElementsByClassName('total-money-sort')[0].addEventListener("click", () => sortModule.sortReports.totalMoneySort('moneyInCity'));
    },
    productInStoreCreateTable: function (reportModel) {
        let strResult = "<table class='table'><thead><tr>" +
            "<th scope='col'><a class = 'city-sort'>City</a></th>" +
            "<th scope='col'><a class = 'address-sort'>Address</a></th>" +
            "<th scope='col'><a class = 'manufacturer-sort'>Manufacturer</a></th>" +
            "<th scope='col'><a class = 'model-sort'>Model</a></th>" +
            "<th scope='col'><a class = 'price-sort'>Price</a></th>" +
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

        document.getElementsByClassName('city-sort')[0].addEventListener("click", () => sortModule.sortReports.citySort('productInStore'));
        document.getElementsByClassName('address-sort')[0].addEventListener("click", () => sortModule.sortReports.addressSort('productInStore'));
        document.getElementsByClassName('manufacturer-sort')[0].addEventListener("click", () => sortModule.sortReports.manufacturerSort('productInStore'));
        document.getElementsByClassName('model-sort')[0].addEventListener("click", () => sortModule.sortReports.modelSort('productInStore'));
        document.getElementsByClassName('price-sort')[0].addEventListener("click", () => sortModule.sortReports.priceSort('productInStore'));
    },
    categoryCreateTable: function (reportModel) {
        let strResult = "<table class='table'><thead><tr>" +
            "<th scope='col'><a class = 'category-sort'>Category</a></th>" +
            "<th scope='col'><a class = 'count-of-products-sort'>Count of Products</a></th>" +
            "</tr></thead><tbody>";
        reportModel.forEach(x => {
            strResult += "<tr><th scope='row'>" + x.category +
                "</th><td> " + x.countProduct +
                "</td>";
        });
        strResult += "</tbody></table>";

        document.getElementById('data-viewer').innerHTML = strResult;

        document.getElementsByClassName('category-sort')[0].addEventListener("click", () => sortModule.sortReports.citySort('category'));
        document.getElementsByClassName('count-of-products-sort')[0].addEventListener("click", () => sortModule.sortReports.countProductSort('category'));
    },
    productCreateTable: function (reportModel) {
        let strResult = "<table class='table'><thead><tr>" +
            "<th scope='col'><a class = 'manufacturer-sort'>Manufacturer</a></th>" +
            "<th scope='col'><a class = 'model-sort'>Model</a></th>" +
            "<th scope='col'><a class = 'price-sort'>Price</a></th>" +
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

        document.getElementsByClassName('manufacturer-sort')[0].addEventListener("click", () => sortModule.sortReports.manufacturerSort('product'));
        document.getElementsByClassName('model-sort')[0].addEventListener("click", () => sortModule.sortReports.modelSort('product'));
        document.getElementsByClassName('price-sort')[0].addEventListener("click", () => sortModule.sortReports.priceSort('product'));
    },
    ordersByDateCreateTable: function (reportModel) {
        let length = reportModel.length > 100 ? 100 : reportModel.length;

        let lastOrders = reportModel.slice(0, length).sort((a, b) => {
            let datePartsA = a.date.split('.');
            let datePartsB = b.date.split('.');
            let dateA = new Date(datePartsA[2], datePartsA[1] - 1, datePartsA[0]);
            let dateB = new Date(datePartsB[2], datePartsB[1] - 1, datePartsB[0]);

            return dateB - dateA;
        });

        let strResult = "";
        for (let i = 0; i < length; i++) {
            var totalAmount = 0;
            strResult += "<div class='accordion'><B>Date:</B> " + lastOrders[i].date +
                ", <B>Store:</B> " + lastOrders[i].city +
                ", " + lastOrders[i].storeAddress +
                "</div>" +
                "<div class='panel'><table class='table'><thead><tr>" +
                "<th scope='col'><a class = 'manufacturer-sort'>Manufacturer</a></th>" +
                "<th scope='col'><a class = 'model-sort'>Model</a></th>" +
                "<th scope='col'><a class = 'price-sort'>Price</a></th>" +
                "<th scope='col'><a class = 'quantity-sort'>Quantity</a></th>" +
                "<th scope='col'><a class = 'total-price-sort'>Total</a></th>" +
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

        document.getElementsByClassName('manufacturer-sort')[0].addEventListener("click", () => sortModule.sortReports.manufacturerSort('ordersByDate'));
        document.getElementsByClassName('model-sort')[0].addEventListener("click", () => sortModule.sortReports.modelSort('ordersByDate'));
        document.getElementsByClassName('price-sort')[0].addEventListener("click", () => sortModule.sortReports.priceSort('ordersByDate'));
        document.getElementsByClassName('quantity-sort')[0].addEventListener("click", () => sortModule.sortReports.quantitySort('ordersByDate'));
        document.getElementsByClassName('total-price-sort')[0].addEventListener("click", () => sortModule.sortReports.totalMoneySort('ordersByDate'));

        accordion(); //site.js
    },
    salesByWorldAndRFCreateTable: function (reportModel) {
        let strResult = "<table class='table'><thead><tr>" +
            "<th scope='col'>Sales In RF, RUB</th>" +
            "<th scope='col'>Sales In The World, RUB</th>" +
            "</tr></thead><tbody>";
        strResult += "<tr><td scope='row'>" + Math.round(reportModel.salesInRF) +
            "</td><td> " + Math.round(reportModel.salesInTheWorld) +
            "</td></tbody></table>";

        document.getElementById('data-viewer').innerHTML = strResult;
    }
}
