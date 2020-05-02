function GetMoneyInCity() {

    fetch('https://localhost:5001/api/report/money-in-city')
        .then((response) => response.json())
        .then((data) => {
            CreateTable(data);
        });

    function CreateTable(reportModel) {
        var strResult = "<table><th>City</th><th>Total Money</th>";
        reportModel.forEach(x => {
            strResult += "<tr><td>" + x.city + "</td><td> " + x.total + "</td><td>";
        });
        strResult += "</table>";

        document.getElementById('DateTable').innerHTML = strResult;
    }
}


fetch('/url', {
    method: 'post',
    body: JSON.stringify(data),
    headers: { 'Content-type': 'application/json' }
})
