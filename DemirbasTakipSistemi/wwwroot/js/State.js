$(function () {
    var modal = $('#createCategoryModal');
    modal.on('click', '[data-save="modal"]', function (event) {

        var form = $(this).parents('.modal').find('form');
        var actionUrl = form.attr('action');
        var sendData = form.serialize();
        $.post(actionUrl, sendData).done(function (data) {
            alert("başarılı");


        });


    });



});