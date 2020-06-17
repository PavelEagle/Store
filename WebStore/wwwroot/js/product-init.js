(function () {
    document.getElementById('product-get-del-method-btn').addEventListener("click", () => productAnimate.showGetByIdDate());
    document.getElementById('product-post-method-btn').addEventListener("click", () => productAnimate.showPostDate());
    document.getElementById('product-update-method-btn').addEventListener("click", () => productAnimate.showUpdateDate());
    document.getElementById('get-by-id-btn').addEventListener("click", () => productDataModule.productGet());
    document.getElementById('post-btn').addEventListener("click", () => productDataModule.productPost());
    document.getElementById('update-btn').addEventListener("click", () => productDataModule.productUpdate());
    document.getElementById('delete-by-id-btn').addEventListener("click", () => productDataModule.productDelete());
    productAnimate.hideProductDate();
    productDataModule.productGet();
})();
