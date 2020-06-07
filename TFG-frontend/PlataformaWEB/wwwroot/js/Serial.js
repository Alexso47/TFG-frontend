function removeSerial() {
    var removeSerials = $('#serials').val();
    $('#serials option:selected').remove();
    var listSerials = $("#txthdnSerials").val().split('/n');
    for (var i = 0; i < removeSerials.length; i++) {
        if (removeSerials[i] != "undefined") {
            if (listSerials.includes(removeSerials[i])) {
                listSerials.splice(listSerials.indexOf(removeSerials[i]), 1);
            }
        }
    }
    $("#txthdnSerials").val(listSerials.join("/n"));
}

function AddSerialToList() {
    var serial = $("#serialToAdd").val();
    if (serial.length > 0) {
        var listSerials = $("#txthdnSerials").val();
        if (listSerials.indexOf(serial) < 0) {
            listSerials += listSerials == "" ? serial : "/n" + serial;
            $("#txthdnSerials").val(listSerials);
            var serials = document.getElementById("serials");
            var option = document.createElement("option");
            option.text = serial;
            serials.add(option, serials[0]);
        }
    }
}

function showErrorSingleAdd(error) {
    $("div#msg_error").css('visibility', 'visible');
    $("div#msg_error").hide().slideDown();
    $("div#msg_error span").html(error);
    window.scrollTo({ top: 0, behavior: 'smooth' });
}
