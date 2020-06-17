let productAnimate = {
    hideProductDate: function() {
        document.getElementById('product-get-by-id-data').style.display = 'none';
        document.getElementById('product-post-data').style.display = 'none';
        document.getElementById('product-update-data').style.display = 'none';
        document.getElementById('product-data-viewer').innerHTML = ' ';
    },
    showGetByIdDate: function () {
        this.hideProductDate();
        this.removeProductBtnActiveClass();
        document.getElementById('product-get-by-id-data').style.display = 'block';
        document.getElementById('product-get-del-method-btn')
            .firstElementChild.classList.add("product-btn-active");
    },
    showPostDate: function () {
        this.hideProductDate();
        this.removeProductBtnActiveClass();
        document.getElementById('product-post-data').style.display = 'block';
        document.getElementById('product-post-method-btn')
            .firstElementChild.classList.add("product-btn-active");
    },
    showUpdateDate: function () {
        this.hideProductDate();
        this.removeProductBtnActiveClass();
        document.getElementById('product-update-data').style.display = 'block';
        document.getElementById('product-update-method-btn')
            .firstElementChild.classList.add("product-btn-active");
    },
    removeProductBtnActiveClass: function () {
        var elems = document.querySelector(".product-btn-active");
        if (elems !== null) {
            elems.classList.remove("product-btn-active");
        }
    }
}
