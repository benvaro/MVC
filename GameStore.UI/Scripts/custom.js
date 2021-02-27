function onSearch(e) {
    if (e.key === "Enter") {
        location.href = `/Games/Index?search=${e.target.value}`;
    }
}