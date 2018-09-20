var urlApi = "http://localhost:49264/api/cir";

function toggleListEdit() {
    if ($("#divEdit").css('display') == 'none')
    {
        $("#cirList").hide();
    }
    else
    {
        $("#cirList").show();
    }
}

function cancel() {
    toggleListEdit();
}

function getCir() {
    $.ajax({
        type: "GET",
        url: urlApi
    }).success(function (data) {
        $("#cirList").empty();
        $.each(data, function (a, b) {
            var sendLink = "<a href='#' onclick='send(" + b.contrato + ")'>Enviar</a>";
            $("#cirList").append("<div>" + sendLink + " | " + b.contrato + "</div>");
        });
    });
}

function send(id) {
    toggleListEdit();

    $.ajax({
        type: "GET",
        url: urlApi + "/" + contrato
    }).success(function (data) {

        $("#txtContrato").val(data.contrato);

    });
}

