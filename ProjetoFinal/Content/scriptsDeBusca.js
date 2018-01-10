$(".modalVendaBusca").click(function(){
    var id = $(this).closest("tr").find(".esseID").text();
    console.log(id);

    $.post("/Home/Modal", { id: id }, function (data) {
        console.log("ok");
        var lista = $("#produtosVenda");
        data.nomes.forEach(function (produto) {
            var produtos = $("<option>").text(produto.Nome);
            lista.append(produtos);
        });
    });
});

$(".btnFecha").click(function () {
   $("#produtosVenda").html(" ");
});

   
