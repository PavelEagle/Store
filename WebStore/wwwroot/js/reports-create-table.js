let reportCreateTableModule = {
    getMoneyInCityCreateTable: function (reportModel) {
        let strResult = "<table class='table'><thead><tr>" +
            "<th scope='col'><a class = 'city-sort' href='#'>City</a></th>" +
            "<th scope='col'><a class = 'total-money-sort' href='#'>Total Money, RUB</a></th>" +
            "</tr></thead><tbody>";
        reportModel.forEach(x => {
            strResult += "<tr><th scope='row'>" + x.city +
                "</th><td> " + x.total +
                "</td></tr>";
        });
        strResult += "</tbody></table>";

        document.getElementById('data-viewer').innerHTML = strResult;
    },
    getProductInStoreCreateTable: function (reportModel) {
        let strResult = "<table class='table'><thead><tr>" +
            "<th scope='col'><a class = 'city-sort' href='#'>City</a></th>" +
            "<th scope='col'><a class = 'address-sort' href='#'>Address</a></th>" +
            "<th scope='col'><a class = 'manufacturer-sort' href='#'>Manufacturer</a></th>" +
            "<th scope='col'><a class = 'model-sort' href='#'>Model</a></th>" +
            "<th scope='col'><a class = 'price-sort' href='#'>Price, RUB</a></th>" +
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
    },
    getCategoryCreateTable: function (reportModel) {
        let strResult = "<table class='table'><thead><tr>" +
            "<th scope='col'><a class = 'category-sort' href='#'>Category</a></th>" +
            "<th scope='col'><a class = 'count-of-products-sort' href='#'>Count of Products</a></th>" +
            "</tr></thead><tbody>";
        reportModel.forEach(x => {
            strResult += "<tr><th scope='row'>" + x.category +
                "</th><td> " + x.countProduct +
                "</td>";
        });
        strResult += "</tbody></table>";

        document.getElementById('data-viewer').innerHTML = strResult;
    },
    getProductCreateTable: function (reportModel) {
        let strResult = "<table class='table'><thead><tr>" +
            "<th scope='col'><a class = 'manufacturer-sort' href='#'>Manufacturer</a></th>" +
            "<th scope='col'><a class = 'model-sort' href='#'>Model</a></th>" +
            "<th scope='col'><a class = 'price-sort' href='#'>Price, RUB</a></th>" +
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
    },
    getOrdersByDateCreateTable: function (reportModel) {
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
                "<th scope='col'><a class = 'manufacturer-sort' href='#'>Manufacturer</a></th>" +
                "<th scope='col'><a class = 'model-sort' href='#'>Model</a></th>" +
                "<th scope='col'><a class = 'price-sort' href='#'>Price</a></th>" +
                "<th scope='col'><a class = 'quantity-sort' href='#'>Quantity</a></th>" +
                "<th scope='col'><a class = 'total-price-sort' href='#'>Total, RUB</a></th>" +
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
        accordion(); //site.js
    },
    GetSalesByWorldAndRFCreateTable: function (reportModel) {
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
