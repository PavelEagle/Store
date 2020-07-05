let paginationModule = {
    test: 1,
    getPageInfo: async function() {
        let data = {
            TotalItems: 100,
            CurrentPage: 2,
            PageSize: 25,
            MaxPages: 7
        };
        let response = await fetch('https://localhost:5001/api/common/pagination', {
            method: 'post',
            body: JSON.stringify(data),
            headers: { 'Content-type': 'application/json' }
        })
        let result = await response.json();
        return result;
    }
}
