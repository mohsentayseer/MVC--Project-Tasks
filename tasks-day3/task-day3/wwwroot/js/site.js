//.btn-delete which inside the table is the btn that will open the popup modal
//.btn-link which inside the popup modal is the btn that will fire the action in the controller
$(".btn-delete").on("click", function () {
    $(".modal").modal("show");
    $(".drug-id").html("#" + this.id);//to get id in this popup modal
    $("#delete-link").attr("href", "/Drug/DeleteDrug/" + this.id);//it is the delete btn that will make the delete action in the controller
});

$(".btn-close", ".btn-cancel").on("click", function () {
    $(".modal").modal("hide");
});