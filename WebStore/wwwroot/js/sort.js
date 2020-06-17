function citySort() {
    data = data.sort((a, b) => (a.city > b.city) ? 1 : (b.city > a.city) ? -1 : 0);
    if (!isSorted) {
        CreateTable(data);
        isSorted = true;
    }
    else if (isSorted) {
        data = data.sort((a, b) => (a.city < b.city) ? 1 : (b.city < a.city) ? -1 : 0);
        CreateTable(data);
        isSorted = false;
    }
}