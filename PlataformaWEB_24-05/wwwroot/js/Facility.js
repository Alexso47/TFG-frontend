function removeFacility() {
    var removeFacilities = $('#facilities').val();
    $('#facilities option:selected').remove();
    var listFacilities = $("#txthdnFacilities").val().split('/n');
    for (var i = 0; i < removeFacilities.length; i++) {
        if (removeFacilities[i] != "undefined") {
            if (listFacilities.includes(removeFacilities[i])) {
                listFacilities.splice(listFacilities.indexOf(removeFacilities[i]), 1);
            }
        }
    }
    $("#txthdnFacilities").val(listFacilities.join("/n"));
}

function AddFacilityToList() {
    var facility = $("#facilityToAdd").val();
    if (facility.length > 9) {
        var listFacilities = $("#txthdnFacilities").val();
        if (listFacilities.indexOf(facility) < 0) {
            listFacilities += listFacilities == "" ? facility : "/n" + facility;
            $("#txthdnFacilities").val(listFacilities);
            var facilities = document.getElementById("facilities");
            var option = document.createElement("option");
            option.text = facility;
            facilities.add(option, facilities[0]);
        }
    }
}

function showErrorSingleAdd(error) {
    $("div#msg_error").css('visibility', 'visible');
    $("div#msg_error").hide().slideDown();
    $("div#msg_error span").html(error);
    window.scrollTo({ top: 0, behavior: 'smooth' });
}
