$(".btnRemoveVenda").click(function () {
    var $tr = $(this).closest("tr");
    var id = $tr.find(".esseID").text();
    console.log(id);
    $.post("/Venda/Remove", { id: id }, function () {
        $tr.fadeOut(200);
        setTimeout(function () {
            $tr.remove();
        }, 200);
    });
});