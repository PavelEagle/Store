let productDataModule = {
    productGet: function () {
        productAnimate.hideProductDate();
        productAnimate.showGetByIdDate();
        let url = 'https://localhost:5001/api/product/' + document.getElementById("product-id").value;
        fetch(url)
            .then((response) => response.json())
            .then((data) => {
                CreateProductTable(data);
            });
    },
    productPost: async function () {
        let data = {
            manufacturer: document.getElementById("post-manufacturer").value,
            model: document.getElementById("post-model").value,
            price: +document.getElementById("post-price").value,
            subcategoryId: +document.getElementById("post-sub-category").value
        };
        let response = await fetch('https://localhost:5001/api/product', {
            method: 'post',
            body: JSON.stringify(data),
            headers: { 'Content-type': 'application/json' }
        })
        let result = await response.json();
        CreateProductTable(result);
    },
    productUpdate: async function () {
        let data = {
            id: +document.getElementById("update-id").value,
            manufacturer: document.getElementById("update-manufacturer").value,
            model: document.getElementById("update-model").value,
            price: +document.getElementById("update-price").value,
            subcategoryId: +document.getElementById("update-subcategory").value
        };
        let response = await fetch('https://localhost:5001/api/product', {
            method: 'post',
            body: JSON.stringify(data),
            headers: { 'Content-type': 'application/json' }
        })
        let result = await response.json();
        CreateProductTable(result);
    },
    productDelete: async function () {
        let url = 'https://localhost:5001/api/product/' + document.getElementById("product-id").value;
        let response = await fetch(url, {
            method: 'delete',
            headers: { 'Content-type': 'application/json' }
        });
        if (response.status == 200) {
            document.getElementById('product-data-viewer').innerHTML = "Product with Id "
                + document.getElementById("product-id").value + " was deleted";
        }
        else document.getElementById('product-data-viewer').innerHTML = "error";
    }
};


window.onload = function () {
    //function ProductGet() {

    //}

    //async function ProductPost() {
     
    //}

    //async function ProductUpdate() {
       
    //}

    //async function ProductDelete() {
        
    //}



    


}
