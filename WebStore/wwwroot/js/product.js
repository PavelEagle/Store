window.onload = function () {
    function ProductGet() {
        HideProductDate();
        ShowGetByIdDate();
        let url = 'https://localhost:5001/api/product/' + document.getElementById("product-id").value;
        fetch(url)
            .then((response) => response.json())
            .then((data) => {
                CreateProductTable(data);
            });
    }

    async function ProductPost() {
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
    }

    async function ProductUpdate() {
        let data = {
            id: +document.getElementById("update-id").value,
            manufacturer: document.getElementById("update-manufacturer").value,
            model: document.getElementById("update-model").value,
            price: +document.getElementById("update-price").value,
            subcategoryId: +document.getElementById("update-subcategory").value
        };
        console.log(data);
        let response = await fetch('https://localhost:5001/api/product', {
            method: 'post',
            body: JSON.stringify(data),
            headers: { 'Content-type': 'application/json' }
        })
        let result = await response.json();
        CreateProductTable(result);
    }

    async function ProductDelete() {
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

    function CreateProductTable(reportModel) {
        console.log(reportModel);
        var strResult = "<table class='table'><thead><tr>" +
                        "<th scope='col'>Id</th>" +
                        "<th scope='col'>Manufacturer</th>" +
                        "<th scope='col'>Model</th>" +
                        "<th scope='col'>Price</th>" +
                        "<th scope='col'>Category</th>" +
                        "<th scope='col'>Subcategory</th>" +
                        "</tr></thead><tbody>";
           strResult += "<tr><td scope='row'>" + reportModel.id +
                        "</td><td>" + reportModel.manufacturer +
                        "</td><td>" + reportModel.model +
                        "</td><td>" + reportModel.price +
                        "</td><td>" + reportModel.categoryName +
                        "</td><td>" + reportModel.subcategory +
                        "</td></tbody></table>";

        document.getElementById('product-data-viewer').innerHTML = strResult;
    }

    function HideProductDate() {
        document.getElementById('product-get-by-id-data').style.display = 'none';
        document.getElementById('product-post-data').style.display = 'none';
        document.getElementById('product-update-data').style.display = 'none';
        document.getElementById('product-data-viewer').innerHTML = ' ';
    }

    function ShowGetByIdDate() {
        HideProductDate();
        removeProductBtnActiveClass();
        document.getElementById('product-get-by-id-data').style.display = 'block';
        document.getElementById('product-get-del-method-btn')
            .firstElementChild.classList.add("product-btn-active");
    }
    function ShowPostDate() {
        HideProductDate();
        removeProductBtnActiveClass();
        document.getElementById('product-post-data').style.display = 'block';
        document.getElementById('product-post-method-btn')
            .firstElementChild.classList.add("product-btn-active");
    }

    function ShowUpdateDate() {
        HideProductDate();
        removeProductBtnActiveClass();
        document.getElementById('product-update-data').style.display = 'block';
        document.getElementById('product-update-method-btn')
            .firstElementChild.classList.add("product-btn-active");
    }

    function removeProductBtnActiveClass() {
        var elems = document.querySelector(".product-btn-active");
        if (elems !== null) {
            elems.classList.remove("product-btn-active");
        }
    }

    document.getElementById('product-get-del-method-btn').addEventListener("click", () => ShowGetByIdDate());
    document.getElementById('product-post-method-btn').addEventListener("click", () => ShowPostDate());
    document.getElementById('product-update-method-btn').addEventListener("click", () => ShowUpdateDate());
    document.getElementById('get-by-id-btn').addEventListener("click", () => ProductGet());
    document.getElementById('post-btn').addEventListener("click", () => ProductPost());
    document.getElementById('update-btn').addEventListener("click", () => ProductUpdate());
    document.getElementById('delete-by-id-btn').addEventListener("click", () => ProductDelete());
    HideProductDate();
    ProductGet();
}
