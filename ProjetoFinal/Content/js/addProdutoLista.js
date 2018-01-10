var total = 0;

    $("#btnAddProd").click(function (e) {
        e.preventDefault();
        AdicionaProdutoNaLista();
    });


    function AdicionaProdutoNaLista(){        
        var url = "/Venda/AddProduto";
        var id = $("#produtoId").val();
        var qtd = $("#qtdProduto").val();
        $.post(url, { id: id, qtd: qtd }, atualiza);

    }

    function atualiza(resposta) {
        var listaDeProdutos = $("#produtos");
        var novoProduto = $("<option>").text(resposta.Nome + ":  R$" + resposta.Valor + " (" + resposta.Quantidade + " uni) " );
        total += resposta.Valor * resposta.Quantidade;
        $("#totalP").val(total.toFixed(2));
        listaDeProdutos.append(novoProduto);
    }