document.getElementById('search-btn').addEventListener("click", () => searchTable()); 
document.getElementById('search-area').addEventListener("keydown", function (event) {
    event.preventDefault();
    let keyCode = event.keyCode; 

    if (keyCode === 13) {
        document.getElementById('search-btn').click();
    }
    else if (keyCode === 8) {
        let str = document.getElementById('search-area').value;
        document.getElementById('search-area').value = str.substring(0, str.length - 1);
    }
    else if (keyCode > 47 && event.keyCode < 58 || event.keyCode > 65 && event.keyCode < 90) {
        document.getElementById('search-area').value += event.key;
    }
});

function accordion() {
    var acc = document.getElementsByClassName("accordion");
    for (let i = 0; i < acc.length; i++) {
        acc[i].addEventListener("click", function () {
            this.classList.toggle("active");
            var panel = this.nextElementSibling;

            if (panel.style.maxHeight) {
                panel.style.maxHeight = null;
            } else {
                panel.style.maxHeight = panel.scrollHeight + "px";
            }
        });
    }
}

function searchTable() {
    let filter, found, data, row, cells;
    filter = document.getElementById("search-area").value.toUpperCase();
    if (document.getElementById("report-info").value == "Orders by date") {
        data = document.getElementById("data-viewer").getElementsByClassName("accordion");
        for (let i = 0; i < data.length; i++) {
            console.log(data[i].innerHTML);
            if (data[i].innerHTML.toUpperCase().indexOf(filter) > -1) {
                found = true;
            }
            if (found) {
                data[i].style.display = "";
                found = false;
            } else {
                data[i].style.display = "none";
            }
        }
    }
    else {
        data = document.getElementById("data-viewer").getElementsByTagName("tbody");
        for (let i = 0; i < data.length; i++) {
            row = data[i].getElementsByTagName("tr");
            for (let j = 0; j < row.length; j++) {
                cells = row[j].querySelectorAll("td, th");
                for (let k = 0; k < cells.length; k++) {
                    if (cells[k].innerHTML.toUpperCase().indexOf(filter) > -1) {
                        found = true;
                    }
                }
                if (found) {
                    row[j].style.display = "";
                    found = false;
                } else {
                    row[j].style.display = "none";
                }
            }
        }    
    }
}

