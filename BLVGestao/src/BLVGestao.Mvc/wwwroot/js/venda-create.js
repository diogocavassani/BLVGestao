$(document).ready(function () {
    var listaProdutos = []
    var produtoJSON = [];
    var totalVenda = 0;
    $("#btnAdicionarProduto").click(function () {

        produtosselecionado = $("#produto-selecionado option:selected").val();
        if (produtosselecionado === undefined) {
            alert("Escolha um produto");
            return false;
        }

        if (parseFloat($("#quantidade").val()) == 0 || parseFloat($("#quantidade").val()) == null || isNaN(parseFloat($("#quantidade").val()))) {
            alert("Digite a quantidade");
            return false;
        }

        produtoInput = produtosselecionado.split(",");
        produtoJSON.push({
            Codigo: parseInt(produtoInput[0]),
            Descricao: produtoInput[1],
            Unidade: produtoInput[2],
            ValorUnitario: parseFloat(produtoInput[3]),
            ValorTotal: null

        });

        produtoJSON[0].ValorTotal = parseFloat($("#quantidade").val()) * parseFloat(produtoJSON[0].ValorUnitario);

        var bodyProdutos = "";
        listaProdutos.push({
            Codigo: produtoJSON[0].Codigo,
            Descricao: produtoJSON[0].Descricao,
            Quantidade: parseFloat($("#quantidade").val()),
            Unidade: produtoJSON[0].Unidade,
            ValorUnitario: produtoJSON[0].ValorUnitario,
            ValorTotal: produtoJSON[0].ValorTotal
        });


        for (var i = 0; i < listaProdutos.length; i++) {
            var produtoTabela = listaProdutos[i];
            bodyProdutos += "<tr>";
            bodyProdutos += `  <td>${produtoTabela.Codigo}</td>`;
            bodyProdutos += `  <td>${produtoTabela.Descricao}</td>`;
            bodyProdutos += `  <td>${produtoTabela.Quantidade}</td>`;
            bodyProdutos += `  <td>${produtoTabela.Unidade}</td>`;
            bodyProdutos += `  <td>${produtoTabela.ValorUnitario}</td>`;
            bodyProdutos += `  <td>${produtoTabela.ValorTotal}</td>`;
            bodyProdutos += `  <td>
                                    <button class="btn btn-success fa fa-plus removerProduto" id="remover${i}" value="${i}">Remover</button>
                               </td>`;

            totalVenda += produtoTabela.ValorTotal
        }

        $("#tBodyProdutos").html(bodyProdutos);
        Teste();
        $("#totalVenda").html(`R$${totalVenda.toFixed(2)}`)
        $("#produto").val("");
        $("#quantidade").val("");
        produtoJSON.pop();


      
        
        

    });
    function Teste() {
        $('.removerProduto').click(function () {
            var valor = parseInt($(this).val());
            //valor += 1;
            listaProdutos.splice(valor, 1);
    
            $(`#remover${valor}`).closest("tr").remove();
            $("#tBodyProdutos").html(bodyProdutos);

        });

    }



    $("#finalizarVenda").click(function () {
        var cliente = parseInt($("#cliente-selecionado option:selected").val());
        var formaPagamento = parseInt($("#pagamento-selecionado option:selected").val());
        var valorPagamento = parseFloat($("#valorPagamento").val());

        if (cliente === undefined || isNaN(cliente)) {
            alert("Selecione um cliente");
            return false;
        }
        else if (formaPagamento === undefined || isNaN(formaPagamento)) {
            alert("Selecione uma forma de pagamento");
            return false;
        }
        else if (listaProdutos.length < 1) {
            alert("Insira pelo menos um produto");
            return false;
        }
        else if (valorPagamento < totalVenda) {
            alert("Valor do pagamento menor que o total da venda");
            return false;
        }
        else if (valorPagamento === undefined || isNaN(valorPagamento)) {
            alert("Digite um valor de pagamento");
            return false;
        }

        var venda = {};
        let itensVenda = [];
        for (var i = 0; i < listaProdutos.length; i++) {
            var produto = {};
            var prodTemp = listaProdutos[i]
            produto.ProdutoId = prodTemp.Codigo;
            produto.Quantidade = prodTemp.Quantidade;
            produto.ValorTotal = prodTemp.ValorTotal;
            if (i > 0) {
                venda.TotalVenda += prodTemp.ValorTotal;
            }
            else {
                venda.TotalVenda = prodTemp.ValorTotal;
            }

            itensVenda.push(produto);

        }


        venda.Cliente = {};
        venda.Cliente.PessoaId = cliente;
        venda.ItemVenda = itensVenda;
        venda.FormaDePagamento = {};
        venda.FormaDePagamento.FormaDePagamentoId = formaPagamento;
        venda.ValorPagamento = valorPagamento;
        venda.ValorTroco = venda.ValorPagamento - venda.TotalVenda;



        $.ajax({
            type: 'POST',
            url: '/Vendas/Create',
            dataType: 'json',
            contentType: 'application/json',
            data: JSON.stringify(venda),
            success: function () {
                window.location.href = '/Venda/Index';
            }
        });
    });


})


