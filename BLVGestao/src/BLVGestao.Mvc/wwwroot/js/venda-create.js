$(document).ready(function () {
    var listaProdutos = []
    var produtos = {};
    $("#btnAdicionarProduto").click(function () {

        var teste = JSON.stringify($("#produto").val())
        var produtoInput = JSON.parse($("#produto").val());
    
        
        console.log(produtoInput);
        console.log(teste);



        
        var bodyProdutos = "";
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

})






















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

