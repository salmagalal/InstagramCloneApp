
function sendReact(id,idstu,react) {
    var x = document.getElementById(id);
    var fa = new FormData();
    fa.append("idpost", x.id);
    fa.append("react", react);
    fa.append("iduser", idstu)
    $.ajax({
        url: 'http://localhost:51338/api/React',
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