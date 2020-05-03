function ProductGet() {
    HideProductDate();
    ShowGetByIdDate();
    let url = 'https://localhost:5001/api/product/' + document.getElementById("productId").value;
    fetch(url)
        .then((response) => response.json())
        .then((data) => {
            CreateProductTable(data);
        });
}

async function ProductPost() {
    let data = {
        manufacturer: document.getElementById("postManufacturer").value,
        model: document.getElementById("postModel").value,
        price: +document.getElementById("postPrice").value,
        subcategoryId: +document.getElementById("postSubcategory").value
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

async function ProductUpdate() {
    let data = {
        id: +document.getElementById("updateId").value,
        manufacturer: document.getElementById("updateManufacturer").value,
        model: document.getElementById("updateModel").value,
        price: +document.getElementById("updatePrice").value,
        subcategoryId: +document.getElementById("updateSubcategory").value
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
    let url = 'https://localhost:5001/api/product/' + document.getElementById("productId").value;
    let response = await fetch(url, {
        method: 'delete',
        headers: { 'Content-type': 'application/json' }
    });
    if (response.status == 200) {
        document.getElementById('productDateTable').innerHTML = "Product with Id "
            + document.getElementById("productId").value + " was deleted";
    }
    else document.getElementById('productDateTable').innerHTML = "error";
}

function CreateProductTable(reportModel) {
    console.log(reportModel);
    var strResult = "<table><th>Id</th>" +
        "<th>Manufacturer</th>" +
        "<th>Model</th>" +
        "<th>Price</th>" +
        "<th>Category</th>" +
        "<th>Subcategory</th>";
    strResult += "<tr><td>" + reportModel.id +
        "</td><td>" + reportModel.manufacturer +
        "</td><td>" + reportModel.model +
        "</td><td>" + reportModel.price +
        "</td><td>" + reportModel.categoryName +
        "</td><td>" + reportModel.subcategory +
        "</td><td>";
    strResult += "</table>";

    document.getElementById('productDateTable').innerHTML = strResult;
}

function HideProductDate() {
    document.getElementById('productGetByIdData').style.display = 'none';
    document.getElementById('productPostData').style.display = 'none';
    document.getElementById('productUpdateData').style.display = 'none';
    document.getElementById('productDateTable').innerHTML = ' ';
}

function ShowGetByIdDate() {
    HideProductDate()
    document.getElementById('productGetByIdData').style.display = 'inline-block';
}
function ShowPostDate() {
    HideProductDate()
    document.getElementById('productPostData').style.display = 'block';
}

function ShowUpdateDate() {
    HideProductDate()
    document.getElementById('productUpdateData').style.display = 'block';
}

window.onload = function () {
    document.getElementById('productGetDelMethodBtn').addEventListener("click", () => ShowGetByIdDate());
    document.getElementById('productPostMethodBtn').addEventListener("click", () => ShowPostDate());
    document.getElementById('productUpdateMethodBtn').addEventListener("click", () => ShowUpdateDate());
    document.getElementById('getByIdBtn').addEventListener("click", () => ProductGet());
    document.getElementById('postBtn').addEventListener("click", () => ProductPost());
    document.getElementById('updateBtn').addEventListener("click", () => ProductUpdate());
    document.getElementById('deleteByIdBtn').addEventListener("click", () => ProductDelete());
    HideProductDate();
}