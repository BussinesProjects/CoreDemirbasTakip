$(function () {

    var modal = $('#createCategoryModal');




    modal.on('click', '[data-save="modal"]', function (event) {
        debugger;
        var form = $(this).parents('.modal').find('form');
        var actionUrl = form.attr('action');
        var sendData = document.getElementById("cName").value;

        //$.post(actionUrl,sendData).done(function (data) {
        //    alert("başarılı");


        //});
        $.ajax({
            type: "POST",
            cache: false,
            url: actionUrl,
            data: { name: sendData },    // multiple data sent using ajax
            success: function (data) {
              alert("Ekleme Başarılı")
            }
        });
        return false;
    });
});


  



