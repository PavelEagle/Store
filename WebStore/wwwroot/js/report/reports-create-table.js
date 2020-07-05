let reportCreateTableModule = {
    createTable: function (reportModel) {
        let titles = Object.keys(reportModel[0]);
        let strResult = "<table class='table'><thead><tr>";
        for (let i = 0; i < titles.length; i++) {
            strResult += "<th scope='col'><a>" + titles[i][0].toUpperCase() + titles[i].substring(1) + "</a></th>";
        }
        strResult += "</tr></thead><tbody>";

        for (let i = 0; i < reportModel.length; i++) {
            let values = Object.values(reportModel[i]);
            strResult += "<tr><td scope='row'>" + values[0] + "</td>";
            for (let j = 1; j < values.length; j++) {
                strResult += "<td>" + values[j] + "</td>";
            }
        }
        strResult += "</tbody></table>";
        document.getElementById('data-viewer').innerHTML = strResult;
    },
   
    reportsTableCreator: {
        moneyInCityCreateTable: function (reportModel) {
            reportCreateTableModule.createTable(reportModel);

            let linkForSort = document.getElementsByTagName('thead')[0].getElementsByTagName('a');
            linkForSort[0].classList.add('city-sort');
            linkForSort[1].classList.add('total-money-sort');

            document.getElementsByClassName('city-sort')[0].addEventListener("click", () => sortModule.sortReports.citySort('moneyInCity'));
            document.getElementsByClassName('total-money-sort')[0].addEventListener("click", () => sortModule.sortReports.totalMoneySort('moneyInCity'));
        },
        productInStoreCreateTable: function (reportModel) {
            
            reportCreateTableModule.createTable(reportModel);

            let linkForSort = document.getElementsByTagName('thead')[0].getElementsByTagName('a');
            linkForSort[0].classList.add('city-sort');
            linkForSort[1].classList.add('address-sort');
            linkForSort[2].classList.add('manufacturer-sort');
            linkForSort[3].classList.add('model-sort');
            linkForSort[4].classList.add('price-sort');

            document.getElementsByClassName('city-sort')[0].addEventListener("click", () => sortModule.sortReports.citySort('productInStore'));
            document.getElementsByClassName('address-sort')[0].addEventListener("click", () => sortModule.sortReports.addressSort('productInStore'));
            document.getElementsByClassName('manufacturer-sort')[0].addEventListener("click", () => sortModule.sortReports.manufacturerSort('productInStore'));
            document.getElementsByClassName('model-sort')[0].addEventListener("click", () => sortModule.sortReports.modelSort('productInStore'));
            document.getElementsByClassName('price-sort')[0].addEventListener("click", () => sortModule.sortReports.priceSort('productInStore'));
        },
        categoryCreateTable: function (reportModel) {
            reportCreateTableModule.createTable(reportModel);

            let linkForSort = document.getElementsByTagName('thead')[0].getElementsByTagName('a');
            linkForSort[0].classList.add('category-sort');
            linkForSort[1].classList.add('count-of-products-sort');

            document.getElementsByClassName('category-sort')[0].addEventListener("click", () => sortModule.sortReports.citySort('category'));
            document.getElementsByClassName('count-of-products-sort')[0].addEventListener("click", () => sortModule.sortReports.countProductSort('category'));
        },
        productCreateTable: function (reportModel) {
            reportCreateTableModule.createTable(reportModel);

            let linkForSort = document.getElementsByTagName('thead')[0].getElementsByTagName('a');
            linkForSort[0].classList.add('manufacturer-sort');
            linkForSort[1].classList.add('model-sort');
            linkForSort[2].classList.add('price-sort');

            document.getElementsByClassName('manufacturer-sort')[0].addEventListener("click", () => sortModule.sortReports.manufacturerSort('product'));
            document.getElementsByClassName('model-sort')[0].addEventListener("click", () => sortModule.sortReports.modelSort('product'));
            document.getElementsByClassName('price-sort')[0].addEventListener("click", () => sortModule.sortReports.priceSort('product'));
        },
        ordersByDateCreateTable: function (reportModel) {
            const length = reportModel.length > 100 ? 100 : reportModel.length;

            let lastOrders = reportModel.slice(0, length).sort((a, b) => {
                let datePartsA, datePartsB, dateA, dateB;
                datePartsA = a.date.split('.');
                datePartsB = b.date.split('.');
                dateA = new Date(datePartsA[2], datePartsA[1] - 1, datePartsA[0]);
                dateB = new Date(datePartsB[2], datePartsB[1] - 1, datePartsB[0]);

                return dateB - dateA;
            });

            let titles, strResult = "";
            titles = Object.keys(reportModel[0].products[0]);

            for (let i = 0; i < length; i++) {
                let totalAmount = 0;
                strResult += "<div class='accordion'><b>Date:</b> " + lastOrders[i].date +
                    ", <b>Store:</b> " + lastOrders[i].city +
                    ", " + lastOrders[i].storeAddress +
                    "</div><div class='panel'><table class='table'><thead><tr>";
                for (let j = 0; j < titles.length; j++) {
                    strResult += "<th scope='col'>" + titles[j][0].toUpperCase() + titles[j].substring(1) + "</th>"
                }
                strResult += "</tr></thead><tbody>";

                for (let j = 0; j < lastOrders[i].products.length; j++) {
                    strResult += "<tr><td scope='row'>" + lastOrders[i].products[j].manufacturer +
                        "</td><td>" + lastOrders[i].products[j].model +
                        "</td><td>" + lastOrders[i].products[j].price +
                        "</td><td>" + lastOrders[i].products[j].quantity +
                        "</td><td>" + lastOrders[i].products[j].total +
                        "</td>";
                    totalAmount += lastOrders[i].products[j].total;
                }

                strResult += "<tr class='total-amount'><td scope='row'><b>Total Amount: </b></td>";
                for (let j = 0; j < titles.length - 1; j++) {
                    strResult += (j == titles.length - 2) ? "</td><td>" + totalAmount : "</td><td>";
                }
                strResult += "</td></table></div>";
            }

            document.getElementById('data-viewer').innerHTML = strResult;

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
}

