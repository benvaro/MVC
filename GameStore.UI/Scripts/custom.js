function onSearch(e) {
    if (e.key === "Enter") {
        location.href = `/Games/Index?search=${e.target.value}`;
    }
}

function ChoosenUrlImg() {
    $("#urlimage").addClass("d-block");
    $("#localImg").addClass("d-none");
}

function ChoosenLocalImg() {
    $("#urlimage").addClass("d-none");
    $("#localImg").addClass("d-block");
}