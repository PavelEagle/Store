function CreateProductTable(reportModel) {
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