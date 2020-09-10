$(document).ready(function () {
    var listaTelefones = [];
    var listaEnderecos = [];

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

    $("#btnAdicionarEndereco").click(function () {
        var bodyAdress = "";
        listaEnderecos.push({
            Logradouro: $("#enderecoLogradouro").val(),
            Numero: parseInt($("#enderecoNumero").val()),
            Bairro: $("#enderecoBairro").val()
        });

        for (var i = 0; i < listaEnderecos.length; i++) {
            var endereco = listaEnderecos[i];

            bodyAdress += "<tr>";
            bodyAdress += `  <td>${endereco.Logradouro}</td>`;
            bodyAdress += `  <td>${endereco.Numero}</td>`;
            bodyAdress += `  <td>${endereco.Bairro}</td>`;
            bodyAdress += "</tr>";
        }

        $("#tBodyAdress").html(bodyAdress);
        $("#logradouro").val("");
        $("#numero").val("");
        $("#bairro").val("");
    });



    $("#btnAdicionarCliente").click(function () {
        var cliente = {};

        cliente.Nome = $("#Nome").val();
        cliente.DataNascimento = $("#DataNascimento").val();
        cliente.Cpf = $("#Cpf").val();
        cliente.Rg = $("#Rg").val();
        cliente.Pessoa = {};
        cliente.Pessoa.Telefone = listaTelefones;
        cliente.Pessoa.Endereco = listaEnderecos;

        $.ajax({
            type: 'POST',
            url: '/Cliente/Create',
            dataType: 'json',
            contentType: 'application/json',
            data: JSON.stringify(cliente),
            success: function () {
                window.location.href = '/Cliente/Index';
            }
        });
    });
});