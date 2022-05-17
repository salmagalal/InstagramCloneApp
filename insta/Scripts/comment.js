function sendcomment(id, idstu) {
    var x = document.getElementById(id);
    var fa = new FormData();

    fa.append("idpost", x.id);
    fa.append("comment", x.value);
    fa.append("iduser", idstu)
    

    $.ajax({
        url: 'http://localhost:51338/api/Comment',
        type: 'POST',
        data: fa,
        cache: false,
        contentType: false,
        processData: false,
        success: function (data) {
            console.log(data);
            x.value = "";
        }
    });
}