// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    AjaxUploadImagem();
});

function AjaxUploadImagem() {
    $(".input-file").change(function () {
        //Formulário de dados via JavaScript
        var Binario = $(this)[0].files[0];
        var Formulario = new FormData();
        Formulario.append("formFile", Binario); 
        $.ajax({
            type: "POST",
            url: "/Home/Index", 
            data: Formulario,
            contentType: false,
            processData: false,
            error: function () {
                alert("Erro no envio do arquivo!");
            },
            success: function (data) {
                alert("Arquivo enviado com sucesso!\n" + data.files[0]);
            }
        });

    });
}
