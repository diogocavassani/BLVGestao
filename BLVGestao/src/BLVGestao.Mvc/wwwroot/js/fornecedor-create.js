$(document).ready(function () {
    var listaTelefones = [];

    $("#btnAdicionarTelefone").click(function () {
        var bodyPhones = "";
        listaTelefones.push({ Numero: parseInt($("#numeroTelefone").val()), TipoTelefone: parseInt($("#tipoTelefone").val()) });

        for (var i = 0; i < listaTelefones.length; i++) {
            var telefone = listaTelefones[i];

            bodyPhones += "<tr>";
            bodyPhones += `  <td>${telefone.Numero}</td>`;
            bodyPhones += `  <td>${telefone.TipoTelefone}</td>`;
            bodyPhones += "</tr>";
        }

        $("#tBodyPhones").html(bodyPhones);
        $("#numeroTelefone").val("");
        $("#tipoTelefone").val("");
    });

    $("#btnAdicionarFornecedor").click(function () {
        console.log("a");
        var fornecedor = {};
        fornecedor.RazaoSocial = $("#RazaoSocial").val();
        fornecedor.NomeFantasia = $("#NomeFantasia").val();
        fornecedor.Cnpj = $("#Cnpj").val();
        fornecedor.Pessoa = {};
        fornecedor.Pessoa.Telefone = listaTelefones;

        $.ajax({
            type: 'POST',
            url: '/Fornecedor/Create',
            dataType: 'json',
            contentType: 'application/json',
            data: JSON.stringify(fornecedor),
            success: function () {

                window.location.href = '/Fornecedor/Index';
            }
        });

    });

});