let paginationModule = {
    data: [],
    pageInfo: {},
    getPageInfo: async function (reportModel) {
        this.data = reportModel;
        console.log(reportModel.length);
        let pageData = {
            TotalItems: reportModel.length,
            CurrentPage: 1,
            PageSize: 25, //get value from menu, maybe it's need and in parametrs
            MaxPages: 10
        };
        let response = await fetch('https://localhost:5001/api/common/pagination', {
            method: 'post',
            body: JSON.stringify(pageData),
            headers: { 'Content-type': 'application/json' }
        })
        let result = await response.json();
        this.pageInfo = {
            currentPage: result.CurrentPage,
            endIndex: result.EndIndex,
            endPage: result.EndPage,
            pageSize: result.PageSize,
            startIndex: result.StartIndex,
            startPage: result.StartPage,
            totalItems: result.TotalItems,
            totalPages: result.TotalPages,
            pages: result.Pages
        }
        let strResult = "";
        for (let i = 0; i < this.pageInfo.pages.length; i++) {
            strResult += "<a class='page-selector' id='page-select-" + (i + 1) + "' href='#'>" + result.Pages[i] + "</a>"
        }
        document.getElementById('pages').innerHTML = strResult;

        for (let i = 0; i < this.pageInfo.pages.length; i++) {
            document.getElementById('page-select-' + (i + 1)).addEventListener("click", () => paginationModule.showpage(i+1));;
        }
        return result;
    },
    showpage: function (pageNumber) {
        this.pageInfo.currentPage = pageNumber;
        const startIndex = (pageNumber - 1) * this.pageInfo.pageSize;
        const endIndex = Math.min(startIndex + this.pageInfo.pageSize - 1, this.pageInfo.totalItems - 1);
        const pageContent = this.data.slice(startIndex, endIndex + 1);
        reportCreateTableModule.createTable(pageContent);
    }
}
