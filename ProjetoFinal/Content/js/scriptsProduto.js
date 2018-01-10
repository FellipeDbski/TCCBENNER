$(".btnRemove").click(function () {
    var $tr = $(this).closest("tr");
    var id = $tr.find(".esseID").text();
    console.log(id);
    $.post("/Produtos/Remove", { id: id }, function () {
        $tr.fadeOut(400);
        setTimeout(function () {
            $tr.remove();
        }, 400);
    }); 
});

$(".modalProdutoBusca").click(function () {
    var $tr = $(this).closest("tr");
    var id = $tr.find(".esseID").text();
    console.log(id);
    $.post("/Produtos/Modal", { id: id }, function (data) {       
        $("#produtosDescricao").text(data.descricao);
    });
});