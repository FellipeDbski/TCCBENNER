﻿$(".btnRemoveCliente").click(function () {
    var $tr = $(this).closest("tr");
    var id = $tr.find(".esseID").text();
    console.log(id);
    $.post("/Clientes/Remove", { id: id }, function () {
        $tr.fadeOut(400);
        setTimeout(function () {
            $tr.remove();
        }, 400);
    });
});