//BAckup
/*
 * var bodyProdutos = "";
        listaProdutos.push({
            Codigo: produtoInput.Codigo,
            Descricao: produtoInput.Descricao,
            Quantidade: parseInt($("#quantidade").val()),
            Unidade: produtoInput.Unidade,
            ValorVenda: produtoInput.ValorVenda,
            ValorTotal: 2
        });

        for (var i = 0; i < listaProdutos.length; i++) {
            var produtoTabela = listaProdutos[i];
            bodyProdutos += "<tr>";
            bodyProdutos += `  <td>${produtoTabela.Codigo}</td>`;
            bodyProdutos += `  <td>${produtoTabela.Descricao}</td>`;
            bodyProdutos += `  <td>${produtoTabela.Quantidade}</td>`;
            bodyProdutos += `  <td>${produtoTabela.Unidade}</td>`;
            bodyProdutos += `  <td>${produtoTabela.ValorVenda}</td>`;
            bodyProdutos += `  <td>${produtoTabela.ValorTotal}</td>`;
        }
        $("#tBodyProdutos").html(bodyProdutos);
        $("#produto").val("");
        $("#quantidade").val("");

    });
 */

//$(document).ready(function () {
//    var listaTelefones = [];

//    $("#btnAdicionarTelefone").click(function () {
//        var bodyPhones = "";
//        listaTelefones.push({ Numero: parseInt($("#numeroTelefone").val()), TipoTelefone: parseInt($("#tipoTelefone").val()) });

//        for (var i = 0; i < listaTelefones.length; i++) {
//            var telefone = listaTelefones[i];

//            bodyPhones += "<tr>";
//            bodyPhones += `  <td>${telefone.Numero}</td>`;
//            bodyPhones += `  <td>${telefone.TipoTelefone}</td>`;
//            bodyPhones += "</tr>";
//        }

//        $("#tBodyPhones").html(bodyPhones);
//        $("#numeroTelefone").val("");
//        $("#tipoTelefone").val("");
//    });

//    $("#btnAdicionarFornecedor").click(function () {
//        console.log("a");
//        var fornecedor = {};
//        fornecedor.RazaoSocial = $("#RazaoSocial").val();
//        fornecedor.NomeFantasia = $("#NomeFantasia").val();
//        fornecedor.Cnpj = $("#Cnpj").val();
//        fornecedor.Pessoa = {};
//        fornecedor.Pessoa.Telefone = listaTelefones;

//        $.ajax({
//            type: 'POST',
//            url: '/Fornecedor/Create',
//            dataType: 'json',
//            contentType: 'application/json',
//            data: JSON.stringify(fornecedor),
//            success: function () {

//                window.location.href = '/Fornecedor/Index';
//            }
//        });

//    });

//});

