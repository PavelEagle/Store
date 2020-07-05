(function () {
    document.getElementById('money-in-city-btn').addEventListener("click", () => reportsDataModule.getMoneyInCity());
    document.getElementById('best-selling-product-btn').addEventListener("click", () => reportsDataModule.getProductInStore("best-selling"));
    document.getElementById('in-warehouse-absent-msc-spb-btn').addEventListener("click", () => reportsDataModule.getProductInStore("in-warehouse-absent-msc-spb"));
    document.getElementById('category-with-five-and-more-products-btn').addEventListener("click", () => reportsDataModule.getCategoryWithFiveAndMoreProducts());
    document.getElementById('sold-out-product-btn').addEventListener("click", () => reportsDataModule.getProduct("sold-out"));
    document.getElementById('no-ordered-product-btn').addEventListener("click", () => reportsDataModule.getProduct("no-ordered"));
    document.getElementById('show-calendar-btn').addEventListener("click", () => reportsAnimate.showCalendar());
    document.getElementById('order-by-date-btn').addEventListener("click", () => reportsDataModule.getOrdersByDate());
    document.getElementById('sales-by-world-and-rf-btn').addEventListener("click", () => reportsDataModule.GetSalesByWorldAndRF());
    reportsAnimate.hideCalendar();
    reportsDataModule.getMoneyInCity();
})();




